using ModelContextProtocol.Server;
using System.ComponentModel;

namespace FIAP.Games.MCPServer.Prompts;

[McpServerPromptType]
public static class FiapGamesPrompts
{
    [McpServerPrompt, Description("Prompt para criar um novo jogo com validações")]
    public static string CriarNovoJogo()
    {
        return @"Você é um assistente especializado em cadastro de jogos. 
Quando o usuário quiser criar um novo jogo, siga estos passos:

1. Solicite o título do jogo
2. Solicite a descrição
3. Solicite o gênero
4. Solicite o preço
5. Valide se todos os campos foram preenchidos
6. Use a ferramenta 'CadastrarJogo' para salvar os dados

Sempre confirme os dados antes de cadastrar.";
    }

    [McpServerPrompt, Description("Prompt para listar e filtrar jogos")]
    public static string ListarJogos()
    {
        return @"Você está ajudando o usuário a encontrar jogos.

Passos:
1. Pergunte se deseja filtrar por título ou ver todos os jogos
2. Se filtrar, use a ferramenta 'ObterJogos' com o filtro informado
3. Se não filtrar, use 'ObterJogos' sem filtro
4. Apresente os resultados de forma clara com nome, descrição e preço";
    }

    [McpServerPrompt, Description("Prompt para atualizar dados de um jogo")]
    public static string AtualizarJogo()
    {
        return @"Você está auxiliando na atualização de um jogo existente.

Processo:
1. Solicite o ID do jogo a atualizar
2. Use 'ObterJogoPorId' para buscar os dados atuais
3. Pergunte qual campo deseja atualizar
4. Confirme a alteração
5. Use a ferramenta 'AtualizarJogo' com os novos dados";
    }
}