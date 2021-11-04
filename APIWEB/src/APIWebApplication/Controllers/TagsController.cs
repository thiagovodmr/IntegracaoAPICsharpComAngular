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
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _repository;

        public TagsController(ITagRepository tagRepository)
        {
            _repository = tagRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Tag>> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public Task<Tag> Get(int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public Task<Tag> Post([FromBody] Tag tag)
        {
            if (tag == null)
            {
                throw new Exception("null value");
            }
            _repository.Create(tag);
            return _repository.GetById(tag.Id);
        }

        // DELETE api/tags/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var tag = await _repository.GetById(id);
            _repository.Delete(tag);
            return Ok();

        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Tag tag)
        {
            try
            {
                var tagCadastrada = await _repository.GetById(tag.Id);
                if (tagCadastrada == null)
                {
                    return BadRequest();
                }

                await _repository.Update(tag);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
