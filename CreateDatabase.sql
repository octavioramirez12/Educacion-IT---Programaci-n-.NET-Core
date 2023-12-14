CREATE TABLE Roles
(
	Id INT NOT NULL IDENTITY(1,1),
	Nombre NVARCHAR(50) NOT NULL,
	Activo BIT NOT NULL,
	PRIMARY KEY (Id)
)

CREATE TABLE Usuarios
(
	Id INT NOT NULL IDENTITY(1,1),
	Nombre NVARCHAR(50) NOT NULL,
	Apellido NVARCHAR(50) NOT NULL,
	Fecha_Nacimiento DATE NOT NULL,
	Clave NVARCHAR(MAX) NOT NULL,
	Mail NVARCHAR(50) NOT NULL,
	Id_Rol INT NOT NULL,
	Activo BIT NOT NULL,
	Codigo INT,
	PRIMARY KEY (Id),
	FOREIGN KEY (Id_Rol) REFERENCES Roles(Id)
)

CREATE TABLE Productos
(
	Id INT NOT NULL IDENTITY(1,1),
	Descripcion NVARCHAR(150) NOT NULL,
	Precio DECIMAL (18,0) NOT NULL,
	Stock INT NOT NULL,
	Imagen NVARCHAR(MAX) NOT NULL,
	Activo bit NOT NULL,
	PRIMARY KEY (Id)
)

INSERT INTO Roles (Nombre, Activo)
VALUES ('Usuario', 1)

INSERT INTO Productos (Descripcion, Precio, Stock, Imagen, Activo)
VALUES ('Buzo', 100, 100, 'asdas', 1)

INSERT INTO Usuarios (Nombre, Apellido, Fecha_Nacimiento, Clave, Mail, Id_Rol, Activo)
VALUES ('Octavio', 'Ramirez', '05-14-2000', '1234', 'octavio.ramirez.3980@gmail.com', 1, 1)