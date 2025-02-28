using Microsoft.AspNetCore.Mvc;
using FoodDeliveryApp.Models;
using FoodDeliveryApp.ViewModels;
using FoodDeliveryApp.Data;
using System;

namespace FoodDeliveryApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult MakePayment(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payment = new Payment
                {
                    OrderId = model.OrderId,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber,
                    ProductName = model.ProductName,
                    Price = model.Price,
                    AmountPaid = model.AmountPaid,
                    PaymentOption = model.PaymentOption,
                    PaymentStatus = "Completed", // Set to "Pending" or "Completed" based on logic
                    PaymentDate = DateTime.Now
                };

                _context.Payments.Add(payment);

                // Update order status after successful payment
                var order = _context.Orders.Find(model.OrderId);
                if (order != null)
                {
                    order.Status = OrderStatus.Accepted; // Update order status
                }

                _context.SaveChanges();

                return RedirectToAction("PaymentSuccess");
            }

            return View("MakePayment", model);
        }

        //[HttpPost]
        //public IActionResult ProcessPayment(PaymentViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var payment = new Payment
        //        {
        //            UserName = model.UserName,
        //            PhoneNumber = model.PhoneNumber,
        //            ProductName = model.ProductName,
        //            Price = model.Price,
        //            PaymentOption = model.PaymentOption,
        //            PaymentDate = DateTime.Now
        //        };

        //        _context.Payments.Add(payment);
        //        _context.SaveChanges();

        //        return RedirectToAction("PaymentSuccess");
        //    }

        //    // If validation fails, return to the form with the model data
        //    return View("MakePayment", model);
        //}

        //public IActionResult PaymentSuccess()
        //{
        //    return View();
        //}

    }
}
