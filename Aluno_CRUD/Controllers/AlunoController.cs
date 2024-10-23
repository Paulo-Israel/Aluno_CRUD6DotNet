using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aluno_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> Get()
        {
            return Ok(await _context.Alunos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> Get(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return BadRequest("Aluno não registrado");
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<List<Aluno>>> AddAluno(Aluno aluno)
        {
            // Não atribua um valor ao Id aqui
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok(await _context.Alunos.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Aluno>>> UpdateAluno(int id, Aluno request)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado");

            // Atualizando os dados do aluno
            aluno.Name = request.Name;
            aluno.FirstName = request.FirstName;
            aluno.LastName = request.LastName;
            aluno.Notas = request.Notas;

            await _context.SaveChangesAsync();
            return Ok(await _context.Alunos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return Ok($"Aluno {aluno.Name} removido com sucesso");
        }
    }
}
