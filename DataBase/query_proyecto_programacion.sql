use db_proyecto_programacion;

CREATE TABLE Movimientos (
  ID INT AUTO_INCREMENT PRIMARY KEY,
  Fecha DATETIME NOT NULL,
  Tipo ENUM('Compra', 'Venta') NOT NULL,
  CantidaMovimientosd INT NOT NULL,
  ValorUnitario DECIMAL(10,2) NULL
);

CREATE TABLE movimientos_peps (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATE NOT NULL,
    tipo VARCHAR(10) NOT NULL, -- 'Compra' o 'Venta'
    cantidad INT NOT NULL,
    valor_unitario DECIMAL(10,2)
);

SELECT * FROM Movimientos;
SELECT * FROM movimientos_peps;