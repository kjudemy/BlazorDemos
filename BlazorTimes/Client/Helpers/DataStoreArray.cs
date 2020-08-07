using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorTimes.Client.Helpers
{
    public class DataStoreArray<T> where T : class
    {
        public static async Task<bool> StoreItemArrayAsync(IJSRuntime jsRuntime, string key, T[] item)
        {
            string jsonItem = System.Text.Json.JsonSerializer.Serialize<T[]>(item);
            return await jsRuntime.InvokeAsync<bool>("datastore.storeItem", key, jsonItem);
        }
        public static async Task<bool> StoreItemAsync(IJSRuntime jsRuntime, string key, T item)
        {
            string jsonItem = System.Text.Json.JsonSerializer.Serialize<T>(item);
            return await jsRuntime.InvokeAsync<bool>("datastore.storeItem", key, jsonItem);
        }
        public static async Task<T> RetrieveItemAsync(IJSRuntime jsRuntime, string key)
        {
            string jsonItem = await jsRuntime.InvokeAsync<string>("datastore.retrieveItem", key);
            T item = null;
            if (jsonItem != null)
            {
                item = System.Text.Json.JsonSerializer.Deserialize<T>(jsonItem);
            }
            return item;
        }
        public static async Task<T[]> RetrieveItemArrayAsync(IJSRuntime jsRuntime, string key)
        {
            string jsonItem = await jsRuntime.InvokeAsync<string>("datastore.retrieveItem", key);
            T[] item = null;
            if (jsonItem != null)
            {
                item = System.Text.Json.JsonSerializer.Deserialize<T[]>(jsonItem);
            }
            return item;
        }
        public static async Task RemoveItemAsync(IJSRuntime jsRuntime, string key)
        {
            await jsRuntime.InvokeVoidAsync("datastore.removeItem", key);
        }
        public static async Task ClearAllAsync(IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync("datastore.clearAll");
        }
        public static async Task<int> GetLength(IJSRuntime jsRuntime)
        {
            return await jsRuntime.InvokeAsync<int>("datastore.getLength");
        }
        public static async Task<string> GetKeyAsync(IJSRuntime jsRuntime, int index)
        {
            return await jsRuntime.InvokeAsync<string>("datastore.getKey", index);
        }
    }
}
