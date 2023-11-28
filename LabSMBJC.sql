CREATE DATABASE  LabSMBJC;
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
Drop TABLE	Cliente;
Drop TABLE VentaDetalle;
Drop TABLE Venta;
DROP TABLE CompraDetalle;
DROP TABLE Compra;
DROP TABLE Usuario;
DROP TABLE Empleado;
DROP TABLE Proveedor;
DROP TABLE Producto;

CREATE TABLE Producto (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  codigo VARCHAR(10) NOT NULL,
  descripcion VARCHAR(250) NOT NULL,
  unidadMedida VARCHAR(20) NOT NULL,
  saldo DECIMAL NOT NULL DEFAULT 0,
  precioVenta DECIMAL NOT NULL CHECK(precioVenta > 0),
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1

);

CREATE TABLE Proveedor (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nit BIGINT NOT NULL,
  razonSocial VARCHAR(100) NOT NULL,
  direccion VARCHAR(250) NULL,
  telefono VARCHAR(30) NOT NULL,
  representante VARCHAR(100) NOT NULL,
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);

CREATE TABLE Empleado (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  cedulaIdentidad VARCHAR(15) NOT NULL,
  nombres VARCHAR(20) NOT NULL,
  primerApellido VARCHAR(20) NULL,
  segudoApellido VARCHAR(20) NULL,
  direccion VARCHAR(250) NOT NULL,
  celular BIGINT NOT NULL,
  cargo VARCHAR(30) NOT NULL,
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);

CREATE TABLE Usuario (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idEmpleado INT NOT NULL,
  usuario VARCHAR(12) NOT NULL,
  clave VARCHAR(100) NOT NULL,
  CONSTRAINT fk_Usuario_Empleado FOREIGN KEY(idEmpleado) REFERENCES Empleado(id),
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);

CREATE TABLE Compra (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idProveedor INT NOT NULL,
  transaccion INT NOT NULL,
  fecha DATE NOT NULL DEFAULT GETDATE(),
  CONSTRAINT fk_Compra_Proveedor FOREIGN KEY(idProveedor) REFERENCES Proveedor(id),
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);
CREATE TABLE CompraDetalle (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idCompra INT NOT NULL,
  idProducto INT NOT NULL,
  cantidad DECIMAL NOT NULL CHECK(cantidad > 0),
  precioUnitario DECIMAL NOT NULL,
  total DECIMAL NOT NULL,
  CONSTRAINT fk_CompraDetalle_Compra FOREIGN KEY(idCompra) REFERENCES Compra(id),
  CONSTRAINT fk_CompraDetalle_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id),
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);

CREATE TABLE Venta (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  transccion VARCHAR(15) NOT NULL,
  fecha DATE NOT NULL DEFAULT GETDATE(),
  idUsuario INT NOT NULL,
  idCliente INT NOT NULL,
  CONSTRAINT fk_Venta_Usuario FOREIGN KEY(idUsuario) REFERENCES Usuario(id),
  CONSTRAINT fk_Venta_Cliente FOREIGN KEY(idCliente) REFERENCES Cliente(id),
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);
CREATE TABLE VentaDetalle (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  cantidad DECIMAL NOT NULL CHECK(cantidad > 0),
  precioUnitario DECIMAL NOT NULL,
  total DECIMAL NOT NULL,
  idVenta INT NOT NULL,
  idProveedor INT NOT NULL,
  CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY(idVenta) REFERENCES Venta(id),
  CONSTRAINT fk_VentaDetalle_Proveedor FOREIGN KEY(idProveedor) REFERENCES Proveedor(id),
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);

CREATE TABLE Cliente (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nit BIGINT NOT NULL,
  razonSocial VARCHAR(100) NOT NULL,
  usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
  fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
  estado SMALLINT NOT NULL DEFAULT 1
);


ALTER PROC paProductoListar @parametro VARCHAR(50)
AS
  SELECT id,codigo,descripcion,unidadMedida,saldo,precioVenta,usuarioRegistro,fechaRegistro,estado 
  FROM Producto
  WHERE estado<>-1 AND descripcion LIKE '%'+REPLACE(@parametro,' ','%')+'%';

EXEC paProductoListar 'CERVEZA PACEÑA ';

-- DML
INSERT INTO Producto(codigo,descripcion,unidadMedida,saldo,precioVenta)
VALUES ('A001', 'CERVEZA PACEÑA DE 1200 ML', '2 CAJAS', 120, 10);

INSERT INTO Producto(codigo,descripcion,unidadMedida,saldo,precioVenta)
VALUES ('A002', 'WISKI', '5 CAJAS',1200 , 50);

UPDATE Producto SET codigo='A001',precioVenta=12 WHERE id=1;
UPDATE Producto SET estado=-1 WHERE id=2; -- Eliminación lógica
UPDATE Producto SET estado=0 WHERE id=2;  -- Establecer registro como inactivo
