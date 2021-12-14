using APIWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Repository
{
    public interface INotaTagRepository : IRepository<NotaTag>
    {
        Task<IEnumerable<JoinNotaTag>> GetByNotaId(int notaId);
        Task AssociarTags(int notaId, ICollection<Tag> tags);
    }
}
