create database proyecto_innube charset utf8mb4;

use proyecto_innube;

create table Cliente_compañia (
id_cliente_compañia varchar(12) primary key not null,
nombre_compañia varchar(30) not null,
telefono_compañia varchar(15) not null,
correo_electronico_compañia varchar(50) unique not null,
direccion_compañia varchar(50) not null,
id_contraseña_compañia int unsigned not null,
nit_compañia varchar(12) unique not null,
id_ciudad int unsigned,
id_departamento int unsigned,

constraint id_contraseña_compañia_fk foreign key (id_contraseña_compañia)
references Contraseña_cliente_compañia (id_contraseña_compañia)
on delete cascade
on update cascade,

constraint id_ciudad_fk foreign key (id_ciudad)
references Ciudad_compañia (id_ciudad)
on delete cascade
on update cascade,

constraint id_departamento_fk foreign key (id_departamento)
references Departamento_compañia (id_departamento)
on delete cascade
on update cascade
);

create table Contraseña_cliente_compañia (
id_contraseña_compañia int unsigned primary key auto_increment not null,
salt varchar(20) not null,
parte_encriptada varchar(150) not null
);

create table Ciudad_compañia (
id_ciudad int unsigned primary key auto_increment not null,
nombre_ciudad varchar(30)
);

create table Departamento_compañia (
id_departamento int unsigned primary key auto_increment not null,
nombre_departamento varchar(30)
);


create table Cliente (
id_cliente varchar(12) primary key not null,
nombre_cliente varchar(30) not null,
apellido_cliente varchar(30) not null,
correo_electronico_cliente varchar(50) unique not null,
id_contraseña_cliente int unsigned,

constraint id_contraseña_cliente_fk foreign key (id_contraseña_cliente)
references Contraseña_cliente (id_contraseña_cliente)
on delete cascade
on update cascade
);

create table Contraseña_cliente (
id_contraseña_cliente int unsigned auto_increment primary key not null,
salt varchar(20) not null,
parte_encriptada varchar(150) not null
);

create table Cliente_general (
id_cliente_general varchar(12) primary key not null,
personal_natural bool not null,
persona_juridica bool not null
);

create table Cotizacion (
id_cotizacion int unsigned auto_increment primary key not null,
precio_total int unsigned not null,
id_cliente_general varchar(12),
subtotal int unsigned not null,

constraint id_cliente_general_fk foreign key (id_cliente_general)
references Cliente_general (id_cliente_general)
on delete cascade
on update cascade
);

create table Demanda_servicio (
id_cotizacion int unsigned auto_increment not null,
id_servicio varchar(12) not null,
fecha_cotizacion date,
cantidad tinyint,
primary key (id_cotizacion, id_servicio),

constraint id_servicio_fk foreign key (id_servicio)
references Servicio_ofrecido (id_servicio)
on delete cascade
on update cascade,

constraint id_cotizacion_fk foreign key (id_cotizacion)
references Cotizacion (id_cotizacion)
on delete cascade
on update cascade
);

create table Servicio_ofrecido (
id_servicio varchar(12) primary key not null,
nombre_servicio varchar(30) not null, 
precio_servicio int unsigned not null,
descripcion varchar(1000) not null);

create table Oferta_servicio (
id_servicio varchar(12) not null,
id_compañia varchar(12) not null,
primary key (id_compañia, id_servicio),

constraint id_servicio_fk2 foreign key (id_servicio)
references Servicio_ofrecido (id_servicio)
on delete cascade
on update cascade,

constraint id_compañia_fk2 foreign key (id_compañia)
references Compañia (id_compañia)
on delete cascade
on update cascade
);

create table Compañia (
id_compañia varchar(12) primary key not null,
nombre_compañia varchar(30) not null,
telefono_compañia varchar(15) not null,
correo_electronico_compañia varchar(50) unique not null,
direccion_compañia varchar(50) not null,
id_contraseña_compañia int unsigned not null,
nit_compañia varchar(12) unique not null,
id_ciudad int unsigned,
id_departamento int unsigned,

constraint id_contraseña_compañia_fk2 foreign key (id_contraseña_compañia)
references Contraseña_compañia (id_contraseña_compañia)
on delete cascade
on update cascade,

constraint id_ciudad_fk2 foreign key (id_ciudad)
references Ciudad_compañia (id_ciudad)
on delete cascade
on update cascade,

constraint id_departamento_fk2 foreign key (id_departamento)
references Departamento_compañia (id_departamento)
on delete cascade
on update cascade
);

create table Contraseña_compañia(
id_contraseña_compañia int unsigned primary key auto_increment not null,
salt varchar(20) not null,
parte_encriptada varchar(150) not null
);

create table Resultado_evaluacion (
id_compañia varchar(12) not null,
id_evaluacion int unsigned auto_increment not null,
aprobado bool not null,
fecha_aprobado date not null,
calificacion tinyint not null,
primary key (id_compañia, id_evaluacion),

constraint id_compañia_fk4 foreign key (id_compañia)
references Compañia (id_compañia)
on delete cascade 
on update cascade,

constraint id_evaluacion_fk foreign key (id_evaluacion)
references Evaluacion (id_evaluacion)
on delete cascade 
on update cascade
);

create table Evaluacion(
id_evaluacion int unsigned auto_increment primary key not null,
nombre_evaluacion varchar(30) not null,
descripcion_evaluacion varchar(1000) not null);

create table Parametro (
id_parametro int unsigned auto_increment primary key not null,
nombre_parametro varchar(30) not null,
descripcion_parametro varchar(1000) not null,
id_evaluacion int unsigned not null,
calificacion_parametro tinyint not null,

constraint id_evaluacion_fk2 foreign key (id_evaluacion)
references Evaluacion (id_evaluacion)
on delete cascade 
on update cascade
);

insert into Ciudad_compañia (nombre_ciudad)
values ('Bogotá'),
('Medellín'),
('Cali'),
('Barranquilla');

insert into Departamento_compañia (nombre_departamento)
values ('Antioquia'),
('Valle del Cauca'),
('Santander'),
('Barranquilla');

insert into Servicio_ofrecido (`id_servicio`, `nombre_servicio`, `precio_servicio`, `descripcion`) 
values ('SO45834545', 'Servicio 1', '34500', 'Es el primer servicios'),
('SO98987878', 'Servicio 2', '50000', 'Es el segundo servicio');

insert into Oferta_servicio (`id_servicio`, `id_compañia`) 
values ('SO45834545', 'CM5755671'),
('sO98987878', 'CM8432523');


