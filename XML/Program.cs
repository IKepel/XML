using System.Xml;
using System.Xml.Linq;

namespace XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car("Toyota", 25000m, "123AX"),
                new Car("BMW", 35000m, "456AS"),
                new Car("Honda", 20000m, "789RF")
            };

            SaveCollectionInXmlFile(cars);
            SetNewCarPriceByNumber("123AX", 44000m);
        }

        static void SaveCollectionInXmlFile(IEnumerable<Car> cars)
        {
            var xmlCars = new XElement("Cars",
            cars.Select(car => new XElement("Car",
                new XElement("Name", car.Name),
                new XElement("Price", car.Price),
                new XElement("Number", car.Number))));

            xmlCars.Save("Xml.xml");
            Console.WriteLine("Collection saved in Xml.xml");
        }

        static void SetNewCarPriceByNumber(string carNumber, decimal newPrice)
        {
            var carsXml = XElement.Load("Xml.xml");
            var carToUpdate = carsXml.Elements("Car").FirstOrDefault(car => car.Element("Number")?.Value.Equals(carNumber) ?? false);

            if (carToUpdate is not null)
            {
                var priceElement = carToUpdate.Element("Price");
                if (priceElement is not null)
                {
                    priceElement.Value = newPrice.ToString();
                    carsXml.Save("Xml.xml");
                    Console.WriteLine($"Price for car with number {carNumber} updated to {newPrice}");
                }
                else
                {
                    Console.WriteLine($"Price element for car with number {carNumber} not found");
                }
            }
            else
            {
                Console.WriteLine($"Car with number {carNumber} not found");
            }
        }
    }
}