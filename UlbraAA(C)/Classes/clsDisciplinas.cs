using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UlbraAA_C_.Classes
{
    public class clsDisciplinas
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string grauFinal { get; set; }
        public List<clsGraus> graus { get; set; }
    }
}
