using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders= new List<Order>();
        List<Product> products1 = new List<Product>();
        products1.Add(new Product("Milk", 1, 2.99, 2));
        products1.Add(new Product("Bread", 2, 4.99, 1));

        Address address1 = new Address("101 1st St", "Ogden", "UT", "USA");
        Customer customer1 = new Customer("Carl Smith", address1);

        Order order1 = new Order(customer1, products1);
        
        List<Product> products2 = new List<Product>();
        products2.Add(new Product("Orange Juice", 3, 3.99, 1));
        products2.Add(new Product("Oreos", 4, 4.59, 1));

        Address address2 = new Address("3045 N fairy Ln", "Vancouver", "BC", "CA");
        Customer customer2 = new Customer("Rachel ", address2);

        Order order2 = new Order(customer2, products2);

        orders.Add(order1);
        orders.Add(order2);

        foreach(Order order in orders)
        {
            Console.WriteLine(Environment.NewLine + $"Total Cost: ${order.CalcTotal()}");
            Console.WriteLine(Environment.NewLine + $"Packing Label: {order.DisplayPackingLabel()}");
            Console.WriteLine(Environment.NewLine + $"Shipping Label: {order.DisplayShippingLabel()}");
        }
    }
}

class Product
{
    private string _name;
    private int _productID;
    private double _price;
    private int _quantity;


    public Product(string name, int productID, double price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;   
    }

    public double CalcTotalPrice()
    {
        return _price * _quantity;
    }

    public string DisplayProducts()
    {
        return $"Product: {_name}, ProductID: {_productID}";
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

    public bool InUSA()
    {
        return _address.IsInUSA();
    }

    public string DisplayInfo()
    {
        return $"Name: {_name}, Address: " + _address.DisplayAddress();
    }
    
}

class Address
{
    private string _street;
    private string _city;
    private string _state; 
    private string _country;
    private bool _inUSA;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
        
        if(country == "USA" || country == "US")
        {
            _inUSA = true;
        }
        else
        {
            _inUSA = false;
        }
    }

    public bool IsInUSA()
    {
        return _inUSA;
    }

    public string DisplayAddress()
    {
        return $"{_street}, {_city} {_state}, {_country}";
    }
}

class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;
    // private Address _address;


    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
        
        // _address = customer._address;
    }

    public double CalcTotal()
    {
        double total = 0;
        foreach(Product product in _products)
        {
            total += product.CalcTotalPrice();
        }
        if(_customer.InUSA())
        {
            total += 5;
        }
        else 
        {
            total += 35;
        }
        return total;
    }

    public string DisplayPackingLabel()
    {
        string packingLabel = "";
        foreach(Product product in _products)
        {
            packingLabel += Environment.NewLine + product.DisplayProducts();
        }
        return packingLabel;
    }

    public string DisplayShippingLabel()
    {
        return Environment.NewLine + _customer.DisplayInfo();
    }

}
