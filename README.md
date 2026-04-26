# Prueba Técnica Fullstack - Limpieza y Orquestación de Horas Extras

## 📌 Descripción General

Se desarrolló una solución Fullstack para automatizar la recepción, validación, limpieza e inserción de novedades de horas extras provenientes de archivos CSV, eliminando dependencias de sistemas legacy y garantizando trazabilidad de errores.

La solución fue construida con arquitectura escalable basada en:

- **Backend:** ASP.NET Core Web API (.NET)
- **Frontend:** React + Vite
- **Base de Datos:** SQL Server
- **Acceso a Datos:** Dapper
- **Arquitectura:** Controller + Service + Repository + Unit Of Work

---

# 🚀 Arquitectura General

```text
Frontend React
     ↓
ASP.NET Core API
     ↓
Service Layer
     ↓
Repository Layer (Dapper)

Bases de datos:

CREATE TABLE Novedades_HorasExtras
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DocumentoEmpleado VARCHAR(50),
    TipoHoraExtra VARCHAR(50),
    CantidadHoras DECIMAL(10,2),
    FechaReporte DATETIME,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Novedades_HorasExtras_Error
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DocumentoEmpleado VARCHAR(50),
    TipoHoraExtra VARCHAR(50),
    CantidadHoras VARCHAR(50),
    FechaReporte VARCHAR(50),
    MotivoError VARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE OR ALTER PROCEDURE sp_InsertHoraExtra
(
    @DocumentoEmpleado VARCHAR(50),
    @TipoHoraExtra VARCHAR(50),
    @CantidadHoras DECIMAL(10,2),
    @FechaReporte DATETIME
)
AS
BEGIN
    INSERT INTO Novedades_HorasExtras
    (
        DocumentoEmpleado,
        TipoHoraExtra,
        CantidadHoras,
        FechaReporte
    )
    VALUES
    (
        @DocumentoEmpleado,
        @TipoHoraExtra,
        @CantidadHoras,
        @FechaReporte
    )
END

CREATE OR ALTER PROCEDURE sp_InsertHoraExtraError
(
    @DocumentoEmpleado VARCHAR(50),
    @TipoHoraExtra VARCHAR(50),
    @CantidadHoras VARCHAR(50),
    @FechaReporte VARCHAR(50),
    @MotivoError VARCHAR(255)
)
AS
BEGIN
    INSERT INTO Novedades_HorasExtras_Error
    (
        DocumentoEmpleado,
        TipoHoraExtra,
        CantidadHoras,
        FechaReporte,
        MotivoError
    )
    VALUES
    (
        @DocumentoEmpleado,
        @TipoHoraExtra,
        @CantidadHoras,
        @FechaReporte,
        @MotivoError
    )
END





CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Password] [varbinary](2000) NULL,
	[Salt] [varbinary](2000) NULL,
	[Tipo] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[TipoPass] [int] NOT NULL,
	[RefreshToken] [nvarchar](500) NULL,
	[TokenRestablecer] [nvarchar](2000) NULL,
	[TokenActivacion] [nvarchar](max) NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaActivacion] [datetime2](7) NULL,
	[FechaUltIngreso] [datetime2](7) NULL,
	[Rol] [int] NULL,
CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
 
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO

	INSERT INTO Usuarios (
		Nombres,
		Apellidos,
		Login,
		Password,
		Salt,
		Tipo,
		Activo,
		Email,
		TipoPass,
		RefreshToken,
		TokenRestablecer,
		TokenActivacion,
		FechaCreacion,
		FechaActivacion,
		FechaUltIngreso,
		Rol
	)
	VALUES (
		'User',
		'Token',
		'vwa-us',
		0x45C8511CC7988CEC7F4475B85D34BAD1D93BB17EAE264C5B339582FC88208FEDB412109DD978F752A81E3D6A96DC7196503C3E537A51771EFB8EB17017CCDB0E,
		0xE836A823A0E37BF564C5117C24508D886AF489A6788B72F6F14964AEAF81698EA25D09214D639D5ABFE907096D4AF619DD21FE94B30E09BABD9E0F1EC7F29FEADA0B50EECA60C50CEE768759D901952C3CA9E915BE5AD411D9BD960E63C5A90ECC0AD7EA3E27BE44A5315732414821B00462C3C4E1FC78D3757322C0D46DD507,
		1,
		1,
		'notificaciones@sistemasentry.com.co',
		1,
		'fdzZecM8HZSPh6V5GhBXCqlDgA+zY4RDDzQZEKSic7s=',
		NULL,
		NULL,
		'2021-09-30 13:28:35.4610911',
		'2021-09-30 13:28:35.4602008',
		'2025-08-08 09:29:28.6400000',
		1
	);

	    CREATE TABLE UsuariosRol (
        IdUsuariosRol INT IDENTITY(1,1) PRIMARY KEY,
        Rol VARCHAR(50)
    );

	    INSERT INTO UsuariosRol (Rol)
    VALUES ('Administrador');

     ↓
SQL Server
