using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.Classes
{
    public class clsUser
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string situacao { get; set; }
        public List<clsPeriodos> periodos { get; set; }

    }
}
