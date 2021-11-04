using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Models
{
    public class NotaTag
    {
        public int Id { get; set; }
        public int NotaId { get; set; }
        public int TagId { get; set; }

        public Nota Nota { get; set; }
        public Tag Tag { get;set; }
    }
}
