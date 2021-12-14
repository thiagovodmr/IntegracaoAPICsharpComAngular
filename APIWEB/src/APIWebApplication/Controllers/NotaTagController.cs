using APIWebApplication.Models;
using APIWebApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaTagController : ControllerBase
    {
        private readonly INotaTagRepository _notaTagRepository;

        public NotaTagController(INotaTagRepository notaTagRepository)
        {
            _notaTagRepository = notaTagRepository;
        }

        [HttpGet]
        public Task<IEnumerable<NotaTag>> Get()
        {
            return _notaTagRepository.GetAll();
        }

        [HttpGet("{notaId:int}")]
        public Task<IEnumerable<JoinNotaTag>> Get(int notaId)
        {
            return _notaTagRepository.GetByNotaId(notaId);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JObject items)
        {
            try
            {
                ICollection<Tag> tags = items["tags"].ToObject<ICollection<Tag>>();
                var notaId = items["notaId"].ToObject<int>();

                await _notaTagRepository.AssociarTags(notaId, tags);

                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // DELETE api/notas/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _notaTagRepository.GetById(id);
            _notaTagRepository.Delete(entity);
            return Ok();

        }

    }
}
