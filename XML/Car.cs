namespace XML
{
    public class Car
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Number { get; set; }

        public Car(string name, decimal price, string number)
        {
            Name = name;
            Price = price;
            Number = number;
        }
    }
}
