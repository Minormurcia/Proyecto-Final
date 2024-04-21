


Create database ACME


create table Empresa
(
  IDEmpresa int primary key, 
  IDTipoEmpresa int,
  Empresa varchar(50),
  Direccion varchar(100),
  RUC Varchar(15),
  FechaCreacion date,
  Presupuesto decimal(18,2),
  Activo bit
)

create table TipoEmpresa
(
  IDEmpresa int primary key, 
  TipoEmpresa varchar(100),
  Descripcion varchar(max),
  Sigla varchar(10),
  Activo bit
)

create table Articulo
(
  IDArticulo int primary key,
  TipoArticulo int,
 
)

create table Requesicion
(
  IDRequesicion int primary key, 
  TipoRequesicion int,
  
  )

  create table RequesicionDetalle
(
  IDRequesicionDetalle int primary key,
  TipoRequesicionDetalle int,
  
  )

  create table UnidadMedida
(
  IDUnidadMedida int primary key,
  TipoUnidadMedida int,
  
  )