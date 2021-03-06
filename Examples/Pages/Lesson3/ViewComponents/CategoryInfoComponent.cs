using System.Collections.Generic;
using Examples.Pages.Lesson3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Pages.Lesson3.ViewComponents
{
    public class CategoryInfoComponent3 : ViewComponent
    {
        public IViewComponentResult Invoke(string categoryNameFilter = null)
        {
            List<CategoryRepository.CategoryInfo> categoryInfos = CategoryRepository.GetCategoryInfos();

            // ReSharper disable once Mvc.ViewComponentViewNotResolved
            return View(new CategoryInfoComponent3ViewModel()
            {
                CategoryNameFilter = categoryNameFilter,
                CategoryInfos = categoryInfos
            });
        }
    }

    public class CategoryInfoComponent3ViewModel
    {
        public string CategoryNameFilter { get; set; }
        public List<CategoryRepository.CategoryInfo> CategoryInfos { get; set; }
    }
}
