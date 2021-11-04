using APIWebApplication.Data;
using APIWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Repository
{
    public class NotaRepository : EFRepository<Nota>, INotaRepository
    {
        public NotaRepository(AppDataContext dbcontext) : base(dbcontext) {}

        public override async Task Update(Nota entity)
        {
            this.Detached(entity);

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private void Detached(Nota entity)
        {
            var local = _dbContext.Set<Nota>()
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
