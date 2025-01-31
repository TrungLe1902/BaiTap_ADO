USE [master]
GO
/****** Object:  Database [ShopDB]    Script Date: 7/15/2024 7:54:57 AM ******/
CREATE DATABASE [ShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopDB', N'ON'
GO
ALTER DATABASE [ShopDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopDB]
GO
/****** Object:  Table [dbo].[Atribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atribute](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttrName] [nvarchar](50) NULL,
	[AttrValue] [nvarchar](50) NULL,
	[GROUPID] [int] NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupAttribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAttribute](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttibute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttibute](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[AttrubuteID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAtribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAtribute]
    @ID INT
AS
BEGIN
    DELETE FROM dbo.Atribute
    WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteGroupAttribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteGroupAttribute]
    @GroupID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM GroupAttribute WHERE ID = @GroupID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
    @ProductID INT
AS
BEGIN
  
    DELETE FROM Products WHERE ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductAttribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProductAttribute]
    @ID INT
  
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM ProductAttribute
    WHERE ID = @ID;
     
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsInfo]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductsInfo]
AS
BEGIN
    SELECT 
        p.ProductID,
        p.Name AS ProductName,
        a.ID AS AttributeID,
        a.AttrName,
        a.AttrValue,
        a.GROUPID,
        a.Price AS AttributePrice,
        ga.Name AS GroupName,
        ga.Price AS GroupPrice
    FROM 
        Products p
        INNER JOIN ProductAttibute pa ON p.ProductID = pa.ProductID
        INNER JOIN Atribute a ON pa.AttrubuteID = a.ID
        INNER JOIN GroupAttribute ga ON a.GROUPID = ga.ID
		
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductAttributes]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductAttributes]
AS
BEGIN
    SELECT 
        p.ProductID,
        p.Name AS ProductName,
        a.ID AS AttributeID,
        a.AttrName,
        a.AttrValue,
        a.GROUPID,
        a.Price AS AttributePrice
    FROM 
        Products p
        INNER JOIN ProductAttibute pa ON p.ProductID = pa.ProductID
        INNER JOIN Atribute a ON pa.AttrubuteID = a.ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[KiemTraGroupAttributeTonTai]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KiemTraGroupAttributeTonTai]
    @GroupID INT,
    @Exists BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Exists = CASE WHEN EXISTS (
        SELECT 1 FROM GroupAttribute 
        WHERE ID = @GroupID
    ) THEN 1 ELSE 0 END;
END
GO
/****** Object:  StoredProcedure [dbo].[KiemTraProductAttributeTonTai]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KiemTraProductAttributeTonTai]
    @ProductID INT,
    @AttributeID INT,
    @Exists BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Exists = CASE WHEN EXISTS (
        SELECT 1 FROM ProductAttribute 
        WHERE ProductID = @ProductID AND AttributeID = @AttributeID
    ) THEN 1 ELSE 0 END;
END
GO
/****** Object:  StoredProcedure [dbo].[KiemTraSanPhamTonTai]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KiemTraSanPhamTonTai]
    @ProductID INT,
    @Exists BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Exists = CASE WHEN EXISTS (SELECT 1 FROM Products WHERE ProductID = @ProductID) THEN 1 ELSE 0 END;
END
GO
/****** Object:  StoredProcedure [dbo].[KiemTraThuocTinhTonTai]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KiemTraThuocTinhTonTai]
    @AttributeID INT,
    @Exists BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Exists = CASE WHEN EXISTS (SELECT 1 FROM Attribute WHERE ID = @AttributeID) THEN 1 ELSE 0 END;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayGiaGroup]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_LayGiaGroup]
    @GroupID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Price FROM GroupAttribute WHERE ID = @GroupID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemAtribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemAtribute]
    @AttrName NVARCHAR(100),
    @AttrValue NVARCHAR(100),
    @GroupID INT,
    @Price INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Atribute (AttrName, AttrValue, GROUPID, Price) OUTPUT INSERTED.ID VALUES (@AttrName, @AttrValue, @GroupID, @Price);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemGroupAttribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemGroupAttribute]
    @Name NVARCHAR(100),
    @Price INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO GroupAttribute (Name, Price) VALUES (@Name, @Price);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemProductAttribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemProductAttribute]
    @ProductID INT,
    @AttributeID INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ProductAttibute (ProductID, AttrubuteID) VALUES (@ProductID, @AttributeID);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemProducts]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemProducts]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Products (Name) OUTPUT INSERTED.ProductID VALUES (@Name);
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAtribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Sua Atribute
CREATE PROCEDURE [dbo].[UpdateAtribute]
    @ProductID INT,
    @AttributeID INT,
    @NewAttrName NVARCHAR(100),
    @NewAttrValue NVARCHAR(100),
    @NewPrice INT
AS
BEGIN
    UPDATE Atribute
    SET AttrName = @NewAttrName, AttrValue = @NewAttrValue, Price = @NewPrice
    WHERE ID = (SELECT AttrubuteID FROM ProductAttibute WHERE ProductID = @ProductID AND AttrubuteID = @AttributeID);
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateGroupAttribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Sua GroupAttribute
CREATE PROCEDURE [dbo].[UpdateGroupAttribute]
    @GroupID INT,
    @NewName NVARCHAR(100),
    @NewPrice INT
AS
BEGIN
    UPDATE GroupAttribute
    SET Name = @NewName, Price = @NewPrice
    WHERE ID = @GroupID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Sua Product
CREATE PROCEDURE [dbo].[UpdateProduct]
    @ProductID INT,
    @NewName NVARCHAR(100)
AS
BEGIN
    UPDATE Products
    SET Name = @NewName
    WHERE ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductAttribute]    Script Date: 7/15/2024 7:54:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Sua ProductAttribute
CREATE PROCEDURE [dbo].[UpdateProductAttribute]
    @ProductID INT,
    @AttributeID INT,
    @NewProductID INT,
    @NewAttributeID INT
AS
BEGIN
    UPDATE ProductAttibute
    SET ProductID = @NewProductID, AttrubuteID = @NewAttributeID
    WHERE ProductID = @ProductID AND AttrubuteID = @AttributeID;
END
GO
USE [master]
GO
ALTER DATABASE [ShopDB] SET  READ_WRITE 
GO
