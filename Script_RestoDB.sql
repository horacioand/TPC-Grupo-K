use master;
GO
-- Creación de la base de datos
CREATE DATABASE RESTO_DB;
GO

USE RESTO_DB;
GO

-- Creación de la tabla Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Usuario NVARCHAR(50) UNIQUE NOT NULL,
    Contrasena NVARCHAR(255) NOT NULL,
    Rol BIT NOT NULL
);
GO

-- Inserción de datos en Usuarios
INSERT INTO Usuarios (Nombre, Usuario, Contrasena, Rol) VALUES
('Admin', 'admin', 'admin123', 1),
('Mesero1', 'mesero1', 'password1', 0),
('Mesero2', 'mesero2', 'password2', 0);
GO

-- Creación de la tabla Mesas
CREATE TABLE Mesas (
    Id INT PRIMARY KEY IDENTITY,
    Numero INT UNIQUE NOT NULL,
    Capacidad INT NOT NULL,
    Estado BIT NOT NULL
);
GO

-- Inserción de datos en Mesas
INSERT INTO Mesas (Numero, Capacidad, Estado) VALUES
(1, 4, 1),
(2, 6, 1),
(3, 2, 0);
GO

-- Creación de la tabla Productos
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio MONEY NOT NULL,
    Stock INT NOT NULL,
    Imagen NVARCHAR(MAX) NULL
);
GO

-- Inserción de datos en Productos
INSERT INTO Productos (Nombre, Precio, Stock, Imagen) VALUES
('Pizza Margarita', 10.50, 50, 'https://example.com/images/pizza_margarita.jpg'),
('Hamburguesa', 8.99, 100, 'https://example.com/images/hamburguesa.jpg'),
('Ensalada César', 6.75, 30, 'https://example.com/images/ensalada_cesar.jpg'),
('Coca-Cola', 1.50, 200, 'https://example.com/images/coca_cola.jpg'),
('Agua Mineral', 1.00, 150, 'https://example.com/images/agua_mineral.jpg');
GO

-- Creación de la tabla Pedidos
CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Estado BIT NOT NULL,
    Total MONEY NOT NULL DEFAULT 0,
    IdMesa INT NOT NULL FOREIGN KEY REFERENCES Mesas(Id)
);
GO

-- Inserción de datos en Pedidos
INSERT INTO Pedidos (Fecha, Estado, Total, IdMesa) VALUES
(GETDATE(), 1, 45.00, 1),
(GETDATE(), 0, 32.75, 2);
GO

-- Creación de la tabla ItemsPedido
CREATE TABLE ItemsPedido (
    Id INT PRIMARY KEY IDENTITY,
    Cantidad INT NOT NULL,
    PrecioUnitario MONEY NOT NULL,
    Subtotal AS (Cantidad * PrecioUnitario) PERSISTED,
    IdPedido INT NOT NULL FOREIGN KEY REFERENCES Pedidos(Id),
    IdProducto INT NOT NULL FOREIGN KEY REFERENCES Productos(Id)
);
GO

-- Inserción de datos en ItemsPedido
INSERT INTO ItemsPedido (Cantidad, PrecioUnitario, IdPedido, IdProducto) VALUES
(2, 10.50, 1, 1),
(1, 8.99, 1, 2),
(3, 1.50, 1, 4),
(1, 6.75, 2, 3),
(1, 1.00, 2, 5);
GO


-- Creación de la tabla Turnos (En caso que a futuro necesitemos)
--CREATE TABLE Turnos (
--    Id INT PRIMARY KEY IDENTITY,
--    Fecha DATE NOT NULL,
--    HoraInicio TIME NOT NULL,
--    HoraFin TIME NOT NULL,
--    IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios(Id)
--);
--GO

-- Inserción de datos en Turnos
--INSERT INTO Turnos (Fecha, HoraInicio, HoraFin, IdUsuario) VALUES
--('2025-01-15', '08:00:00', '16:00:00', 2),
--('2025-01-15', '16:00:00', '00:00:00', 3);
--GO


-- Creación de la tabla Ventas
CREATE TABLE Ventas (
    Id INT PRIMARY KEY IDENTITY,
    IdMesero INT NOT NULL FOREIGN KEY REFERENCES Usuarios(Id),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    TotalCuenta MONEY NOT NULL,
    PlatillosConsumidos INT NOT NULL,
    NumeroPersonas INT NOT NULL
);
GO

-- Inserción de datos en Ventas
INSERT INTO Ventas (IdMesero, Fecha, TotalCuenta, PlatillosConsumidos, NumeroPersonas) VALUES
(2, GETDATE(), 45.00, 3, 4),
(3, GETDATE(), 32.75, 2, 2);
GO

-- Creación de la tabla AsignacionMesas
CREATE TABLE AsignacionMesas (
    Id INT PRIMARY KEY IDENTITY,
    IdMesa INT NOT NULL FOREIGN KEY REFERENCES Mesas(Id),
    IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios(Id),
    Fecha DATE NOT NULL DEFAULT GETDATE()
);
GO

-- Inserción de datos en AsignacionMesas
INSERT INTO AsignacionMesas (IdMesa, IdUsuario, Fecha) VALUES
(1, 2, '2025-01-15'),
(2, 3, '2025-01-15');
GO
