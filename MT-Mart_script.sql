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
    sProductName nvarchar(255),				   -- Tên sản phẩm
	iCategoryID int,								

	constraint FK_Products_ProductCategories foreign key (iCategoryID) references tblProductCategories(iCategoryID)
)
go

create table tblProductDetails (
	iProductDetailID int identity(1,1) primary key,
    iProductID int not null,
    iUnitID int,							   -- Mã đơn vị tính (FK from tblUnits)
    iSupplierID int,							   -- Mã NCC (FK from tblSuppliers)
    fImportPrice decimal(18,2),
	fSellPrice decimal(18,2) default 0,
    iQuantity int default 0,				   -- Số lượng

    constraint FK_ProductDetails_Products foreign key (iProductID) references tblProducts(iProductID),
    constraint FK_ProductDetails_Suppliers foreign key (iSupplierID) references tblSuppliers(iSupplierID),
    constraint FK_ProductDetails_Units foreign key (iUnitID) references tblUnits(iUnitID),
    constraint UQ_ProductSupplierUnit unique (iProductID, iSupplierID, iUnitID)
)
go

create table tblDiscountedProducts (
    iDiscountID int identity(1,1) primary key,          -- Mã giảm giá
    iProductID int NOT NULL,                            -- Mã sản phẩm (FK)
    fDiscountPercent decimal(4,2) default 0,            -- Giảm theo %
    fDiscountAmount decimal(18,2) default 0,            -- Giảm theo số tiền
    dStartDate datetime NOT NULL,                       -- Ngày bắt đầu giảm giá
    dEndDate datetime NOT NULL,                         -- Ngày kết thúc giảm giá
    sDescription nvarchar(255) NULL,                    -- Ghi chú (tuỳ chọn)

    constraint FK_DiscountedProducts_Product foreign key (iProductID) references tblProducts(iProductID)
)
go

create table tblInvoices (
	iInvoiceID int identity(1,1) primary key,   
    iEmployeeID int,							
    iCustomerID int,							
    dCreatedDate datetime,						
    fTotal decimal(18,2),							
    fVAT DECIMAL(5, 2) check (fVAT between 0 and 100), 						

	constraint FK_Invoices_Employee foreign key (iEmployeeID) references tblEmployees(iEmployeeID),
	constraint FK_Invoices_Customers foreign key (iCustomerID) references tblCustomers(iCustomerID)
)
go

create table tblInvoiceDetails (
	iInvoiceDetailID int identity(1,1) primary key,
	iInvoiceID int, 
    iProductID int,							   
    iQuantity int default 0,				   
	fUnitPrice decimal(18,2),					  

	constraint FK_InvoiceDetail_Invoice foreign key (iInvoiceID) references tblInvoices(iInvoiceID),
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


insert into tblSuppliers (sCompanyName, sAddress, sPhone, sEmail) values
(N'Công ty TNHH Thực Phẩm Ánh Dương', N'123 Trần Hưng Đạo, Hà Nội', '0901000001', 'anhduong@sup.vn'),
(N'Công ty Cổ phần Nước Giải Khát Hương Việt', N'45 Nguyễn Huệ, TP.HCM', '0901000002', 'huongviet@sup.vn'),
(N'Công ty TNHH TM-SX Đồ Hộp Đại Phát', N'98 Lý Thường Kiệt, Đà Nẵng', '0901000003', 'daiphat@sup.vn'),
(N'Công ty CP Sữa Việt', N'12 Pasteur, TP.HCM', '0901000004', 'suaviet@sup.vn'),
(N'Công ty TNHH Sản Xuất Bánh Kẹo Kim Ngọc', N'15 Hoàng Hoa Thám, Huế', '0901000005', 'kimngoc@sup.vn'),
(N'Công ty TNHH Hương Vị Quê', N'22 Trần Phú, Nha Trang', '0901000006', 'huongvi@sup.vn'),
(N'Công ty TNHH Rau Sạch Mekong', N'5 Nguyễn Văn Cừ, Cần Thơ', '0901000007', 'mehong@sup.vn'),
(N'Công ty TNHH Hóa Mỹ Phẩm Nhật Việt', N'8 Phạm Văn Đồng, TP.HCM', '0901000008', 'nhatviet@sup.vn'),
(N'Công ty TNHH Gia Vị Bốn Mùa', N'66 Lạc Long Quân, Hà Nội', '0901000009', 'bonmua@sup.vn'),
(N'Công ty CP Thực Phẩm Hữu Cơ', N'10 Hai Bà Trưng, Vũng Tàu', '0901000010', 'huuco@sup.vn'),
(N'Công ty TNHH Đồ Gia Dụng Toàn Cầu', N'200 CMT8, TP.HCM', '0901000011', 'toancau@sup.vn'),
(N'Công ty CP Sản Xuất Đồ Hộp An Tâm', N'88 Lê Văn Sỹ, TP.HCM', '0901000012', 'antam@sup.vn'),
(N'Công ty TNHH Thực Phẩm Đông Lạnh', N'36 Quang Trung, Hải Phòng', '0901000013', 'donglanh@sup.vn'),
(N'Công ty TNHH Bánh Kẹo Ngon Mỗi Ngày', N'77 Nguyễn Trãi, Hà Nội', '0901000014', 'ngonmoingay@sup.vn'),
(N'Công ty TNHH Phân Phối Sản Phẩm Sạch', N'99 Nguyễn Văn Linh, Đà Nẵng', '0901000015', 'sachviet@sup.vn');
go

insert into tblProductCategories (sCategoryName) values
(N'Nước giải khát'),
(N'Đồ ăn nhanh'),
(N'Gia vị'),
(N'Đồ hộp'),
(N'Rau củ quả'),
(N'Đồ gia dụng'),
(N'Bánh kẹo'),
(N'Thực phẩm đông lạnh'),
(N'Đồ dùng văn phòng'),
(N'Trang thiết bị y tế'),
(N'Mỹ phẩm');
go

insert into tblUnits (sUnitName) values
(N'Chai'),
(N'Hộp'),
(N'Gói'),
(N'Túi'),
(N'Cái'),
(N'Bịch'),
(N'Lon'),
(N'Bộ'),
(N'Thùng')
go
