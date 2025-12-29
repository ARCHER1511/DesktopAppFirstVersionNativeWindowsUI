public class OrderService
{
    private readonly IUnitOfWork _uow;

    public OrderService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Order> GetOrderAsync(Guid id)
    {
        return await _uow.Orders.GetOrderDetailsAsync(id);
    }

    public async Task CreateOrderAsync(Order order)
    {
        await _uow.Repository<Order>().AddAsync(order);
        await _uow.SaveChangesAsync();
    }
}
//how to use the repo factory 