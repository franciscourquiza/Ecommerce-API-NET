﻿using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto order) 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Client") 
            {
                if (order == null)
                {
                    return BadRequest();
                }
                string emailClient = User.Claims.SingleOrDefault(c => c.Type.Contains("nameidentifier")).Value;
                Order createdOrder= _orderService.AddOrder(order, emailClient);

                await _orderService.SaveChangesAsync();
                return Ok();


            }
            return Forbid();
        }
        [HttpGet("{id}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id); 

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetOrders() 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_orderService.GetOrders());
            return Forbid();
        }
        [HttpGet("GetPendingOrders")]
        public IActionResult GetPendingOrders() 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_orderService.GetPendingOrders());
            return Forbid();
        }
    }
}
