
using DataTransfertObject.DTO;
using System.Text;
using System.Net.Mime;
using System.Text.Json;
using AspProject.Models;
using Mapster;
using System.Text.Json.Nodes;

namespace AspProject.Services
{
    public class CategoryService
    {
        static HttpClient httpClient = new HttpClient();

        public async Task<List<CategorieViewDTO>> GetAllCategory()
        {

            List<CategorieDTO> categories = new List<CategorieDTO>();

            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:7035/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                categories = await responseMessage.Content.ReadAsAsync<List<CategorieDTO>>();
            }

            return categories.Adapt<List<CategorieViewDTO>>();
        }

        public async Task<CategorieViewDTO> GetCategoryById(int id)
        {

            CategorieDTO categorie = new CategorieDTO();

            string url = "https://localhost:7035/api/Category/" + id;

            HttpResponseMessage responseMessage = await httpClient.GetAsync(url); ;
            if (responseMessage.IsSuccessStatusCode)
            {
                categorie = await responseMessage.Content.ReadAsAsync<CategorieDTO>();
            }

            return categorie.Adapt<CategorieViewDTO>();
        }
        public async Task<string> CreateCategorie(CategorieViewDTO categorieViewDTO)
        {
            //CategorieDTO categorieDTO = categorie;
            //var categorieSerial = categorieDTO; 
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,

                RequestUri = new Uri("https://localhost:7035/api/Category/"),

                Content = new StringContent(JsonSerializer.Serialize(categorieViewDTO.Adapt<CategorieDTO>()),Encoding.UTF8,MediaTypeNames.Application.Json),
            };  

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> EditCategorie(CategorieViewDTO categorieViewDTO)
        {
            //CategorieDTO categorieDTO = categorie;
            //var categorieSerial = categorieDTO; 
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,

                RequestUri = new Uri("https://localhost:7035/api/Category/"),

                Content = new StringContent(JsonSerializer.Serialize(categorieViewDTO.Adapt<CategorieDTO>()), Encoding.UTF8, MediaTypeNames.Application.Json),
            };

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteCategorie(int id)
        {
            string url = "https://localhost:7035/api/Category/" + id;

            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(url);

            return await responseMessage.Content.ReadAsStringAsync();
        }

    }
}
