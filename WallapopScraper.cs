using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

public class WallapopScraper
{
    private readonly IHttpClientFactory _httpClientFactory;

    private Dictionary<string, string> HEADERS = new() {
        {"Accept", "application/json, text/plain, */*"},
        {"Cache-Control", "no-cache"},
        {"Connection", "keep-alive"},
        {"DNT", "1"},
        {"DeviceOS", "0"},
        {"Origin", "https://es.wallapop.com"},
        {"Pragma", "no-cache"},
        {"Referer", "https://es.wallapop.com/"},
        {"Sec-Fetch-Dest", "empty"},
        {"Sec-Fetch-Mode", "cors"},
        {"Sec-Fetch-Site", "same-site"},
        {"sec-ch-ua-mobile", "?0"},
        {"sec-ch-ua-platform", "\"Windows\""}
    };

    private const string URL = "https://api.wallapop.com/api/v3/general/search";

    public WallapopScraper(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> ExtractDataFromWebAsync(QueryModel query)
    {

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            foreach (var kv in HEADERS) 
                httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);

            string queryEncoded = query.BuildQuery();
            System.Console.WriteLine($"Query: {queryEncoded}");

            var response = await httpClient.GetAsync($"{URL}{queryEncoded}");

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();
                return html;
            }
            else
            {
                Console.WriteLine("Error al hacer la solicitud HTTP. Código de estado: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores, puedes registrarlos o lanzar una excepción personalizada según tus necesidades.
            Console.WriteLine("Error: " + ex.Message);
        }

        // Si ocurre un error o no se puede extraer la información, puedes devolver un valor predeterminado o nulo.
        return string.Empty;
    }

    
}
