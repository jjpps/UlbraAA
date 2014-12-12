using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_.DB.Classes
{
   public class CursoRepositorio
    {
       private static database getDataBase() 
       {
           database db = new database();

           if (db.DatabaseExists() == false) {
               db.CreateDatabase();
           }
               
           
           
           return db;
       }
       public static List<Curso> GetCurso()
       {
           database db = getDataBase();
           var query = from c in db.Curso  select c;
          
           List<Curso> curso = new List<Curso>(query.AsEnumerable());
           return curso;
       }

       public static void create (Curso c)//salvar
       {
           database db = getDataBase(); 
           db.Curso.InsertOnSubmit(c);
           db.SubmitChanges();
       }
       public static void DropCurso() 
       {
           database db = getDataBase();
           if (db.DatabaseExists() == true) 
           {
               db.DeleteDatabase();
           }
           
       }



    }
}
