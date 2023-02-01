using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models.DTOAPI;
using System.Net.Http;

namespace Devs2Blu.ProjetosAula.CSharpMVCRevisao.Services
{
    public class ServiceAPI
    {
        private readonly HttpClient _httpClient;

        public ServiceAPI()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CardDTO>> GetListCards()
        {
            var objJSONResponse = await Get<GetListDataCardsDTO>(URL_API_PT);
            var listCards = objJSONResponse.Data;
            return listCards;
        }

        public async Task<List<CardDTO>> GetCardByName(string name)
        {
            var urlSearch = $"{URL_API}?name={name}";
            var objJSONResponse = await Get<GetListDataCardsDTO>(urlSearch);
            var listCards = objJSONResponse.Data;
            return listCards;
        }


        #region BaseMethods

        public async Task<T> Get<T>(string url)
        {
            var objHttp = await GetAsync(url);

            if (!objHttp.IsSuccessStatusCode)
                return (T)(object)url;

            return await objHttp.Content.ReadFromJsonAsync<T>();

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
        #endregion


        #region CONSTS

        private const string URL_API = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        private const string URL_API_PT = "https://db.ygoprodeck.com/api/v7/cardinfo.php?language=pt";

        #endregion
    }
}
