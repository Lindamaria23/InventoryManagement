
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/23/2021 14:12:00
-- Generated from EDMX file: C:\Users\linda\source\repos\InventoryManagement\InventoryManagement\InventoryManagement\Models\InventoryModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InventoryManagement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StockItem] nvarchar(max)  NOT NULL,
    [Sellin] int  NOT NULL,
    [Quality] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------