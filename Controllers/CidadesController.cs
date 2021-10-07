using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSS_Visual.Data;
using PSS_Visual.Models;

namespace PSS_Visual.Controllers
{
    [Route("api/cidades")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        public CidadesController(ApplicationDbContext context) => _context = context;

        // GET: api/Cidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> GetCidades()
        {
            return await _context.Cidades.ToListAsync();
        }

        // GET: api/Cidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetCidade(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // PUT: api/Cidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade(int id, Cidade cidade)
        {
            try
            {
                if (id != cidade.ID) return BadRequest();

                _context.Entry(cidade).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return NoContent();
        }

        // POST: api/Cidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cidade>> PostCidade(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidade", new { id = cidade.ID }, cidade);
        }

        // DELETE: api/Cidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        bool CidadeExists(int id) => _context.Cidades.Any(x => x.ID == id);
        bool CidadeExists(Cidade cidade) => _context.Cidades.Any(x => x.Descricao == cidade.Descricao && x.UF == cidade.UF);
    }
}
