using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cocktails.Model;
using Cocktails.Client.ViewModels;

namespace Cocktails.Client.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CocktailsController> _logger;

        public CocktailsController(
            IHttpClientFactory httpClientFactory,
            ILogger<CocktailsController> logger)
        {
            _httpClientFactory = httpClientFactory 
                ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get, "/api/cocktails/");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var cocktails = await JsonSerializer
                    .DeserializeAsync<List<CocktailWithoutIngredients>>(responseStream, options);
                
                return View(new CocktailsIndexViewModel(cocktails 
                    ?? new List<CocktailWithoutIngredients>()));
            }
        }

        public async Task<IActionResult> EditCocktail(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get, $"/api/cocktails/{id}?includeIngredients=true");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var deserializedCocktail = await JsonSerializer
                    .DeserializeAsync<Cocktail>(responseStream, options);

                if (deserializedCocktail == null)
                {
                    throw new Exception("Deserialized cocktail must not be null.");
                }

                var ingredientNames = deserializedCocktail.Ingredients
                    .Select(x => x.Name).ToList();

                var editCocktailViewModel = new EditCocktailViewModel()
                {
                    Id = deserializedCocktail.Id,
                    Name = deserializedCocktail.Name,
                    Description = deserializedCocktail.Description!,
                    Ingredients = string.Join(", ", ingredientNames)
            };

                return View(editCocktailViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCocktail(EditCocktailViewModel editCocktailViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // create an CocktailForUpdate instance
            var cocktailForUpdate = new CocktailForUpdate();
            cocktailForUpdate.Id = editCocktailViewModel.Id;
            cocktailForUpdate.Name = editCocktailViewModel.Name;
            cocktailForUpdate.Description = editCocktailViewModel.Description;

            string[]? values = editCocktailViewModel.Ingredients?.Split(',')
                .Select(sValue => sValue.Trim()).ToArray();

            if (values != null)
            {
                foreach (var item in values)
                {
                    cocktailForUpdate.Ingredients
                        .Add(new IngredientWithoutCocktails { Name = item });
                }
            }

            // serialize it
            var serializedCocktailForUpdate = JsonSerializer.Serialize(cocktailForUpdate);

            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Put, $"/api/cocktails/{editCocktailViewModel.Id}")
            {
                Content = new StringContent(
                    serializedCocktailForUpdate,
                    System.Text.Encoding.Unicode,
                    "application/json")
            };

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCocktail(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Delete, $"/api/cocktails/{id}");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }

        public IActionResult AddCocktail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCocktail(AddCocktailViewModel addCocktailViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // create a CocktailForCreation instance
            var cocktailForCreation = new CocktailForCreation();
            cocktailForCreation.Name = addCocktailViewModel.Name;
            cocktailForCreation.Description = addCocktailViewModel.Description;
            
            string[]? values = addCocktailViewModel.Ingredients?.Split(',')
                .Select(sValue => sValue.Trim()).ToArray();

            if (values != null) 
            {
                foreach (var item in values)
                {
                    cocktailForCreation.Ingredients
                        .Add(new IngredientWithoutCocktails { Name = item });
                }
            }

            // serialize it
            var serializedCocktailForCreation = JsonSerializer.Serialize(cocktailForCreation);

            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Post, $"/api/cocktails")
            {
                Content = new StringContent(
                    serializedCocktailForCreation,
                    System.Text.Encoding.Unicode,
                    "application/json")
            };

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
