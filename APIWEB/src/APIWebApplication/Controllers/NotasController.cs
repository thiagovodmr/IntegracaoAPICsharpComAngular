using APIWebApplication.Models;
using APIWebApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotaRepository _repository;
        
        public NotasController(INotaRepository notaRepository)
        {
            _repository = notaRepository;
        }
        
        [HttpGet]
        public Task<IEnumerable<Nota>> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public Task<Nota> Get(int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public Task<Nota> Post([FromBody] Nota item)
        {
            if (item == null)
            {
                throw new Exception("null value");
            }
            _repository.Create(item);
            return _repository.GetById(item.Id);
        }

        // DELETE api/notas/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var nota = await _repository.GetById(id);
            _repository.Delete(nota);
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Nota nota)
        {
            try
            {
                var notaCadastrada = await _repository.GetById(nota.Id);
                if (notaCadastrada == null)
                {
                    return BadRequest();
                }

                await _repository.Update(nota);
                return Ok();
            }
            catch(Exception e) {
                return BadRequest(e.Message);
            }
            
        }

    }
}
