using GameStore.WebUI.Models;

namespace GameStore.WebUI.Clients
{
    public class GamesClient(HttpClient httpClient)
    {
        public async Task<GameSummary[]> GetGames() => 
            await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

        public async Task AddGame(GameDetails game) =>
            await httpClient.PostAsJsonAsync("games", game);


        public async Task<GameDetails> GetGame(int id) =>
            await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Could not find game!");


        public async Task UpdateGame(GameDetails updatedGame) =>
            await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);


        public async Task DeleteGame(int id) =>
            await httpClient.DeleteAsync($"games/{id}");
    }
}
