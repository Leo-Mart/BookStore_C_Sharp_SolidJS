using BookStore.Models.Orders;

namespace BookStore.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrderFromCreateDto(this CreateOrderDto orderDto)
        {
            return new Order
            {
                OrderStatus = orderDto.OrderStatus,
                OrderTotalCost = orderDto.OrderTotalCost,
                Items = orderDto.Items.Select(oi => oi.ToOrderItemFromOrderItemDto()).ToList()
            };
        }

        public static OrderDto ToDtoFromOrder(this Order order)
        {
            return new OrderDto
            {
                AppUserId = order.AppUserId,
                OrderStatus = order.OrderStatus,
                OrderTotalCost = order.OrderTotalCost,
                Items = order.Items.Select(oi => oi.ToOrderItemDtoFromOrderItem()).ToList()
            };
            
        }
    }
}