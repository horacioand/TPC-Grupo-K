-- Crear base de datos
CREATE DATABASE RESTO_DB;
GO

USE RESTO_DB;
GO

-- Tabla Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Usuario NVARCHAR(50) UNIQUE NOT NULL,
    Contrasena NVARCHAR(255) NOT NULL,
    Rol BIT NOT NULL,
	Activo int NOT NULL
);

-- Tabla Mesas
CREATE TABLE Mesas (
    Id INT PRIMARY KEY IDENTITY,
    Numero INT UNIQUE NOT NULL,
    Capacidad INT NOT NULL,
    Estado BIT NOT NULL
);

-- Tabla AsignacionMesas
CREATE TABLE AsignacionMesas (
    Id INT PRIMARY KEY IDENTITY,
    IdMesa INT NOT NULL,
	IdUsuario INT NOT NULL,
	FOREIGN KEY (IdMesa) REFERENCES Mesas(Id),
	FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
    --Fecha DATE NOT NULL DEFAULT GETDATE()
);

-- Tabla Categorias
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Productos
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio MONEY NOT NULL,
    --Stock INT NOT NULL,
    UrlImagen NVARCHAR(255) NOT NULL,
    IdCategoria INT NOT NULL FOREIGN KEY REFERENCES Categorias(Id),
	Activo int NOT NULL
);

-- Tabla Pedidos
CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Estado BIT NOT NULL,
    Total MONEY NOT NULL DEFAULT 0,
    IdMesa INT NOT NULL FOREIGN KEY REFERENCES Mesas(Id),
	nroClientes INT NOT NULL
);

-- Tabla ItemsPedido
CREATE TABLE ItemsPedido (
    Id INT PRIMARY KEY IDENTITY,
    Cantidad INT NOT NULL,
    PrecioUnitario MONEY NOT NULL,
    --Subtotal AS (Cantidad * PrecioUnitario),
    IdPedido INT NOT NULL FOREIGN KEY REFERENCES Pedidos(Id),
    IdProducto INT NOT NULL FOREIGN KEY REFERENCES Productos(Id)
);

-- Tabla Turnos
CREATE TABLE Turnos (
    Id INT PRIMARY KEY IDENTITY,
    Fecha DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios(Id)
);

-- Tabla Ventas
CREATE TABLE Ventas (
    Id INT PRIMARY KEY IDENTITY,
    IdMesero INT NOT NULL FOREIGN KEY REFERENCES Usuarios(Id),
	IdPedido INT NOT NULL FOREIGN KEY REFERENCES Pedidos(Id),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    TotalCuenta MONEY NOT NULL,
    PlatillosConsumidos INT NOT NULL
);

-- Insertar datos en Usuarios
INSERT INTO Usuarios (Nombre, Usuario, Contrasena, Rol, Activo) VALUES
('Juan Pérez', 'juan', '12345', 1, 1),
('Ana López', 'ana', '67890', 0, 1),
('Carlos Gómez', 'carlos', 'abcde', 0, 1);

-- Insertar datos en Mesas
INSERT INTO Mesas (Numero, Capacidad, Estado) VALUES
(1, 4, 0),
(2, 2, 0),
(3, 6, 0),
(4, 8, 0),
(5, 4, 0);

-- Insertar datos en AsignacionMesas
INSERT INTO AsignacionMesas (IdMesa, IdUsuario) VALUES
(1, 1),
(2, 2),
(3, 1),
(4, 3),
(5, 2);

-- Insertar datos en Categorias
INSERT INTO Categorias (Nombre) VALUES
('Bebidas'),
('Comidas'),
('Postres');

-- Insertar datos en Productos
INSERT INTO Productos (Nombre, Precio, UrlImagen, IdCategoria, Activo) VALUES
('Coca Cola', 1.5,  'https://acdn.mitiendanube.com/stores/861/458/products/351391-daa87de693ab884fa816700111096932-640-0.jpg', 1, 1),
('Fanta', 1.5,  'https://dcdn.mitiendanube.com/stores/001/151/835/products/77908950010171-f5d162eb6218e6544815890789301064-640-0.jpg', 1, 1),
('Sprite', 1.5,  'https://acdn.mitiendanube.com/stores/001/144/141/products/whatsapp-image-2021-08-25-at-11-08-571-f2321c146eb51f1dac16299005725116-640-0.jpeg', 1, 1),
('Agua Mineral', 1.0,  'https://acdn.mitiendanube.com/stores/001/157/846/products/556223-800-auto1-ce2a3f6e53b82deb5116354447231576-640-0.jpg', 1, 1),
('Café', 2.0,  'https://example.com/images/cafe.jpg', 1, 1),
('Té', 1.8,  'https://example.com/images/te.jpg', 1, 1),
('Jugo de Naranja', 2.5,  'https://acdn.mitiendanube.com/stores/001/127/840/products/jugo-natural-de-naranja-x-500cc-estancia-los-naranjos1-4402d488109e7e3fcd16242294926165-640-0.jpg', 1, 1),
('Jugo de Manzana', 2.5,  'https://png.pngtree.com/png-vector/20241224/ourlarge/pngtree-fresh-apple-juice-bottle-with-organic-red-apples-and-leaves-png-image_14843478.png', 1, 1),
('Cerveza', 3.0,  'https://acdn.mitiendanube.com/stores/001/163/250/products/img_7784-1024x10241-0a2ba5ea767e775a0815882026581912-640-0.jpg', 1, 1),
('Vino', 5.0,  'https://acdn.mitiendanube.com/stores/004/156/900/products/proyecto-chino-53-92e24f1745a0729ea217316171020203-640-0.jpg', 1, 1),

('Hamburguesa', 5.0,  'https://www.hola.com/horizon/square/cc77c84852d0-dia-hamburguesa-t.jpg?im=Resize=(640),type=downsize', 2, 1),
('Pizza', 8.0,  'https://acdn.mitiendanube.com/stores/001/497/896/products/pizza-muzza-jamon-tabla1-5757811e6ccb5d33a117019968750411-640-0.jpg', 2, 1),
('Pasta', 7.0,  'https://pngimg.com/uploads/pasta/pasta_PNG67.png', 2, 1),
('Ensalada', 4.5,  'https://consalyazucar.com/cdn/recipes/ensalada_de_pollo_mediterranea.jpg', 2, 1),
('Sopa', 3.5,  'https://example.com/images/sopa.jpg', 2, 1),
('Pollo Asado', 6.5,  'https://example.com/images/pollo_asado.jpg', 2, 1),
('Tacos', 4.0,  'https://example.com/images/tacos.jpg', 2, 1),
('Sushi', 9.0,  'https://example.com/images/sushi.jpg', 2, 1),
('Carne Asada', 10.0,  'https://example.com/images/carne_asada.jpg', 2, 1),
('Pescado', 8.5,  'https://example.com/images/pescado.jpg', 2, 1),

('Pastel de Chocolate', 3.0,  'https://example.com/images/pastel_chocolate.jpg', 3, 1),
('Helado', 2.5,  'https://example.com/images/helado.jpg', 3, 1),
('Flan', 2.0,  'https://example.com/images/flan.jpg', 3, 1),
('Tarta de Manzana', 3.5,  'https://example.com/images/tarta_manzana.jpg', 3, 1),
('Mousse de Limón', 3.0,  'https://example.com/images/mousse_limon.jpg', 3, 1),
('Brownie', 2.8,  'https://example.com/images/brownie.jpg', 3, 1),
('Gelatina', 1.5,  'https://example.com/images/gelatina.jpg', 3, 1),
('Cheesecake', 4.5,  'https://example.com/images/cheesecake.jpg', 3, 1);

