use LabSMBJC;
--paUsuarioLista
select *from usuario;
insert into usuario(idEmpleado,usuario,clave)
values(1,'beisagasaul','12345678010')
insert into usuario(idEmpleado,usuario,clave)
values(2,'perezjuan','10987654321')
insert into usuario(idEmpleado,usuario,clave)
values(3,'velaluis','22222222222')
go
--USUARIO
alter PROC paUsuarioListar @parametro VARCHAR(50)
AS
  SELECT *
  FROM Usuario
  WHERE estado<>-1 AND cargo LIKE '%'+REPLACE(@parametro,' ','%')+'%';

EXEC paUsuarioListar 'empleado';

select  * from Empleado;
select* from Cliente
select *from usuario

select * from VentaDetalle;

select * from Proveedor;


--PROVEEDOR
insert into proveedor(nit,razonsocial,direccion,telefono,representante)
values('102030','LTDA','calle oruro','76453533','Jose ')
insert into proveedor(nit,razonsocial,direccion,telefono,representante)
values('102049','LTDA','calle sucre','71203533','Rene ')
INSERT INTO proveedor (nit, razonsocial, direccion, telefono, representante)
VALUES ('102049', 'ElectroTech Solutions, Inc.', 'Calle Sucre 123', '71203533', 'René García');

INSERT INTO proveedor (nit, razonsocial, direccion, telefono, representante)
VALUES ('203156', 'FashionMasters International, LLC', 'Avenida Bolívar 456', '71234567', 'Maria Lopez');

INSERT INTO proveedor (nit, razonsocial, direccion, telefono, representante)
VALUES ('304823', 'OfficePro Supplies, Corp.', 'Calle Comercio 789', '72123456', 'Juan Rodríguez');
GO
ALTER PROC paProveedorListar @parametro VARCHAR(50)
AS
  SELECT *
  FROM Proveedor
  WHERE estado<>-1 AND razonSocial LIKE '%'+REPLACE(@parametro,' ','%')+'%';

EXEC paProveedorListar 'Electro';
select* from VentaDetalle
select* from Venta
select* from Proveedor
-- Insertar datos en la tabla VentaDetalle
INSERT INTO VentaDetalle (cantidad, precioUnitario, total, idVenta, idProveedor)
VALUES (5, 25, 129, 2,6 );

INSERT INTO VentaDetalle (cantidad, precioUnitario, total, idVenta, idProveedor)
VALUES (10, 12, 125, 7, 5);
GO
CREATE PROC paDventaListar @parametro VARCHAR(50)
AS
BEGIN
  SELECT *
  FROM VentaDetalle
  WHERE estado <> -1 AND CONVERT(VARCHAR, id) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END;


EXEC paDventaListar '1' ;
--VENTA
SELECT *FROM Venta	
select* from Compra
select* from Producto

select* from CompraDetalle
INSERT INTO Compra (idProveedor, transaccion)
VALUES (2, 98765);

-- Insertar otra compra con proveedor 102 y transacción 87654
INSERT INTO Compra (idProveedor, transaccion)
VALUES (3, 87654);
INSERT INTO CompraDetalle (idCompra, idProducto, cantidad, precioUnitario, total)
VALUES (1, 24, 5, 10, 55)
       
-- Insertar detalles de otra compra con idCompra igual a 2 y productos con idProducto 203 y 204
INSERT INTO CompraDetalle (idCompra, idProducto, cantidad, precioUnitario, total)
VALUES (2, 12, 10, 5, 90)

go
     CREATE PROC paDcompraoListar @parametro VARCHAR(50)
AS
BEGIN
  SELECT *
  FROM CompraDetalle
  WHERE estado <> -1 AND CONVERT(VARCHAR, id) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END;


EXEC paDcompraoListar '2' ;
--empleado
select *from Empleado
go
alter PROC paEmpleadoListar @parametro VARCHAR(50)
AS
BEGIN
  SELECT *
  FROM Empleado
  WHERE estado <> -1 AND cedulaIdentidad LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END;
EXEC paEmpleadoListar '10345';
--compra
select* from Compra
 ALTER PROC paCompraoListar @parametro VARCHAR(50)
AS
BEGIN
  SELECT *
  FROM Compra
  WHERE estado <> -1 AND CONVERT(VARCHAR, id) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END;
exec  paCompraoListar '2'
--venta
select* from Venta
    CREATE PROC paVentaListar @parametro VARCHAR(50)
AS
BEGIN
  SELECT *
  FROM Venta
  WHERE estado <> -1 AND CONVERT(VARCHAR, id) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END;
exec  paVentaListar '2'