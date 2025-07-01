create database NMCNPM_Nhom7;
go

use NMCNPM_Nhom7;
go

create table tblRoles (
	iRoleID tinyint identity(1,1) primary key,  -- Mã quyền
	sRoleName nvarchar(50) unique not null		-- Tên quyền
)
go

create table tblEmployees (
	iEmployeeID int identity(1,1) primary key,  -- Mã nhân viên(PK)
	sFullName nvarchar(255) not null,		    -- Họ tên	
	bGender bit default 1,					    -- Giới tính
	dBirthDate date,						    -- Ngày sinh
	sPhone char(10) unique not null,			-- Số điện thoại
	sEmail varchar(255) unique null,			-- Email
	sCCCD char(12) unique not null,				-- Căn cước công dân
	sAddress nvarchar(255) null,				-- Địa chỉ
	sPasswordHash varchar(255) not null,		-- Mật khẩu đã mã hoá
	iRoleID tinyint not null,					-- Mã quyền
	sStatus NVARCHAR(10) CHECK (sStatus IN ('active', 'blocked')) DEFAULT 'active',  -- Trạng thái tài khoản

	constraint FK_Roles_iEmployeeID foreign key (iRoleID) references tblRoles(iRoleID)
)
go

create table tblCustomers (
	iCustomerID int identity(1,1) primary key,
	sFullName nvarchar(255) not null,
	sPhone char(10) unique not null,
	iLoyaltyPoints int default 0 
)
go

create table tblProductCategories (
	iCategoryID int identity(1,1) primary key,  -- Mã loại hàng
    sCategoryName nvarchar(255) not null		-- Tên loại hàng	
)
go

create table tblSuppliers (
	iSupplierID int identity(1,1) primary key,  -- Mã NCC
    sCompanyName nvarchar(255) not null,        -- Tên NCC
    sAddress nvarchar(255) null,                -- Địa chỉ
    sPhone char(10) unique null,			    -- SĐT
    sEmail varchar(255) unique null				-- Email
)
go

create table tblUnits (
	iUnitID int identity(1,1) primary key,
	sUnitName nvarchar(255) unique not null
)
go

create table tblProducts (
	iProductID int identity(1,1) primary key,  -- Mã sản phẩm(PK)
    sProductName nvarchar(255) ,			   -- Tên sản phẩm
	iCategoryID int,
    fPrice decimal(18,2),					   -- Đơn giá
    iQuantity int default 0,				   -- Số lượng
    iUnitID int,							   -- Mã đơn vị tính (FK from tblUnits)
    iSupplierID int							   -- Mã NCC (FK from tblSuppliers)

	constraint FK_Products_ProductCategories foreign key (iCategoryID) references tblProductCategories(iCategoryID),
	constraint FK_Units_iUnitID foreign key (iUnitID) references tblUnits(iUnitID),
	constraint FK_Suppliers_iSupplierID foreign key (iSupplierID) references tblSuppliers(iSupplierID)
)
go

create table tblDiscountedProducts (
    iDiscountID int identity(1,1) primary key,          -- Mã giảm giá
    iProductID int NOT NULL,                            -- Mã sản phẩm (FK)
    fDiscountPercent decimal(5,2) default 0,            -- Giảm theo %
    fDiscountAmount decimal(18,2) default 0,            -- Giảm theo số tiền
    dStartDate datetime NOT NULL,                       -- Ngày bắt đầu giảm giá
    dEndDate datetime NOT NULL,                         -- Ngày kết thúc giảm giá
    sDescription nvarchar(255) NULL,                    -- Ghi chú (tuỳ chọn)

    constraint FK_DiscountedProducts_Product foreign key (iProductID) references tblProducts(iProductID)
)
go

create table tblInvoices (
	idInvoiceID int identity(1,1) primary key,  -- Mã hóa đơn (PK)
    iEmployeeID int,							-- Mã nhân viên (FK from tblEmployees)
    iCustomerID int,							-- Mã khách hàng (FK from tblCustomers)
    dCreatedDate datetime,						-- Ngày lập
    fTotal decimal(18,2),						-- Tổng tiền
    fVAT DECIMAL(5, 2), 						-- VAT

	constraint FK_Invoices_Employee foreign key (iEmployeeID) references tblEmployees(iEmployeeID),
	constraint FK_Invoices_Customers foreign key (iCustomerID) references tblCustomers(iCustomerID)
)
go

create table tblInvoiceDetails (
	iInvoiceDetailID int identity(1,1) primary key,
	iInvoiceID int,  -- Mã hóa đơn (PK)
    iProductID int,							   -- Mã sản phẩm (FK from tblProducts)
    iQuantity int default 0,				   -- Số lượng
	fUnitPrice decimal(18,2),					   -- Đơn giá

	constraint FK_InvoiceDetail_Invoice foreign key (iInvoiceID) references tblInvoices(idInvoiceID),
    constraint FK_InvoiceDetail_Product foreign key (iProductID) references tblProducts(iProductID)
)
go

use NMCNPM_Nhom7;
go 

INSERT INTO tblRoles (sRoleName)
VALUES  
	('Admin'),
    ('User');
go