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

        /// <summary>
        /// Поиск продуктов по названию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("Products/SearchProducts")]
        [HttpGet]
        public async Task<IActionResult> SearchAsync(string name)
        {
            if (!(name is null))
            {
                var findedProducts = await _products.GetByNameAsync(name);

                var result = new List<ProductViewModel>();

                foreach (var product in findedProducts)
                {
                    result.Add(_mapper.Map<ProductViewModel>(product));
                }

                return View("Products", result);
            }

            return RedirectToAction("Products");
        }

        /// <summary>
        /// Получить список всех продуктов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получить страницу создания нового продукта
        /// </summary>
        /// <returns></returns>
        [Route("Products/AddProduct")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View("AddProduct");
        }

        /// <summary>
        /// HTTP POST метод создания нового продукта
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [Route("Products/AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductViewModel newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);

            var category = await _categories.GetAsync(newProduct.Category);

            if (category == null)
            {
                var newCategory = await _categories.CreateAsync(new Category { Name = newProduct.Category });

                if (newCategory)
                {
                    category = await _categories.GetAsync(newProduct.Category);
                }
            }

            product.Category = category;

            var result = await _products.CreateAsync(product);

            if (result)
                return RedirectToAction("Products");
            else
                return RedirectToAction("Index");
        }
         
        /// <summary>
        /// Получить страницу редактирования существующего продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Products/EditProduct")]
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _products.GetByIdAsync(id);

            if (product is null)
            {
                return RedirectToAction("Products");
            }

            var result = _mapper.Map<ProductViewModel>(product);

            return View("EditProduct", result);
        }

        /// <summary>
        /// HTTP POST метод редактирования продукта
        /// </summary>
        /// <param name="updateProduct"></param>
        /// <returns></returns>
        [Route("Products/EditProduct")]
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

        /// <summary>
        /// HTTP POST метод удаления продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
