using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB
{
    [Table]
    public class Disciplina

    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdNao { get; set; }
    
        
        [Column(IsPrimaryKey = false)]
        public string id { get; set; }

        [Column(IsPrimaryKey = false)]
        public string nome { get; set; }

        [Column()]
        public string grauFinal { get; set; }

        [Column(IsPrimaryKey = false)]
        public string idPeriodo { get; set; }
    }
}
