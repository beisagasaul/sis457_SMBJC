use LabSMBJC;


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
  (1, 1, 2, 25.50, 51.00),
  (2, 2, 3, 15.75, 47.25),
  (3, 3, 1, 30.00, 30.00),
  (4, 4, 4, 40.25, 161.00),
  (5, 5, 2, 18.50, 37.00);


--insertando datos de Cliente
select * from Cliente
INSERT INTO Cliente (razonSocial, cedulaIdentidad, celular)
VALUES
  ('Cliente1', 'CI123456', '71234567'),
  ('Cliente2', 'CI789012', '75678901'),
  ('EmpresaA', 'CI345678', '70123456'),
  ('EmpresaB', 'CI901234', '76543210'),
  ('Cliente3', 'CI567890', '72345678');

--insertando datos de Empleado
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
  (2, 'lopez2', '54321');
  