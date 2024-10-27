using Models.Dtos;

namespace ToDoApp.Services;

public interface IItemService
{
    Task<IEnumerable<ToDoItemDto>> GetAllItems();
    Task<ToDoItemDto> GetItemById(int id);
    Task<ToDoItemDto> CreateItem(CreateItemToDoDto createItemToDoDto);
    Task<ToDoItemDto> DeleteItem(int id);
    Task<ToDoItemDto> UpdateItem(int id, UpdateItemToDoDto updateItemToDoDto);

}