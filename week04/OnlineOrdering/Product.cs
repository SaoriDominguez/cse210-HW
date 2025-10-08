using System;

public class Product
{
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        if (pricePerUnit < 0) throw new ArgumentException("Price per unit cannot be negative.");
        if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.");

        _name = name ?? "";
        _productId = productId ?? "";
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public double GetLineTotal()
    {
        return _pricePerUnit * _quantity;
    }

    public string GetPackingLine()
    {
        // e.g., "A123 — USB-C Cable (x2)"
        return $"{_productId} — {_name} (x{_quantity})";
    }

    // Optional getters/setters if needed later:
    public string GetName() => _name;
    public string GetProductId() => _productId;
    public int GetQuantity() => _quantity;
    public double GetPricePerUnit() => _pricePerUnit;

    public void SetQuantity(int quantity)
    {
        if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.");
        _quantity = quantity;
    }
}
