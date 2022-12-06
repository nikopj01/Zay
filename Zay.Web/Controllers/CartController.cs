using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Zay.ApplicationCore.Entities;
using Zay.ApplicationCore.Interfaces;
using Zay.Infrastructure.Models;

namespace Zay.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager; 
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            Cart itemCart = _cartService.GetProductsInCart(currentUser.Email);
            return View(itemCart);
        }
    }
}
