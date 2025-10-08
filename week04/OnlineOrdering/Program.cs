using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== Order 1 (USA customer) =====
        var addrUSA = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        var custUSA = new Customer("Homer Simpson", addrUSA);

        var order1 = new Order(custUSA);
        order1.AddProduct(new Product("USB-C Cable", "CABL-UC-01", 7.50, 2));
        order1.AddProduct(new Product("Wireless Mouse", "MSE-WL-09", 18.99, 1));
        order1.AddProduct(new Product("Notebook A5", "NOTE-A5-02", 3.25, 3));

        // ===== Order 2 (International customer) =====
        var addrINT = new Address("Av. Reforma 100", "CDMX", "CDMX", "Mexico");
        var custINT = new Customer("Saori D.", addrINT);

        var order2 = new Order(custINT);
        order2.AddProduct(new Product("Mechanical Keyboard", "KEY-MECH-88", 59.99, 1));
        order2.AddProduct(new Product("Desk Lamp", "LAMP-DESK-12", 22.40, 2));

        // ===== Print results =====
        PrintOrder("ORDER #1 (USA)", order1);
        Console.WriteLine();
        PrintOrder("ORDER #2 (International)", order2);
    }

    static void PrintOrder(string title, Order order)
    {
        Console.WriteLine($"=== {title} ===");
        Console.WriteLine("-- Packing Label --");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine();
        Console.WriteLine("-- Shipping Label --");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"Subtotal: ${order.GetSubtotal():0.00}");
        Console.WriteLine($"Shipping: ${order.GetShippingCost():0.00}");
        Console.WriteLine($"TOTAL:    ${order.GetTotal():0.00}");
    }
}
