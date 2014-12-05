using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB
{
    [Table]
    public class Graus
    {

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int IdNaoUsado { get; set; }

        [Column(IsPrimaryKey = false)]
        public string nome { get; set; }
        [Column(IsPrimaryKey = false)]
        public string nota { get; set; }

        [Column(IsPrimaryKey = false)]
        public string idDisciplina { get; set; }
    }
}
