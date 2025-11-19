# 🔐 Employee Login System

A  Windows Forms application built with VB.NET and MySQL that demonstrates secure authentication, role-based access control, and employee management capabilities.

![VB.NET](https://img.shields.io/badge/VB.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)

## 📋 Table of Contents
- [Features](#features)
- [Screenshots](#screenshots)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Security Features](#security-features)
- [Contributing](#contributing)
- [License](#license)

## ✨ Features

### Authentication & Security
- ✅ Secure login system with MySQL database
- ✅ Parameterized SQL queries (SQL injection protection)
- ✅ Role-based access control (Admin/Employee)
- ✅ Session management
- ✅ Password strength indicator
- ✅ Account activation/deactivation

### Admin Dashboard
- 📊 Employee list with real-time search
- ➕ Create new employee accounts
- 👁️ View detailed employee information
- 📈 Statistics dashboard (total, active, roles)
- 🔄 Refresh and filter capabilities
- 🔍 Advanced search functionality

### Employee Dashboard
- 👤 Personal profile view
- 🔒 Change password functionality
- 📅 Last login tracking
- 🚪 Secure logout

## 📸 Screenshots

### Login Screen
```
![Screenshot](./assets/login.jpg).
![Screenshot](./assets/loginSuccess.JPG).
```

### Admin Dashboard
```
![Screenshot](./assets/adminPanel.jpg)
![Screenshot](./assets/adminPanel1.jpg)
```

### Employee Dashboard
```
![Screenshot](./assets/employeePanel.jpg)
![Screenshot](./assets/employeePanel1.jpg)
```

## 🛠️ Technologies Used

- **Frontend**: Windows Forms (.NET Framework 4.7.2+)
- **Backend Language**: Visual Basic .NET
- **Database**: MySQL 8.0+
- **Database Connector**: MySql.Data (NuGet)
- **IDE**: Visual Studio 2022 Community Edition

## 📦 Prerequisites

Before you begin, ensure you have installed:

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) (Community Edition or higher)
- [MySQL Server 8.0+](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) (optional, for database management)
- [.NET Framework 4.7.2 or higher](https://dotnet.microsoft.com/download/dotnet-framework)

## 🚀 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/employee-login-system.git
cd employee-login-system
```

### 2. Open in Visual Studio

1. Open Visual Studio 2022
2. File → Open → Project/Solution
3. Select `EmployeeLoginSystem.sln`

### 3. Restore NuGet Packages

Visual Studio should automatically restore packages. If not:

```bash
# In Visual Studio Package Manager Console:
Update-Package -reinstall
```

Or manually:
- Tools → NuGet Package Manager → Manage NuGet Packages for Solution
- Click "Restore" if prompted

## 💾 Database Setup

### 1. Create Database

Open MySQL Workbench and run:

```sql
CREATE DATABASE IF NOT EXISTS employee_login_system;
USE employee_login_system;

CREATE TABLE employees (
    employee_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    role ENUM('admin', 'employee') DEFAULT 'employee',
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    last_login TIMESTAMP NULL,
    INDEX idx_username (username),
    INDEX idx_email (email)
);
```

### 2. Insert Sample Data

```sql
INSERT INTO employees (username, password_hash, first_name, last_name, email, role) VALUES
('admin', 'admin123', 'System', 'Administrator', 'admin@company.com', 'admin'),
('jsmith', 'pass123', 'Jane', 'Smith', 'jane.smith@company.com', 'employee'),
('bjohnson', 'pass456', 'Bob', 'Johnson', 'bob.johnson@company.com', 'employee');
```

**⚠️ Note**: These are plain text passwords for development only. In production, use proper password hashing

## ⚙️ Configuration

### 1. Database Connection

1. Copy `AppConfig.example.vb` to `AppConfig.vb`
2. Open `AppConfig.vb`
3. Update the connection string:

```vb
Public Shared ReadOnly Property ConnectionString As String
    Get
        Return "Server=localhost;" &
               "Port=3306;" &
               "Database=employee_login_system;" &
               "Uid=root;" &
               "Pwd=YOUR_MYSQL_PASSWORD;" &
               "SslMode=Required;"
    End Get
End Property
```

**Replace:**
- `YOUR_MYSQL_PASSWORD` with your MySQL root password
- `localhost` with your MySQL server address (if different)
- `3306` with your MySQL port (if different)

### 2. Build the Project

```bash
# In Visual Studio:
Build → Rebuild Solution
# Or press: Ctrl + Shift + B
```

## 🎮 Usage

### Running the Application

1. Press **F5** in Visual Studio (or click Start)
2. The login form will appear

### Test Credentials

| Username | Password | Role | Access Level |
|----------|----------|------|--------------|
| `admin` | `admin123` | Admin | Full access to admin dashboard |
| `jsmith` | `pass123` | Employee | Employee dashboard only |
| `bjohnson` | `pass456` | Employee | Employee dashboard only |

### Admin Functions

1. **View All Employees**: See complete list with details
2. **Search Employees**: Real-time search by username, name, or email
3. **Add Employee**: Create new accounts with validation
4. **View Details**: See detailed employee information
5. **View Statistics**: Dashboard showing totals and breakdowns

### Employee Functions

1. **View Profile**: See personal information
2. **Change Password**: Update account password
3. **Logout**: Secure session termination

## 📁 Project Structure

```
EmployeeLoginSystem/
│
├── Forms/                      # User Interface
│   ├── LoginForm.vb           # Main login interface
│   ├── AdminDashboard.vb      # Admin control panel
│   ├── EmployeeDashboard.vb   # Employee portal
│   └── AddEmployeeForm.vb     # Employee creation form
│
├── Models/                     # Data Models
│   └── Employee.vb            # Employee entity class
│
├── DataAccess/                 # Database Layer
│   ├── DatabaseHelper.vb      # Connection management
│   └── EmployeeRepository.vb  # CRUD operations
│
├── Utils/                      # Utilities
│   ├── AppConfig.vb           # Configuration (not in repo)
│   ├── AppConfig.example.vb   # Config template
│   ├── CurrentUser.vb         # Session management
│   └── PasswordHelper.vb      # Password hashing utilities
│
└── Resources/                  # Assets (if any)
```

## 🔒 Security Features

This application implements several security best practices:

### ✅ Implemented
- **Parameterized Queries**: Prevents SQL injection attacks
- **Input Validation**: Client-side validation for all inputs
- **Duplicate Prevention**: Username and email uniqueness
- **Session Management**: Tracks logged-in users
- **Role-Based Access**: Different access levels for admin/employee
- **Connection String Security**: Credentials not committed to Git

### ⚠️ For Production (Not Yet Implemented)
- Password hashing (currently plain text for learning)
- SSL/TLS database connections
- Login attempt limiting
- Session timeout
- Audit logging
- Two-factor authentication
- Password reset functionality

## 🏗️ Architecture

This project follows the **Three-Tier Architecture** pattern:

1. **Presentation Layer** (Forms): User interface and user interaction
2. **Business Logic Layer** (Models, Utils): Application logic and validation
3. **Data Access Layer** (DataAccess): Database operations

### Design Patterns Used
- **Repository Pattern**: Centralized data access
- **Singleton Pattern**: CurrentUser session management
- **Factory Pattern**: Database connection creation

## 🐛 Known Issues

- Password are stored as plain text (for educational purposes)
- No password recovery mechanism
- Limited error logging
- No email notifications

See [Issues](https://github.com/osha-san/employee-login-system/issues) for more.

## 🚧 Roadmap

- [ ] Implement BCrypt password hashing
- [ ] Add password reset functionality
- [ ] Implement activity audit logs
- [ ] Add email notifications
- [ ] Export employee list to Excel/PDF
- [ ] Add employee photo upload
- [ ] Implement department management
- [ ] Add reporting dashboard
- [ ] Create user manual

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Your Name**
- GitHub: [@osha-san](https://github.com/osha-san)
- LinkedIn: [Your LinkedIn](https://linkedin.com/in/joshua-santiago-b6670b18a/)
- Email: joshuasantiago17.22@gmail.com

## 🙏 Acknowledgments

- Inspired by real-world employee management systems
- Built as a learning project for VB.NET and database integration
- Thanks to the Visual Studio and MySQL communities


---

**⭐ If you find this project useful, please consider giving it a star!**

---

## 🔧 Troubleshooting

### Database Connection Error
- Verify MySQL is running
- Check credentials in `AppConfig.vb`
- Ensure database exists

### Build Errors
- Restore NuGet packages
- Check .NET Framework version
- Rebuild solution

### Login Fails
- Verify test data is in database
- Check for typos in username/password
- Ensure account is active (`is_active = 1`)

---

*Last Updated: November 2025*
