using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB

{
    [Table]
   public class Periodo
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdNaoUsado { get; set; }

        [Column(IsPrimaryKey = false)]
        public string periodo { get; set; }

        [Column(IsPrimaryKey = false)]
        public string IdCurso { get; set; }


    }
}
