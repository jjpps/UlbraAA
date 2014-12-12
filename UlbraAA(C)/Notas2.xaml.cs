using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UlbraAA_C_.Classes;
using UlbraAA_C_.DB;
using UlbraAA_C_.DB.Classes;

namespace UlbraAA_C_
{
    public partial class Notas2 : PhoneApplicationPage
    {
        public Notas2()
        {
            InitializeComponent();
            verificaDB();
            
        }

        //variaves

        int selindex_periodo = 0;
        bool controle = false;

       

        //listas

        #region Listas
        List<clsDisciplinas> listDisciplinas = new List<clsDisciplinas>();
        List<string> _periodos = new List<string>();
        List<string> NomeMat = new List<string>();
        List<string> _periodosDB = new List<string>();
        List<Disciplina> NomeMatDB = new List<Disciplina>();
        
        #endregion


        //metodos

        #region Metodos
        public void getMat()
        {
            listDisciplinas.Clear();

            foreach (clsDisciplinas _discplina in (Application.Current as App).user[(Application.Current as App).curso].periodos[selindex_periodo].disciplinas)
            {

                listDisciplinas.Add(_discplina);

            }

            lstMat.ItemsSource = null;
            lstMat.ItemsSource = listDisciplinas;
            controle = true;
        }//pega materia
        public void getMatDB() 
        {
            NomeMatDB.Clear();
            lstMat.ItemsSource = null;
          
            string x = _periodosDB[selindex_periodo].ToString();
            foreach (Disciplina d in DisciplinaRepositorio.GetDisciplina(x))//PERDENDO ID
            {
                
                
                NomeMatDB.Add(d);
               
                
            }
            lstMat.ItemsSource = null;
            lstMat.ItemsSource = NomeMatDB;
            controle = true;

            
       
        }

        

        public void escreveperiodosDB() 
        {
            
            foreach (Periodo p in PeriodoRepositorio.GetPeriodo(ClsGlobal.IdCurso))
            {
                _periodosDB.Add(p.periodo);
            }
            lpkCurso.ItemsSource = _periodosDB;
        }

        private void escreveperiodos()
        {
            foreach (clsPeriodos pperiodo in (Application.Current as App).user[(Application.Current as App).curso].periodos)
            {
                _periodos.Add(pperiodo.periodo);
                
                
            }

            lpkCurso.ItemsSource = _periodos;

        }//escreve periodo 
        #endregion

        public void verificaDB() 
        {
            if (ClsGlobal.ctDB == true)
            {
                escreveperiodosDB();
                getMatDB();
            }
            else 
            {
                escreveperiodos();
                getMat();
            }
        }
        //eventos

        #region Eventos
        private void abrepagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));
        }

        private void lpkCurso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            controle = false;
            selindex_periodo = lpkCurso.SelectedIndex;
            
            if (ClsGlobal.ctDB == true)
            {
                getMatDB();
            }
            else
            {
                getMat();
            }
        }

        private void lstMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (controle==true)
            {

                (Application.Current as App).cadeira = lstMat.SelectedIndex;
                (Application.Current as App).periodo = selindex_periodo;
                int x = lstMat.SelectedIndex;
                string z = NomeMatDB[x].id;
                ClsGlobal.NomeMateria = NomeMatDB[x].nome;
                ClsGlobal.GrauFinalDB = NomeMatDB[x].grauFinal;
                ClsGlobal.IdMateria = z;
               
              
                abrepagina("/NotasFinal.xaml");
            }
        } 
        #endregion
    }
}