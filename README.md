# BookStore

### Lalia Book Store

Project Overview 

The BookStore Web Application is a full-stack ASP.NET Core MVC project that allows users to browse, filter, and purchase books while providing administrators with role-based management functionalities. The website features a clean and modern UI with a beige-and-brown color scheme, designed to provide an intuitive shopping experience.


### Technologies Used

**Frontend**

HTML, CSS, Bootstrap – For structuring and styling the UI, ensuring responsiveness.
Razor Pages (CSHTML) – Used for dynamically rendering content on views.
JavaScript – Enhances interactivity in some areas (e.g., form validation, filtering).

**Backend**

ASP.NET Core MVC – The framework for handling requests, responses, and business logic.
Entity Framework Core (EF Core) – ORM used for database operations.
ASP.NET Identity – Manages authentication and authorization, supporting role-based access control.
Dependency Injection (DI) – Used to manage services like authentication, database access, and email sending.

**Database**

SQL Server – Used to store book details, user data, roles, and orders.
EF Core Migrations – Helps with database schema changes without data loss.

**Security**

ASP.NET Identity – Handles user authentication and roles securely.
Data Validation – Ensures input correctness (e.g., preventing text input in numeric fields).
Authorization Policies – Restricts admin-only pages.
Error Handling & Restrictions 
If a regular user tries to access the Book List or Roles, they get redirected or denied access.

If an unauthenticated user tries to visit a restricted page, they are prompted to log in
Other Integrations
Session & Cookies – Stores user sessions and cart information.

### How It Works

**User Authentication & Authorization**

Users can register and log in using ASP.NET Identity.
If a user registers with admin@site.com, they are automatically assigned the Admin role.
Role-based access ensures only admins can manage books and roles.
**Login Page**
Users can log in using their email and password. 
Admin users are redirected to the Books Management Page after login.
Regular users are redirected to the homepage.
**Register Page**
New users can create an account which gets stored in a database 

### Book Management

Books are stored in a SQL Server database and fetched via Entity Framework Core.
Users can filter books by title, author, or price range using LINQ queries.
**Shopping Cart & Orders**
Users can add books to a cart, which is stored using Session or Database.

**Admin Panel**
Admins can add, update, or delete books from the catalog.
Role management allows them to assign roles to users dynamically.

### User Interface (UI) Overview

**General Layout**
A clean beige-and-brown color scheme inspired by classic bookstores.

**Navigation Bar with links to:**
Store – Main book listing page.
Book List – View all books (Admin-only).
Roles – Manage user roles (Admin-only).
User Profile Section – Displays logged-in user’s email and logout option.

### Pages & Features

**Home Page**
Displays a welcome message with links to key sections.
Redirects users to Store by default after login/logout.
**Store Page**
Book browsing experience with filters for title, author, and price range.
Books are displayed in cards with images, titles, and categories.
Cart system allows users to add books and proceed to checkout.
**Admin Pages**
Book List – CRUD operations for book management.
Role Management – Assign or remove roles dynamically.
Order List – View and process customer orders.

**Authentication & Account Management**
Users can register, login, and update profiles.
Admins can see a list of all registered users and their roles.

