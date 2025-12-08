# SecureLife Insurance Website

A comprehensive insurance management system built with ASP.NET Core 8 and modern web technologies.

## Features

- **Frontend**: Modern responsive web interface with Bootstrap 5
- **Backend**: ASP.NET Core Web API with Entity Framework
- **Authentication**: JWT-based authentication system
- **Insurance Services**: Auto, Home, Life, Health, Travel, and Business insurance
- **Management**: Customer, Policy, Claim, and Quote management
- **Dashboard**: User-friendly dashboard for customers and agents

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or VS Code
- Web browser (Chrome, Firefox, Edge, Safari)

## Quick Start

1. **Navigate to the project directory:**
   ```bash
   cd InsuranceProject
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

4. **Open your browser and go to:**
   - HTTPS: `https://localhost:7000`
   - HTTP: `http://localhost:5000`

## Default Test Accounts

### Admin Account
- Username: `admin`
- Password: `admin123`
- Role: Admin (full access)

### Agent Account
- Username: `agent1`
- Password: `agent123`
- Role: Agent (manage policies and claims)

### Customer Account
- Username: `customer1`
- Password: `customer123`
- Role: Customer (view own data)

## How to Use

### For New Visitors:
1. Visit the homepage
2. Browse insurance services
3. Click "Get Quote" on any service card
4. Fill out the quote form
5. Receive instant premium calculation

### For Existing Customers:
1. Click "Login" in the top navigation
2. Use your credentials to sign in
3. Access your dashboard to view:
   - Active policies
   - Claims status
   - Quote history
   - Account information

### For New Customers:
1. Click "Login" then "Register here"
2. Create a new account
3. Start requesting quotes and managing policies

## API Endpoints

The application provides a comprehensive REST API:

- **Authentication**: `/api/auth/login`, `/api/auth/register`
- **Customers**: `/api/customers`
- **Policies**: `/api/policies`
- **Claims**: `/api/claims`
- **Quotes**: `/api/quotes`

API documentation is available at `/swagger` when running in development mode.

## Technology Stack

- **Backend**: ASP.NET Core 8, Entity Framework Core
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Database**: In-Memory Database (for demo)
- **Authentication**: JWT Bearer tokens
- **Icons**: Font Awesome
- **Styling**: Bootstrap 5 with custom CSS

## Project Structure

```
InsuranceProject/
├── Controllers/          # API Controllers
├── Models/              # Data models
├── Services/            # Business logic services
├── Data/               # Database context and seed data
├── wwwroot/            # Static web files
│   ├── css/           # Stylesheets
│   ├── js/            # JavaScript files
│   └── index.html     # Main webpage
└── Program.cs          # Application entry point
```

## Development

To modify the website:

1. **Frontend changes**: Edit files in `wwwroot/`
   - `index.html` - Main webpage structure
   - `css/styles.css` - Custom styling
   - `js/app.js` - JavaScript functionality

2. **Backend changes**: Edit files in the main project
   - `Controllers/` - API endpoints
   - `Services/` - Business logic
   - `Models/` - Data structures

3. **Database changes**: Modify `Data/SeedData.cs` for sample data

## Deployment

### Local IIS
1. Publish: `dotnet publish -c Release`
2. Copy published files to IIS directory
3. Configure IIS application

### Docker
```bash
docker build -t insurance-app .
docker run -p 8080:8080 insurance-app
```

### Cloud Deployment
- Azure App Service
- AWS Elastic Beanstalk
- Google Cloud Run

## Troubleshooting

### Common Issues:

1. **Port already in use**: Change ports in `Properties/launchSettings.json`
2. **CORS errors**: Check CORS configuration in `Program.cs`
3. **Database issues**: Delete and recreate the in-memory database by restarting the app

### Getting Help:

1. Check browser console for JavaScript errors
2. Check application logs for server errors
3. Use Swagger UI for API testing: `/swagger`

## License

This project is for educational/demonstration purposes.

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SecureLife Insurance - Your Protection Partner</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/styles.css">
</head>
<body>
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top">
        <div class="container">
            <a class="navbar-brand fw-bold" href="#home">
                <i class="fas fa-shield-alt me-2"></i>SecureLife Insurance
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav me-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#home">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#services">Services</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#features">Features</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#testimonials">Reviews</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#about">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#contact">Contact</a>
                    </li>
                </ul>
                <ul class="navbar-nav">
                    <li class="nav-item" id="loginNav">
                        <a class="nav-link" href="#" onclick="showLogin()">
                            <i class="fas fa-sign-in-alt me-1"></i>Login
                        </a>
                    </li>
                    <li class="nav-item" id="dashboardNav" style="display: none;">
                        <a class="nav-link" href="#" onclick="showDashboard()">
                            <i class="fas fa-tachometer-alt me-1"></i>Dashboard
                        </a>
                    </li>
                    <li class="nav-item" id="logoutNav" style="display: none;">
                        <a class="nav-link" href="#" onclick="logout()">
                            <i class="fas fa-sign-out-alt me-1"></i>Logout
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Main Content -->
    <div id="mainContent">
        <!-- Hero Section -->
        <section id="home" class="hero-section bg-gradient text-white">
            <div class="container">
                <div class="row align-items-center min-vh-100">
                    <div class="col-lg-6">
                        <div class="animate__animated animate__fadeInLeft">
                            <span class="badge bg-light text-primary mb-3 px-3 py-2">
                                <i class="fas fa-star me-1"></i>Rated #1 Insurance Provider 2024
                            </span>
                            <h1 class="display-3 fw-bold mb-4">Protect What Matters Most</h1>
                            <p class="lead mb-4">Comprehensive insurance solutions tailored to your needs. From auto to life insurance, we've got you covered with competitive rates and exceptional service.</p>
                            
                            <!-- Key Benefits -->
                            <div class="row mb-4">
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>Instant Online Quotes</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>24/7 Claims Support</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>No Hidden Fees</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>Multi-Policy Discounts</span>
                                </div>
                            </div>

                            <div class="d-grid gap-2 d-md-flex">
                                <button class="btn btn-light btn-lg me-md-2 pulse-btn" onclick="showQuoteForm()">
                                    <i class="fas fa-calculator me-2"></i>Get Free Quote
                                </button>
                                <button class="btn btn-outline-light btn-lg" onclick="showLogin()">
                                    <i class="fas fa-user me-2"></i>Customer Portal
                                </button>
                            </div>
                            
                            <!-- Trust Indicators -->
                            <div class="mt-4 d-flex align-items-center flex-wrap">
                                <small class="text-light me-4 mb-2">
                                    <i class="fas fa-users me-1"></i>50,000+ Happy Customers
                                </small>
                                <small class="text-light me-4 mb-2">
                                    <i class="fas fa-star me-1"></i>4.9/5 Customer Rating
                                </small>
                                <small class="text-light mb-2">
                                    <i class="fas fa-award me-1"></i>A+ BBB Rating
                                </small>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="hero-image text-center">
                            <div class="hero-graphic">
                                <i class="fas fa-shield-alt display-1 text-light mb-4 floating-icon"></i>
                                <div class="hero-stats">
                                    <div class="stat-bubble stat-bubble-1">
                                        <i class="fas fa-car"></i>
                                        <div>Auto Insurance</div>
                                    </div>
                                    <div class="stat-bubble stat-bubble-2">
                                        <i class="fas fa-home"></i>
                                        <div>Home Insurance</div>
                                    </div>
                                    <div class="stat-bubble stat-bubble-3">
                                        <i class="fas fa-heartbeat"></i>
                                        <div>Life Insurance</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Quick Quote Banner -->
        <section class="py-4 bg-success text-white">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-8">
                        <h5 class="mb-0">
                            <i class="fas fa-bolt me-2"></i>
                            Get an instant quote in under 2 minutes!
                        </h5>
                    </div>
                    <div class="col-lg-4 text-lg-end mt-2 mt-lg-0">
                        <button class="btn btn-light btn-sm" onclick="showQuoteForm()">
                            Start Now <i class="fas fa-arrow-right ms-1"></i>
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <!-- Services Section -->
        <section id="services" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Our Insurance Services</h2>
                        <p class="lead text-muted">Comprehensive coverage options for every aspect of your life</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-car text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Auto Insurance</h5>
                                <p class="card-text">Comprehensive vehicle coverage with competitive rates and excellent customer service.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Collision</span>
                                    <span class="badge bg-light text-dark me-1">Liability</span>
                                    <span class="badge bg-light text-dark">Comprehensive</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $299/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Auto')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-home text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Home Insurance</h5>
                                <p class="card-text">Protect your home and belongings with our comprehensive homeowners insurance policies.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Property</span>
                                    <span class="badge bg-light text-dark me-1">Liability</span>
                                    <span class="badge bg-light text-dark">Personal Property</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $799/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Home')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-heartbeat text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Life Insurance</h5>
                                <p class="card-text">Secure your family's future with our flexible life insurance plans and coverage options.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Term Life</span>
                                    <span class="badge bg-light text-dark me-1">Whole Life</span>
                                    <span class="badge bg-light text-dark">Universal</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $25/month</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Life')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-user-md text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Health Insurance</h5>
                                <p class="card-text">Quality healthcare coverage with access to top medical providers and facilities.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Individual</span>
                                    <span class="badge bg-light text-dark me-1">Family</span>
                                    <span class="badge bg-light text-dark">Group</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $199/month</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Health')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-plane text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Travel Insurance</h5>
                                <p class="card-text">Travel with confidence knowing you're protected against unexpected events and emergencies.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Trip Cancellation</span>
                                    <span class="badge bg-light text-dark me-1">Medical</span>
                                    <span class="badge bg-light text-dark">Baggage</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $49/trip</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Travel')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-building text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Business Insurance</h5>
                                <p class="card-text">Comprehensive business protection including liability, property, and workers' compensation.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">General Liability</span>
                                    <span class="badge bg-light text-dark me-1">Property</span>
                                    <span class="badge bg-light text-dark">Workers' Comp</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $399/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Business')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Features Section -->
        <section id="features" class="py-5 bg-light">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Why Choose SecureLife Insurance?</h2>
                        <p class="lead text-muted">Experience the difference with our customer-first approach</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-clock text-primary display-5"></i>
                            </div>
                            <h5>Quick Processing</h5>
                            <p class="text-muted">Get quotes in minutes, not hours. Our streamlined process gets you covered fast.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-mobile-alt text-primary display-5"></i>
                            </div>
                            <h5>Mobile App</h5>
                            <p class="text-muted">Manage your policies, file claims, and get support anywhere with our mobile app.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-percentage text-primary display-5"></i>
                            </div>
                            <h5>Best Rates</h5>
                            <p class="text-muted">Compare rates from multiple carriers to find the best coverage at the lowest price.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-headset text-primary display-5"></i>
                            </div>
                            <h5>Expert Support</h5>
                            <p class="text-muted">Our licensed agents are here to help you choose the right coverage for your needs.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Testimonials Section -->
        <section id="testimonials" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">What Our Customers Say</h2>
                        <p class="lead text-muted">Don't just take our word for it</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"SecureLife made getting car insurance so easy! Their online quote system saved me hours, and I got better coverage for less money than my previous provider."</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Sarah Johnson</h6>
                                        <small class="text-muted">Auto Insurance Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"When we had a claim after the storm, SecureLife handled everything quickly and professionally. The claim was processed in just 3 days!"</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Mike Chen</h6>
                                        <small class="text-muted">Home Insurance Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"The customer service is outstanding! They helped me bundle my auto and home insurance, saving me over $500 per year. Highly recommended!"</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Emily Rodriguez</h6>
                                        <small class="text-muted">Multi-Policy Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- About Section -->
        <section id="about" class="py-5 bg-light">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-6">
                        <h2 class="display-5 fw-bold mb-4">About SecureLife Insurance</h2>
                        <p class="lead mb-4">Founded in 1998, we've been protecting families and businesses for over 25 years with integrity, innovation, and personalized service.</p>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-check-circle text-success me-3"></i>
                                <h5 class="mb-0">25+ Years of Experience</h5>
                            </div>
                            <p class="text-muted ms-5">Trusted by thousands of customers with decades of insurance expertise and financial stability.</p>
                        </div>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-dollar-sign text-success me-3"></i>
                                <h5 class="mb-0">Competitive Rates</h5>
                            </div>
                            <p class="text-muted ms-5">Get the best coverage at rates that fit your budget with our multi-policy discounts and loyalty programs.</p>
                        </div>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-phone text-success me-3"></i>
                                <h5 class="mb-0">24/7 Customer Support</h5>
                            </div>
                            <p class="text-muted ms-5">Round-the-clock support when you need us most. File claims, get help, or make policy changes anytime.</p>
                        </div>

                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-award text-success me-3"></i>
                                <h5 class="mb-0">Award-Winning Service</h5>
                            </div>
                            <p class="text-muted ms-5">Recognized by JD Power for customer satisfaction and rated A+ by the Better Business Bureau.</p>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="stats-grid">
                            <div class="row g-3">
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold counter" data-target="50000">0</h3>
                                        <p class="text-muted mb-0">Happy Customers</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold">$2B+</h3>
                                        <p class="text-muted mb-0">Coverage Provided</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold counter" data-target="98">0</h3>
                                        <p class="text-muted mb-0">% Customer Satisfaction</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold">24/7</h3>
                                        <p class="text-muted mb-0">Support Available</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Call to Action Section -->
        <section class="py-5 bg-primary text-white">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-8">
                        <h3 class="fw-bold mb-2">Ready to Get Protected?</h3>
                        <p class="mb-0">Join thousands of satisfied customers who trust SecureLife Insurance. Get your free quote today!</p>
                    </div>
                    <div class="col-lg-4 text-lg-end mt-3 mt-lg-0">
                        <button class="btn btn-light btn-lg me-2" onclick="showQuoteForm()">
                            <i class="fas fa-calculator me-2"></i>Get Free Quote
                        </button>
                        <button class="btn btn-outline-light btn-lg" onclick="showLogin()">
                            <i class="fas fa-phone me-2"></i>Call Now
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <!-- Contact Section -->
        <section id="contact" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Get In Touch</h2>
                        <p class="lead text-muted">Ready to get started? Contact us today!</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-phone text-primary display-6"></i>
                            </div>
                            <h5>Call Us</h5>
                            <p class="text-muted">1-800-SECURE-LIFE<br>(1-800-732-8735)</p>
                            <p class="small text-success">
                                <i class="fas fa-clock me-1"></i>Available 24/7
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-envelope text-primary display-6"></i>
                            </div>
                            <h5>Email Us</h5>
                            <p class="text-muted">info@securelife.com<br>support@securelife.com</p>
                            <p class="small text-success">
                                <i class="fas fa-reply me-1"></i>Response within 2 hours
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-map-marker-alt text-primary display-6"></i>
                            </div>
                            <h5>Visit Us</h5>
                            <p class="text-muted">123 Insurance Ave<br>Financial District, NY 10004</p>
                            <p class="small text-success">
                                <i class="fas fa-clock me-1"></i>Mon-Fri 9AM-6PM
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <!-- Login Modal -->
    <div class="modal fade" id="loginModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Customer Login</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="loginForm">
                        <div class="mb-3">
                            <label for="loginUsername" class="form-label">Username</label>
                            <input type="text" class="form-control" id="loginUsername" required>
                        </div>
                        <div class="mb-3">
                            <label for="loginPassword" class="form-label">Password</label>
                            <input type="password" class="form-control" id="loginPassword" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Login</button>
                        </div>
                        <div class="text-center mt-3">
                            <small>Don't have an account? <a href="#" onclick="showRegister()">Register here</a></small>
                        </div>
                        <hr>
                        <div class="text-center">
                            <small class="text-muted">
                                <strong>Test Accounts:</strong><br>
                                Admin: admin/admin123<br>
                                Customer: customer1/customer123
                            </small>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Register Modal -->
    <div class="modal fade" id="registerModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Create Account</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="registerForm">
                        <div class="mb-3">
                            <label for="registerUsername" class="form-label">Username</label>
                            <input type="text" class="form-control" id="registerUsername" required>
                        </div>
                        <div class="mb-3">
                            <label for="registerEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="registerEmail" required>
                        </div>
                        <div class="mb-3">
                            <label for="registerPassword" class="form-label">Password</label>
                            <input type="password" class="form-control" id="registerPassword" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Register</button>
                        </div>
                        <div class="text-center mt-3">
                            <small>Already have an account? <a href="#" onclick="showLogin()">Login here</a></small>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Quote Modal -->
    <div class="modal fade" id="quoteModal" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Get Insurance Quote</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="quoteForm">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label for="quoteFirstName" class="form-label">First Name</label>
                                    <input type="text" class="form-control" id="quoteFirstName" required>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label for="quoteLastName" class="form-label">Last Name</label>
                                    <input type="text" class="form-control" id="quoteLastName" required>
                                </div>
                            </div>
                        </div>
                        <div class="mb-3">
                            <label for="quoteEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="quoteEmail" required>
                        </div>
                        <div class="mb-3">
                            <label for="quotePhone" class="form-label">Phone</label>
                            <input type="tel" class="form-control" id="quotePhone" required>
                        </div>
                        <div class="mb-3">
                            <label for="quotePolicyType" class="form-label">Insurance Type</label>
                            <select class="form-select" id="quotePolicyType" required>
                                <option value="">Select Insurance Type</option>
                                <option value="0">Auto Insurance</option>
                                <option value="1">Home Insurance</option>
                                <option value="2">Life Insurance</option>
                                <option value="3">Health Insurance</option>
                                <option value="4">Travel Insurance</option>
                                <option value="5">Business Insurance</option>
                            </select>
                        </div>
                        <div class="mb-3">
                            <label for="quoteCoverageAmount" class="form-label">Coverage Amount ($)</label>
                            <input type="number" class="form-control" id="quoteCoverageAmount" min="1000" required>
                        </div>
                        <div class="mb-3">
                            <label for="quoteBirthDate" class="form-label">Date of Birth</label>
                            <input type="date" class="form-control" id="quoteBirthDate" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Request Quote</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Dashboard -->
    <div id="dashboardContent" style="display: none;">
        <!-- Dashboard content will be loaded here -->
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="js/app.js"></script>
</body>
</html>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SecureLife Insurance - Your Protection Partner</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/styles.css">
</head>
<body>
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top">
        <div class="container">
            <a class="navbar-brand fw-bold" href="#home">
                <i class="fas fa-shield-alt me-2"></i>SecureLife Insurance
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav me-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#home">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#services">Services</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#features">Features</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#testimonials">Reviews</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#about">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#contact">Contact</a>
                    </li>
                </ul>
                <ul class="navbar-nav">
                    <li class="nav-item" id="loginNav">
                        <a class="nav-link" href="#" onclick="showLogin()">
                            <i class="fas fa-sign-in-alt me-1"></i>Login
                        </a>
                    </li>
                    <li class="nav-item" id="dashboardNav" style="display: none;">
                        <a class="nav-link" href="#" onclick="showDashboard()">
                            <i class="fas fa-tachometer-alt me-1"></i>Dashboard
                        </a>
                    </li>
                    <li class="nav-item" id="logoutNav" style="display: none;">
                        <a class="nav-link" href="#" onclick="logout()">
                            <i class="fas fa-sign-out-alt me-1"></i>Logout
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Main Content -->
    <div id="mainContent">
        <!-- Hero Section -->
        <section id="home" class="hero-section bg-gradient text-white">
            <div class="container">
                <div class="row align-items-center min-vh-100">
                    <div class="col-lg-6">
                        <div class="animate__animated animate__fadeInLeft">
                            <span class="badge bg-light text-primary mb-3 px-3 py-2">
                                <i class="fas fa-star me-1"></i>Rated #1 Insurance Provider 2024
                            </span>
                            <h1 class="display-3 fw-bold mb-4">Protect What Matters Most</h1>
                            <p class="lead mb-4">Comprehensive insurance solutions tailored to your needs. From auto to life insurance, we've got you covered with competitive rates and exceptional service.</p>
                            
                            <!-- Key Benefits -->
                            <div class="row mb-4">
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>Instant Online Quotes</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>24/7 Claims Support</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>No Hidden Fees</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>Multi-Policy Discounts</span>
                                </div>
                            </div>

                            <div class="d-grid gap-2 d-md-flex">
                                <button class="btn btn-light btn-lg me-md-2 pulse-btn" onclick="showQuoteForm()">
                                    <i class="fas fa-calculator me-2"></i>Get Free Quote
                                </button>
                                <button class="btn btn-outline-light btn-lg" onclick="showLogin()">
                                    <i class="fas fa-user me-2"></i>Customer Portal
                                </button>
                            </div>
                            
                            <!-- Trust Indicators -->
                            <div class="mt-4 d-flex align-items-center flex-wrap">
                                <small class="text-light me-4 mb-2">
                                    <i class="fas fa-users me-1"></i>50,000+ Happy Customers
                                </small>
                                <small class="text-light me-4 mb-2">
                                    <i class="fas fa-star me-1"></i>4.9/5 Customer Rating
                                </small>
                                <small class="text-light mb-2">
                                    <i class="fas fa-award me-1"></i>A+ BBB Rating
                                </small>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="hero-image text-center">
                            <div class="hero-graphic">
                                <i class="fas fa-shield-alt display-1 text-light mb-4 floating-icon"></i>
                                <div class="hero-stats">
                                    <div class="stat-bubble stat-bubble-1">
                                        <i class="fas fa-car"></i>
                                        <div>Auto Insurance</div>
                                    </div>
                                    <div class="stat-bubble stat-bubble-2">
                                        <i class="fas fa-home"></i>
                                        <div>Home Insurance</div>
                                    </div>
                                    <div class="stat-bubble stat-bubble-3">
                                        <i class="fas fa-heartbeat"></i>
                                        <div>Life Insurance</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Quick Quote Banner -->
        <section class="py-4 bg-success text-white">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-8">
                        <h5 class="mb-0">
                            <i class="fas fa-bolt me-2"></i>
                            Get an instant quote in under 2 minutes!
                        </h5>
                    </div>
                    <div class="col-lg-4 text-lg-end mt-2 mt-lg-0">
                        <button class="btn btn-light btn-sm" onclick="showQuoteForm()">
                            Start Now <i class="fas fa-arrow-right ms-1"></i>
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <!-- Services Section -->
        <section id="services" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Our Insurance Services</h2>
                        <p class="lead text-muted">Comprehensive coverage options for every aspect of your life</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-car text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Auto Insurance</h5>
                                <p class="card-text">Comprehensive vehicle coverage with competitive rates and excellent customer service.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Collision</span>
                                    <span class="badge bg-light text-dark me-1">Liability</span>
                                    <span class="badge bg-light text-dark">Comprehensive</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $299/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Auto')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-home text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Home Insurance</h5>
                                <p class="card-text">Protect your home and belongings with our comprehensive homeowners insurance policies.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Property</span>
                                    <span class="badge bg-light text-dark me-1">Liability</span>
                                    <span class="badge bg-light text-dark">Personal Property</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $799/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Home')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-heartbeat text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Life Insurance</h5>
                                <p class="card-text">Secure your family's future with our flexible life insurance plans and coverage options.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Term Life</span>
                                    <span class="badge bg-light text-dark me-1">Whole Life</span>
                                    <span class="badge bg-light text-dark">Universal</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $25/month</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Life')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-user-md text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Health Insurance</h5>
                                <p class="card-text">Quality healthcare coverage with access to top medical providers and facilities.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Individual</span>
                                    <span class="badge bg-light text-dark me-1">Family</span>
                                    <span class="badge bg-light text-dark">Group</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $199/month</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Health')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-plane text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Travel Insurance</h5>
                                <p class="card-text">Travel with confidence knowing you're protected against unexpected events and emergencies.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Trip Cancellation</span>
                                    <span class="badge bg-light text-dark me-1">Medical</span>
                                    <span class="badge bg-light text-dark">Baggage</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $49/trip</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Travel')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-building text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Business Insurance</h5>
                                <p class="card-text">Comprehensive business protection including liability, property, and workers' compensation.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">General Liability</span>
                                    <span class="badge bg-light text-dark me-1">Property</span>
                                    <span class="badge bg-light text-dark">Workers' Comp</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $399/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Business')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Features Section -->
        <section id="features" class="py-5 bg-light">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Why Choose SecureLife Insurance?</h2>
                        <p class="lead text-muted">Experience the difference with our customer-first approach</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-clock text-primary display-5"></i>
                            </div>
                            <h5>Quick Processing</h5>
                            <p class="text-muted">Get quotes in minutes, not hours. Our streamlined process gets you covered fast.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-mobile-alt text-primary display-5"></i>
                            </div>
                            <h5>Mobile App</h5>
                            <p class="text-muted">Manage your policies, file claims, and get support anywhere with our mobile app.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-percentage text-primary display-5"></i>
                            </div>
                            <h5>Best Rates</h5>
                            <p class="text-muted">Compare rates from multiple carriers to find the best coverage at the lowest price.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-headset text-primary display-5"></i>
                            </div>
                            <h5>Expert Support</h5>
                            <p class="text-muted">Our licensed agents are here to help you choose the right coverage for your needs.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Testimonials Section -->
        <section id="testimonials" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">What Our Customers Say</h2>
                        <p class="lead text-muted">Don't just take our word for it</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"SecureLife made getting car insurance so easy! Their online quote system saved me hours, and I got better coverage for less money than my previous provider."</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Sarah Johnson</h6>
                                        <small class="text-muted">Auto Insurance Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"When we had a claim after the storm, SecureLife handled everything quickly and professionally. The claim was processed in just 3 days!"</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Mike Chen</h6>
                                        <small class="text-muted">Home Insurance Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"The customer service is outstanding! They helped me bundle my auto and home insurance, saving me over $500 per year. Highly recommended!"</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Emily Rodriguez</h6>
                                        <small class="text-muted">Multi-Policy Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- About Section -->
        <section id="about" class="py-5 bg-light">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-6">
                        <h2 class="display-5 fw-bold mb-4">About SecureLife Insurance</h2>
                        <p class="lead mb-4">Founded in 1998, we've been protecting families and businesses for over 25 years with integrity, innovation, and personalized service.</p>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-check-circle text-success me-3"></i>
                                <h5 class="mb-0">25+ Years of Experience</h5>
                            </div>
                            <p class="text-muted ms-5">Trusted by thousands of customers with decades of insurance expertise and financial stability.</p>
                        </div>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-dollar-sign text-success me-3"></i>
                                <h5 class="mb-0">Competitive Rates</h5>
                            </div>
                            <p class="text-muted ms-5">Get the best coverage at rates that fit your budget with our multi-policy discounts and loyalty programs.</p>
                        </div>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-phone text-success me-3"></i>
                                <h5 class="mb-0">24/7 Customer Support</h5>
                            </div>
                            <p class="text-muted ms-5">Round-the-clock support when you need us most. File claims, get help, or make policy changes anytime.</p>
                        </div>

                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-award text-success me-3"></i>
                                <h5 class="mb-0">Award-Winning Service</h5>
                            </div>
                            <p class="text-muted ms-5">Recognized by JD Power for customer satisfaction and rated A+ by the Better Business Bureau.</p>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="stats-grid">
                            <div class="row g-3">
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold counter" data-target="50000">0</h3>
                                        <p class="text-muted mb-0">Happy Customers</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold">$2B+</h3>
                                        <p class="text-muted mb-0">Coverage Provided</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold counter" data-target="98">0</h3>
                                        <p class="text-muted mb-0">% Customer Satisfaction</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold">24/7</h3>
                                        <p class="text-muted mb-0">Support Available</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Call to Action Section -->
        <section class="py-5 bg-primary text-white">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-8">
                        <h3 class="fw-bold mb-2">Ready to Get Protected?</h3>
                        <p class="mb-0">Join thousands of satisfied customers who trust SecureLife Insurance. Get your free quote today!</p>
                    </div>
                    <div class="col-lg-4 text-lg-end mt-3 mt-lg-0">
                        <button class="btn btn-light btn-lg me-2" onclick="showQuoteForm()">
                            <i class="fas fa-calculator me-2"></i>Get Free Quote
                        </button>
                        <button class="btn btn-outline-light btn-lg" onclick="showLogin()">
                            <i class="fas fa-phone me-2"></i>Call Now
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <!-- Contact Section -->
        <section id="contact" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Get In Touch</h2>
                        <p class="lead text-muted">Ready to get started? Contact us today!</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-phone text-primary display-6"></i>
                            </div>
                            <h5>Call Us</h5>
                            <p class="text-muted">1-800-SECURE-LIFE<br>(1-800-732-8735)</p>
                            <p class="small text-success">
                                <i class="fas fa-clock me-1"></i>Available 24/7
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-envelope text-primary display-6"></i>
                            </div>
                            <h5>Email Us</h5>
                            <p class="text-muted">info@securelife.com<br>support@securelife.com</p>
                            <p class="small text-success">
                                <i class="fas fa-reply me-1"></i>Response within 2 hours
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-map-marker-alt text-primary display-6"></i>
                            </div>
                            <h5>Visit Us</h5>
                            <p class="text-muted">123 Insurance Ave<br>Financial District, NY 10004</p>
                            <p class="small text-success">
                                <i class="fas fa-clock me-1"></i>Mon-Fri 9AM-6PM
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <!-- Login Modal -->
    <div class="modal fade" id="loginModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Customer Login</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="loginForm">
                        <div class="mb-3">
                            <label for="loginUsername" class="form-label">Username</label>
                            <input type="text" class="form-control" id="loginUsername" required>
                        </div>
                        <div class="mb-3">
                            <label for="loginPassword" class="form-label">Password</label>
                            <input type="password" class="form-control" id="loginPassword" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Login</button>
                        </div>
                        <div class="text-center mt-3">
                            <small>Don't have an account? <a href="#" onclick="showRegister()">Register here</a></small>
                        </div>
                        <hr>
                        <div class="text-center">
                            <small class="text-muted">
                                <strong>Test Accounts:</strong><br>
                                Admin: admin/admin123<br>
                                Customer: customer1/customer123
                            </small>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Register Modal -->
    <div class="modal fade" id="registerModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Create Account</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="registerForm">
                        <div class="mb-3">
                            <label for="registerUsername" class="form-label">Username</label>
                            <input type="text" class="form-control" id="registerUsername" required>
                        </div>
                        <div class="mb-3">
                            <label for="registerEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="registerEmail" required>
                        </div>
                        <div class="mb-3">
                            <label for="registerPassword" class="form-label">Password</label>
                            <input type="password" class="form-control" id="registerPassword" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Register</button>
                        </div>
                        <div class="text-center mt-3">
                            <small>Already have an account? <a href="#" onclick="showLogin()">Login here</a></small>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Quote Modal -->
    <div class="modal fade" id="quoteModal" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Get Insurance Quote</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="quoteForm">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label for="quoteFirstName" class="form-label">First Name</label>
                                    <input type="text" class="form-control" id="quoteFirstName" required>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label for="quoteLastName" class="form-label">Last Name</label>
                                    <input type="text" class="form-control" id="quoteLastName" required>
                                </div>
                            </div>
                        </div>
                        <div class="mb-3">
                            <label for="quoteEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="quoteEmail" required>
                        </div>
                        <div class="mb-3">
                            <label for="quotePhone" class="form-label">Phone</label>
                            <input type="tel" class="form-control" id="quotePhone" required>
                        </div>
                        <div class="mb-3">
                            <label for="quotePolicyType" class="form-label">Insurance Type</label>
                            <select class="form-select" id="quotePolicyType" required>
                                <option value="">Select Insurance Type</option>
                                <option value="0">Auto Insurance</option>
                                <option value="1">Home Insurance</option>
                                <option value="2">Life Insurance</option>
                                <option value="3">Health Insurance</option>
                                <option value="4">Travel Insurance</option>
                                <option value="5">Business Insurance</option>
                            </select>
                        </div>
                        <div class="mb-3">
                            <label for="quoteCoverageAmount" class="form-label">Coverage Amount ($)</label>
                            <input type="number" class="form-control" id="quoteCoverageAmount" min="1000" required>
                        </div>
                        <div class="mb-3">
                            <label for="quoteBirthDate" class="form-label">Date of Birth</label>
                            <input type="date" class="form-control" id="quoteBirthDate" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Request Quote</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Dashboard -->
    <div id="dashboardContent" style="display: none;">
        <!-- Dashboard content will be loaded here -->
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="js/app.js"></script>
</body>
</html>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SecureLife Insurance - Your Protection Partner</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/styles.css">
</head>
<body>
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top">
        <div class="container">
            <a class="navbar-brand fw-bold" href="#home">
                <i class="fas fa-shield-alt me-2"></i>SecureLife Insurance
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav me-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#home">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#services">Services</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#features">Features</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#testimonials">Reviews</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#about">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#contact">Contact</a>
                    </li>
                </ul>
                <ul class="navbar-nav">
                    <li class="nav-item" id="loginNav">
                        <a class="nav-link" href="#" onclick="showLogin()">
                            <i class="fas fa-sign-in-alt me-1"></i>Login
                        </a>
                    </li>
                    <li class="nav-item" id="dashboardNav" style="display: none;">
                        <a class="nav-link" href="#" onclick="showDashboard()">
                            <i class="fas fa-tachometer-alt me-1"></i>Dashboard
                        </a>
                    </li>
                    <li class="nav-item" id="logoutNav" style="display: none;">
                        <a class="nav-link" href="#" onclick="logout()">
                            <i class="fas fa-sign-out-alt me-1"></i>Logout
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Main Content -->
    <div id="mainContent">
        <!-- Hero Section -->
        <section id="home" class="hero-section bg-gradient text-white">
            <div class="container">
                <div class="row align-items-center min-vh-100">
                    <div class="col-lg-6">
                        <div class="animate__animated animate__fadeInLeft">
                            <span class="badge bg-light text-primary mb-3 px-3 py-2">
                                <i class="fas fa-star me-1"></i>Rated #1 Insurance Provider 2024
                            </span>
                            <h1 class="display-3 fw-bold mb-4">Protect What Matters Most</h1>
                            <p class="lead mb-4">Comprehensive insurance solutions tailored to your needs. From auto to life insurance, we've got you covered with competitive rates and exceptional service.</p>
                            
                            <!-- Key Benefits -->
                            <div class="row mb-4">
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>Instant Online Quotes</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>24/7 Claims Support</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>No Hidden Fees</span>
                                </div>
                                <div class="col-sm-6 mb-2">
                                    <i class="fas fa-check-circle text-success me-2"></i>
                                    <span>Multi-Policy Discounts</span>
                                </div>
                            </div>

                            <div class="d-grid gap-2 d-md-flex">
                                <button class="btn btn-light btn-lg me-md-2 pulse-btn" onclick="showQuoteForm()">
                                    <i class="fas fa-calculator me-2"></i>Get Free Quote
                                </button>
                                <button class="btn btn-outline-light btn-lg" onclick="showLogin()">
                                    <i class="fas fa-user me-2"></i>Customer Portal
                                </button>
                            </div>
                            
                            <!-- Trust Indicators -->
                            <div class="mt-4 d-flex align-items-center flex-wrap">
                                <small class="text-light me-4 mb-2">
                                    <i class="fas fa-users me-1"></i>50,000+ Happy Customers
                                </small>
                                <small class="text-light me-4 mb-2">
                                    <i class="fas fa-star me-1"></i>4.9/5 Customer Rating
                                </small>
                                <small class="text-light mb-2">
                                    <i class="fas fa-award me-1"></i>A+ BBB Rating
                                </small>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="hero-image text-center">
                            <div class="hero-graphic">
                                <i class="fas fa-shield-alt display-1 text-light mb-4 floating-icon"></i>
                                <div class="hero-stats">
                                    <div class="stat-bubble stat-bubble-1">
                                        <i class="fas fa-car"></i>
                                        <div>Auto Insurance</div>
                                    </div>
                                    <div class="stat-bubble stat-bubble-2">
                                        <i class="fas fa-home"></i>
                                        <div>Home Insurance</div>
                                    </div>
                                    <div class="stat-bubble stat-bubble-3">
                                        <i class="fas fa-heartbeat"></i>
                                        <div>Life Insurance</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Quick Quote Banner -->
        <section class="py-4 bg-success text-white">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-8">
                        <h5 class="mb-0">
                            <i class="fas fa-bolt me-2"></i>
                            Get an instant quote in under 2 minutes!
                        </h5>
                    </div>
                    <div class="col-lg-4 text-lg-end mt-2 mt-lg-0">
                        <button class="btn btn-light btn-sm" onclick="showQuoteForm()">
                            Start Now <i class="fas fa-arrow-right ms-1"></i>
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <!-- Services Section -->
        <section id="services" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Our Insurance Services</h2>
                        <p class="lead text-muted">Comprehensive coverage options for every aspect of your life</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-car text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Auto Insurance</h5>
                                <p class="card-text">Comprehensive vehicle coverage with competitive rates and excellent customer service.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Collision</span>
                                    <span class="badge bg-light text-dark me-1">Liability</span>
                                    <span class="badge bg-light text-dark">Comprehensive</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $299/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Auto')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-home text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Home Insurance</h5>
                                <p class="card-text">Protect your home and belongings with our comprehensive homeowners insurance policies.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Property</span>
                                    <span class="badge bg-light text-dark me-1">Liability</span>
                                    <span class="badge bg-light text-dark">Personal Property</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $799/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Home')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-heartbeat text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Life Insurance</h5>
                                <p class="card-text">Secure your family's future with our flexible life insurance plans and coverage options.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Term Life</span>
                                    <span class="badge bg-light text-dark me-1">Whole Life</span>
                                    <span class="badge bg-light text-dark">Universal</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $25/month</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Life')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-user-md text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Health Insurance</h5>
                                <p class="card-text">Quality healthcare coverage with access to top medical providers and facilities.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Individual</span>
                                    <span class="badge bg-light text-dark me-1">Family</span>
                                    <span class="badge bg-light text-dark">Group</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $199/month</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Health')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-plane text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Travel Insurance</h5>
                                <p class="card-text">Travel with confidence knowing you're protected against unexpected events and emergencies.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">Trip Cancellation</span>
                                    <span class="badge bg-light text-dark me-1">Medical</span>
                                    <span class="badge bg-light text-dark">Baggage</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $49/trip</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Travel')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                        <div class="service-card card h-100 border-0 shadow-sm">
                            <div class="card-body text-center p-4">
                                <div class="service-icon mb-3">
                                    <i class="fas fa-building text-primary display-4"></i>
                                </div>
                                <h5 class="card-title">Business Insurance</h5>
                                <p class="card-text">Comprehensive business protection including liability, property, and workers' compensation.</p>
                                <div class="mb-3">
                                    <span class="badge bg-light text-dark me-1">General Liability</span>
                                    <span class="badge bg-light text-dark me-1">Property</span>
                                    <span class="badge bg-light text-dark">Workers' Comp</span>
                                </div>
                                <p class="text-muted small mb-3">Starting from $399/year</p>
                                <button class="btn btn-outline-primary" onclick="getQuote('Business')">Get Quote</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Features Section -->
        <section id="features" class="py-5 bg-light">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Why Choose SecureLife Insurance?</h2>
                        <p class="lead text-muted">Experience the difference with our customer-first approach</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-clock text-primary display-5"></i>
                            </div>
                            <h5>Quick Processing</h5>
                            <p class="text-muted">Get quotes in minutes, not hours. Our streamlined process gets you covered fast.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-mobile-alt text-primary display-5"></i>
                            </div>
                            <h5>Mobile App</h5>
                            <p class="text-muted">Manage your policies, file claims, and get support anywhere with our mobile app.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-percentage text-primary display-5"></i>
                            </div>
                            <h5>Best Rates</h5>
                            <p class="text-muted">Compare rates from multiple carriers to find the best coverage at the lowest price.</p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="feature-card text-center p-4 h-100 bg-white rounded shadow-sm">
                            <div class="feature-icon mb-3">
                                <i class="fas fa-headset text-primary display-5"></i>
                            </div>
                            <h5>Expert Support</h5>
                            <p class="text-muted">Our licensed agents are here to help you choose the right coverage for your needs.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Testimonials Section -->
        <section id="testimonials" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">What Our Customers Say</h2>
                        <p class="lead text-muted">Don't just take our word for it</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row g-4">
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"SecureLife made getting car insurance so easy! Their online quote system saved me hours, and I got better coverage for less money than my previous provider."</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Sarah Johnson</h6>
                                        <small class="text-muted">Auto Insurance Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"When we had a claim after the storm, SecureLife handled everything quickly and professionally. The claim was processed in just 3 days!"</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Mike Chen</h6>
                                        <small class="text-muted">Home Insurance Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="testimonial-card card border-0 shadow-sm h-100">
                            <div class="card-body p-4">
                                <div class="stars mb-3">
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                    <i class="fas fa-star text-warning"></i>
                                </div>
                                <p class="card-text">"The customer service is outstanding! They helped me bundle my auto and home insurance, saving me over $500 per year. Highly recommended!"</p>
                                <div class="d-flex align-items-center mt-3">
                                    <div class="avatar me-3">
                                        <i class="fas fa-user-circle text-primary fa-2x"></i>
                                    </div>
                                    <div>
                                        <h6 class="mb-0">Emily Rodriguez</h6>
                                        <small class="text-muted">Multi-Policy Customer</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- About Section -->
        <section id="about" class="py-5 bg-light">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-6">
                        <h2 class="display-5 fw-bold mb-4">About SecureLife Insurance</h2>
                        <p class="lead mb-4">Founded in 1998, we've been protecting families and businesses for over 25 years with integrity, innovation, and personalized service.</p>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-check-circle text-success me-3"></i>
                                <h5 class="mb-0">25+ Years of Experience</h5>
                            </div>
                            <p class="text-muted ms-5">Trusted by thousands of customers with decades of insurance expertise and financial stability.</p>
                        </div>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-dollar-sign text-success me-3"></i>
                                <h5 class="mb-0">Competitive Rates</h5>
                            </div>
                            <p class="text-muted ms-5">Get the best coverage at rates that fit your budget with our multi-policy discounts and loyalty programs.</p>
                        </div>
                        
                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-phone text-success me-3"></i>
                                <h5 class="mb-0">24/7 Customer Support</h5>
                            </div>
                            <p class="text-muted ms-5">Round-the-clock support when you need us most. File claims, get help, or make policy changes anytime.</p>
                        </div>

                        <div class="feature mb-4">
                            <div class="d-flex align-items-center mb-2">
                                <i class="fas fa-award text-success me-3"></i>
                                <h5 class="mb-0">Award-Winning Service</h5>
                            </div>
                            <p class="text-muted ms-5">Recognized by JD Power for customer satisfaction and rated A+ by the Better Business Bureau.</p>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="stats-grid">
                            <div class="row g-3">
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold counter" data-target="50000">0</h3>
                                        <p class="text-muted mb-0">Happy Customers</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold">$2B+</h3>
                                        <p class="text-muted mb-0">Coverage Provided</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold counter" data-target="98">0</h3>
                                        <p class="text-muted mb-0">% Customer Satisfaction</p>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="stat-card text-center p-4 bg-white rounded shadow-sm">
                                        <h3 class="text-primary fw-bold">24/7</h3>
                                        <p class="text-muted mb-0">Support Available</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Call to Action Section -->
        <section class="py-5 bg-primary text-white">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-8">
                        <h3 class="fw-bold mb-2">Ready to Get Protected?</h3>
                        <p class="mb-0">Join thousands of satisfied customers who trust SecureLife Insurance. Get your free quote today!</p>
                    </div>
                    <div class="col-lg-4 text-lg-end mt-3 mt-lg-0">
                        <button class="btn btn-light btn-lg me-2" onclick="showQuoteForm()">
                            <i class="fas fa-calculator me-2"></i>Get Free Quote
                        </button>
                        <button class="btn btn-outline-light btn-lg" onclick="showLogin()">
                            <i class="fas fa-phone me-2"></i>Call Now
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <!-- Contact Section -->
        <section id="contact" class="py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mb-5">
                        <h2 class="display-5 fw-bold">Get In Touch</h2>
                        <p class="lead text-muted">Ready to get started? Contact us today!</p>
                        <div class="underline mx-auto"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-phone text-primary display-6"></i>
                            </div>
                            <h5>Call Us</h5>
                            <p class="text-muted">1-800-SECURE-LIFE<br>(1-800-732-8735)</p>
                            <p class="small text-success">
                                <i class="fas fa-clock me-1"></i>Available 24/7
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-envelope text-primary display-6"></i>
                            </div>
                            <h5>Email Us</h5>
                            <p class="text-muted">info@securelife.com<br>support@securelife.com</p>
                            <p class="small text-success">
                                <i class="fas fa-reply me-1"></i>Response within 2 hours
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-4 mb-4">
                        <div class="contact-info text-center p-4">
                            <div class="contact-icon mb-3">
                                <i class="fas fa-map-marker-alt text-primary display-6"></i>
                            </div>
                            <h5>Visit Us</h5>
                            <p class="text-muted">123 Insurance Ave<br>Financial District, NY 10004</p>
                            <p class="small text-success">
                                <i class="fas fa-clock me-1"></i>Mon-Fri 9AM-6PM
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <!-- Login Modal -->
    <div class="modal fade" id="loginModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Customer Login</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="loginForm">
                        <div class="mb-3">
                            <label for="loginUsername" class="form-label">Username</label>
                            <input type="text" class="form-control" id="loginUsername" required>
                        </div>
                        <div class="mb-3">
                            <label for="loginPassword" class="form-label">Password</label>
                            <input type="password" class="form-control" id="loginPassword" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Login</button>
                        </div>
                        <div class="text-center mt-3">
                            <small>Don't have an account? <a href="#" onclick="showRegister()">Register here</a></small>
                        </div>
                        <hr>
                        <div class="text-center">
                            <small class="text-muted">
                                <strong>Test Accounts:</strong><br>
                                Admin: admin/admin123<br>
                                Customer: customer1/customer123
                            </small>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Register Modal -->
    <div class="modal fade" id="registerModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Create Account</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="registerForm">
                        <div class="mb-3">
                            <label for="registerUsername" class="form-label">Username</label>
                            <input type="text" class="form-control" id="registerUsername" required>
                        </div>
                        <div class="mb-3">
                            <label for="registerEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="registerEmail" required>
                        </div>
                        <div class="mb-3">
                            <label for="registerPassword" class="form-label">Password</label>
                            <input type="password" class="form-control" id="registerPassword" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Register</button>
                        </div>
                        <div class="text-center mt-3">
                            <small>Already have an account? <a href="#" onclick="showLogin()">Login here</a></small>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Quote Modal -->
    <div class="modal fade" id="quoteModal" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Get Insurance Quote</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="quoteForm">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label for="quoteFirstName" class="form-label">First Name</label>
                                    <input type="text" class="form-control" id="quoteFirstName" required>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="mb-3">
                                    <label for="quoteLastName" class="form-label">Last Name</label>
                                    <input type="text" class="form-control" id="quoteLastName" required>
                                </div>
                            </div>
                        </div>
                        <div class="mb-3">
                            <label for="quoteEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="quoteEmail" required>
                        </div>
                        <div class="mb-3">
                            <label for="quotePhone" class="form-label">Phone</label>
                            <input type="tel" class="form-control" id="quotePhone" required>
                        </div>
                        <div class="mb-3">
                            <label for="quotePolicyType" class="form-label">Insurance Type</label>
                            <select class="form-select" id="quotePolicyType" required>
                                <option value="">Select Insurance Type</option>
                                <option value="0">Auto Insurance</option>
                                <option value="1">Home Insurance</option>
                                <option value="2">Life Insurance</option>
                                <option value="3">Health Insurance</option>
                                <option value="4">Travel Insurance</option>
                                <option value="5">Business Insurance</option>
                            </select>
                        </div>
                        <div class="mb-3">
                            <label for="quoteCoverageAmount" class="form-label">Coverage Amount ($)</label>
                            <input type="number" class="form-control" id="quoteCoverageAmount" min="1000" required>
                        </div>
                        <div class="mb-3">
                            <label for="quoteBirthDate" class="form-label">Date of Birth</label>
                            <input type="date" class="form-control" id="quoteBirthDate" required>
                        </div>
                        <div class="d-grid">
                            <button type="submit" class="btn btn-primary">Request Quote</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Dashboard -->
    <div id="dashboardContent" style="display: none;">
        <!-- Dashboard content will be loaded here -->
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="js/app.js"></script>
</body>
</html>

    :root {
    --primary-color: #0d6efd;
    --secondary-color: #6c757d;
    --success-color: #198754;
    --warning-color: #ffc107;
    --danger-color: #dc3545;
    --light-color: #f8f9fa;
    --dark-color: #212529;
}

body {
    padding-top: 76px;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

/* Navigation */
.navbar-brand {
    font-size: 1.5rem;
}

/* Hero Section */
.hero-section {
    background: linear-gradient(135deg, var(--primary-color) 0%, #0b5ed7 100%);
    padding: 100px 0;
    position: relative;
    overflow: hidden;
}

.hero-section::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: url('data:image/svg+xml,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100"><defs><pattern id="grain" width="100" height="100" patternUnits="userSpaceOnUse"><circle cx="25" cy="25" r="1" fill="white" opacity="0.1"/><circle cx="75" cy="75" r="1" fill="white" opacity="0.1"/><circle cx="50" cy="50" r="1" fill="white" opacity="0.1"/></pattern></defs><rect width="100" height="100" fill="url(%23grain)"/></svg>');
    opacity: 0.1;
}

.hero-image {
    position: relative;
    text-align: center;
    padding: 2rem;
}

.hero-graphic {
    position: relative;
}

.floating-icon {
    animation: float 3s ease-in-out infinite;
}

.stat-bubble {
    position: absolute;
    background: rgba(255, 255, 255, 0.9);
    border-radius: 50px;
    padding: 15px 20px;
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
    color: var(--primary-color);
    font-size: 0.8rem;
    font-weight: 600;
    animation: bubble 4s ease-in-out infinite;
}

.stat-bubble-1 {
    top: 20%;
    left: -10%;
    animation-delay: 0s;
}

.stat-bubble-2 {
    top: 60%;
    right: -10%;
    animation-delay: 1s;
}

.stat-bubble-3 {
    bottom: 10%;
    left: 10%;
    animation-delay: 2s;
}

.pulse-btn {
    animation: pulse 2s infinite;
}

/* Service Cards */
.service-card {
    transition: all 0.3s ease;
    border-radius: 15px;
}

.service-card:hover {
    transform: translateY(-10px);
    box-shadow: 0 15px 35px rgba(0, 0, 0, 0.15) !important;
}

.service-card .card-body {
    padding: 2rem;
}

.service-icon {
    transition: transform 0.3s ease;
}

.service-card:hover .service-icon {
    transform: scale(1.1);
}

/* Feature Cards */
.feature-card {
    transition: all 0.3s ease;
    border-radius: 15px;
}

.feature-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.15) !important;
}

.feature-icon {
    transition: transform 0.3s ease;
}

.feature-card:hover .feature-icon {
    transform: scale(1.1);
}

/* Testimonial Cards */
.testimonial-card {
    transition: all 0.3s ease;
    border-radius: 15px;
}

.testimonial-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.15) !important;
}

.stars {
    font-size: 1.1rem;
}

/* Stats Cards */
.stat-card {
    transition: all 0.3s ease;
    border-radius: 15px;
}

.stat-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.15) !important;
}

/* Contact Info */
.contact-info {
    transition: all 0.3s ease;
    border-radius: 15px;
    background: rgba(13, 110, 253, 0.05);
}

.contact-info:hover {
    background: rgba(13, 110, 253, 0.1);
    transform: translateY(-3px);
}

.contact-icon {
    transition: transform 0.3s ease;
}

.contact-info:hover .contact-icon {
    transform: scale(1.1);
}

/* Underline Decoration */
.underline {
    width: 60px;
    height: 4px;
    background: var(--primary-color);
    margin: 0 auto 2rem;
    border-radius: 2px;
}

/* Dashboard Styles */
.dashboard-header {
    background: linear-gradient(135deg, var(--primary-color) 0%, #0b5ed7 100%);
    color: white;
    padding: 2rem 0;
}

.dashboard-card {
    border: none;
    border-radius: 15px;
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
    transition: all 0.3s ease;
}

.dashboard-card:hover {
    transform: translateY(-2px);
    box-shadow: 0 8px 25px rgba(0, 0, 0, 0.15);
}

.metric-card {
    background: linear-gradient(135deg, #fff 0%, #f8f9fa 100%);
    border-left: 4px solid var(--primary-color);
}

.metric-value {
    font-size: 2rem;
    font-weight: bold;
    color: var(--primary-color);
}

/* Table Styles */
.table-responsive {
    border-radius: 10px;
    overflow: hidden;
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
}

.table th {
    background-color: var(--primary-color);
    color: white;
    border: none;
    font-weight: 600;
}

.table td {
    border-color: #dee2e6;
    vertical-align: middle;
}

/* Status Badges */
.status-active { background-color: var(--success-color); }
.status-expired { background-color: var(--secondary-color); }
.status-cancelled { background-color: var(--danger-color); }
.status-suspended { background-color: var(--warning-color); }

.status-submitted { background-color: var(--primary-color); }
.status-underreview { background-color: var(--warning-color); }
.status-approved { background-color: var(--success-color); }
.status-rejected { background-color: var(--danger-color); }
.status-closed { background-color: var(--secondary-color); }

.status-draft { background-color: var(--secondary-color); }
.status-generated { background-color: var(--primary-color); }
.status-sent { background-color: var(--warning-color); }
.status-accepted { background-color: var(--success-color); }
.status-declined { background-color: var(--danger-color); }

/* Forms */
.form-control:focus {
    border-color: var(--primary-color);
    box-shadow: 0 0 0 0.2rem rgba(13, 110, 253, 0.25);
}

.btn-primary {
    background-color: var(--primary-color);
    border-color: var(--primary-color);
    transition: all 0.3s ease;
}

.btn-primary:hover {
    background-color: #0b5ed7;
    border-color: #0a58ca;
    transform: translateY(-1px);
    box-shadow: 0 4px 15px rgba(13, 110, 253, 0.3);
}

/* Modal Styles */
.modal-content {
    border: none;
    border-radius: 15px;
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
}

.modal-header {
    border-bottom: 1px solid #dee2e6;
    border-radius: 15px 15px 0 0;
}

/* Loading Spinner */
.loading-spinner {
    display: none;
    text-align: center;
    padding: 2rem;
}

/* Alert Styles */
.alert {
    border: none;
    border-radius: 10px;
}

/* Animations */
@keyframes float {
    0%, 100% { transform: translateY(0px); }
    50% { transform: translateY(-20px); }
}

@keyframes bubble {
    0%, 100% { transform: translateY(0px); opacity: 0.8; }
    50% { transform: translateY(-15px); opacity: 1; }
}

@keyframes pulse {
    0% { box-shadow: 0 0 0 0 rgba(255, 255, 255, 0.7); }
    70% { box-shadow: 0 0 0 10px rgba(255, 255, 255, 0); }
    100% { box-shadow: 0 0 0 0 rgba(255, 255, 255, 0); }
}

.fade-in {
    animation: fadeIn 0.5s ease-in;
}

@keyframes fadeIn {
    from { opacity: 0; transform: translateY(20px); }
    to { opacity: 1; transform: translateY(0); }
}

.slide-in-right {
    animation: slideInRight 0.5s ease-out;
}

@keyframes slideInRight {
    from { transform: translateX(100%); }
    to { transform: translateX(0); }
}

/* Counter Animation */
.counter {
    transition: all 2s ease-in-out;
}

/* Responsive Design */
@media (max-width: 768px) {
    body {
        padding-top: 70px;
    }
    
    .hero-section {
        padding: 50px 0;
    }
    
    .display-3 {
        font-size: 2.5rem;
    }
    
    .display-5 {
        font-size: 2rem;
    }
    
    .service-card {
        margin-bottom: 1.5rem;
    }
    
    .dashboard-card {
        margin-bottom: 1rem;
    }
    
    .stat-bubble {
        position: relative;
        display: inline-block;
        margin: 0.5rem;
        top: auto !important;
        left: auto !important;
        right: auto !important;
        bottom: auto !important;
    }
    
    .hero-graphic {
        margin-top: 2rem;
    }
}

@media (max-width: 576px) {
    .display-3 {
        font-size: 2rem;
    }
    
    .btn-lg {
        font-size: 1rem;
        padding: 0.75rem 1.5rem;
    }
    
    .service-card .card-body {
        padding: 1.5rem;
    }
}

/* Utility Classes */
.cursor-pointer {
    cursor: pointer;
}

.border-radius-lg {
    border-radius: 15px !important;
}

.shadow-hover:hover {
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.15) !important;
    transition: all 0.3s ease;
}

/* Print Styles */
@media print {
    .no-print {
        display: none !important;
    }
    
    .navbar, .modal, .btn {
        display: none !important;
    }
    
    body {
        padding-top: 0;
    }
}

/* Scroll Animation */
.animate-on-scroll {
    opacity: 0;
    transform: translateY(30px);
    transition: all 0.6s ease-out;
}

.animate-on-scroll.animated {
    opacity: 1;
    transform: translateY(0);
}

/* Badge Styles */
.badge {
    font-size: 0.75em;
    border-radius: 0.5rem;
}

/* Custom Scrollbar */
::-webkit-scrollbar {
    width: 8px;
}

::-webkit-scrollbar-track {
    background: #f1f1f1;
}

::-webkit-scrollbar-thumb {
    background: var(--primary-color);
    border-radius: 4px;
}

::-webkit-scrollbar-thumb:hover {
    background: #0b5ed7;
}