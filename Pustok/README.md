# Pustok E-Commerce Project

## Project Structure

```
Pustok.MVC/
??? Areas/
?   ??? Admin/
?       ??? Controllers/
?       ?   ??? DashboardController.cs
?     ?   ??? CategoriesController.cs
?       ?   ??? ProductsController.cs
?       ?   ??? SlidersController.cs
?       ??? Views/
??? Attributes/
?   ??? AllowedExtensionsAttribute.cs
?   ??? MaxFileSizeAttribute.cs
??? Controllers/
?   ??? HomeController.cs
?   ??? AccountController.cs
?   ??? ProductController.cs
??? Data/
?   ??? AppDbContext.cs
?   ??? Migrations/
??? Dto/
?   ??? (Data Transfer Objects)
??? Extensions/
?   ??? ProductExtensions.cs
?   ??? CategoryExtensions.cs
?   ??? SliderExtensions.cs
??? Models/
?   ??? AppUser.cs
?   ??? Product.cs
?   ??? Category.cs
?   ??? Slider.cs
?   ??? ProductImage.cs
?   ??? ErrorViewModel.cs
??? Services/
? ??? Interfaces/
?   ?   ??? IEmailService.cs
?   ?   ??? IFileService.cs
?   ??? Implementations/
?       ??? EmailService.cs
?       ??? FileService.cs
??? ViewModels/
?   ??? Users/
?   ?   ??? UserLoginVm.cs
?   ? ??? UserRegisterVm.cs
?   ?   ??? UserProfileVm.cs
?   ?   ??? UserProfileUpdateVm.cs
?   ?   ??? ForgotPasswordVm.cs
?   ?   ??? ResetPasswordVm.cs
?   ?   ??? ResetPasswordWithCodeVm.cs
???? Product/
?   ?   ??? ProductCreateViewModel.cs
?   ?   ??? ProductEditViewModel.cs
?   ?   ??? ProductListViewModel.cs
?   ?   ??? ProductDetailsViewModel.cs
?   ??? Category/
?   ?   ??? CategoryCreateViewModel.cs
?   ?   ??? CategoryEditViewModel.cs
? ?   ??? CategoryViewModel.cs
?   ??? Slider/
?   ?   ??? SliderCreateViewModel.cs
?   ?   ??? SliderEditViewModel.cs
?   ?   ??? SliderViewModel.cs
?   ?   ??? SliderListViewModel.cs
?   ??? Home/
?   ?   ??? HomeViewModel.cs
?   ??? Dashboard/
?   ?   ??? DashboardViewModel.cs
?   ??? Shared/
?       ??? PaginatedListViewModel.cs
? ??? ApiResponse.cs
?       ??? ProductFilterViewModel.cs
??? Views/
?   ??? Home/
?   ??? Account/
?   ?   ??? Login.cshtml
?   ?   ??? Register.cshtml
?   ?   ??? ForgotPassword.cshtml
?   ?   ??? Profile.cshtml
?   ?   ??? EditProfile.cshtml
?   ?   ??? AccessDenied.cshtml
?   ??? Product/
???? Shared/
?   ??? _Layout.cshtml
?       ??? _Notifications.cshtml
??? wwwroot/
?   ??? css/
?   ??? js/
?   ??? image/
??? Program.cs
??? appsettings.json
```

## Features

### Authentication & Authorization
- ? ASP.NET Core Identity integration
- ? User registration with validation
- ? User login/logout
- ? Password reset functionality
- ? User profile management
- ? **My Account dashboard with tabs**
- ? **Profile update with password change**
- ? Account lockout after failed attempts
- ? Remember me functionality

### My Account Features
- ? **Dashboard** - Account overview
- ? **Orders** - Order history (ready for integration)
- ? **Address** - Manage shipping address
- ? **Account Details** - Update profile and change password
- ? Responsive tab-based navigation
- ? Real-time user information display

### Admin Panel
- ? Dashboard
- ? Category management (CRUD)
- ? Product management (CRUD)
- ? Slider management (CRUD)

### Frontend
- ? Home page with sliders
- ? Product listing
- ? Product details
- ? Category browsing
- ? Search functionality

### Services
- ? Email service interface
- ? File upload service
- ? Extension methods for model mapping

### ViewModels
- ? Separation of concerns
- ? Validation attributes
- ? Data transfer objects
- ? API response models

## Technologies Used

- **Framework**: ASP.NET Core 8.0 MVC
- **ORM**: Entity Framework Core 8.0
- **Database**: SQL Server
- **Authentication**: ASP.NET Core Identity
- **JSON**: Newtonsoft.Json
- **UI**: Bootstrap 5, Custom CSS

## Configuration

### Database Connection
Update `appsettings.json`:
```json
{
  "ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=PustokDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Identity Settings
- Minimum password length: 8 characters
- Requires uppercase, lowercase, and digit
- Lockout: 5 failed attempts = 15 minutes lockout
- Cookie expiration: 7 days

## Database Migrations

```bash
# Create migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

## Running the Project

```bash
# Restore packages
dotnet restore

# Build project
dotnet build

# Run project
dotnet run
```

## Default Routes

- Home: `/`
- Login: `/Account/Login`
- Register: `/Account/Register`
- **My Account: `/Account/MyAccount`**
- **Edit Profile: `/Account/EditProfile`**
- Admin Dashboard: `/Admin/Dashboard`
- Admin Products: `/Admin/Products`
- Admin Categories: `/Admin/Categories`
- Admin Sliders: `/Admin/Sliders`

## Project Conventions

### Naming Conventions
- ViewModels: `{Entity}{Action}Vm.cs` (e.g., `UserLoginVm.cs`)
- Services: `I{Name}Service.cs` interface, `{Name}Service.cs` implementation
- Controllers: `{Entity}Controller.cs`
- Views: Matching controller action names

### Folder Structure
- **Areas**: Feature-based organization (Admin panel)
- **Attributes**: Custom validation attributes
- **Controllers**: Request handlers
- **Data**: Database context and migrations
- **Dto**: Data transfer objects
- **Extensions**: Extension methods
- **Models**: Entity models
- **Services**: Business logic
- **ViewModels**: View-specific models
- **Views**: Razor views

## Security Features

- ? CSRF protection with `[ValidateAntiForgeryToken]`
- ? Password hashing via Identity
- ? Secure authentication cookies
- ? SQL injection protection via EF Core
- ? XSS protection via Razor encoding
- ? Account lockout protection
- ? Authorization attributes

## Future Enhancements

- [ ] Shopping cart functionality
- [ ] Order management
- [ ] Payment integration
- [ ] Product reviews and ratings
- [ ] Wishlist
- [ ] Advanced search and filtering
- [ ] Email confirmation
- [ ] Two-factor authentication
- [ ] Social login (Google, Facebook)
- [ ] Admin role management

## License

This project is for educational purposes.
