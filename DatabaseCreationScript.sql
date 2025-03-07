USE [master]
GO
/****** Object:  Database [PruebaTecnica]    ******/
CREATE DATABASE [PruebaTecnica] 
GO
USE [PruebaTecnica]
GO
/****** Object:  Table [dbo].[Factura]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura](
	[Id] [bigint] NOT NULL,
	[NumeroFactura] [varchar](100) NOT NULL,
	[NumeroDocumento] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Monto] [Int] NOT NULL
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [master]
GO
ALTER DATABASE [PruebaTecnica] SET  READ_WRITE 
GO

/*Application Login and user creation*/
USE [master]
GO

CREATE LOGIN [PruebaTecnica] WITH PASSWORD='123456', DEFAULT_DATABASE=[PruebaTecnica], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [master]
GO
ALTER LOGIN [PruebaTecnica] WITH PASSWORD=N'Zemog@!P@ssword'
GO
USE [PruebaTecnica]
GO
CREATE USER [PruebaTecnica] FOR LOGIN [PruebaTecnica]
GO
USE [PruebaTecnica]
GO
ALTER USER [PruebaTecnica] WITH DEFAULT_SCHEMA=[dbo]
GO
USE [PruebaTecnica]
GO
ALTER ROLE [db_owner] ADD MEMBER [PruebaTecnica]
GO

/*End of script*/
