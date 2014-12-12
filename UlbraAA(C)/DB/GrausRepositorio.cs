using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB
{
   public class GrausRepositorio
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
       public static List<Graus> GetGraus(string idDisciplina)
       {
           database db = getDataBase();
           var query = from g in db.Graus where g.idDisciplina == idDisciplina select g;

           List<Graus> graus = new List<Graus>(query.AsEnumerable());
           return graus;
       }
       public static void create (Graus g)
       {
           database db = getDataBase();
           db.Graus.InsertOnSubmit(g);
           db.SubmitChanges();
       }
       public static void DropGraus()
       {
           database db = getDataBase();
           if (db.DatabaseExists() == true)
           {
               db.DeleteDatabase();
           }
       }
    }
}
