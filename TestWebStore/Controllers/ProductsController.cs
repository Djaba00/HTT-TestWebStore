using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TestWebStore.DataAccess.Repositories.Categories;
using TestWebStore.DataAccess.Repositories.Products;
using TestWebStore.Models.Entities;
using TestWebStore.Models.ViewModels;

namespace TestWebStore.Controllers
{
    public class ProductsController : Controller
    {
        private IMapper _mapper;

        IProductsRepository _products;
        ICategoriesRepository _categories;

        public ProductsController(IMapper mapper, IProductsRepository products, ICategoriesRepository categories)
        {
            _mapper = mapper;
            _products = products;
            _categories = categories;
        }

        [Route("Products/SearchProducts")]
        [HttpGet]
        public async Task<IActionResult> SearchAsync(string name)
        {
            if (!(name is null))
            {
                var findedProducts = await _products.GetByNameAsync(name);

                var result = _mapper.Map<ProductViewModel>(findedProducts);

                return Json(result);
            }

            return RedirectToAction("Products");
        }

        [Route("Products/Products")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _products.GetAllAsync();

            var result = new List<ProductViewModel>();

            foreach (var product in products)
            {
                result.Add(_mapper.Map<ProductViewModel>(product));
            }

            return View("Products", result);
        }

        [Route("Products/AddProduct")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View("AddProduct");
        }

        [Route("Products/AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductViewModel newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);

            var category = await _categories.GetAsync(newProduct.Category);

            product.Category = category;

            var result = await _products.CreateAsync(product);

            if (result)
                return RedirectToAction("Products");
            else
                return RedirectToAction("Index");
        }

        [Route("Products/EditProduct")]
        [HttpGet]
        public IActionResult EditProduct()
        {
            return View("Product/EditProduct");
        }

        [Route("EditProduct")]
        [HttpPost]
        public async Task<IActionResult> EditProductAsync(ProductViewModel updateProduct)
        {
            var product = _mapper.Map<Product>(updateProduct);

            var categury = await _categories.GetAsync(updateProduct.Category);

            product.CategoryId = categury.Id;

            var result = await _products.UpdateAsync(product);

            if (result)
                return RedirectToAction("Products");
            else
                return RedirectToAction("Index");
        }

        [Route("Products/RemoveProduct")]
        [HttpPost]
        public async Task<IActionResult> RemoveProductAsync(int id)
        {
            var removeProduct = await _products.GetByIdAsync(id);

            var result = await _products.DeleteAsync(removeProduct);

            if (result)
                return RedirectToAction("Products");
            else
                return RedirectToAction("Index");
        }
    }
}
