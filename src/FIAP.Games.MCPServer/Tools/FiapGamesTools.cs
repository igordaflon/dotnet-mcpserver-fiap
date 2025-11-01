using FIAP.Games.MCPServer.Clients;
using FiapGames.MCPServer.DTOs;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace FIAP.Games.MCPServer.Tools;

[McpServerToolType]
public static class FiapGamesTools
{
    [McpServerTool, Description("Busca os jogos, definindo um filtro opcional por título")]
    public static async Task<string> ObterJogos(JogoApiClient jogoApiClient,
        [Description("Filtro opcional pelo título do jogo")] string titulo)
    {
        try
        {
            var jogos = await jogoApiClient.ObterJogosAsync(titulo);
            return jogos.Count == 0
                ? "Nenhum jogo encontrado"
                : JsonSerializer.Serialize(jogos);
        }
        catch (Exception ex)
        {
            //Log
            return $"Erro ao buscar jogos: {ex.Message}";
        }
    }

    [McpServerTool, Description("Busca um jogo pelo código")]
    public static async Task<string> ObterJogoPorId(JogoApiClient jogoApiClient,
        [Description("Filtro obrigatório pelo id")] int id)
    {
        try
        {
            var jogo = await jogoApiClient.ObterJogoPorIdAsync(id);
            return jogo is null
                ? "Nenhum jogo encontrado"
                : JsonSerializer.Serialize(jogo);
        }
        catch (Exception ex)
        {
            //Log
            return $"Erro ao buscar jogo: {ex.Message}";
        }
    }

    [McpServerTool, Description("Criar/Cadastrar/Inserir um jogo")]
    public static async Task<string> CadastrarJogo(JogoApiClient jogoApiClient,
        [Description("Dados para criação do jogo")] JogoRequest jogo)
    {
        try
        {
            var id = await jogoApiClient.CriarJogoAsync(jogo);
            return id is null
                ? "Não foi possível cadastrar o jogo"
                : JsonSerializer.Serialize(jogo);
        }
        catch (Exception ex)
        {
            //Log
            return $"Erro ao cadastrar o jogo: {ex.Message}";
        }
    }

    [McpServerTool, Description("Atualizar/editar os dados de um jogo")]
    public static async Task<string> AtualizarJogo(JogoApiClient jogoApiClient,
        [Description("Código ou identificador do jogo")] int id,
        [Description("Dados para atualização de um jogo")] JogoRequest jogo)
    {
        try
        {
            var sucesso = await jogoApiClient.AtualizarJogoAsync(id, jogo);
            return sucesso
                ? "Jogo atualizado com sucesso"
                : "Não foi possível atualizar o jogo";
        }
        catch (Exception ex)
        {
            //Log
            return $"Erro ao atualizar o jogo: {ex.Message}";
        }
    }


    [McpServerTool, Description("Atualizar apenas o preço de um jogo")]
    public static async Task<string> AtualizarPrecoDoJogo(JogoApiClient jogoApiClient,
        [Description("Código ou identificador do jogo")] int id,
        [Description("Novo preço do jogo")] decimal preco)
    {
        try
        {
            var sucesso = await jogoApiClient.AtualizarPrecoAsync(id, preco);
            return sucesso
                ? "Preço do jogo atualizado com sucesso"
                : "Não foi possível atualizar o preço do jogo";
        }
        catch (Exception ex)
        {
            //Log
            return $"Erro ao atualizar o preço do jogo: {ex.Message}";
        }
    }

    [McpServerTool, Description("Excluir um jogo pelo código")]
    public static async Task<string> ExcluirJogo(JogoApiClient jogoApiClient,
        [Description("Filtro obrigatório pelo id")] int id)
    {
        try
        {
            var jogo = await jogoApiClient.ExcluirJogoAsync(id);
            return jogo
                ? "Jogo excluído com sucesso"
                : "Erro ao excluir jogo";
        }
        catch (Exception ex)
        {
            //Log
            return $"Erro ao excluir jogo: {ex.Message}";
        }
    }
}
