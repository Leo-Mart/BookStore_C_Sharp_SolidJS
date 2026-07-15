using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Models.Addresses;
using BookStore.Models.Orders;
using BookStore.Models.PaymentMethods;
using BookStore.Models.Payments;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Services
{
    public class OrderService(
        ILogger<OrderService> logger,
        IOrderRepository orderRepo,
        IPaymentMethodRepository paymentMethodRepo,
        IPaymentRepository paymentRepo,
        IAddressRepository addressRepo,
        UserManager<AppUser> userManager,
        ApplicationDbContext context,
        IBookRepository bookRepo,
        IShippingMethodRepository smRepo
    ) : IOrderService
    {
        private readonly ILogger<OrderService> _logger = logger;
        private readonly IOrderRepository _orderRepo = orderRepo;
        private readonly IPaymentMethodRepository _paymentMethodRepo = paymentMethodRepo;
        private readonly IPaymentRepository _paymentRepo = paymentRepo;
        private readonly IAddressRepository _addressRepo = addressRepo;
        private readonly IBookRepository _bookRepo = bookRepo;
        private readonly IShippingMethodRepository _smRepo = smRepo;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ApplicationDbContext _context = context;

        public async Task<Order?> CreateNewOrderForUser(CreateOrderDto order, string userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return null;
                }
                // check if the user has any addresses
                var addressesExist = await _addressRepo.CheckIfUserHasAddresses(user.Id);
                Address? savedAddress = new Address { };
                if (addressesExist)
                {
                    // if addresses exists, check if this specific incoming address exists
                    var addressExists = await _addressRepo.CheckAddressExistsByInfoAsync(
                        new Address
                        {
                            Street = order.Address.Street,
                            City = order.Address.City,
                            PostalCode = order.Address.PostalCode,
                        },
                        user.Id
                    );
                    if (addressExists)
                    {
                        // if the incoming address already exists, get that address and pass that onward
                        savedAddress = await _addressRepo.GetAddressByInfoAsync(
                            new Address
                            {
                                Street = order.Address.Street,
                                City = order.Address.City,
                                PostalCode = order.Address.PostalCode,
                            }
                        );
                    }
                    else
                    {
                        // the incoming address does not exits in the db for that user, we create a new address
                        // and add that to the db, it does not get marked as default however.
                        // The User can do this themseles in the user-page.
                        var address = new Address
                        {
                            AppUserId = user.Id,
                            Street = order.Address.Street,
                            City = order.Address.City,
                            PostalCode = order.Address.PostalCode,
                        };

                        savedAddress = await _addressRepo.CreateNewAddressAsync(address);
                    }
                }
                else
                {
                    // create the new address, mark as default and save
                    var address = new Address
                    {
                        AppUserId = user.Id,
                        Street = order.Address.Street,
                        City = order.Address.City,
                        PostalCode = order.Address.PostalCode,
                        IsDefault = true,
                    };

                    savedAddress = await _addressRepo.CreateNewAddressAsync(address);
                }

                var paymentMethod = new PaymentMethod
                {
                    AppUserId = user.Id,
                    Type = order.PaymentMethod.Type,
                    CardLastFour = order.PaymentMethod.CardLastFour,
                    CardNumber = order.PaymentMethod.CardNumber,
                    CVV = order.PaymentMethod.CVV,
                    ExpiryDate = order.PaymentMethod.ExpiryDate,
                };
                var savedPaymentMethod = await _paymentMethodRepo.CreateNewPaymentMethodAsync(
                    paymentMethod
                );

                var shippingMethod = await _smRepo.GetShippingMethodByIdentifierAsync(
                    order.ShippingMethod.Identifier
                );

                if (shippingMethod == null)
                {
                    return null;
                }

                decimal total = shippingMethod.Price;
                foreach (var item in order.Items)
                {
                    var book = await _bookRepo.GetBookByIdAsync(item.BookId);
                    total += book.Price * item.Quantity;
                }
                if (total != order.OrderTotalCost)
                {
                    order.OrderTotalCost = total;
                }
                var orderToSave = order.ToOrderFromCreateDto();
                if (savedAddress == null)
                {
                    // something went wrong, throw a 500
                    return null;
                }
                orderToSave.AddressId = savedAddress.Id;
                orderToSave.AppUserId = user.Id;
                orderToSave.PaymentMethodId = paymentMethod.Id;
                orderToSave.ShippingMethodId = shippingMethod.Id;
                var savedOrder = await _orderRepo.CreateOrderAsync(orderToSave);

                var payment = new Payment
                {
                    OrderId = savedOrder.Id,
                    PaymentMethodId = savedPaymentMethod.Id,
                    Amount = order.OrderTotalCost,
                    Status = PaymentStatus.Pending,
                    PaymentDate = new DateTime(2026, 10, 1),
                };
                var savedPayment = await _paymentRepo.CreateNewPaymentAsync(payment);

                await transaction.CommitAsync();

                return savedOrder;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Order?> CreateNewOrderForGuest(CreateOrderDto order)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var address = new Address
                {
                    Street = order.Address.Street,
                    City = order.Address.City,
                    PostalCode = order.Address.PostalCode,
                };
                var savedAddress = await _addressRepo.CreateNewAddressAsync(address);

                var paymentMethod = new PaymentMethod
                {
                    Type = order.PaymentMethod.Type,
                    CardLastFour = order.PaymentMethod.CardLastFour,
                    CardNumber = order.PaymentMethod.CardNumber,
                    CVV = order.PaymentMethod.CVV,
                    ExpiryDate = order.PaymentMethod.ExpiryDate,
                };
                var savedPaymentMethod = await _paymentMethodRepo.CreateNewPaymentMethodAsync(
                    paymentMethod
                );

                var shippingMethod = await _smRepo.GetShippingMethodByIdentifierAsync(
                    order.ShippingMethod.Identifier
                );

                if (shippingMethod == null)
                {
                    return null;
                }

                decimal total = shippingMethod.Price;
                foreach (var item in order.Items)
                {
                    var book = await _bookRepo.GetBookByIdAsync(item.BookId);
                    total += book.Price * item.Quantity;
                }
                if (total != order.OrderTotalCost)
                {
                    order.OrderTotalCost = total;
                }
                var orderToSave = order.ToOrderFromCreateDto();
                orderToSave.AddressId = address.Id;
                orderToSave.PaymentMethodId = paymentMethod.Id;
                orderToSave.ShippingMethodId = shippingMethod.Id;
                orderToSave.GuestEmail = order.GuestEmail;
                var savedOrder = await _orderRepo.CreateOrderAsync(orderToSave);

                var payment = new Payment
                {
                    OrderId = savedOrder.Id,
                    PaymentMethodId = savedPaymentMethod.Id,
                    Amount = order.OrderTotalCost,
                    Status = PaymentStatus.Pending,
                    PaymentDate = new DateTime(2026, 10, 1),
                };
                var savedPayment = await _paymentRepo.CreateNewPaymentAsync(payment);

                await transaction.CommitAsync();

                return savedOrder;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

