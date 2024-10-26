using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using TodoAppApi.Data;
using TodoAppApi.Entities;

namespace TodoAppApi.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ToDoAppDbContext _dbContext;
    public ItemRepository(ToDoAppDbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    
    public async Task<IEnumerable<ToDoItem>> GetAllItems()
    {
        var items = await _dbContext.items.ToListAsync();
        return items;
    }

    public async Task<ToDoItem> GetItemById(int id)
    {
        var item = await _dbContext.items.FindAsync(id);
        return item;
    }

    public async Task<ToDoItem> CreateItem(ToDoItem newItem)
    {
        if (newItem == null)
        {
            return null;
        }

        await _dbContext.items.AddAsync(newItem);
        await _dbContext.SaveChangesAsync();
        return newItem;

    }

    public async Task<ToDoItem> UpdateItem(int id, ToDoItem updatedItem)
    {
        var item = await _dbContext.items.FindAsync(id);
        if (item == null) return null;
        
        item.Text = updatedItem.Text;
        item.Completed = updatedItem.Completed;
        item.Deadline = updatedItem.Deadline;

        await _dbContext.SaveChangesAsync();
        return item;

    }

    public async Task<ToDoItem> DeleteItem(int id)
    {
        var item = await _dbContext.items.FindAsync(id);

        if (item == null)
        {
            return item;
        }
        _dbContext.items.Remove(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }
}