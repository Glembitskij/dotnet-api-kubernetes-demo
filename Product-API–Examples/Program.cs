using Product_API_Examples.Models;
using System.Net.Http.Json;

HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:5000/") };

// Get all products
var products = await httpClient.GetFromJsonAsync<List<Product>>("api/products");

foreach (var product in products!)
{
    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
}

// Update a product

HttpResponseMessage response = await httpClient.PutAsync("api/products/1", JsonContent.Create(new Product
{
    Id = 1,
    Name = "Updated Product",
    Price = 19.99m,
    Stock = 15
}));

Console.WriteLine(response.StatusCode);