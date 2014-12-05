using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB
{
    public class PeriodoRepositorio
    {
        private static database getDataBase()
        {
            database db = new database();
            if (db.DatabaseExists() == false)
            {
                db.CreateDatabase();

            }
            return db;
        }

        public static List<Periodo> GetPeriodo(string idCurso)
        {
            database db = getDataBase();
            var query = from p in db.Periodo where p.IdCurso == idCurso select p;
            List<Periodo> periodo = new List<Periodo>(query.AsEnumerable());
            return periodo;
        }

        public static void create(Periodo p)
        {
            database db = getDataBase();
            db.Periodo.InsertOnSubmit(p);
            db.SubmitChanges();
        }
    }
}
