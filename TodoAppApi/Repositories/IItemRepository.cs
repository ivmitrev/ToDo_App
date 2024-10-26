using TodoAppApi.Entities;

namespace TodoAppApi.Repositories;

public interface IItemRepository
{
    Task<IEnumerable<ToDoItem>> GetAllItems();
    Task<ToDoItem> GetItemById(int id);
    Task<ToDoItem> CreateItem(ToDoItem newItem);
    Task<ToDoItem> UpdateItem(int id, ToDoItem newItem);
    Task<ToDoItem> DeleteItem(int id);
}