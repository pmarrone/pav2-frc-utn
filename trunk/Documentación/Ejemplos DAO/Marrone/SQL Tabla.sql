USE [PAV]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 09/19/2013 22:21:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Cuit] [nvarchar](13) NULL,
	[CreditoMaximo] [decimal](18, 2) NULL,
	[FechaNacimiento] [date] NULL,
	[TieneCasa] [tinyint] NULL,
	[NumeroDocumento] [bigint] NULL,
	[Sexo] [nvarchar](1) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


