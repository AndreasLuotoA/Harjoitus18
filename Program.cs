
namespace Copilot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Matti", Email = "matti@example.com", Address = "Osoite 1", Country = "Suomi" },
                new Customer { Name = "Pulla", Email = "Pulla@example.com", Address = "Osoite 2", Country = "Ruotsi" },
                new Customer { Name = "Kissa", Email = "Kissa@example.com", Address = "Osoite 3", Country = "Norja" },
                new Customer { Name = "Koira", Email = "Koira@example.com", Address = "Osoite 4", Country = "Peru" }
            };

            FileLoader.SaveCustomersAsCsv(customers, @"c:\temp\test.txt");

            Console.WriteLine("Asiakasoliot tallennettu tiedostoon.");

            Console.WriteLine("Paina 'a' ladataksesi asiakkaat tiedostosta.");
            var key = Console.ReadKey();
            if (key.KeyChar != 'a')
            {
                return;
            }

            var filePath = @"C:\temp\test.txt";
            var fileContent = FileLoader.ReadFileContent(filePath);
            var customers2 = FileLoader.ParseCustomersFromCsv(fileContent);

            foreach (var customer in customers2)
            {
                Console.WriteLine($"Name: {customer.Name} Email: {customer.Email} Address: {customer.Address} Country: {customer.Country}");
            }
        }
    }
}
