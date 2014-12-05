using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB
{
    [Table]
    public class Curso
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int idNaoUsado { get; set; }


        [Column(IsPrimaryKey = true)]
        public string id { get; set; }

        [Column(IsPrimaryKey = false)]
        public string nome { get; set; }

        [Column(IsPrimaryKey = false)]
        public string situacao { get; set; }
       
        
    }
}
