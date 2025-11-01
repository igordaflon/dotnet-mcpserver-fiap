using FiapGames.MCPServer.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace FIAP.Games.MCPServer.Clients
{
    public class JogoApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public JogoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<JogoResponse>> ObterJogosAsync(string? titulo = null)
        {
            var url = string.IsNullOrWhiteSpace(titulo) ? "jogos" : $"jogos?titulo={Uri.EscapeDataString(titulo)}";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return [];

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<JogoResponse>>(_jsonOptions);
        }

        public async Task<JogoResponse?> ObterJogoPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"jogos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<JogoResponse>(_jsonOptions);
        }

        public async Task<int?> CriarJogoAsync(JogoRequest jogo)
        {
            var response = await _httpClient.PostAsJsonAsync("jogos", jogo);

            if (!response.IsSuccessStatusCode)
                return null;

            var id = await response.Content.ReadFromJsonAsync<int>(_jsonOptions);
            return id;
        }

        public async Task<bool> AtualizarJogoAsync(int id, JogoRequest jogo)
        {
            var response = await _httpClient.PutAsJsonAsync($"jogos/{id}", jogo);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AtualizarPrecoAsync(int id, decimal novoPreco)
        {
            var response = await _httpClient.PatchAsync($"jogos/{id}/preco/{novoPreco}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ExcluirJogoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"jogos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return false;

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
