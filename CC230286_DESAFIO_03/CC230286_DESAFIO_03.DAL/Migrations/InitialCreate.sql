IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Apellido] nvarchar(100) NOT NULL,
    [Email] nvarchar(150) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

CREATE TABLE [Productos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(150) NOT NULL,
    [Descripcion] nvarchar(500) NULL,
    [Precio] decimal(18,2) NOT NULL,
    [Stock] int NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([Id])
);

CREATE TABLE [Pedidos] (
    [Id] int NOT NULL IDENTITY,
    [FechaPedido] datetime2 NOT NULL,
    [Cantidad] int NOT NULL,
    [ClienteId] int NOT NULL,
    [ProductoId] int NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedidos_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pedidos_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([Id]) ON DELETE NO ACTION
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Email', N'Nombre') AND [object_id] = OBJECT_ID(N'[Clientes]'))
    SET IDENTITY_INSERT [Clientes] ON;
INSERT INTO [Clientes] ([Id], [Apellido], [Email], [Nombre])
VALUES (1, N'Martinez', N'carlos.martinez@example.com', N'Carlos'),
(2, N'Lopez', N'ana.lopez@example.com', N'Ana'),
(3, N'Hernandez', N'david.hernandez@example.com', N'David');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellido', N'Email', N'Nombre') AND [object_id] = OBJECT_ID(N'[Clientes]'))
    SET IDENTITY_INSERT [Clientes] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'Nombre', N'Precio', N'Stock') AND [object_id] = OBJECT_ID(N'[Productos]'))
    SET IDENTITY_INSERT [Productos] ON;
INSERT INTO [Productos] ([Id], [Descripcion], [Nombre], [Precio], [Stock])
VALUES (1, N'Core i7 16GB RAM SSD 512GB', N'Laptop Dell Inspiron', 899.99, 15),
(2, N'Mouse ergonómico receptor USB', N'Mouse Inalámbrico Logitech', 24.5, 50),
(3, N'Teclado switches Red con iluminación', N'Teclado Mecánico RGB', 65.0, 30),
(4, N'Panel IPS 75Hz HDMI/VGA', N'Monitor 24 Pulgadas Full HD', 145.0, 20);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'Nombre', N'Precio', N'Stock') AND [object_id] = OBJECT_ID(N'[Productos]'))
    SET IDENTITY_INSERT [Productos] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cantidad', N'ClienteId', N'FechaPedido', N'ProductoId') AND [object_id] = OBJECT_ID(N'[Pedidos]'))
    SET IDENTITY_INSERT [Pedidos] ON;
INSERT INTO [Pedidos] ([Id], [Cantidad], [ClienteId], [FechaPedido], [ProductoId])
VALUES (1, 1, 1, '2026-10-01T10:00:00.0000000Z', 1),
(2, 2, 2, '2026-10-02T14:30:00.0000000Z', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cantidad', N'ClienteId', N'FechaPedido', N'ProductoId') AND [object_id] = OBJECT_ID(N'[Pedidos]'))
    SET IDENTITY_INSERT [Pedidos] OFF;

CREATE INDEX [IX_Pedidos_ClienteId] ON [Pedidos] ([ClienteId]);

CREATE INDEX [IX_Pedidos_ProductoId] ON [Pedidos] ([ProductoId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261010064838_InitialCreate', N'10.0.12');

COMMIT;
GO

