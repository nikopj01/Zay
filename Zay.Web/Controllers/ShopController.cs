using Microsoft.AspNetCore.Mvc;
using Zay.ApplicationCore.Interfaces;

namespace Zay.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(string keywords = "")
        {
            var listOfProducts = _productService.GetProducts(keywords);
            return View(listOfProducts);
        }

        public IActionResult Details(string id)
        {
            var selectedProduct = _productService.GetProductDetails(id);
            return View(selectedProduct);
        }

        [HttpPost]
        public IActionResult AddToChart(string productId, int quantity, string size)
        {
            return Json(new { success = true, message = "welldone" });
        }
    }
}
