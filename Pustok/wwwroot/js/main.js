// Main JavaScript File
document.addEventListener('DOMContentLoaded', function() {
    console.log('Pustok Online Store Loaded');
    
    // Add to cart functionality
    const addToCartButtons = document.querySelectorAll('a[href="#"]');
    addToCartButtons.forEach(button => {
        if (button.textContent.includes('Add to Cart')) {
      button.addEventListener('click', function(e) {
      e.preventDefault();
    alert('Product added to cart!');
         });
  }
    });
});
