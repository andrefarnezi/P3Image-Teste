USE [P3ImageTeste]
GO

INSERT INTO [dbo].[Categoria]
           ([descricao]
           ,[slug])
     VALUES
           ('Veículos e Acessórios',
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
           , 'Opção1;Opção2;Opção3'
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
           , 'Opção1;Opção2;Opção3'
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
