USE [master]
GO

CREATE DATABASE [P3ImageTeste] ON  PRIMARY 
( 
    NAME = N'P3ImageTeste', 
    FILENAME = N'D:\teste\P3Image-teste\P3ImageTeste.mdf' ,			--local data path
    SIZE = 8000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB 
)
GO

USE[P3ImageTeste]

CREATE TABLE [dbo].[Categoria](
	[categoriaId] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [nvarchar](200) NOT NULL,
	[slug] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[categoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[SubCategoria](
	[subCategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [nvarchar](200) NOT NULL,
	[slug] [nvarchar](150) NOT NULL,
	[categoria_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[subCategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SubCategoria]  WITH CHECK ADD  CONSTRAINT [FKEFE741EF93758887] FOREIGN KEY([categoria_id])
REFERENCES [dbo].[Categoria] ([categoriaId])
GO

ALTER TABLE [dbo].[SubCategoria] CHECK CONSTRAINT [FKEFE741EF93758887]
GO

CREATE TABLE [dbo].[Campos](
	[campoId] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [nvarchar](200) NOT NULL,
	[lista] [nvarchar](200) NOT NULL,
	[tipo] [int] NOT NULL,
	[ordem] [int] NOT NULL,
	[subCategoria_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[campoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Campos]  WITH CHECK ADD  CONSTRAINT [FK2C2DD8E78E91471A] FOREIGN KEY([subCategoria_id])
REFERENCES [dbo].[SubCategoria] ([subCategoriaId])
GO

ALTER TABLE [dbo].[Campos] CHECK CONSTRAINT [FK2C2DD8E78E91471A]
GO


