using Models.Dtos;
using TodoAppApi.Entities;

namespace TodoAppApi.Mappers;

public static class DtoMapper
{
    public static IEnumerable<ToDoItemDto> FromItemToItemDtoCollection(this IEnumerable<ToDoItem> items)
    {
        return items.Select(x => x.FromItemToItemDto()).ToList();
    }

    public static ToDoItemDto FromItemToItemDto(this ToDoItem item)
    {
        return new ToDoItemDto()
        {
            Id = item.Id,
            Text = item.Text,
            Deadline = item.Deadline,
            Completed = item.Completed
        };
    }

    public static ToDoItem FromItemCreateToItem(this CreateItemToDoDto createItemToDoDto)
    {
        return new ToDoItem()
        {
            Text = createItemToDoDto.Text,
            Deadline = createItemToDoDto.Deadline,
            Completed = false
        };
    }

    public static ToDoItem FromItemUpdateToItem(this UpdateItemToDoDto updateItemToDoDto)
    {
        return new ToDoItem()
        {
            Text = updateItemToDoDto.Text,
            Deadline = updateItemToDoDto.Deadline,
            //Completed = updateItemToDoDto.Completed
        };
    }

}