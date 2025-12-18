using E_commerace.Services.Abstraction.IOrderService;
using E_commerace.Shared.Dtos.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Presentation.Api.Controller
{
    public class OrderController(IOrderService  _orderService): APIBaseController
    {
        //create order
        [HttpPost]

     public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
        {
            var userEmail = ""; //User.FindFirst(ClaimsTypes.Email);
            var result=await _orderService.CreateOrderAsync(orderRequest, userEmail);
            return Ok(result);
        }
        //get all delievery method
        [HttpGet]
        public async Task<IActionResult> GetAllDelieveryMethod()
        {
            var result= await _orderService.GetAllDelieveryMethod();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var userEmail = "";// User.FindFirst(ClaimsTypes.Email);
            var result = await _orderService.GetOrdersByIdForUserAsync(id, userEmail);
             
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersForUser()
        {
            var userEmail = "";// User.FindFirst(ClaimsTypes.Email);
            var result = await _orderService.GetOrdersForUserAsync( userEmail);
            return Ok(result);
        }

    }
}
