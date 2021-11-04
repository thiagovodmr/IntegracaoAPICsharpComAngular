using APIWebApplication.Data;
using APIWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Repository
{
    public class TagRepository : EFRepository<Tag> , ITagRepository
    {
        public TagRepository(AppDataContext dbcontext) : base(dbcontext) { }

        public override async Task Update(Tag entity)
        {
            this.Detached(entity);

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        private void Detached(Tag entity)
        {
            var local = _dbContext.Set<Tag>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _dbContext.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
