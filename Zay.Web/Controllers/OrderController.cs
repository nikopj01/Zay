using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zay.ApplicationCore.Entities;
using Zay.ApplicationCore.Interfaces;
using Zay.Infrastructure.Models;
using Zay.Infrastructure.Services;

namespace Zay.Web.Controllers
{
    public class OrderController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public OrderController(UserManager<ApplicationUser> userManager, IOrderService orderService,
            IMapper mapper, ICartService cartService)
        {
            _userManager = userManager;
            _orderService = orderService;   
            _mapper = mapper;
            _cartService = cartService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var itemOrder = _orderService.GetOrders(currentUser.Email);
            return View(itemOrder);
        }

        [Authorize]
        public async Task<IActionResult> AddOrder()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            Cart itemCart = _cartService.GetProductsInCart(currentUser.Email);
            itemCart._id = String.Empty;
            var result = _mapper.Map<Cart, Order>(itemCart);
            _orderService.SaveOrder(result);
            return RedirectToAction("Index");
        }
    }
}
