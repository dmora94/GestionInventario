
CREATE TRIGGER [INVENTARIO].[TG_ACTUALIZARSTOCKEDICIONTRANSACCION]
ON [INVENTARIO].[TRANSACCIONES]
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Diferencias TABLE (
        IDPRODUCTO INT,
        DiferenciaStock INT,
        TIPOTRANSACCION VARCHAR(10)
    );

    INSERT INTO @Diferencias (IDPRODUCTO, DiferenciaStock, TIPOTRANSACCION)
    SELECT 
        i.IDPRODUCTO,
        CASE
            -- COMPRA: Si antes era menor, sumamos la diferencia. Si antes era mayor, restamos la diferencia.
            WHEN i.TIPOTRANSACCION = 'COMPRA' AND i.CANTIDAD > d.CANTIDAD THEN i.CANTIDAD - d.CANTIDAD
            WHEN i.TIPOTRANSACCION = 'COMPRA' AND i.CANTIDAD < d.CANTIDAD THEN -(d.CANTIDAD - i.CANTIDAD)
            -- VENTA: Si antes era mayor, sumamos la diferencia. Si antes era menor, restamos la diferencia.
            WHEN i.TIPOTRANSACCION = 'VENTA' AND i.CANTIDAD < d.CANTIDAD THEN d.CANTIDAD - i.CANTIDAD
            WHEN i.TIPOTRANSACCION = 'VENTA' AND i.CANTIDAD > d.CANTIDAD THEN -(i.CANTIDAD - d.CANTIDAD)
            ELSE 0
        END,
        i.TIPOTRANSACCION
    FROM inserted i
    INNER JOIN deleted d ON i.ID = d.ID;

    UPDATE p
    SET p.STOCK = p.STOCK + d.DiferenciaStock
    FROM [INVENTARIO].[PRODUCTOS] p
    INNER JOIN @Diferencias d ON p.ID = d.IDPRODUCTO;
END;
