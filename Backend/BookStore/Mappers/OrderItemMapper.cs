using BookStore.Models.OrderItems;

namespace BookStore.Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItemDto ToOrderItemDtoFromOrderItem(this OrderItem orderItem)
        {
            return new OrderItemDto
            {
                OrderId = orderItem.OrderId,
                BookId = orderItem.BookId,
                UnitPrice = orderItem.UnitPrice,
                Quantity = orderItem.Quantity
            };
        }

        public static OrderItem ToOrderItemFromOrderItemDto(this OrderItemDto orderItemDto)
        {
            return new OrderItem
            {
                OrderId = orderItemDto.OrderId,
                BookId = orderItemDto.BookId,
                UnitPrice = orderItemDto.UnitPrice,
                Quantity = orderItemDto.Quantity
            };
        }
    }
}