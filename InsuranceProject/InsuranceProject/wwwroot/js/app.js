// Global variables
let authToken = localStorage.getItem('authToken');
let currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
let apiBaseUrl = '/api';

// Initialize app
document.addEventListener('DOMContentLoaded', function() {
    initializeApp();
    setupEventListeners();
    
    if (authToken) {
        updateNavigation(true);
        validateToken();
    }
});

function initializeApp() {
    // Smooth scrolling for navigation links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

function setupEventListeners() {
    // Login form
    document.getElementById('loginForm').addEventListener('submit', handleLogin);
    
    // Register form
    document.getElementById('registerForm').addEventListener('submit', handleRegister);
    
    // Quote form
    document.getElementById('quoteForm').addEventListener('submit', handleQuoteRequest);
}

// Authentication functions
async function handleLogin(e) {
    e.preventDefault();
    
    const username = document.getElementById('loginUsername').value;
    const password = document.getElementById('loginPassword').value;
    
    try {
        showLoading('Logging in...');
        
        const response = await fetch(`${apiBaseUrl}/auth/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password })
        });
        
        if (response.ok) {
            const data = await response.json();
            authToken = data.token;
            currentUser = {
                username: data.username,
                role: data.role,
                expires: data.expires
            };
            
            localStorage.setItem('authToken', authToken);
            localStorage.setItem('currentUser', JSON.stringify(currentUser));
            
            updateNavigation(true);
            hideModal('loginModal');
            showAlert('Login successful!', 'success');
            
        } else {
            const error = await response.text();
            showAlert(error || 'Login failed', 'danger');
        }
    } catch (error) {
        console.error('Login error:', error);
        showAlert('Network error. Please try again.', 'danger');
    } finally {
        hideLoading();
    }
}

async function handleRegister(e) {
    e.preventDefault();
    
    const username = document.getElementById('registerUsername').value;
    const email = document.getElementById('registerEmail').value;
    const password = document.getElementById('registerPassword').value;
    
    try {
        showLoading('Creating account...');
        
        const response = await fetch(`${apiBaseUrl}/auth/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, email, password, role: 'Customer' })
        });
        
        if (response.ok) {
            const data = await response.json();
            authToken = data.token;
            currentUser = {
                username: data.username,
                role: data.role,
                expires: data.expires
            };
            
            localStorage.setItem('authToken', authToken);
            localStorage.setItem('currentUser', JSON.stringify(currentUser));
            
            updateNavigation(true);
            hideModal('registerModal');
            showAlert('Account created successfully!', 'success');
            
        } else {
            const error = await response.text();
            showAlert(error || 'Registration failed', 'danger');
        }
    } catch (error) {
        console.error('Registration error:', error);
        showAlert('Network error. Please try again.', 'danger');
    } finally {
        hideLoading();
    }
}

function logout() {
    authToken = null;
    currentUser = {};
    localStorage.removeItem('authToken');
    localStorage.removeItem('currentUser');
    
    updateNavigation(false);
    showMainContent();
    showAlert('Logged out successfully', 'info');
}

function updateNavigation(isLoggedIn) {
    const loginNav = document.getElementById('loginNav');
    const dashboardNav = document.getElementById('dashboardNav');
    const logoutNav = document.getElementById('logoutNav');
    
    if (isLoggedIn) {
        loginNav.style.display = 'none';
        dashboardNav.style.display = 'block';
        logoutNav.style.display = 'block';
    } else {
        loginNav.style.display = 'block';
        dashboardNav.style.display = 'none';
        logoutNav.style.display = 'none';
    }
}

async function validateToken() {
    if (!authToken || !currentUser.expires) return false;
    
    const expiresDate = new Date(currentUser.expires);
    if (expiresDate <= new Date()) {
        logout();
        return false;
    }
    
    return true;
}

// Quote functions
async function handleQuoteRequest(e) {
    e.preventDefault();
    
    const firstName = document.getElementById('quoteFirstName').value;
    const lastName = document.getElementById('quoteLastName').value;
    const email = document.getElementById('quoteEmail').value;
    const phone = document.getElementById('quotePhone').value;
    const policyType = parseInt(document.getElementById('quotePolicyType').value);
    const coverageAmount = parseFloat(document.getElementById('quoteCoverageAmount').value);
    
    try {
        showLoading('Processing quote request...');
        
        // First, create or find customer
        let customer = await findOrCreateCustomer(firstName, lastName, email, phone);
        
        if (customer) {
            // Calculate premium
            const premium = await calculatePremium(customer.id, policyType, coverageAmount);
            
            if (premium !== null) {
                // Create quote
                const quote = await createQuote(customer.id, policyType, coverageAmount, premium);
                
                if (quote) {
                    hideModal('quoteModal');
                    showQuoteResult(quote, premium);
                }
            }
        }
    } catch (error) {
        console.error('Quote request error:', error);
        showAlert('Failed to process quote request. Please try again.', 'danger');
    } finally {
        hideLoading();
    }
}

async function findOrCreateCustomer(firstName, lastName, email, phone) {
    try {
        // Try to find existing customer by email
        const findResponse = await fetch(`${apiBaseUrl}/customers/email/${encodeURIComponent(email)}`);
        
        if (findResponse.ok) {
            return await findResponse.json();
        }
        
        // Create new customer
        const customer = {
            firstName,
            lastName,
            email,
            phone,
            address: 'To be updated',
            dateOfBirth: new Date('1990-01-01').toISOString()
        };
        
        const createResponse = await fetch(`${apiBaseUrl}/customers`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(customer)
        });
        
        if (createResponse.ok) {
            return await createResponse.json();
        }
        
        throw new Error('Failed to create customer');
    } catch (error) {
        console.error('Customer creation error:', error);
        throw error;
    }
}

async function calculatePremium(customerId, policyType, coverageAmount) {
    try {
        const response = await fetch(`${apiBaseUrl}/quotes/calculate`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                customerId,
                policyType,
                coverageAmount
            })
        });
        
        if (response.ok) {
            return await response.json();
        }
        
        throw new Error('Failed to calculate premium');
    } catch (error) {
        console.error('Premium calculation error:', error);
        return null;
    }
}

async function createQuote(customerId, policyType, coverageAmount, estimatedPremium) {
    try {
        const quote = {
            customerId,
            policyType,
            coverageAmount,
            estimatedPremium,
            status: 1, // Generated
            notes: 'Generated from website quote request'
        };
        
        const response = await fetch(`${apiBaseUrl}/quotes`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(quote)
        });
        
        if (response.ok) {
            return await response.json();
        }
        
        throw new Error('Failed to create quote');
    } catch (error) {
        console.error('Quote creation error:', error);
        return null;
    }
}

function showQuoteResult(quote, premium) {
    const policyTypes = ['Auto', 'Home', 'Life', 'Health', 'Travel', 'Business'];
    const policyTypeName = policyTypes[quote.policyType] || 'Unknown';
    
    const resultHtml = `
        <div class="alert alert-success">
            <h4><i class="fas fa-check-circle me-2"></i>Quote Generated Successfully!</h4>
            <hr>
            <div class="row">
                <div class="col-md-6">
                    <p><strong>Quote Number:</strong> ${quote.quoteNumber}</p>
                    <p><strong>Insurance Type:</strong> ${policyTypeName}</p>
                    <p><strong>Coverage Amount:</strong> $${quote.coverageAmount.toLocaleString()}</p>
                </div>
                <div class="col-md-6">
                    <p><strong>Estimated Premium:</strong> $${premium.toLocaleString()}</p>
                    <p><strong>Valid Until:</strong> ${new Date(quote.validUntil).toLocaleDateString()}</p>
                </div>
            </div>
            <div class="mt-3">
                <button class="btn btn-primary me-2" onclick="showLogin()">
                    <i class="fas fa-sign-in-alt me-1"></i>Login to Accept Quote
                </button>
                <button class="btn btn-outline-primary" onclick="contactAgent()">
                    <i class="fas fa-phone me-1"></i>Contact Agent
                </button>
            </div>
        </div>
    `;
    
    const alertDiv = document.createElement('div');
    alertDiv.innerHTML = resultHtml;
    document.body.insertBefore(alertDiv.firstElementChild, document.body.firstChild);
    
    // Remove after 30 seconds
    setTimeout(() => {
        const alert = document.querySelector('.alert-success');
        if (alert) alert.remove();
    }, 30000);
}

// Dashboard functions
async function showDashboard() {
    if (!authToken) {
        showLogin();
        return;
    }
    
    showLoading('Loading dashboard...');
    
    try {
        const dashboardHtml = `
            <div class="dashboard-header">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <h1><i class="fas fa-tachometer-alt me-2"></i>Dashboard</h1>
                            <p class="mb-0">Welcome back, ${currentUser.username}! Here's your insurance overview.</p>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="container mt-4">
                <div id="dashboardMetrics" class="row mb-4">
                    <!-- Metrics will be loaded here -->
                </div>
                
                <div class="row">
                    <div class="col-12">
                        <div class="card dashboard-card">
                            <div class="card-header">
                                <ul class="nav nav-tabs card-header-tabs" id="dashboardTabs">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="policies-tab" data-bs-toggle="tab" href="#policies">
                                            <i class="fas fa-file-contract me-1"></i>My Policies
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="claims-tab" data-bs-toggle="tab" href="#claims">
                                            <i class="fas fa-exclamation-triangle me-1"></i>My Claims
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="quotes-tab" data-bs-toggle="tab" href="#quotes">
                                            <i class="fas fa-calculator me-1"></i>My Quotes
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="card-body">
                                <div class="tab-content" id="dashboardTabContent">
                                    <div class="tab-pane fade show active" id="policies">
                                        <div id="policiesContent">Loading...</div>
                                    </div>
                                    <div class="tab-pane fade" id="claims">
                                        <div id="claimsContent">Loading...</div>
                                    </div>
                                    <div class="tab-pane fade" id="quotes">
                                        <div id="quotesContent">Loading...</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="row mt-4">
                    <div class="col-12 text-center">
                        <button class="btn btn-outline-primary me-2" onclick="showMainContent()">
                            <i class="fas fa-arrow-left me-1"></i>Back to Home
                        </button>
                        <button class="btn btn-primary" onclick="showQuoteForm()">
                            <i class="fas fa-plus me-1"></i>Request New Quote
                        </button>
                    </div>
                </div>
            </div>
        `;
        
        document.getElementById('mainContent').style.display = 'none';
        document.getElementById('dashboardContent').innerHTML = dashboardHtml;
        document.getElementById('dashboardContent').style.display = 'block';
        
        // Load dashboard data
        await loadDashboardData();
        
    } catch (error) {
        console.error('Dashboard error:', error);
        showAlert('Failed to load dashboard. Please try again.', 'danger');
    } finally {
        hideLoading();
    }
}

async function loadDashboardData() {
    try {
        // For demo purposes, we'll show sample data
        // In a real app, you'd fetch data based on the logged-in user
        
        const metricsHtml = `
            <div class="col-md-3">
                <div class="card metric-card dashboard-card">
                    <div class="card-body text-center">
                        <div class="metric-value">3</div>
                        <div class="text-muted">Active Policies</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card metric-card dashboard-card">
                    <div class="card-body text-center">
                        <div class="metric-value">1</div>
                        <div class="text-muted">Open Claims</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card metric-card dashboard-card">
                    <div class="card-body text-center">
                        <div class="metric-value">2</div>
                        <div class="text-muted">Pending Quotes</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card metric-card dashboard-card">
                    <div class="card-body text-center">
                        <div class="metric-value">$2,500</div>
                        <div class="text-muted">Total Premium</div>
                    </div>
                </div>
            </div>
        `;
        
        document.getElementById('dashboardMetrics').innerHTML = metricsHtml;
        
        // Load sample policies
        const policiesHtml = `
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Policy Number</th>
                            <th>Type</th>
                            <th>Coverage</th>
                            <th>Premium</th>
                            <th>Status</th>
                            <th>Expires</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>AUTO-2024-001</td>
                            <td>Auto Insurance</td>
                            <td>$50,000</td>
                            <td>$1,200</td>
                            <td><span class="badge status-active">Active</span></td>
                            <td>Dec 31, 2024</td>
                        </tr>
                        <tr>
                            <td>HOME-2024-001</td>
                            <td>Home Insurance</td>
                            <td>$250,000</td>
                            <td>$800</td>
                            <td><span class="badge status-active">Active</span></td>
                            <td>Mar 15, 2025</td>
                        </tr>
                        <tr>
                            <td>LIFE-2024-001</td>
                            <td>Life Insurance</td>
                            <td>$100,000</td>
                            <td>$500</td>
                            <td><span class="badge status-active">Active</span></td>
                            <td>Jun 30, 2025</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        `;
        
        document.getElementById('policiesContent').innerHTML = policiesHtml;
        
        // Load sample claims
        const claimsHtml = `
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Claim Number</th>
                            <th>Policy</th>
                            <th>Amount</th>
                            <th>Status</th>
                            <th>Submitted</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>CL-2024-001</td>
                            <td>AUTO-2024-001</td>
                            <td>$2,500</td>
                            <td><span class="badge status-underreview">Under Review</span></td>
                            <td>Nov 15, 2024</td>
                            <td>
                                <button class="btn btn-sm btn-outline-primary">View Details</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="mt-3">
                <button class="btn btn-primary" onclick="submitClaim()">
                    <i class="fas fa-plus me-1"></i>Submit New Claim
                </button>
            </div>
        `;
        
        document.getElementById('claimsContent').innerHTML = claimsHtml;
        
        // Load sample quotes
        const quotesHtml = `
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Quote Number</th>
                            <th>Type</th>
                            <th>Coverage</th>
                            <th>Premium</th>
                            <th>Status</th>
                            <th>Valid Until</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>QT-2024-001</td>
                            <td>Health Insurance</td>
                            <td>$15,000</td>
                            <td>$300</td>
                            <td><span class="badge status-generated">Generated</span></td>
                            <td>Dec 15, 2024</td>
                            <td>
                                <button class="btn btn-sm btn-success me-1">Accept</button>
                                <button class="btn btn-sm btn-outline-danger">Decline</button>
                            </td>
                        </tr>
                        <tr>
                            <td>QT-2024-002</td>
                            <td>Travel Insurance</td>
                            <td>$5,000</td>
                            <td>$150</td>
                            <td><span class="badge status-sent">Sent</span></td>
                            <td>Nov 30, 2024</td>
                            <td>
                                <button class="btn btn-sm btn-success me-1">Accept</button>
                                <button class="btn btn-sm btn-outline-danger">Decline</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        `;
        
        document.getElementById('quotesContent').innerHTML = quotesHtml;
        
    } catch (error) {
        console.error('Error loading dashboard data:', error);
    }
}

// UI Helper functions
function showMainContent() {
    document.getElementById('mainContent').style.display = 'block';
    document.getElementById('dashboardContent').style.display = 'none';
}

function showLogin() {
    const modal = new bootstrap.Modal(document.getElementById('loginModal'));
    modal.show();
}

function showRegister() {
    const loginModal = bootstrap.Modal.getInstance(document.getElementById('loginModal'));
    if (loginModal) loginModal.hide();
    
    const modal = new bootstrap.Modal(document.getElementById('registerModal'));
    modal.show();
}

function showQuoteForm() {
    const modal = new bootstrap.Modal(document.getElementById('quoteModal'));
    modal.show();
}

function getQuote(policyType) {
    showQuoteForm();
    
    // Pre-select the policy type
    const policyTypeMap = {
        'Auto': '0',
        'Home': '1',
        'Life': '2',
        'Health': '3',
        'Travel': '4',
        'Business': '5'
    };
    
    if (policyTypeMap[policyType]) {
        document.getElementById('quotePolicyType').value = policyTypeMap[policyType];
    }
}

function hideModal(modalId) {
    const modal = bootstrap.Modal.getInstance(document.getElementById(modalId));
    if (modal) modal.hide();
}

function showAlert(message, type = 'info') {
    const alertDiv = document.createElement('div');
    alertDiv.className = `alert alert-${type} alert-dismissible fade show position-fixed`;
    alertDiv.style.cssText = 'top: 100px; right: 20px; z-index: 9999; min-width: 300px;';
    alertDiv.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    
    document.body.appendChild(alertDiv);
    
    // Auto-remove after 5 seconds
    setTimeout(() => {
        if (alertDiv.parentNode) {
            alertDiv.remove();
        }
    }, 5000);
}

function showLoading(message = 'Loading...') {
    const loadingDiv = document.createElement('div');
    loadingDiv.id = 'loadingOverlay';
    loadingDiv.className = 'position-fixed d-flex align-items-center justify-content-center';
    loadingDiv.style.cssText = 'top: 0; left: 0; width: 100%; height: 100%; background: rgba(0,0,0,0.5); z-index: 9999;';
    loadingDiv.innerHTML = `
        <div class="text-center text-white">
            <div class="spinner-border mb-3" role="status">
                <span class="visually-hidden">Loading...</span>
            </div>
            <div>${message}</div>
        </div>
    `;
    
    document.body.appendChild(loadingDiv);
}

function hideLoading() {
    const loadingDiv = document.getElementById('loadingOverlay');
    if (loadingDiv) {
        loadingDiv.remove();
    }
}

function contactAgent() {
    showAlert('Our agents will contact you within 24 hours!', 'success');
}

function submitClaim() {
    showAlert('Claim submission form will be implemented in the next version.', 'info');
}

// Utility functions
function formatCurrency(amount) {
    return new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD'
    }).format(amount);
}

function formatDate(dateString) {
    return new Date(dateString).toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'short',
        day: 'numeric'
    });
}

// API helper function
async function apiCall(endpoint, options = {}) {
    const defaultOptions = {
        headers: {
            'Content-Type': 'application/json',
            ...(authToken && { 'Authorization': `Bearer ${authToken}` })
        }
    };
    
    const response = await fetch(`${apiBaseUrl}${endpoint}`, {
        ...defaultOptions,
        ...options,
        headers: { ...defaultOptions.headers, ...options.headers }
    });
    
    if (!response.ok) {
        throw new Error(`API call failed: ${response.status} ${response.statusText}`);
    }
    
    return response;
}