using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace FIAP.Games.MCPServer.Resources;

[McpServerResourceType]
public static class FiapGamesResources
{
    [McpServerResource, Description("Guia de uso da API de jogos")]
    public static string GuiaApiJogos()
    {
        return @"# Guia de Uso - API de Jogos

## Endpoints Disponíveis

### 1. Listar Jogos
- **Tool**: ObterJogos
- **Parâmetro**: titulo (opcional)
- **Retorno**: Lista de jogos em JSON

### 2. Buscar Jogo por ID
- **Tool**: ObterJogoPorId
- **Parâmetro**: id (obrigatório)
- **Retorno**: Dados do jogo

### 3. Criar Jogo
- **Tool**: CadastrarJogo
- **Parâmetro**: Objeto JogoRequest com título, descrição, gênero e preço
- **Retorno**: ID do jogo criado

### 4. Atualizar Jogo
- **Tool**: AtualizarJogo
- **Parâmetro**: id e dados atualizados
- **Retorno**: Confirmação de sucesso

## Modelos de Dados

### JogoRequest
{ ""titulo"": ""Título do Jogo"", ""descricao"": ""Descrição"", ""genero"": ""Ação"", ""preco"": 59.90 }";
    }
}