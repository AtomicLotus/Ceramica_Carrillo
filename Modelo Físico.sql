/*
 * ER/Studio 8.0 SQL Code Generation
 * Company :      UTM
 * Project :      Modelo Relacional.DM1
 * Author :       ANDRE
 *
 * Date Created : Tuesday, June 20, 2017 16:46:31
 * Target DBMS : Microsoft SQL Server 2008
 */

USE master
go
CREATE DATABASE BDCarrillo
go
USE BDCarrillo
go
/* 
 * TABLE: Actividades 
 */

CREATE TABLE Actividades(
    IdActividad    int             IDENTITY(1,1),
    Nombre         varchar(50)     NULL,
    Descripcion    varchar(max)    NULL,
    FechaLimite    date            NULL,
    IdPersonal     int             NOT NULL,
    CONSTRAINT PK5 PRIMARY KEY NONCLUSTERED (IdActividad)
)
go



IF OBJECT_ID('Actividades') IS NOT NULL
    PRINT '<<< CREATED TABLE Actividades >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Actividades >>>'
go

/* 
 * TABLE: Anomalias 
 */

CREATE TABLE Anomalias(
    IdAnomalias    int             IDENTITY(1,1),
    Descripcion    varchar(max)    NOT NULL,
    Fecha          date            NOT NULL,
    IdPersonal     int             NOT NULL,
    IdProductos    int             NOT NULL,
    CONSTRAINT PK8 PRIMARY KEY NONCLUSTERED (IdAnomalias)
)
go



IF OBJECT_ID('Anomalias') IS NOT NULL
    PRINT '<<< CREATED TABLE Anomalias >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Anomalias >>>'
go

/* 
 * TABLE: Categorias 
 */

CREATE TABLE Categorias(
    idCategoria        int             IDENTITY(1,1),
    NombreCategoria    varchar(100)    NOT NULL,
    idTipoProducto     int             NOT NULL,
    CONSTRAINT PK10 PRIMARY KEY NONCLUSTERED (idCategoria)
)
go



IF OBJECT_ID('Categorias') IS NOT NULL
    PRINT '<<< CREATED TABLE Categorias >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Categorias >>>'
go

/* 
 * TABLE: Compras 
 */

CREATE TABLE Compras(
    IdCompras      int      IDENTITY(1,1),
    IdProductos    int      NOT NULL,
    Unidades       int      NOT NULL,
    Precio         float    NOT NULL,
    Total          float    NOT NULL,
    CONSTRAINT PK12 PRIMARY KEY NONCLUSTERED (IdCompras)
)
go



IF OBJECT_ID('Compras') IS NOT NULL
    PRINT '<<< CREATED TABLE Compras >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Compras >>>'
go

/* 
 * TABLE: DetalleFolio 
 */

CREATE TABLE DetalleFolio(
    IdDetalle      int      NOT NULL,
    IdFolio        int      NOT NULL,
    IdProductos    int      NOT NULL,
    Unidades       int      NOT NULL,
    Precio         float    NOT NULL,
    CONSTRAINT PK7 PRIMARY KEY NONCLUSTERED (IdDetalle)
)
go



IF OBJECT_ID('DetalleFolio') IS NOT NULL
    PRINT '<<< CREATED TABLE DetalleFolio >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE DetalleFolio >>>'
go

/* 
 * TABLE: Folio 
 */

CREATE TABLE Folio(
    IdFolio       int      NOT NULL,
    TotalVenta    float    NOT NULL,
    FechaVenta    date     NOT NULL,
    IdPersonal    int      NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (IdFolio)
)
go



IF OBJECT_ID('Folio') IS NOT NULL
    PRINT '<<< CREATED TABLE Folio >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Folio >>>'
go

/* 
 * TABLE: Personal 
 */

CREATE TABLE Personal(
    IdPersonal         int             IDENTITY(1,1),
    Nombre             varchar(50)     NOT NULL,
    Apellido           varchar(100)    NOT NULL,
    Usuario            varchar(20)     NOT NULL,
    Contrasena         varchar(20)     NOT NULL,
    Telefono           varchar(15)     NULL,
    Movil              varchar(15)     NOT NULL,
    Direccion          varchar(100)    NULL,
    FechaNacimiento    date            NULL,
    Puesto             varchar(20)     NOT NULL,
    CONSTRAINT PK2 PRIMARY KEY NONCLUSTERED (IdPersonal)
)
go



IF OBJECT_ID('Personal') IS NOT NULL
    PRINT '<<< CREATED TABLE Personal >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Personal >>>'
go

/* 
 * TABLE: Productos 
 */

CREATE TABLE Productos(
    IdProductos      int             IDENTITY(1,1),
    Descripcion      varchar(100)    NOT NULL,
    PrecioVenta      float           NOT NULL,
    PrecioMayoreo    float           NOT NULL,
    Unidades         int             NULL,
    idCategoria      int             NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (IdProductos)
)
go



IF OBJECT_ID('Productos') IS NOT NULL
    PRINT '<<< CREATED TABLE Productos >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Productos >>>'
go

/* 
 * TABLE: Solicitudes 
 */

CREATE TABLE Solicitudes(
    idSolicitudes    char(10)        NOT NULL,
    Descripcion      varchar(max)    NULL,
    Status           varchar(20)     NULL,
    IdPersonal       int             NOT NULL,
    IdProductos      int             NOT NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (idSolicitudes)
)
go



IF OBJECT_ID('Solicitudes') IS NOT NULL
    PRINT '<<< CREATED TABLE Solicitudes >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Solicitudes >>>'
go

/* 
 * TABLE: TipoProductos 
 */

CREATE TABLE TipoProductos(
    idTipoProducto    int             IDENTITY(1,1),
    NombreTipo        varchar(100)    NOT NULL,
    CONSTRAINT PK9 PRIMARY KEY NONCLUSTERED (idTipoProducto)
)
go



IF OBJECT_ID('TipoProductos') IS NOT NULL
    PRINT '<<< CREATED TABLE TipoProductos >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE TipoProductos >>>'
go

/* 
 * TABLE: Actividades 
 */

ALTER TABLE Actividades ADD CONSTRAINT RefPersonal6 
    FOREIGN KEY (IdPersonal)
    REFERENCES Personal(IdPersonal)
go


/* 
 * TABLE: Anomalias 
 */

ALTER TABLE Anomalias ADD CONSTRAINT RefPersonal4 
    FOREIGN KEY (IdPersonal)
    REFERENCES Personal(IdPersonal)
go

ALTER TABLE Anomalias ADD CONSTRAINT RefProductos5 
    FOREIGN KEY (IdProductos)
    REFERENCES Productos(IdProductos)
go


/* 
 * TABLE: Categorias 
 */

ALTER TABLE Categorias ADD CONSTRAINT RefTipoProductos14 
    FOREIGN KEY (idTipoProducto)
    REFERENCES TipoProductos(idTipoProducto)
go


/* 
 * TABLE: Compras 
 */

ALTER TABLE Compras ADD CONSTRAINT RefProductos15 
    FOREIGN KEY (IdProductos)
    REFERENCES Productos(IdProductos)
go


/* 
 * TABLE: DetalleFolio 
 */

ALTER TABLE DetalleFolio ADD CONSTRAINT RefFolio8 
    FOREIGN KEY (IdFolio)
    REFERENCES Folio(IdFolio)
go

ALTER TABLE DetalleFolio ADD CONSTRAINT RefProductos10 
    FOREIGN KEY (IdProductos)
    REFERENCES Productos(IdProductos)
go


/* 
 * TABLE: Folio 
 */

ALTER TABLE Folio ADD CONSTRAINT RefPersonal7 
    FOREIGN KEY (IdPersonal)
    REFERENCES Personal(IdPersonal)
go


/* 
 * TABLE: Productos 
 */

ALTER TABLE Productos ADD CONSTRAINT RefCategorias13 
    FOREIGN KEY (idCategoria)
    REFERENCES Categorias(idCategoria)
go


/* 
 * TABLE: Solicitudes 
 */

ALTER TABLE Solicitudes ADD CONSTRAINT RefPersonal1 
    FOREIGN KEY (IdPersonal)
    REFERENCES Personal(IdPersonal)
go

ALTER TABLE Solicitudes ADD CONSTRAINT RefProductos2 
    FOREIGN KEY (IdProductos)
    REFERENCES Productos(IdProductos)
go


