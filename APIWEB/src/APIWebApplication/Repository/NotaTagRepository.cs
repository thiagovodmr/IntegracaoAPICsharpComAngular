using APIWebApplication.Data;
using APIWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Repository
{
    public class NotaTagRepository : EFRepository<NotaTag>, INotaTagRepository

    {
        public NotaTagRepository(AppDataContext appDataContext) : base(appDataContext){}

        public async Task<IEnumerable<JoinNotaTag>> GetByNotaId(int notaId)
        {
            var tags = await _dbContext.Set<Tag>().AsNoTracking()
                .Join(
                    _dbContext.NotaTag,
                    tag => tag.Id,
                    notaTag => notaTag.TagId,
                    (tag, notatag) => new JoinNotaTag
                    {
                        Id = notatag.Id,
                        Nome = tag.Nome,
                        TagId = tag.Id,
                        NotaId = notatag.NotaId
                    }
                ).Where(n => n.NotaId == notaId).ToListAsync();

            return tags;
        }

        public virtual async Task AssociarTags(int notaId, ICollection<Tag> tags)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {

                foreach (Tag tag in tags)
                {
                    var entity = new NotaTag { NotaId = notaId, TagId = tag.Id };
                    _dbContext.Set<NotaTag>().Add(entity);
                    await _dbContext.SaveChangesAsync();
                }

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }
    }
}
