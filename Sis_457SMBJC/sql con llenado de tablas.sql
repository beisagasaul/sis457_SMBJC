﻿create database LabSMBJC;

GO

USE MASTER
GO
CREATE LOGIN  usrlabsmbjc WITH PASSWORD=N'123456',
DEFAULT_DATABASE= LabSMBJC,
CHECK_EXPIRATION=OFF,
CHECK_POLICY=ON
GO

USE LabSMBJC
GO
CREATE USER usrlabsmbjc FOR LOGIN  usrlabsmbjc
GO
ALTER ROLE db_owner ADD MEMBER usrlabsmbjc
GO
DROP TABLE VentaDetalle;
DROP TABLE Producto;
DROP TABLE Categoria;
DROP TABLE Venta;
DROP TABLE Usuario;
DROP TABLE Empleado;
DROP TABLE Cliente;

CREATE TABLE Empleado(
  idEmpleado INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(20) NOT NULL,
  apellidos VARCHAR(50) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  cargo VARCHAR(20) NOT NULL,
  salario FLOAT NOT NULL,
);

CREATE TABLE Usuario(
  idUsuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idEmpleado INT NOT NULL,
  usuario VARCHAR(30) NOT NULL,
  clave VARCHAR(30) NOT NULL,
  FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado)
);

CREATE TABLE Categoria(
  idCategoria INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(30) NOT NULL
);

CREATE TABLE Producto(
  idProducto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idCategoria INT NOT NULL,
  codigo VARCHAR(20) NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  descripcion VARCHAR(500) NOT NULL,
  precio DECIMAL (5,2) NOT NULL,
  FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
);

CREATE TABLE Cliente(
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  razonSocial VARCHAR(50) NOT NULL,
  cedulaIdentidad VARCHAR(15) NOT NULL,
  celular VARCHAR(8) NOT NULL DEFAULT '0',
);

CREATE TABLE Venta(
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idUsuario INT NOT NULL,
  idCliente INT NOT NULL,
  totalVenta DECIMAL NOT NULL,
  fechaVenta DATE NOT NULL DEFAULT GETDATE(),
  CONSTRAINT fk_Venta_Usuario FOREIGN KEY(idUsuario) REFERENCES Usuario(idUsuario),
  CONSTRAINT fk_Venta_Cliente FOREIGN KEY(idCliente) REFERENCES Cliente(id)
);

CREATE TABLE VentaDetalle(
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idVenta INT NOT NULL,
  idProducto INT NOT NULL,
  cantidad INT NOT NULL CHECK(cantidad > 0),
  precioUnitario DECIMAL NOT NULL,
  total DECIMAL NOT NULL,
  CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY(idVenta) REFERENCES Venta(id),
  CONSTRAINT fk_VentaDetalle_Producto FOREIGN KEY(idProducto) REFERENCES Producto(idProducto)
);

ALTER TABLE Empleado ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Empleado ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Empleado ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Usuario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Usuario ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Categoria ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Categoria ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Categoria ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Producto ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Cliente ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cliente ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cliente ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Venta ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Venta ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Venta ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE VentaDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE VentaDetalle ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE VentaDetalle ADD estado SMALLINT NOT NULL DEFAULT 1;

--Procedimientos Almacenados
CREATE PROC paEmpleadoListar @parametro VARCHAR(50)
AS
  SELECT idEmpleado,nombre,apellidos,telefono,cargo,salario
  FROM Empleado
  WHERE estado<>-1 AND nombre LIKE '%'+REPLACE(@parametro,' ','%')+'%';

  CREATE PROCEDURE paProductosListar @parametro VARCHAR(50)
AS
  SELECT p.*, c.nombre AS categoria
  FROM producto AS p
  INNER JOIN categoria AS c ON p.idCategoria = c.idCategoria
  WHERE p.estado<>-1 AND p.nombre LIKE '%'+REPLACE(@parametro,' ','%')+'%';


 CREATE PROC paClienteListar @parametro VARCHAR(50)
AS 
  SELECT *
  FROM Cliente
  WHERE estado<>-1 AND razonSocial LIKE '%'+REPLACE(@parametro,' ','%');

  CREATE PROC paVentaListar @parametro VARCHAR(50)
AS 
  SELECT v.*, u.usuario, c.razonSocial
  FROM Venta v
  INNER JOIN Usuario u ON u.idUsuario = v.idUsuario
  INNER JOIN Cliente c ON c.id = v.idCliente 
  WHERE v.estado<>-1 AND c.razonSocial LIKE '%'+REPLACE(@parametro,' ','%')+'%';

  CREATE PROC paVentaDetalleListar @parametro VARCHAR(50)
AS 
  SELECT vd.*, p.nombre, c.razonSocial
  FROM VentaDetalle vd
  INNER JOIN Producto p ON p.idProducto = vd.idProducto
  INNER JOIN Venta v ON v.id = vd.idVenta
  INNER JOIN Cliente c ON c.id = v.idCliente 
  WHERE vd.estado<>-1 AND c.razonSocial LIKE '%'+REPLACE(@parametro,' ','%')+'%';



  USE LabSMBJC

  --insertando datos de categorias
select * from Categoria;
insert into Categoria(nombre)values
('Clasicos Destilados'),
('Cervezas Exóticas'),
('Licores Frutales'),
('Bebidas Premium'),
('Sabores Locales');
--insertando datos de Productos
select * from Producto
INSERT INTO Producto (idCategoria, codigo, nombre, descripcion, precio) VALUES
(1, 'A001', '"Whisky Éter', ' Suavidad y misterio en cada trago.', 25.99),
(2, 'A002', 'Cerveza Artesanal IPA', 'Cerveza con notas cítricas', 19.99),
(3, 'A003', 'Frambuesa Fugaz ', 'Licor de frambuesa vibrante y efímero ', 8.99),
(4, 'A004', 'Élite Reserva', 'Élite Reserva: Elegancia líquida', 49.99),
(5, 'A005', 'SaborRaíces', 'Tradición embotellada', 15.99);

--insertando datos de Cliente
select * from Cliente
INSERT INTO Cliente (razonSocial, cedulaIdentidad, celular)
VALUES
  ('Cliente1', 'CI123456', '71234567'),
  ('Cliente2', 'CI789012', '75678901'),
  ('EmpresaA', 'CI345678', '70123456'),
  ('EmpresaB', 'CI901234', '76543210'),
  ('Cliente3', 'CI567890', '72345678');

  select * from Empleado
INSERT INTO Empleado (nombre, apellidos, telefono, cargo, salario)
VALUES
  ('Juan', 'Pérez Gómez', '71234567', 'empleado', 5000.00),
  ('María', 'López Rodríguez', '75678901', 'emplead', 2500.00),
  ('Carlos', 'Martínez García', '70123456', 'emplead', 3500.00),
  ('Laura', 'Gutiérrez Ramírez', '76543210', 'emplead', 4500.00),
  ('Pedro', 'Sánchez Vargas', '72345678', 'emplead', 3000.00);


  --insertando datos de Usuario
select * from Usuario
INSERT INTO Usuario (idEmpleado, usuario, clave)
VALUES
  (1, 'perez1', '12345'),
  (2, 'lopez2', '54321'),
  (3, 'lopez3', '54321'),
  (4, 'lopez4', '54321'),
  (5, 'lopez5', '54321');


--insertando datos de Venta
select * from Venta
INSERT INTO Venta (idUsuario, idCliente, totalVenta)
VALUES
  (1, 1, 150.75),
  (1, 2, 220.50),
  (1, 3, 75.30),
  (2, 4, 300.00),
  (2, 5, 125.40);

--insertando datos de VentaDetalle
select * from VentaDetalle
INSERT INTO VentaDetalle (idVenta, idProducto, cantidad, precioUnitario, total)
VALUES
  (3, 1, 2, 25.50, 51.00),
  (4, 2, 3, 15.75, 47.25),
  (5, 3, 1, 30.00, 30.00),
  (6, 4, 4, 40.25, 161.00),
  (7, 5, 2, 18.50, 37.00);