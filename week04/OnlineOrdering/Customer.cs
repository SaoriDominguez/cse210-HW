using System;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name ?? "";
        _address = address;
    }

    public string GetName() => _name;

    public bool IsUSA()
    {
        return _address != null && _address.IsUSA();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.ToLabelString()}";
    }
}
