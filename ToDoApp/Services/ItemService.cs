using System.Net.Http.Json;
using Models.Dtos;

namespace ToDoApp.Services;

public class ItemService : IItemService
{
    private readonly HttpClient _httpClient;

    public ItemService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<ToDoItemDto>> GetAllItems()
    {
        try
        {
            var items = await this._httpClient.GetFromJsonAsync<IEnumerable<ToDoItemDto>>("api/items");
            items.Reverse();
            return items;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);   
            throw;
        }
    }

    public async Task<ToDoItemDto> GetItemById(int id)
    {
        try
        {
            var item = await _httpClient.GetFromJsonAsync<ToDoItemDto>($"api/items/{id}");
            return item;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
    public async Task<ToDoItemDto> CreateItem(CreateItemToDoDto createItemToDoDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/items", createItemToDoDto);
            response.EnsureSuccessStatusCode();
            
            var createdItem = await response.Content.ReadFromJsonAsync<ToDoItemDto>();

            return createdItem;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ToDoItemDto> DeleteItem(int id)
    {
        try
        {
            var itemToDelete = await _httpClient.DeleteFromJsonAsync<ToDoItemDto>($"api/items/{id}");
            if (itemToDelete == null)
            {
                throw new Exception("Not found");
            }
            return itemToDelete;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<ToDoItemDto> UpdateItem(int id, UpdateItemToDoDto updateItemToDoDto)
    {
        try
        {
            var response = await _httpClient.PatchAsJsonAsync($"api/items/{id}",updateItemToDoDto);
            response.EnsureSuccessStatusCode();
            var updatedItem = await response.Content.ReadFromJsonAsync<ToDoItemDto>();
            return updatedItem;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}