using GameStore.WebUI.Models;

namespace GameStore.WebUI.Clients
{
    public class GenresClient(HttpClient httpClient)
    {
        public async Task <Genre[]> GetGenres() =>
            await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
    }
}
