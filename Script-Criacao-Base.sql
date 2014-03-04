USE [master]
GO

CREATE DATABASE [P3ImageTeste] ON  PRIMARY 
( 
    NAME = N'P3ImageTeste', 
    FILENAME = N'D:\teste\P3Image-teste\P3ImageTeste.mdf' ,			--local data path
    SIZE = 8000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB 
)