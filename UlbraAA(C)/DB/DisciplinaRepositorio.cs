using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB
{
   public class DisciplinaRepositorio
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
       public static List<Disciplina> GetDisciplina(string idPeriodo)
       {
           database db = getDataBase();
           var query = from d in db.Disciplina where d.idPeriodo == idPeriodo select d;
           List<Disciplina> disciplina = new List<Disciplina>(query.AsEnumerable());
           return disciplina;

       }

       public static void create (Disciplina d)
       {
           database db = getDataBase();
           db.Disciplina.InsertOnSubmit(d);
           db.SubmitChanges();
       }
    }
}
