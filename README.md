# MT Mart(Quản lý bán hàng) - ASP.NET Core MVC

## Yêu cầu hệ thống
- **.NET 9.0 hoặc mới hơn**
- **SQL Server**
- **Visual Studio 2022**

## Cài đặt và chạy dự án
### 1. Clone repository
```sh
git clone https://github.com/Rykrax/NMCNPM_Nhom7
cd NMCNPM_Nhom7
```
### 2. Cấu Hình Cơ Sở Dữ Liệu
Tạo Database trên SQL Server
Mở SQL Server Management Studio (SSMS) và đăng nhập vào SQL Server (nếu có).

Mở file script MT-Mart_script.sql hoặc chạy các lệnh CREATE TABLE theo mô hình dữ liệu của bạn.

### 3. Cấu hình `appsettings.json`
Trong thư mục **NMCNPM_Nhom7**, tạo tệp `appsettings.json` và thêm nội dung sau:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
Thay thế `YOUR_SERVER`, `YOUR_DATABASE`, `YOUR_USERNAME`, và `YOUR_PASSWORD` bằng thông tin SQL Server của bạn, nếu không đăng nhập thì xóa `User Id=YOUR_USERNAME;Password=YOUR_PASSWORD`.

### 4. Chạy ứng dụng
Nhấn `Ctrl + F5` để chạy dự án hoặc sử dụng lệnh:
```sh
dotnet run
```
