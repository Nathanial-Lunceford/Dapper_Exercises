// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using SQL_Exercise;

//^^^^MUST HAVE USING DIRECTIVES^^^^




internal class Project
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        string connString = config.GetConnectionString("DefaultConnection");
        IDbConnection conn = new MySqlConnection(connString);

        var repo = new DepartmentRepository(conn);
        var departments = repo.GetAllDepartments();

        /*foreach(var dept in departments)
        {
            Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
        }*/

        var productRepo = new ProductRepository(conn);
        var products = productRepo.GetAllProducts();


        Console.WriteLine("Enter your own product name, price, and ID in separate lines");

        Console.WriteLine("Enter the product name");
        string customName = Console.ReadLine();

        Console.WriteLine("Enter the price");
        double customPrice = Double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the product ID");
        int customProdID = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the Category ID between 1 and 5");
        int customCatID = Convert.ToInt32(Console.ReadLine());

        productRepo.CreateProduct(customName, customPrice, customProdID, customCatID);

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.Name}, {prod.Price}, {prod.ProductID} ");
        }
    }
}