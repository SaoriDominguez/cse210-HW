using System;

public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street ?? "";
        _city = city ?? "";
        _stateProvince = stateProvince ?? "";
        _country = country ?? "";
    }

    // USA check (case-insensitive, trims spaces)
    public bool IsUSA()
    {
        return _country.Trim().ToUpper() == "USA" || _country.Trim().ToUpper() == "UNITED STATES";
    }

    // Multiline label for shipping
    public string ToLabelString()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}
