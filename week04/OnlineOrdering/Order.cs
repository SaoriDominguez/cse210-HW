using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product p)
    {
        if (p != null) _products.Add(p);
    }

    public double GetSubtotal()
    {
        double sum = 0;
        foreach (var p in _products)
        {
            sum += p.GetLineTotal();
        }
        return sum;
    }

    public double GetShippingCost()
    {
        // USA: $5, International: $35 (one-time)
        return _customer.IsUSA() ? 5.0 : 35.0;
    }

    public double GetTotal()
    {
        return GetSubtotal() + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        // One line per product: "id — name (xqty)"
        var sb = new StringBuilder();
        foreach (var p in _products)
        {
            sb.AppendLine(p.GetPackingLine());
        }
        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}
