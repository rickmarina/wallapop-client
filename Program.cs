using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
                        .AddHttpClient()
                        .AddTransient<WallapopScraper>()
                        .BuildServiceProvider(); 

        
        string keywords = String.Join(" ",args[0..]); 
        System.Console.WriteLine($"Searching : {keywords}...");

        var web = serviceProvider.GetRequiredService<WallapopScraper>(); 
        var response = await web.ExtractDataFromWebAsync(new QueryModel() {keywords = keywords});

        var responseModel = JsonSerializer.Deserialize<ResponseWallapopModel>(response);

        Console.WriteLine($"Results #: {responseModel?.search_objects?.Count}");

        if (responseModel?.search_objects is not null) { 
            foreach (var w in responseModel.search_objects) {
                Console.WriteLine($"id: {w.id}");
                Console.WriteLine($"title: {w.title}");
                Console.WriteLine($"image: {w.images?.FirstOrDefault()?.small}");
                Console.WriteLine($"price: {w.price} {w.currency}");
                Console.WriteLine($"{new String('-',20)}");

            }
        }
        //Console.WriteLine($"Response: {response}");
        Console.WriteLine("end");

    }
}