# ?? Pustok - E-commerce Bookstore Platform

Modern ASP.NET Core MVC il? haz?rlanm?? tam funksional e-commerce kitab ma?azas?.

## ?? Features

### Frontend
- ?? Modern v? responsive home page
- ?? Product listing v? detail pages
- ?? Shopping cart functionality
- ?? Advanced search v? filtering
- ?? Mobile-friendly design
- ? Fast v? optimized performance

### Admin Panel
- ?? Comprehensive dashboard
- ?? Product management (CRUD)
- ??? Category management
- ?? User management
- ?? Sales tracking
- ?? Modern UI with custom design

### Security & Validation
- ? Server-side validation (Data Annotations)
- ? Client-side validation (jQuery + HTML5)
- ? CSRF protection
- ? SQL injection prevention
- ? Input sanitization

## ??? Tech Stack

- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: SQL Server + Entity Framework Core
- **Frontend**: HTML5, CSS3, JavaScript, jQuery
- **Icons**: Font Awesome 6
- **Design**: Custom CSS (AdminLTE inspired)

## ?? Prerequisites

- .NET 8.0 SDK or higher
- SQL Server 2019 or higher
- Visual Studio 2022 or VS Code

## ?? Installation

1. Clone repository:
```bash
git clone https://github.com/amil740/Backend.git
cd Pustok
```

2. Database connection string-i yenil?yin:
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PustokDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

3. Database migration-lar? t?tbiq edin:
```bash
dotnet ef database update
```

4. Layih?ni i?? sal?n:
```bash
dotnet run
```

5. Browser-d? aç?n:
```
http://localhost:5000
```

## ?? Admin Panel

Admin panel? daxil olmaq:
```
http://localhost:5000/admin
```

## ?? Project Structure

```
Pustok/
??? Areas/
?   ??? Admin/
?       ??? Controllers/
?       ?   ??? DashboardController.cs
?    ?   ??? ProductsController.cs
?       ?   ??? CategoriesController.cs
?       ??? Views/
??? Controllers/
?   ??? HomeController.cs
?   ??? ProductController.cs
??? Models/
?   ??? Product.cs
?   ??? Category.cs
?   ??? ProductImage.cs
??? Data/
?   ??? AppDbContext.cs
?   ??? Migrations/
??? Views/
???? Home/
?   ??? Product/
?   ??? Shared/
??? wwwroot/
?   ??? admin/
?   ?   ??? css/
?   ?   ??? js/
?   ??? css/
?   ??? js/
?   ??? images/
??? Program.cs
```

## ?? Key Features Detail

### Product Management
- ? Add/Edit/Delete products
- ? Multiple image upload
- ? Stock management
- ? Price & discount management
- ? Category assignment
- ? Featured products
- ? Product variants

### Category Management
- ? Hierarchical categories
- ? Parent-child relationships
- ? Icon support
- ? Active/Inactive status
- ? Bulk operations

### Validation System
- ? Required fields validation
- ? String length validation
- ? Range validation (Price, Stock, etc.)
- ? Email format validation
- ? Duplicate checking (SKU, Names)
- ? Custom business rules
- ? Real-time client-side validation

## ?? Database Schema

### Products Table
- Id, Name, Description, Price, OldPrice
- Author, Publisher, ISBN, PageCount
- StockQuantity, SKU
- MainImagePath, HoverImagePath
- CategoryId (FK)
- IsFeatured, IsNew, IsOnSale, IsActive
- ViewCount, SalesCount, Rating
- CreatedDate

### Categories Table
- Id, Name, Description
- IconClass
- ParentCategoryId (FK - Self-referencing)
- IsActive, CreatedDate

### ProductImages Table
- Id, ImagePath, ProductId (FK)
- IsPrimary, Order

## ?? UI/UX Features

- Modern gradient colors
- Smooth animations
- Responsive sidebar
- Interactive forms
- Toast notifications
- Confirmation dialogs
- Loading states
- Error handling

## ?? Security Features

1. **Input Validation**
   - Server-side validation with Data Annotations
   - Client-side validation with jQuery
   - XSS protection

2. **Database Security**
   - Parameterized queries
   - Entity Framework protection
   - SQL injection prevention

3. **Authentication & Authorization**
   - Role-based access control (Coming soon)
   - Secure password hashing (Coming soon)
   - JWT tokens (Coming soon)

## ?? Known Issues

- File upload functionality needs implementation
- Authentication system needs to be added
- Image optimization needed
- DataTables integration pending

## ?? Future Enhancements

- [ ] User authentication & authorization
- [ ] Order management system
- [ ] Payment gateway integration
- [ ] Email notifications
- [ ] Product reviews & ratings
- [ ] Wishlist functionality
- [ ] Advanced reporting
- [ ] Multi-language support
- [ ] SEO optimization

## ?? Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## ?? License

This project is licensed under the MIT License.

## ????? Developer

**Amil Mamishov**
- GitHub: [@amil740](https://github.com/amil740)
- Email: your.email@example.com

## ?? Support

For support, email your.email@example.com or create an issue on GitHub.

---

? If you like this project, please give it a star on GitHub!
