using Microsoft.AspNetCore.Mvc;
using ThirdTask.Helper;
using ThirdTask.Interfaces;
using ThirdTask.Repository;

namespace ThirdTask.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = (ProductRepository?)productRepository;
        }


        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
    }

}
