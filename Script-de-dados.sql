USE [P3ImageTeste]
GO

INSERT INTO [dbo].[Categoria]
           ([descricao]
           ,[slug])
     VALUES
           ('Ve�culos e Acess�rios',
           'veiculos-e-acessorios')
GO


INSERT INTO [dbo].[SubCategoria]
           ([descricao]
           ,[slug]
           ,[categoria_id])
     VALUES
           ('Som'
           ,'som'
           ,1)
GO

INSERT INTO [dbo].[Campos]
           ([descricao]
           ,[lista]
           ,[tipo]
           ,[ordem]
           ,[subCategoria_id])
     VALUES
           ('Campo1'
           , 'Op��o1;Op��o2;Op��o3'
           , 3
           ,1
           ,1)
GO
INSERT INTO [dbo].[Campos]
           ([descricao]
           ,[lista]
           ,[tipo]
           ,[ordem]
           ,[subCategoria_id])
     VALUES
           ('Campo2'
           , 'Op��o1;Op��o2;Op��o3'
           , 4
           ,2
           ,1)
GO
INSERT INTO [dbo].[Campos]
           ([descricao]
           ,[lista]
           ,[tipo]
           ,[ordem]
           ,[subCategoria_id])
     VALUES
           ('Campo3'
           ,null
           , 1
           ,3
           ,1)
GO
INSERT INTO [dbo].[Campos]
           ([descricao]
           ,[lista]
           ,[tipo]
           ,[ordem]
           ,[subCategoria_id])
     VALUES
           ('Campo4'
           ,null
           , 2
           ,4
           ,1)
GO
