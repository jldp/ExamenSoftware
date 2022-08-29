create database PruebaEmpleados

use PruebaEmpleados

create table areas(
	id_area int identity primary key not null,
	nombre varchar (40) not null,
)

INSERT INTO areas VALUES('NOC')
INSERT INTO areas VALUES('Innovacion y Mejora')
INSERT INTO areas VALUES('CIS')
INSERT INTO areas VALUES('IT')
INSERT INTO areas VALUES('Implementaciones')

create table empleados(
	id_empleado int identity primary key not null,
	nombre varchar (40) not null,
	apellidoPaterno varchar (40) not null,
	correo varchar (40) not null,
	id_area INT FOREIGN KEY REFERENCES areas(id_area) NOT NULL
)

INSERT INTO empleados VALUES('Daniel','Martinez', 'dmartinez@stargroup.com.mx', 1)
INSERT INTO empleados VALUES('Pedro','Bernal', 'pbernal@stargroup.com.mx', 1)
INSERT INTO empleados VALUES('Jorge','Delgado', 'jdelgado@stargomexico.com', 1)
INSERT INTO empleados VALUES('Obed','Moreno', 'omoreno@stargomexico.com', 2)
INSERT INTO empleados VALUES('Gerardo','Galvez', 'galvez@stargroup.com.mx', 3)
INSERT INTO empleados VALUES('Antonio','Zarate', 'azarate@stargo.com', 4)
INSERT INTO empleados VALUES('Oscar','Caballero', 'caballero@stargroup.com.mx', 4)

select * from empleados