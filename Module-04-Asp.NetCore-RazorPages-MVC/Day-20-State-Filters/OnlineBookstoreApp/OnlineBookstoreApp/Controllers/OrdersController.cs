using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreApp.Extensions;
using OnlineBookstoreApp.Filters;
using OnlineBookstoreApp.Models;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Route: /Orders/Summary
        public IActionResult Summary()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            if (cart.Count == 0)
            {
                TempData["Error"] = "Your cart is empty. Please add books to your cart before checking out.";
                return RedirectToPage("/Cart/Index");
            }

            decimal total = 0;
            foreach (var item in cart)
            {
                total += item.Book.Price * item.Quantity;
            }

            ViewBag.Total = total;
            return View(cart);
        }

        // Route: /Orders/PlaceOrder (POST)
        [HttpPost]
        public IActionResult PlaceOrder(string customerName)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            if (cart.Count == 0)
            {
                return RedirectToPage("/Cart/Index");
            }

            decimal total = 0;
            foreach (var item in cart)
            {
                total += item.Book.Price * item.Quantity;
            }

            var order = new Order
            {
                CustomerName = customerName,
                Items = cart,
                TotalAmount = total,
                OrderDate = DateTime.Now
            };

            _orderRepository.Add(order);

            // Clear cart from session
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Confirmation", new { id = order.Id });
        }

        // Route: /Orders/Confirmation/{id:int}
        public IActionResult Confirmation(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} was not found.");
            }
            return View(order);
        }
    }
}
