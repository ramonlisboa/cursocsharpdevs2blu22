using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models;
using System.Net.Http.Headers;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Services
{
    public class PokemonAPIService
    {
        private readonly HttpClient _httpClient;
        private const string URL_API_PKMN = "https://pokeapi.co/api/v2/pokemon/";

        public PokemonAPIService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Pokemons> GetPokemons()
        {
            return await Get<Pokemons>(URL_API_PKMN);
        }

        public async Task<T> Get<T>(string url)
        {
            var listHttp = await GetAsync(url);

            if (!listHttp.IsSuccessStatusCode)
                return (T)(object)url;

            return await listHttp.Content.ReadFromJsonAsync<T>();

        }

        public async Task<List<T>> GetList<T>(string url)
        {
            var listHttp = await GetAsync(url);

            if (!listHttp.IsSuccessStatusCode)
                return new List<T>();

            return await listHttp.Content.ReadFromJsonAsync<List<T>>();
            
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var getRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            return await _httpClient.SendAsync(getRequest);
        }
    }
}
