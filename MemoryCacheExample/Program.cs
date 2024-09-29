using System;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a MemoryCache instance
            var cache = new MemoryCache(new MemoryCacheOptions());

            // Define a cache key and value
            string cacheKey = "item1";
            string cacheValue = "This is a cached item";

            // Set the cache item
            cache.Set(cacheKey, cacheValue, TimeSpan.FromMinutes(5));

            // Retrieve the cache item
            if (cache.TryGetValue(cacheKey, out string cachedItem))
            {
                Console.WriteLine($"Cache hit: {cachedItem}");
            }
            else
            {
                Console.WriteLine("Cache miss");
            }

            // Simulate cache expiration
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(6));

            // Try retrieving the cache item again
            if (cache.TryGetValue(cacheKey, out cachedItem))
            {
                Console.WriteLine($"Cache hit: {cachedItem}");
            }
            else
            {
                Console.WriteLine("Cache miss after expiration");
            }
        }
    }
}
