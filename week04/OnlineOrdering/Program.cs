using System;
using System.Collections.Generic;
using System.Globalization;

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public string GetAddressLabel()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetAddressLabel()}";
    }
}

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public Product(string name, string productId, double price)
        : this(name, productId, price, 1)
    {
    }

    public Product(string name, string productId, string price, int quantity)
        : this(name, productId, double.Parse(price, CultureInfo.InvariantCulture), quantity)
    {
    }

    public Product(string name, string productId, string price)
        : this(name, productId, double.Parse(price, CultureInfo.InvariantCulture), 1)
    {
    }

    public string Name => _name;
    public string ProductId => _productId;
    public int Quantity => _quantity;

    public double GetTotalPrice()
    {
        return _price * _quantity;
    }
}

class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string GetPackingLabel()
    {
        string output = "Packing Label:\n";
        foreach (Product product in _products)
        {
            output += $"- {product.Name} ({product.ProductId}) x{product.Quantity}\n";
        }
        return output.TrimEnd();
    }

    public string GetPackingLable()
    {
        return GetPackingLabel();
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetShippingLabel();
    }

    public string GetShippingLable()
    {
        return GetShippingLabel();
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }
        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address(
            "123 Main Street",
            "Seattle",
            "Washington",
            "USA");

        Customer customer = new Customer("John Smith", address);

        Order order = new Order(customer);
        order.AddProduct(new Product("Laptop", "L001", 1));

        Order order1 = new Order(customer);
        order1.AddProduct(new Product("Mouse", "M001", 2));
        order1.AddProduct(new Product("Keyboard", "K001", 1));

        Address address2 = new Address(
            "45 Queen Street",
            "Auckland",
            "Auckland",
            "New Zealand");

        Customer customer2 = new Customer("Sarah Williams", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Headphones", "H004", 75.00, 1));
        order2.AddProduct(new Product("USB Cable", "U005", "12.50", 3));
        order2.AddProduct(new Product("Phone Stand", "P006", "20.00", 2));

        Console.WriteLine(order1.GetPackingLable());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLable());
        Console.WriteLine($"Total cost: ${order1.GetTotalCost():0.00}");

        Console.WriteLine("\n============================");

        Console.WriteLine(order2.GetPackingLable());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLable());
        Console.WriteLine($"TotalCost:${order2.GetTotalCost():0.00}");
    }
}
