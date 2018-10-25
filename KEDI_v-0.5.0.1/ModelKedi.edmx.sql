
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/25/2018 18:59:19
-- Generated from EDMX file: E:\KEDI\KEDI_v-0.5.0.1\ModelKedi.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KEDI];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GirisLog_Personel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GirisLog] DROP CONSTRAINT [FK_GirisLog_Personel];
GO
IF OBJECT_ID(N'[dbo].[FK_Indirimler_Urunler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Indirimler] DROP CONSTRAINT [FK_Indirimler_Urunler];
GO
IF OBJECT_ID(N'[dbo].[FK_Masalar_Salonlar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Masalar] DROP CONSTRAINT [FK_Masalar_Salonlar];
GO
IF OBJECT_ID(N'[dbo].[FK_Odeme_Indirimler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odeme] DROP CONSTRAINT [FK_Odeme_Indirimler];
GO
IF OBJECT_ID(N'[dbo].[FK_Odeme_Siparisler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odeme] DROP CONSTRAINT [FK_Odeme_Siparisler];
GO
IF OBJECT_ID(N'[dbo].[FK_Personel_Yetkiler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personel] DROP CONSTRAINT [FK_Personel_Yetkiler];
GO
IF OBJECT_ID(N'[dbo].[FK_Siparisler_Masalar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Siparisler] DROP CONSTRAINT [FK_Siparisler_Masalar];
GO
IF OBJECT_ID(N'[dbo].[FK_Siparisler_Personel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Siparisler] DROP CONSTRAINT [FK_Siparisler_Personel];
GO
IF OBJECT_ID(N'[dbo].[FK_Siparisler_Urunler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Siparisler] DROP CONSTRAINT [FK_Siparisler_Urunler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GirisLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GirisLog];
GO
IF OBJECT_ID(N'[dbo].[Indirimler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Indirimler];
GO
IF OBJECT_ID(N'[dbo].[Loglar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loglar];
GO
IF OBJECT_ID(N'[dbo].[Masalar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Masalar];
GO
IF OBJECT_ID(N'[dbo].[Odeme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Odeme];
GO
IF OBJECT_ID(N'[dbo].[Personel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personel];
GO
IF OBJECT_ID(N'[dbo].[Salonlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salonlar];
GO
IF OBJECT_ID(N'[dbo].[Siparisler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Siparisler];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Urunler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Urunler];
GO
IF OBJECT_ID(N'[dbo].[Yetkiler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Yetkiler];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Indirimlers'
CREATE TABLE [dbo].[Indirimlers] (
    [IndirimID] int IDENTITY(1,1) NOT NULL,
    [IndirimAdi] nvarchar(50)  NOT NULL,
    [Oran] decimal(10,5)  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [UrunID] int  NULL
);
GO

-- Creating table 'Loglars'
CREATE TABLE [dbo].[Loglars] (
    [LogID] int IDENTITY(1,1) NOT NULL,
    [TabloAdi] nvarchar(50)  NOT NULL,
    [Sutun] nvarchar(50)  NOT NULL,
    [OncekiVeri] nvarchar(max)  NOT NULL,
    [YeniVeri] nvarchar(max)  NOT NULL,
    [Tarih] datetime  NOT NULL
);
GO

-- Creating table 'Masalars'
CREATE TABLE [dbo].[Masalars] (
    [MasaID] int IDENTITY(1,1) NOT NULL,
    [MasaAdi] nvarchar(50)  NOT NULL,
    [SalonID] int  NOT NULL,
    [KonumX] decimal(10,5)  NOT NULL,
    [KonumY] decimal(10,5)  NOT NULL,
    [Tarih] datetime  NOT NULL
);
GO

-- Creating table 'Odemes'
CREATE TABLE [dbo].[Odemes] (
    [OdemeID] int IDENTITY(1,1) NOT NULL,
    [SiparisID] int  NOT NULL,
    [OdemeYontemi] int  NOT NULL,
    [IndirimID] int  NULL,
    [Notlar] nvarchar(max)  NULL,
    [Tarih] datetime  NOT NULL
);
GO

-- Creating table 'Personels'
CREATE TABLE [dbo].[Personels] (
    [KullaniciID] int IDENTITY(1,1) NOT NULL,
    [KullaniciAdi] nvarchar(50)  NOT NULL,
    [YetkiID] int  NOT NULL,
    [Sifre] nvarchar(50)  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [TelefonNum] nvarchar(11)  NOT NULL
);
GO

-- Creating table 'Salonlars'
CREATE TABLE [dbo].[Salonlars] (
    [SalonID] int IDENTITY(1,1) NOT NULL,
    [SalonAdi] nvarchar(50)  NOT NULL,
    [Tarih] datetime  NOT NULL
);
GO

-- Creating table 'Siparislers'
CREATE TABLE [dbo].[Siparislers] (
    [SiparisID] int IDENTITY(1,1) NOT NULL,
    [SiparisAdi] nvarchar(50)  NOT NULL,
    [MasaID] int  NOT NULL,
    [UrunID] int  NOT NULL,
    [UrunSayi] int  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [KullaniciID] int  NOT NULL,
    [Notlar] nvarchar(max)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Urunlers'
CREATE TABLE [dbo].[Urunlers] (
    [UrunID] int IDENTITY(1,1) NOT NULL,
    [UrunAdi] nvarchar(50)  NOT NULL,
    [UstUrunID] int  NULL,
    [Fiyat] decimal(10,5)  NOT NULL,
    [Tarih] datetime  NULL,
    [Notlar] nvarchar(max)  NULL,
    [AltOzellik] bit  NULL
);
GO

-- Creating table 'Yetkilers'
CREATE TABLE [dbo].[Yetkilers] (
    [YetkiID] int IDENTITY(1,1) NOT NULL,
    [YetkiAdi] nvarchar(50)  NOT NULL,
    [MasaAcma] bit  NOT NULL,
    [MasaTasima] bit  NOT NULL,
    [MasaBirlestirme] bit  NOT NULL,
    [HesapAlma] bit  NOT NULL,
    [HesapIptal] bit  NOT NULL,
    [UrunAyarlari] bit  NOT NULL,
    [MasaAyarlari] bit  NOT NULL,
    [PersonelAyarlari] bit  NOT NULL,
    [Raporlama] bit  NOT NULL
);
GO

-- Creating table 'GirisLogs'
CREATE TABLE [dbo].[GirisLogs] (
    [LogID] int  NOT NULL,
    [KullaniciID] int  NOT NULL,
    [Tarih] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IndirimID] in table 'Indirimlers'
ALTER TABLE [dbo].[Indirimlers]
ADD CONSTRAINT [PK_Indirimlers]
    PRIMARY KEY CLUSTERED ([IndirimID] ASC);
GO

-- Creating primary key on [LogID] in table 'Loglars'
ALTER TABLE [dbo].[Loglars]
ADD CONSTRAINT [PK_Loglars]
    PRIMARY KEY CLUSTERED ([LogID] ASC);
GO

-- Creating primary key on [MasaID] in table 'Masalars'
ALTER TABLE [dbo].[Masalars]
ADD CONSTRAINT [PK_Masalars]
    PRIMARY KEY CLUSTERED ([MasaID] ASC);
GO

-- Creating primary key on [OdemeID] in table 'Odemes'
ALTER TABLE [dbo].[Odemes]
ADD CONSTRAINT [PK_Odemes]
    PRIMARY KEY CLUSTERED ([OdemeID] ASC);
GO

-- Creating primary key on [KullaniciID] in table 'Personels'
ALTER TABLE [dbo].[Personels]
ADD CONSTRAINT [PK_Personels]
    PRIMARY KEY CLUSTERED ([KullaniciID] ASC);
GO

-- Creating primary key on [SalonID] in table 'Salonlars'
ALTER TABLE [dbo].[Salonlars]
ADD CONSTRAINT [PK_Salonlars]
    PRIMARY KEY CLUSTERED ([SalonID] ASC);
GO

-- Creating primary key on [SiparisID] in table 'Siparislers'
ALTER TABLE [dbo].[Siparislers]
ADD CONSTRAINT [PK_Siparislers]
    PRIMARY KEY CLUSTERED ([SiparisID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [UrunID] in table 'Urunlers'
ALTER TABLE [dbo].[Urunlers]
ADD CONSTRAINT [PK_Urunlers]
    PRIMARY KEY CLUSTERED ([UrunID] ASC);
GO

-- Creating primary key on [YetkiID] in table 'Yetkilers'
ALTER TABLE [dbo].[Yetkilers]
ADD CONSTRAINT [PK_Yetkilers]
    PRIMARY KEY CLUSTERED ([YetkiID] ASC);
GO

-- Creating primary key on [LogID] in table 'GirisLogs'
ALTER TABLE [dbo].[GirisLogs]
ADD CONSTRAINT [PK_GirisLogs]
    PRIMARY KEY CLUSTERED ([LogID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UrunID] in table 'Indirimlers'
ALTER TABLE [dbo].[Indirimlers]
ADD CONSTRAINT [FK_Indirimler_Urunler]
    FOREIGN KEY ([UrunID])
    REFERENCES [dbo].[Urunlers]
        ([UrunID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Indirimler_Urunler'
CREATE INDEX [IX_FK_Indirimler_Urunler]
ON [dbo].[Indirimlers]
    ([UrunID]);
GO

-- Creating foreign key on [IndirimID] in table 'Odemes'
ALTER TABLE [dbo].[Odemes]
ADD CONSTRAINT [FK_Odeme_Indirimler]
    FOREIGN KEY ([IndirimID])
    REFERENCES [dbo].[Indirimlers]
        ([IndirimID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Odeme_Indirimler'
CREATE INDEX [IX_FK_Odeme_Indirimler]
ON [dbo].[Odemes]
    ([IndirimID]);
GO

-- Creating foreign key on [SalonID] in table 'Masalars'
ALTER TABLE [dbo].[Masalars]
ADD CONSTRAINT [FK_Masalar_Salonlar]
    FOREIGN KEY ([SalonID])
    REFERENCES [dbo].[Salonlars]
        ([SalonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Masalar_Salonlar'
CREATE INDEX [IX_FK_Masalar_Salonlar]
ON [dbo].[Masalars]
    ([SalonID]);
GO

-- Creating foreign key on [MasaID] in table 'Siparislers'
ALTER TABLE [dbo].[Siparislers]
ADD CONSTRAINT [FK_Siparisler_Masalar]
    FOREIGN KEY ([MasaID])
    REFERENCES [dbo].[Masalars]
        ([MasaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Siparisler_Masalar'
CREATE INDEX [IX_FK_Siparisler_Masalar]
ON [dbo].[Siparislers]
    ([MasaID]);
GO

-- Creating foreign key on [SiparisID] in table 'Odemes'
ALTER TABLE [dbo].[Odemes]
ADD CONSTRAINT [FK_Odeme_Siparisler]
    FOREIGN KEY ([SiparisID])
    REFERENCES [dbo].[Siparislers]
        ([SiparisID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Odeme_Siparisler'
CREATE INDEX [IX_FK_Odeme_Siparisler]
ON [dbo].[Odemes]
    ([SiparisID]);
GO

-- Creating foreign key on [YetkiID] in table 'Personels'
ALTER TABLE [dbo].[Personels]
ADD CONSTRAINT [FK_Personel_Yetkiler]
    FOREIGN KEY ([YetkiID])
    REFERENCES [dbo].[Yetkilers]
        ([YetkiID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Personel_Yetkiler'
CREATE INDEX [IX_FK_Personel_Yetkiler]
ON [dbo].[Personels]
    ([YetkiID]);
GO

-- Creating foreign key on [KullaniciID] in table 'Siparislers'
ALTER TABLE [dbo].[Siparislers]
ADD CONSTRAINT [FK_Siparisler_Personel]
    FOREIGN KEY ([KullaniciID])
    REFERENCES [dbo].[Personels]
        ([KullaniciID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Siparisler_Personel'
CREATE INDEX [IX_FK_Siparisler_Personel]
ON [dbo].[Siparislers]
    ([KullaniciID]);
GO

-- Creating foreign key on [UrunID] in table 'Siparislers'
ALTER TABLE [dbo].[Siparislers]
ADD CONSTRAINT [FK_Siparisler_Urunler]
    FOREIGN KEY ([UrunID])
    REFERENCES [dbo].[Urunlers]
        ([UrunID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Siparisler_Urunler'
CREATE INDEX [IX_FK_Siparisler_Urunler]
ON [dbo].[Siparislers]
    ([UrunID]);
GO

-- Creating foreign key on [KullaniciID] in table 'GirisLogs'
ALTER TABLE [dbo].[GirisLogs]
ADD CONSTRAINT [FK_GirisLog_Personel]
    FOREIGN KEY ([KullaniciID])
    REFERENCES [dbo].[Personels]
        ([KullaniciID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GirisLog_Personel'
CREATE INDEX [IX_FK_GirisLog_Personel]
ON [dbo].[GirisLogs]
    ([KullaniciID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------