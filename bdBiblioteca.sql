
--CREAR BASE DE DATOS--
create database bdBiblioteca 

--USAR BASE DE DATOS--
use bdBiblioteca

--CREAR TABLAS--
create table alumno(
	claveUnica int not null primary key,
	nombreA char(50),
	apellidoM char(50),
	apellidoP char(50),
	correo varchar(30),
	semestre smallint,
	programa char(50),
	contrase�a varchar(50),
	cantPrestamos int,
	histPrestamos int,
	multa bit,
	adeudo float);

create table empleado(
	claveUnica smallint not null primary key,
	nombreA char(50),
	apellidoM char(50),
	apellidoP char(50),
	contrase�a varchar(50));

create table categoria(
	idCategoria int primary key,
	nombreC char(50));

create table libro(
	idLibro smallint primary key,
	nombreL char(50),
	autor char(50),
	editorial char(50),
	fechaPublicacion date,
	idCategoria int references categoria,
	disponible bit);

create table prestamo(
	idLibro smallint references libro,
	claveUnica int references alumno,
	fechaPrestamo char(50),
	fechaEntrega char(50),
	primary key (idLibro, claveUnica));


--INSERTAR DATOS A TABLA DE CATEGORIA--
insert into categoria values(1,'Matem�ticas')
insert into categoria values(2,'Ingenier�a')
insert into categoria values(3,'Filosof�a')
insert into categoria values(4,'Literatura')
insert into categoria values(5,'Derecho')
insert into categoria values(6,'Econom�a')
insert into categoria values(7,'Historia')

--INSERTAR DATOS A TABLA DE ALUMNOS--
insert into alumno values(195111,'Mariana','Zapata','Covarrubias','mzapata4@itam.mx',3,'Mecatr�nica e Industrial',195111,0,0,0,0)
insert into alumno values(195106,'Mauricio','Verduzco','Chavira','mverduzc@itam.mx',3,'Mecatr�nica e Industrial',195106,0,0,0,0)
insert into alumno values(163125,'Carlos','Holohlavsky','Fernandez','carlosholo@itam.mx',3,'Econom�a y Ciencia Pol�tica',163125,0,0,0,0)
insert into alumno values(195525,'Mariel','Gutierrez','Zapien','mguti122@itam.mx',3,'Computacion',195525,0,0,0,0)

--INSERTAR DATOS A TABLA DE EMPLEADOS--
insert into empleado values(562,'Gerardo','Ojeda','del Campo',562)
insert into empleado values(184,'Sofia','Corona','Mart�nez',184)
insert into empleado values(274,'Esteban','Jimenez','Arraz',274)

insert into libro values(1,'Un mundo feliz','Aldous Huxley','Porr�a','10/10/1932',4,0)


