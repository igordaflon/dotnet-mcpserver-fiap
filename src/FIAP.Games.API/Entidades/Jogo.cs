using FIAP.Games.API.Entidades.Base;

namespace FIAP.Games.API.Entidades;

public class Jogo : Entity
{
    public string Titulo { get; private set; }
    public decimal Preco { get; private set; }

    public Jogo(string titulo, decimal preco)
    {
        Titulo = titulo;
        Preco = preco;
    }

    public void AtualizarDados(string titulo, decimal preco)
    {
        Titulo = titulo;
        Preco = preco;
    }

    public void AlterarPreco(decimal preco)
    {
        Preco = preco;
    }
}
