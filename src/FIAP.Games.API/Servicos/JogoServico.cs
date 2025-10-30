using FIAP.Games.API.Data.Contexts;
using FIAP.Games.API.Entidades;
using FIAP.Games.API.Interfaces;

namespace FIAP.Games.API.Servicos;

public class JogoServico : IJogoServico
{
    private readonly FiapGamesDbContext _context;

    public JogoServico(FiapGamesDbContext context)
    {
        _context = context;
    }

    public List<Jogo> ObterJogos(string titulo)
    {
        return _context.Jogos
            .Where(p => string.IsNullOrWhiteSpace(titulo) || p.Titulo.Contains(titulo))
            .ToList();
    }

    public Jogo? ObterPorId(int id)
    {
        return _context.Jogos
            .FirstOrDefault(p => p.Id == id);
    }

    public int Criar(Jogo jogo)
    {
        _context.Jogos.Add(jogo);
        _context.SaveChanges();
        return jogo.Id;
    }

    public void Atualizar(Jogo jogoOriginal, Jogo jogoAlteracoes)
    {
        jogoOriginal.AtualizarDados(jogoAlteracoes.Titulo, jogoAlteracoes.Preco);
        _context.SaveChanges();
    }

    public void AtualizarPreco(Jogo jogoOriginal, decimal preco)
    {
        jogoOriginal.AlterarPreco(preco);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var jogo = ObterPorId(id);
        if (jogo == null)
            throw new ArgumentException("O jogo com o identificador informado não existe", "id");

        _context.Jogos.Remove(jogo);
        _context.SaveChanges();
    }
}
