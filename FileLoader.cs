
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace Copilot
{
    public class FileLoader
    {
        public static List<Customer> ParseCustomersFromCsv(string csv)
        {
            var customers = new List<Customer>();
            var lines = csv.Split('\n');
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var customer = new Customer
                {
                    Name = parts[0],
                    Email = parts[1],
                    Address = parts[2],
                    Country = parts[3]
                };
                customers.Add(customer);
            }
            return customers;
        }

        public static void SaveCustomersAsCsv(List<Customer> customers, string path)
        {
            var csv = new StringBuilder();
            foreach (var customer in customers)
            {
                var line = $"{customer.Name},{customer.Email},{customer.Address},{customer.Country}";
                csv.AppendLine(line);
            }

            if (customers.Count > 0)
            {
                csv.Remove(csv.Length - Environment.NewLine.Length, Environment.NewLine.Length);
            }

            File.WriteAllText(path, csv.ToString());
        }

        public static string ReadFileContent(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            return fileContent;
        }
    }
}