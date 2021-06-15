namespace CourseWork.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using CourseWork.Common;
    using CourseWork.Data.Services;
    using CourseWork.ViewModels.Cards;

    public class CardsController : Controller
    {
        private readonly ICardsService service;

        public CardsController(ICardsService service)
        {
            this.service = service;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CreateCardInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.service.CreateAsync(model);
            return this.RedirectToAction(nameof(this.All));
        }


        [Authorize]
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;
            var viewModel = new CardsListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                CardsCount = this.service.GetCount(),
                Cards = this.service.GetAll<CardsInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.service.AddCardToUserCollection(userId, id);

            return this.RedirectToAction(nameof(this.Collection));
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.service.RemoveCardFromUserCollection(id, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Collection()
        {
            //// var user = await this.userManager.GetUserAsync(this.User);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.service.GetById(userId);
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var card = this.service.GetById<SingleCardViewModel>(id);
            return this.View(card);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.service.GetById<EditCardInputModel>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditCardInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.service.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task <IActionResult> Delete(int id)
        {
            await this.service.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}

