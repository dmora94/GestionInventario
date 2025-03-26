IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GestionInventario')
BEGIN
    CREATE DATABASE GestionInventario;
    PRINT 'Base de datos GestionInventario creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La base de datos GestionInventario ya existe.';
END;