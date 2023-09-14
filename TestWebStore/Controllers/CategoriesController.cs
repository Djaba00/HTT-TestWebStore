using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestWebStore.DataAccess.Repositories.Categories;
using TestWebStore.DataAccess.Repositories.Products;
using TestWebStore.Models.ViewModels;

namespace TestWebStore.Controllers
{
    public class CategoriesController : Controller
    {
        private IMapper _mapper;

        IProductsRepository _products;
        ICategoriesRepository _categories;

        public CategoriesController(IMapper mapper, IProductsRepository products, ICategoriesRepository categories)
        {
            _mapper = mapper;
            _products = products;
            _categories = categories;
        }

        [Route("Categories/SearhCategories")]
        [HttpGet]
        public async Task<IActionResult> SearchAsync(string name)
        {
            if (!(name is null))
            {
                var findedCategories = await _products.GetByNameAsync(name);

                var result = _mapper.Map<CategoryViewModel>(findedCategories);

                return Json(result);
            }

            return RedirectToAction("Categories");
        }

        [Route("Categories/Categories")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _categories.GetAllAsync();

            var result = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                result.Add(_mapper.Map<CategoryViewModel>(category));
            }

            return Json(result);
        }
    }
}
