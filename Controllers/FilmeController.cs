using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme) 
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmeId), new {id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes() 
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmeId(int id) 
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null) {
                return Ok(filme);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id) 
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null) {
                filmes.Remove(filme);
                return Ok(filme);
            }
            return NotFound();
        }

    }
}