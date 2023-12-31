USE [ProductManagemt]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[User_name] [nvarchar](max) NOT NULL,
	[Avartar] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[ResetPasswordToken] [nvarchar](max) NULL,
	[ResetPasswordTokenExpiry] [datetime2](7) NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
	[DecentralizationId] [int] NOT NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[decentralizations]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[decentralizations](
	[DecentralizationId] [int] IDENTITY(1,1) NOT NULL,
	[Authorrity_name] [nvarchar](max) NOT NULL,
	[Create_at] [datetime2](7) NOT NULL,
	[Update_at] [datetime2](7) NULL,
 CONSTRAINT [PK_decentralizations] PRIMARY KEY CLUSTERED 
(
	[DecentralizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_Statuses]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_Statuses](
	[Order_StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Status_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_order_Statuses] PRIMARY KEY CLUSTERED 
(
	[Order_StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Orginal_Price] [float] NOT NULL,
	[Actual_Price] [float] NOT NULL,
	[Full_name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
	[PaymentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Order_StatusId] [int] NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders_detail]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders_detail](
	[Order_DetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Price_total] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_orders_detail] PRIMARY KEY CLUSTERED 
(
	[Order_DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Payment_method] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_Images]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_Images](
	[Product_ImageId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Image_product] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_product_Images] PRIMARY KEY CLUSTERED 
(
	[Product_ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_Reviews]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_Reviews](
	[Product_ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[Content_rated] [nvarchar](max) NOT NULL,
	[Point_evaluation] [int] NOT NULL,
	[Content_seen] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_product_Reviews] PRIMARY KEY CLUSTERED 
(
	[Product_ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_Types]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_Types](
	[Product_TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name_product_type] [nvarchar](max) NOT NULL,
	[Image_type_product] [nvarchar](max) NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
 CONSTRAINT [PK_product_Types] PRIMARY KEY CLUSTERED 
(
	[Product_TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name_product] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Avartar_image_product] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Discount] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[number_of_views] [int] NULL,
	[Create_at] [datetime2](7) NOT NULL,
	[Update_at] [datetime2](7) NULL,
	[Product_TypeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 8/9/2023 11:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[User_name] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Created_at] [datetime2](7) NOT NULL,
	[Updated_at] [datetime2](7) NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230811043419_data', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230814045106_data1', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230814063745_data2', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230814073903_data1', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230815034941_data2', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230815040502_data2', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230815041412_data2', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230829084631_data3', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230830020956_addid', N'7.0.10')
GO
SET IDENTITY_INSERT [dbo].[accounts] ON 

INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (2, N'annv', N'https://cdn-icons-png.flaticon.com/512/6596/6596121.png', N'123456789', 1, N'88EA73541223E33BDA1CE2739FEC68F4B4F7CBAB1F9B7D31B115A856254946FC3B4AB5922638827B9FD21FD12FB75C5E8082A304E9ADC01903C96334789E893F', CAST(N'2023-09-07T09:27:56.6657223' AS DateTime2), CAST(N'2023-08-15T11:05:43.5700660' AS DateTime2), CAST(N'2023-08-15T16:20:54.3237058' AS DateTime2), 1)
INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (3, N'binhht', N'https://cdn-icons-png.flaticon.com/512/6596/6596121.png', N'987654321', 0, NULL, NULL, CAST(N'2023-08-15T11:09:11.5600776' AS DateTime2), CAST(N'2023-09-06T10:25:54.6873995' AS DateTime2), 1)
INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (5, N'caott', N'', N'9232443', 1, NULL, NULL, CAST(N'2023-08-15T11:14:58.3466809' AS DateTime2), NULL, 11)
INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (7, N'dungnn', N'', N'cnv2344', 1, NULL, NULL, CAST(N'2023-08-15T11:17:56.8894703' AS DateTime2), NULL, 1)
INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (8, N'datnt', N'', N'dat12345', 0, NULL, NULL, CAST(N'2023-08-15T21:13:17.1087867' AS DateTime2), NULL, 1)
INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (14, N'aods', N'', N'1233987', 1, NULL, NULL, CAST(N'2023-08-18T10:45:34.5431799' AS DateTime2), NULL, 1)
INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (15, N'nhasds', N'', N'123abc', 1, NULL, NULL, CAST(N'2023-08-21T09:55:03.0979686' AS DateTime2), NULL, 2)
INSERT [dbo].[accounts] ([AccountId], [User_name], [Avartar], [Password], [Status], [ResetPasswordToken], [ResetPasswordTokenExpiry], [Created_at], [Updated_at], [DecentralizationId]) VALUES (16, N'nhasds', N'', N'123abc', 1, NULL, NULL, CAST(N'2023-08-25T11:44:16.4780206' AS DateTime2), NULL, 2)
SET IDENTITY_INSERT [dbo].[accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[decentralizations] ON 

INSERT [dbo].[decentralizations] ([DecentralizationId], [Authorrity_name], [Create_at], [Update_at]) VALUES (1, N'Admin', CAST(N'2023-08-14T23:16:52.4093245' AS DateTime2), CAST(N'2023-08-25T11:27:26.1164184' AS DateTime2))
INSERT [dbo].[decentralizations] ([DecentralizationId], [Authorrity_name], [Create_at], [Update_at]) VALUES (2, N'Seller', CAST(N'2023-08-15T10:31:25.2880334' AS DateTime2), NULL)
INSERT [dbo].[decentralizations] ([DecentralizationId], [Authorrity_name], [Create_at], [Update_at]) VALUES (11, N'User', CAST(N'2023-09-06T10:54:01.6791712' AS DateTime2), NULL)
INSERT [dbo].[decentralizations] ([DecentralizationId], [Authorrity_name], [Create_at], [Update_at]) VALUES (12, N'Shipper', CAST(N'2023-09-06T10:54:41.7679513' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[decentralizations] OFF
GO
SET IDENTITY_INSERT [dbo].[order_Statuses] ON 

INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (1, N'New(wait for confirmation)')
INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (2, N'The seller is preparing the goods')
INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (3, N'Delivered to the carrier')
INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (4, N'Delivering')
INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (5, N'Completed')
INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (6, N'Confirm receipt of goods')
INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (7, N'Evaluated')
INSERT [dbo].[order_Statuses] ([Order_StatusId], [Status_name]) VALUES (8, N'Failed')
SET IDENTITY_INSERT [dbo].[order_Statuses] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (2, 740000, 698000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-08-16T12:38:32.7839892' AS DateTime2), CAST(N'2023-08-16T14:46:54.3711043' AS DateTime2), 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (5, 140000, 98000, N'Nguyen Van An', N'anv@gmail.com', N'0123456789', N'Ha Noi', CAST(N'2023-08-16T15:36:50.2049999' AS DateTime2), CAST(N'2023-08-29T10:53:54.3457994' AS DateTime2), 1, 4, 2)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (6, 140000, 98000, N'Nguyen Van An', N'anv@gmail.com', N'0123456789', N'Ha Noi', CAST(N'2023-08-16T15:40:40.4214806' AS DateTime2), NULL, 1, 4, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (7, 200000, 200000, N'Nguyen Van An', N'anv@gmail.com', N'0123456789', N'Ha Noi', CAST(N'2023-08-16T15:40:46.5401639' AS DateTime2), CAST(N'2023-08-16T15:50:34.5112787' AS DateTime2), 1, 4, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (8, 600000, 600000, N'Ho Thi Binh', N'binhht@gmail.com', N'0987612534', N'Thai Binh', CAST(N'2023-08-21T10:56:46.3450498' AS DateTime2), NULL, 1, 5, 6)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (9, 600000, 600000, N'Sang Mas', N'dgdfh@gmail.com', N'0987612534', N'Hai Duong', CAST(N'2023-08-29T10:12:38.2342437' AS DateTime2), NULL, 1, 19, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (10, 600000, 600000, N'nhasds', N'dgdfh@gmail.com', N'0987612534', N'Hai Duong', CAST(N'2023-08-29T10:19:26.6016485' AS DateTime2), NULL, 2, 18, 2)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (11, 600000, 600000, N'Nguyen Van C', N'cnv@gmail.com', N'0987612534', N'Hai Duong', CAST(N'2023-08-29T16:01:24.3698439' AS DateTime2), NULL, 2, 7, 2)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (12, 600000, 600000, N'Nguyen Van C', N'cnv@gmail.com', N'0987612534', N'Hai Duong', CAST(N'2023-09-06T11:09:34.9479037' AS DateTime2), NULL, 2, 7, 2)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (13, 420000, 294000, N'Nguyen Van C', N'cnv@gmail.com', N'0987612534', N'Hai Duong', CAST(N'2023-09-06T11:10:38.9010350' AS DateTime2), NULL, 2, 7, 2)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (14, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T16:32:37.7085917' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (15, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T16:33:30.5766985' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (16, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T16:35:16.4772913' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (17, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T16:37:22.6290913' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (18, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T16:38:48.9254974' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (19, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T22:50:32.5304840' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (20, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T22:52:34.7987734' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (21, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-07T22:54:13.4366942' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (22, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-08T10:42:15.9489468' AS DateTime2), NULL, 1, 5, 1)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (23, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-08T10:59:47.5461683' AS DateTime2), NULL, 2, 5, 2)
INSERT [dbo].[orders] ([OrderId], [Orginal_Price], [Actual_Price], [Full_name], [Email], [Phone], [Address], [Created_at], [Updated_at], [PaymentId], [UserId], [Order_StatusId]) VALUES (24, 600000, 600000, N'Ho Thi Binh', N'romes57840@horsgit.com', N'0987612534', N'Thai Binh', CAST(N'2023-09-08T11:10:36.5602417' AS DateTime2), NULL, 2, 5, 2)
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[orders_detail] ON 

INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (2, 2, 600000, 3, CAST(N'2023-08-16T12:38:38.3848947' AS DateTime2), CAST(N'2023-08-16T14:46:54.1302402' AS DateTime2), 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (3, 2, 140000, 1, CAST(N'2023-08-16T14:13:41.9185335' AS DateTime2), CAST(N'2023-08-16T14:46:54.3493772' AS DateTime2), 7)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (7, 5, 140000, 1, CAST(N'2023-08-16T15:36:50.4663884' AS DateTime2), NULL, 7)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (9, 6, 140000, 1, CAST(N'2023-08-16T15:40:40.5793805' AS DateTime2), NULL, 7)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (10, 7, 200000, 1, CAST(N'2023-08-16T15:40:46.5831810' AS DateTime2), CAST(N'2023-08-16T15:50:34.1968609' AS DateTime2), 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (13, 8, 600000, 3, CAST(N'2023-08-21T10:56:51.0129195' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (14, 9, 600000, 3, CAST(N'2023-08-29T10:12:44.1238285' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (15, 10, 600000, 3, CAST(N'2023-08-29T10:19:31.9971190' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (16, 11, 600000, 3, CAST(N'2023-08-29T16:01:28.0660817' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (17, 12, 600000, 3, CAST(N'2023-09-06T11:09:35.9120227' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (18, 13, 420000, 3, CAST(N'2023-09-06T11:10:38.9232261' AS DateTime2), NULL, 7)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (19, 14, 600000, 3, CAST(N'2023-09-07T16:32:41.4525574' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (20, 15, 600000, 3, CAST(N'2023-09-07T16:33:30.6210416' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (21, 16, 600000, 3, CAST(N'2023-09-07T16:35:20.4411504' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (22, 17, 600000, 3, CAST(N'2023-09-07T16:37:24.5490071' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (23, 18, 600000, 3, CAST(N'2023-09-07T16:38:52.5213631' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (24, 19, 600000, 3, CAST(N'2023-09-07T22:50:47.5754106' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (25, 20, 600000, 3, CAST(N'2023-09-07T22:52:38.4264365' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (26, 21, 600000, 3, CAST(N'2023-09-07T22:54:16.0023108' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (27, 22, 600000, 3, CAST(N'2023-09-08T10:42:19.7131703' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (28, 23, 600000, 3, CAST(N'2023-09-08T10:59:51.8617790' AS DateTime2), NULL, 8)
INSERT [dbo].[orders_detail] ([Order_DetailId], [OrderId], [Price_total], [Quantity], [Created_at], [Updated_at], [ProductId]) VALUES (29, 24, 600000, 3, CAST(N'2023-09-08T11:10:37.0699635' AS DateTime2), NULL, 8)
SET IDENTITY_INSERT [dbo].[orders_detail] OFF
GO
SET IDENTITY_INSERT [dbo].[payment] ON 

INSERT [dbo].[payment] ([PaymentId], [Payment_method], [Status], [Created_at], [Updated_at]) VALUES (1, N'cash', 1, CAST(N'2023-08-15T21:14:51.7252138' AS DateTime2), CAST(N'2023-08-15T21:34:15.8783927' AS DateTime2))
INSERT [dbo].[payment] ([PaymentId], [Payment_method], [Status], [Created_at], [Updated_at]) VALUES (2, N'MoMo', 1, CAST(N'2023-08-15T21:20:01.4458936' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[payment] OFF
GO
SET IDENTITY_INSERT [dbo].[product_Images] ON 

INSERT [dbo].[product_Images] ([Product_ImageId], [Title], [Image_product], [Status], [Created_at], [Updated_at], [ProductId]) VALUES (7, N'rice1', N'rice1.png', 1, CAST(N'2023-08-16T11:04:27.1116968' AS DateTime2), CAST(N'2023-08-16T12:47:58.9011422' AS DateTime2), 7)
INSERT [dbo].[product_Images] ([Product_ImageId], [Title], [Image_product], [Status], [Created_at], [Updated_at], [ProductId]) VALUES (11, N'rice2', N'rice2.png', 0, CAST(N'2023-08-16T11:35:49.1238381' AS DateTime2), CAST(N'2023-08-16T12:47:58.9065073' AS DateTime2), 7)
INSERT [dbo].[product_Images] ([Product_ImageId], [Title], [Image_product], [Status], [Created_at], [Updated_at], [ProductId]) VALUES (12, N'Fish Images', N'fish1.png', 1, CAST(N'2023-08-16T11:42:43.3469427' AS DateTime2), NULL, 8)
INSERT [dbo].[product_Images] ([Product_ImageId], [Title], [Image_product], [Status], [Created_at], [Updated_at], [ProductId]) VALUES (17, N'Fish Images', N'fish2.png', 1, CAST(N'2023-08-18T10:49:29.7157403' AS DateTime2), NULL, 13)
INSERT [dbo].[product_Images] ([Product_ImageId], [Title], [Image_product], [Status], [Created_at], [Updated_at], [ProductId]) VALUES (19, N'fish pink', N'fish_pink.png', 1, CAST(N'2023-09-06T10:49:51.9647185' AS DateTime2), CAST(N'2023-09-06T10:50:26.5062039' AS DateTime2), 15)
INSERT [dbo].[product_Images] ([Product_ImageId], [Title], [Image_product], [Status], [Created_at], [Updated_at], [ProductId]) VALUES (20, N'fish pink', N'fish_pink_2.png', 0, CAST(N'2023-09-06T10:50:26.5371130' AS DateTime2), NULL, 15)
INSERT [dbo].[product_Images] ([Product_ImageId], [Title], [Image_product], [Status], [Created_at], [Updated_at], [ProductId]) VALUES (21, N'Fish Images', N'fish1.png', 0, CAST(N'2023-09-06T10:52:26.0231673' AS DateTime2), NULL, 16)
SET IDENTITY_INSERT [dbo].[product_Images] OFF
GO
SET IDENTITY_INSERT [dbo].[product_Reviews] ON 

INSERT [dbo].[product_Reviews] ([Product_ReviewId], [Content_rated], [Point_evaluation], [Content_seen], [Status], [Created_at], [Updated_at], [UserId], [ProductId]) VALUES (5, N'Bad', 0, N'Review Rice1', 1, CAST(N'2023-08-16T11:04:27.7220118' AS DateTime2), CAST(N'2023-08-16T12:47:58.9100887' AS DateTime2), 4, 7)
INSERT [dbo].[product_Reviews] ([Product_ReviewId], [Content_rated], [Point_evaluation], [Content_seen], [Status], [Created_at], [Updated_at], [UserId], [ProductId]) VALUES (6, N'Good', 0, N'Review Rice2', 1, CAST(N'2023-08-16T11:35:49.1454010' AS DateTime2), CAST(N'2023-08-16T12:47:58.9131172' AS DateTime2), 5, 7)
INSERT [dbo].[product_Reviews] ([Product_ReviewId], [Content_rated], [Point_evaluation], [Content_seen], [Status], [Created_at], [Updated_at], [UserId], [ProductId]) VALUES (7, N'good', 0, N'Review Fish', 0, CAST(N'2023-08-16T11:42:43.3618312' AS DateTime2), NULL, 5, 8)
INSERT [dbo].[product_Reviews] ([Product_ReviewId], [Content_rated], [Point_evaluation], [Content_seen], [Status], [Created_at], [Updated_at], [UserId], [ProductId]) VALUES (12, N'good', 0, N'Review Fish', 0, CAST(N'2023-08-18T10:49:29.8665942' AS DateTime2), NULL, 5, 13)
INSERT [dbo].[product_Reviews] ([Product_ReviewId], [Content_rated], [Point_evaluation], [Content_seen], [Status], [Created_at], [Updated_at], [UserId], [ProductId]) VALUES (13, N'goood', 100, N'good rice', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 5, 8)
SET IDENTITY_INSERT [dbo].[product_Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[product_Types] ON 

INSERT [dbo].[product_Types] ([Product_TypeId], [Name_product_type], [Image_type_product], [Created_at], [Updated_at]) VALUES (2, N'food', N'foodVN.png', CAST(N'2023-08-16T09:51:59.3747265' AS DateTime2), CAST(N'2023-08-16T09:55:49.7772910' AS DateTime2))
INSERT [dbo].[product_Types] ([Product_TypeId], [Name_product_type], [Image_type_product], [Created_at], [Updated_at]) VALUES (3, N'clothes', N'clothes.png', CAST(N'2023-08-16T09:56:38.4200248' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[product_Types] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([ProductId], [Name_product], [Price], [Quantity], [Avartar_image_product], [Title], [Discount], [Status], [number_of_views], [Create_at], [Update_at], [Product_TypeId], [UserId]) VALUES (7, N'rice', 140000, 97, N'rice.png', N'Rice', 30, 1, 2, CAST(N'2023-08-16T11:04:23.5765576' AS DateTime2), CAST(N'2023-08-16T12:47:58.9353008' AS DateTime2), 2, 4)
INSERT [dbo].[products] ([ProductId], [Name_product], [Price], [Quantity], [Avartar_image_product], [Title], [Discount], [Status], [number_of_views], [Create_at], [Update_at], [Product_TypeId], [UserId]) VALUES (8, N'Fish1', 200000, 61, N'fish.png', N'Fish', 0, 0, 0, CAST(N'2023-08-16T11:42:43.2181838' AS DateTime2), NULL, 2, 5)
INSERT [dbo].[products] ([ProductId], [Name_product], [Price], [Quantity], [Avartar_image_product], [Title], [Discount], [Status], [number_of_views], [Create_at], [Update_at], [Product_TypeId], [UserId]) VALUES (13, N'Fish2', 200000, 100, N'fish.png', N'Fish', 0, 0, 0, CAST(N'2023-08-18T10:49:29.6538258' AS DateTime2), NULL, 2, 7)
INSERT [dbo].[products] ([ProductId], [Name_product], [Price], [Quantity], [Avartar_image_product], [Title], [Discount], [Status], [number_of_views], [Create_at], [Update_at], [Product_TypeId], [UserId]) VALUES (15, N'Fish3', 210000, 100, N'fish3.png', N'Fish', 0, 1, 0, CAST(N'2023-09-06T10:49:51.7242496' AS DateTime2), CAST(N'2023-09-06T10:50:26.5659832' AS DateTime2), 2, 7)
INSERT [dbo].[products] ([ProductId], [Name_product], [Price], [Quantity], [Avartar_image_product], [Title], [Discount], [Status], [number_of_views], [Create_at], [Update_at], [Product_TypeId], [UserId]) VALUES (16, N'Fish', 200000, 0, N'fish.png', N'Fish', 0, 0, NULL, CAST(N'2023-09-06T10:52:26.0053340' AS DateTime2), NULL, 2, 5)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (4, N'Nguyen Van An', N'0123456789', N'annv@gmail.com', N'Ha Noi', CAST(N'2023-08-15T11:05:43.5700660' AS DateTime2), CAST(N'2023-08-15T16:20:54.5053505' AS DateTime2), 2)
INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (5, N'Ho Thi Binh', N'0987612534', N'romes57840@horsgit.com', N'Thai Binh', CAST(N'2023-08-15T11:09:11.5600776' AS DateTime2), CAST(N'2023-09-06T10:25:55.1804771' AS DateTime2), 3)
INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (7, N'Nguyen Van C', N'0987612534', N'cnv@gmail.com', N'Hai Duong', CAST(N'2023-08-15T11:14:58.3466809' AS DateTime2), NULL, 5)
INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (10, N'Nguyen Van D', N'0987612534', N'dnv@gmail.com', N'Hai Duong', CAST(N'2023-08-15T11:17:58.7504496' AS DateTime2), NULL, 7)
INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (11, N'Nguyen Tien Dat', N'0987612543', N'datnt@gmail.com', N'Hoa Binh', CAST(N'2023-08-15T21:13:19.4016043' AS DateTime2), NULL, 8)
INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (17, N'Ai', N'0987612534', N'dnv@gmail.com', N'Hai Duong', CAST(N'2023-08-18T10:45:34.7960457' AS DateTime2), NULL, 14)
INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (18, N'nhasds', N'0987612534', N'dgdfh@gmail.com', N'Hai Duong', CAST(N'2023-08-21T09:55:03.4716537' AS DateTime2), NULL, 15)
INSERT [dbo].[users] ([UserId], [User_name], [Phone], [Email], [Address], [Created_at], [Updated_at], [AccountId]) VALUES (19, N'Sang Mas', N'0987612534', N'dgd@gmail.com', N'Hai Duong', CAST(N'2023-08-25T11:44:18.3508274' AS DateTime2), NULL, 16)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[products] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[products] ADD  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Created_at]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_decentralizations_DecentralizationId] FOREIGN KEY([DecentralizationId])
REFERENCES [dbo].[decentralizations] ([DecentralizationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_decentralizations_DecentralizationId]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_order_Statuses_Order_StatusId] FOREIGN KEY([Order_StatusId])
REFERENCES [dbo].[order_Statuses] ([Order_StatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_order_Statuses_Order_StatusId]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_payment_PaymentId] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[payment] ([PaymentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_payment_PaymentId]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_users_UserId]
GO
ALTER TABLE [dbo].[orders_detail]  WITH CHECK ADD  CONSTRAINT [FK_orders_detail_orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orders_detail] CHECK CONSTRAINT [FK_orders_detail_orders_OrderId]
GO
ALTER TABLE [dbo].[orders_detail]  WITH CHECK ADD  CONSTRAINT [FK_orders_detail_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orders_detail] CHECK CONSTRAINT [FK_orders_detail_products_ProductId]
GO
ALTER TABLE [dbo].[product_Images]  WITH CHECK ADD  CONSTRAINT [FK_product_Images_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[product_Images] CHECK CONSTRAINT [FK_product_Images_products_ProductId]
GO
ALTER TABLE [dbo].[product_Reviews]  WITH CHECK ADD  CONSTRAINT [FK_product_Reviews_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[product_Reviews] CHECK CONSTRAINT [FK_product_Reviews_products_ProductId]
GO
ALTER TABLE [dbo].[product_Reviews]  WITH CHECK ADD  CONSTRAINT [FK_product_Reviews_users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[product_Reviews] CHECK CONSTRAINT [FK_product_Reviews_users_UserId]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[accounts] ([AccountId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_accounts_AccountId]
GO
