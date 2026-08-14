-- Eliminar las tablas si ya existen (en orden inverso a las dependencias)
DROP TABLE IF EXISTS Libros;
DROP TABLE IF EXISTS Categorias;
DROP TABLE IF EXISTS Autores;

-- 1. Tabla Autores
CREATE TABLE Autores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL
);

-- 2. Tabla Categorias
CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

-- 3. Tabla Libros (con sus llaves foráneas)
CREATE TABLE Libros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(200) NOT NULL,
    FechaPublicacion DATETIME NOT NULL,
    AutorId INT NOT NULL,
    CategoriaId INT NOT NULL,
    CONSTRAINT FK_Libros_Autores FOREIGN KEY (AutorId) REFERENCES Autores(Id),
    CONSTRAINT FK_Libros_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);