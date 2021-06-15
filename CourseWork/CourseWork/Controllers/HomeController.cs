namespace CourseWork.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using CourseWork.Data.Services;
    using CourseWork.ViewModels.Index;
    using CourseWork.ViewModels;

    public class HomeController : Controller
    {
        private readonly ICardsService service;

        public HomeController(ICardsService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                RandomCards = this.service.GetRandom<IndexPageCardsViewModel>(9),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
