using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB
{
    class database:DataContext
    {
        public static string DBConnectionString = "Data Source ='isostore:notas.sdf'";

        public database()
            : base(DBConnectionString)
        {}
        public Table<Curso> Curso
        {
            get
            {
                return this.GetTable<Curso>(); 
            }
        }
        public Table<Periodo> Periodo
        {
            get
            {
                return this.GetTable<Periodo>();
            }
        }
        public Table<Disciplina> Disciplina
        {
            get 
            {
                return this.GetTable<Disciplina>();
            }
        }
        public Table<Graus> Graus
        {
            get
            {
                return this.GetTable<Graus>();

            }
        }
    }
}
