// ========================================
// PUSTOK ADMIN PANEL CUSTOM JAVASCRIPT
// ========================================

(function ($) {
    'use strict';

    // Document Ready
    $(document).ready(function () {

        // Initialize all functions
        initSidebar();
        initDataTables();
        initFormValidation();
        initDeleteConfirmation();
        initTooltips();
        initActiveMenu();

    });

    // ========================================
    // SIDEBAR TOGGLE
    // ========================================
    function initSidebar() {
        // Mobile sidebar toggle
        $('.sidebar-toggle').on('click', function () {
            $('.main-sidebar').toggleClass('active');
        });

        // Close sidebar when clicking outside on mobile
        $(document).on('click', function (e) {
            if ($(window).width() < 768) {
                if (!$(e.target).closest('.main-sidebar, .sidebar-toggle').length) {
                    $('.main-sidebar').removeClass('active');
                }
            }
        });
    }

    // ========================================
    // ACTIVE MENU ITEM
    // ========================================
    function initActiveMenu() {
        var currentPath = window.location.pathname;

        $('.nav-sidebar .nav-link').each(function () {
            var href = $(this).attr('href');

            if (currentPath.indexOf(href) !== -1 && href !== '/Admin' && href !== '/') {
                $(this).addClass('active');
                $(this).closest('.nav-item').addClass('active');
            }
        });
    }

    // ========================================
    // DATA TABLES
    // ========================================
    function initDataTables() {
        if ($.fn.DataTable && $('.data-table').length) {
            $('.data-table').DataTable({
                responsive: true,
                pageLength: 10,
                language: {
                    search: "Search:",
                    lengthMenu: "Show _MENU_ entries",
                    info: "Showing _START_ to _END_ of _TOTAL_ entries",
                    paginate: {
                        first: "First",
                        last: "Last",
                        next: "Next",
                        previous: "Previous"
                    }
                }
            });
        }
    }

    // ========================================
    // FORM VALIDATION
    // ========================================
    function initFormValidation() {
        $('form').on('submit', function (e) {
            var form = $(this);
            var isValid = true;

            // Check required fields
            form.find('[required]').each(function () {
                var field = $(this);
                var value = field.val();

                // Handle different input types
                if (field.is('select')) {
                    if (!value || value === '' || value === '0') {
                        isValid = false;
                        markFieldInvalid(field, 'Please select an option');
                    } else {
                        markFieldValid(field);
                    }
                } else if (field.is(':checkbox')) {
                    if (!field.is(':checked') && field.attr('data-required') === 'true') {
                        isValid = false;
                        markFieldInvalid(field, 'This field is required');
                    } else {
                        markFieldValid(field);
                    }
                } else {
                    if (!value || value.trim() === '') {
                        isValid = false;
                        markFieldInvalid(field, 'This field is required');
                    } else {
                        markFieldValid(field);
                    }
                }
            });

            // Validate email format
            form.find('input[type="email"]').each(function () {
                var email = $(this);
                var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

                if (email.val() && !emailPattern.test(email.val())) {
                    isValid = false;
                    markFieldInvalid(email, 'Please enter a valid email address');
                }
            });

            // Validate number ranges
            form.find('input[type="number"]').each(function () {
                var field = $(this);
                var value = parseFloat(field.val());
                var min = parseFloat(field.attr('min'));
                var max = parseFloat(field.attr('max'));

                if (field.val()) {
                    if (!isNaN(min) && value < min) {
                        isValid = false;
                        markFieldInvalid(field, 'Value must be at least ' + min);
                    } else if (!isNaN(max) && value > max) {
                        isValid = false;
                        markFieldInvalid(field, 'Value must not exceed ' + max);
                    } else {
                        markFieldValid(field);
                    }
                }
            });

            // Validate text length
            form.find('input[type="text"], textarea').each(function () {
                var field = $(this);
                var value = field.val();
                var minLength = parseInt(field.attr('minlength'));
                var maxLength = parseInt(field.attr('maxlength'));

                if (value) {
                    if (!isNaN(minLength) && value.length < minLength) {
                        isValid = false;
                        markFieldInvalid(field, 'Must be at least ' + minLength + ' characters');
                    } else if (!isNaN(maxLength) && value.length > maxLength) {
                        isValid = false;
                        markFieldInvalid(field, 'Must not exceed ' + maxLength + ' characters');
                    } else {
                        markFieldValid(field);
                    }
                }
            });

            if (!isValid) {
                e.preventDefault();
                showNotification('Please fix all validation errors before submitting', 'error');
                // Scroll to first error
                var firstError = form.find('.is-invalid').first();
                if (firstError.length) {
                    $('html, body').animate({
                        scrollTop: firstError.offset().top - 100
                    }, 500);
                    firstError.focus();
                }
            }
        });

        // Real-time validation on input
        $('input, textarea, select').on('input change blur', function () {
            var field = $(this);

            // Skip if form hasn't been submitted yet
            if (!field.closest('form').hasClass('was-validated')) {
                return;
            }

            validateField(field);
        });

        // Mark form as validated on first submit attempt
        $('form').on('submit', function () {
            $(this).addClass('was-validated');
        });
    }

    // Helper function to mark field as invalid
    function markFieldInvalid(field, message) {
        field.addClass('is-invalid').removeClass('is-valid');

        // Remove existing validation messages
        field.siblings('.invalid-feedback, .text-danger:not([data-valmsg-for])').remove();

        // Add new validation message
        if (message && !field.siblings('[data-valmsg-for="' + field.attr('name') + '"]').length) {
            field.after('<div class="invalid-feedback d-block">' + message + '</div>');
        }
    }

    // Helper function to mark field as valid
    function markFieldValid(field) {
        field.removeClass('is-invalid').addClass('is-valid');
        field.siblings('.invalid-feedback').remove();
    }

    // Validate individual field
    function validateField(field) {
        var isValid = true;
        var value = field.val();

        // Required check
        if (field.attr('required')) {
            if (field.is('select')) {
                if (!value || value === '' || value === '0') {
                    isValid = false;
                    markFieldInvalid(field, 'Please select an option');
                }
            } else if (!value || value.trim() === '') {
                isValid = false;
                markFieldInvalid(field, 'This field is required');
            }
        }

        // Email validation
        if (isValid && field.attr('type') === 'email' && value) {
            var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(value)) {
                isValid = false;
                markFieldInvalid(field, 'Please enter a valid email address');
            }
        }

        // Number range validation
        if (isValid && field.attr('type') === 'number' && value) {
            var numValue = parseFloat(value);
            var min = parseFloat(field.attr('min'));
            var max = parseFloat(field.attr('max'));

            if (!isNaN(min) && numValue < min) {
                isValid = false;
                markFieldInvalid(field, 'Value must be at least ' + min);
            } else if (!isNaN(max) && numValue > max) {
                isValid = false;
                markFieldInvalid(field, 'Value must not exceed ' + max);
            }
        }

        if (isValid) {
            markFieldValid(field);
        }

        return isValid;
    }

    // ========================================
    // DELETE CONFIRMATION
    // ========================================
    function initDeleteConfirmation() {
        $(document).on('click', '.btn-delete, [data-action="delete"]', function (e) {
            var confirmed = confirm('Are you sure you want to delete this item? This action cannot be undone.');

            if (!confirmed) {
                e.preventDefault();
                return false;
            }
        });
    }

    // ========================================
    // TOOLTIPS
    // ========================================
    function initTooltips() {
        if ($.fn.tooltip) {
            $('[data-toggle="tooltip"]').tooltip();
        }
    }

    // ========================================
    // IMAGE PREVIEW
    // ========================================
    window.previewImage = function (input, previewId) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#' + previewId).attr('src', e.target.result).show();
            };

            reader.readAsDataURL(input.files[0]);
        }
    };

    // ========================================
    // NOTIFICATIONS
    // ========================================
    window.showNotification = function (message, type) {
        type = type || 'info';

        var alertClass = 'alert-' + type;
        var icon = '';

        switch (type) {
            case 'success':
                icon = '<i class="fas fa-check-circle"></i>';
                break;
            case 'error':
            case 'danger':
                icon = '<i class="fas fa-exclamation-circle"></i>';
                alertClass = 'alert-danger';
                break;
            case 'warning':
                icon = '<i class="fas fa-exclamation-triangle"></i>';
                break;
            default:
                icon = '<i class="fas fa-info-circle"></i>';
        }

        var notification = $('<div class="alert ' + alertClass + ' alert-dismissible fade show" role="alert">' +
            icon + ' ' + message +
            '<button type="button" class="close" data-dismiss="alert">&times;</button>' +
            '</div>');

        $('.content').prepend(notification);

        setTimeout(function () {
            notification.fadeOut(function () {
                $(this).remove();
            });
        }, 5000);
    };

    // ========================================
    // AJAX FORM SUBMIT
    // ========================================
    window.submitFormAjax = function (formId, successCallback) {
        $('#' + formId).on('submit', function (e) {
            e.preventDefault();

            var form = $(this);
            var url = form.attr('action');
            var method = form.attr('method') || 'POST';
            var formData = new FormData(this);

            $.ajax({
                url: url,
                type: method,
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    showNotification('Operation completed successfully!', 'success');
                    if (typeof successCallback === 'function') {
                        successCallback(response);
                    }
                },
                error: function (xhr, status, error) {
                    showNotification('An error occurred: ' + error, 'error');
                }
            });
        });
    };

    // ========================================
    // UTILITY FUNCTIONS
    // ========================================

    // Format currency
    window.formatCurrency = function (amount) {
        return '$' + parseFloat(amount).toFixed(2);
    };

    // Format date
    window.formatDate = function (date) {
        var d = new Date(date);
        var day = ('0' + d.getDate()).slice(-2);
        var month = ('0' + (d.getMonth() + 1)).slice(-2);
        var year = d.getFullYear();
        return day + '/' + month + '/' + year;
    };

    // Confirm action
    window.confirmAction = function (message, callback) {
        if (confirm(message)) {
            if (typeof callback === 'function') {
                callback();
            }
            return true;
        }
        return false;
    };

})(jQuery);
