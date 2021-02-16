using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class ProductReader
    {
        private readonly string path = "App_Data/data.txt";

        enum Headers
        {
            Id,
            Category,
            Name,
            Description,
            Price,
            Count
        }

        public List<Product> ReadFromFile()
        {

            string[] lines = File.ReadAllLines(path);

            List<Product> result = new List<Product>();
            foreach (string line in lines)
            {
                string[] items = line.Split(',');

                Product product = new Product
                {
                    Id = Convert.ToInt32(items[(int)Headers.Id].Trim()),
                    Category = items[(int)Headers.Category].Trim(),
                    Name = items[(int)Headers.Name].Trim(),
                    Description = items[(int)Headers.Description].Trim(),
                    Price = Convert.ToDouble(items[(int)Headers.Price].Trim()),
                    Count = Convert.ToInt32(items[(int)Headers.Count].Trim())
                };

                result.Add(product);
            }

            return result;
        }

        public List<Product> ReadFromFileCategories(string[] categories)
        {
            var categoriesLowerCase = categories.Select(c => c.ToLower());
            List<Product> result = new List<Product>();
            if ((categories?.Length ?? 0) > 0)
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] items = line.Split(',');

                    Product product = new Product
                    {
                        Id = Convert.ToInt32(items[(int)Headers.Id].Trim()),
                        Category = items[(int)Headers.Category].Trim(),
                        Name = items[(int)Headers.Name].Trim(),
                        Description = items[(int)Headers.Description].Trim(),
                        Price = Convert.ToDouble(items[(int)Headers.Price].Trim()),
                        Count = Convert.ToInt32(items[(int)Headers.Count].Trim())
                    };

                    if (categoriesLowerCase.Contains(product.Category.ToLower()))
                    {
                        result.Add(product);
                    }
                }

            }

            return result;
        }
    }
}
