using FIAP.Games.API.DTOs.Request;
using FIAP.Games.API.Entidades;
using FIAP.Games.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Games.API.Controllers;

[ApiController]
[Route("/api/jogos")]
public class JogoController : ControllerBase
{
    private readonly IJogoServico _jogoServico;

    public JogoController(IJogoServico jogoServico)
    {
        _jogoServico = jogoServico;
    }

    [HttpGet]
    public ActionResult<List<Jogo>> Obterjogos(string? titulo)
    {
        var jogos = _jogoServico.ObterJogos(titulo);
        if (jogos == null || jogos.Count == 0)
            return NoContent();

        return Ok(jogos);
    }

    [HttpGet("{id}")]
    public ActionResult<Jogo> ObterPorId(int id)
    {
        var jogo = _jogoServico.ObterPorId(id);
        if (jogo == null)
            return NotFound();

        return Ok(jogo);
    }

    [HttpPost]
    public ActionResult Criarjogo(JogoRequest jogo)
    {
        var jogoEntidade = jogo.ConverterParaEntidade();
        var id = _jogoServico.Criar(jogoEntidade);
        return CreatedAtAction(nameof(ObterPorId), new { Id = id }, id);
    }

    [HttpPut("{id}")]
    public ActionResult Atualizarjogo(int id, JogoRequest jogo)
    {
        var jogoOriginal = _jogoServico.ObterPorId(id);
        if (jogoOriginal == null)
            return NotFound();

        var jogoAlteracoes = jogo.ConverterParaEntidade();
        _jogoServico.Atualizar(jogoOriginal, jogoAlteracoes);
        return NoContent();
    }

    [HttpPatch("{id}/preco/{preco}")]
    public ActionResult AtualizarPrecoJogo(int id, decimal preco)
    {
        var jogoOriginal = _jogoServico.ObterPorId(id);
        if (jogoOriginal == null)
            return NotFound();

        _jogoServico.AtualizarPreco(jogoOriginal, preco);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public ActionResult Excluirjogo(int id)
    {
        try
        {
            _jogoServico.Remover(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            if (ex.ParamName.Equals("id"))
                return NotFound();

            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = ex.Message });
        }
    }
}
