using AutoMapper;
using E_commerace.Domain.Entities.Products;
using E_commerace.Services.Abstraction.IOrderService;
using E_commerace.Services.Sepecification;
using E_commerace.Shared.Dtos.Orders;
using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities.Orders;
using E_Commerace.Domain.Exception.NotFound;
using E_Commerace.Domain.Exceptions.BadRequest;
using E_Commerace.Domain.Exceptions.NotFound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Services
{
    public class OrderService(IUnitOfWork _unitOfWork,IMapper _mapper,IBasketRepository _basketRepository) : IOrderService
    {
        public async Task<OrderResponse?> CreateOrderAsync(OrderRequest orderRequest, string UserEmail)
        {
            //get order address
            var address= _mapper.Map<Address>(orderRequest.shipToAddress);
            //get delievery method
            var deliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod,int>()
         .GetByIdAsync(orderRequest.DelievryMethodId);
            if (deliveryMethod == null) throw new DelievryMethodNotFoundException();
            //get basket from basket repo
            var basket = await _basketRepository.GetBasketAsync(orderRequest.BasketId);
            if (basket == null) throw new BasketNotFoundException(orderRequest.BasketId);
            //create order items
            var orderItems=new List<OrderItem>();
            
            foreach (var orderItem in basket.Items) {
         var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(orderItem.Id);
         
                if (product is  null) throw new ProductNotFoundException(orderItem.Id);
                if (product.Price != orderItem.Price) orderItem.Price = product.Price;

                var productItem = new ProductItemOrdered(orderItem.Id, orderItem.ProductName, orderItem.PictureUrl);
                var orderItemObj = new OrderItem(productItem, orderItem.Price, orderItem.Quantity);
                orderItems.Add(orderItemObj);
            
            }
            //calculate total price
            var totalPrice=orderItems.Sum(orderItems=>orderItems.Price*orderItems.Quantity);
          var order =new Order(UserEmail, address, orderItems, deliveryMethod, totalPrice);
            //add order in db
             _unitOfWork.GetRepository<Order, Guid>().Add(order);
            var count = await _unitOfWork.SaveChangesAsync();
            if(count <= 0)  throw new CreateOrUpdateBasketBadRequestException();
            return _mapper.Map<OrderResponse>(order);


        }

        public async Task<IEnumerable<DelieveryMethodResponse>> GetAllDelieveryMethod()
        {
            var result=  await _unitOfWork.GetRepository<DeliveryMethod, int>().GetAll();
            return _mapper.Map<IEnumerable<DelieveryMethodResponse>>(result);

        }

        public async Task<OrderResponse?> GetOrdersByIdForUserAsync(Guid orderId, string UserEmail)
        {

            var specification = new OrdersWithItemsAndDelievryMethodSpecification(orderId,UserEmail);
            var result = await _unitOfWork.GetRepository<Order, Guid>().GetAsync(specification);
            if (result == null ) throw new OrderNotFoundException(orderId);
            return _mapper.Map<OrderResponse>(result);
        }

        public async Task<IEnumerable<OrderResponse>> GetOrdersForUserAsync(string UserEmail)
        {
            var specification=new OrdersWithItemsAndDelievryMethodSpecification(UserEmail);
            var result= await _unitOfWork.GetRepository<Order,Guid>().GetAll(specification);
            return _mapper.Map<IEnumerable<OrderResponse>>(result);

        }
    }
}
