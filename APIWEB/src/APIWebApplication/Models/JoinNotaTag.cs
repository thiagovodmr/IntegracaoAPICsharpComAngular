using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Models
{
    public class JoinNotaTag
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public int TagId { get; set; }
        public int NotaId { get; set; }
    }
}
