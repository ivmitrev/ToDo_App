using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using TodoAppApi.Entities;
using TodoAppApi.Mappers;
using TodoAppApi.Repositories;

namespace TodoAppApi.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemController(IItemRepository _itemRepository)
    {
        this._itemRepository = _itemRepository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetAllItems()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var items = await _itemRepository.GetAllItems();
        if (items == null)
        {
            return NotFound();
        }

        var itemDtos = items.FromItemToItemDtoCollection();
        return Ok(itemDtos);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ToDoItemDto>> GetItemById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var item = await _itemRepository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }

        var itemDto = item.FromItemToItemDto();
        return Ok(itemDto);
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItemDto>> CreateItem([FromBody] CreateItemToDoDto newItemCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newItem = newItemCreateDto.FromItemCreateToItem();
        await _itemRepository.CreateItem(newItem);
        if (newItem == null)
        {
            return BadRequest("Unable to create item.");
        }
        var newItemDto = newItem.FromItemToItemDto();
        return Ok(newItemDto);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ToDoItemDto>> DeleteItem([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var itemToDelete = await _itemRepository.DeleteItem(id);
        if (itemToDelete == null)
        {
            return BadRequest();
        }

        var itemToDeleteDto = itemToDelete.FromItemToItemDto();
        return Ok(itemToDeleteDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<ToDoItemDto>> UpdateItem([FromRoute] int id,[FromBody] UpdateItemToDoDto updateItem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var itemToUpdate = updateItem.FromItemUpdateToItem();
        itemToUpdate = await _itemRepository.UpdateItem(id, itemToUpdate);
        if (itemToUpdate == null)
        {
            return NotFound();
        }
        
        
        return Ok(itemToUpdate);
    }


}