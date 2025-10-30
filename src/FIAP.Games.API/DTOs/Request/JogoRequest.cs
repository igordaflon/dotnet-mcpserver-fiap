using FIAP.Games.API.Entidades;

namespace FIAP.Games.API.DTOs.Request;

public record JogoRequest(string Titulo, decimal Preco)
{
    public Jogo ConverterParaEntidade()
    {
        return new Jogo(Titulo, Preco);
    }
}
