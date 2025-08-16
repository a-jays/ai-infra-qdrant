using Qdrant.Client;

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QdrantDemon
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var http = new HttpClient { BaseAddress = new Uri("http://localhost:6333/") };

            // 🔹 List all collections
            var collections = await http.GetFromJsonAsync<dynamic>("collections");
            Console.WriteLine("Collections:");
            Console.WriteLine(collections);

            // 🔹 Create a new collection (example: "demo_collection")
            var createResponse = await http.PutAsJsonAsync("collections/demo_collection_1", new
            {
                vectors = new { size = 4, distance = "Cosine" }
            });

            Console.WriteLine($"Create collection status: {createResponse.StatusCode}");

            // 🔹 Insert some points
            var insertResponse = await http.PutAsJsonAsync("collections/demo_collection_1/points", new
            {
                points = new[]
                {
                new { id = 1, vector = new float[] { 0.1f, 0.2f, 0.3f, 0.4f } },
                new { id = 2, vector = new float[] { 0.2f, 0.3f, 0.4f, 0.5f } }
            }
            });

            Console.WriteLine($"Insert points status: {insertResponse.StatusCode} \n\n");

            // 🔹 Search for nearest vector
            var searchResponse = await http.PostAsJsonAsync("collections/demo_collection_1/points/search", new
            {
                vector = new float[] { 0.2f, 0.3f, 0.4f, 0.5f },
                limit = 2
            });

            var searchResult = await searchResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Search result:");
            Console.WriteLine(searchResult);
            Console.ReadLine();
        }
    }
}
