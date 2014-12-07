using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using UlbraAA_C_.Classes;
using UlbraAA_C_.DB;
using UlbraAA_C_.DB.Classes;


namespace UlbraAA_C_
{
    public partial class Notas : PhoneApplicationPage
    {
        public Notas()
        {
            
            InitializeComponent();
            selindex_new = 0;
            selindex_old = 0;
            verificaDB();
        }
        

        //variaveis
        bool ctrPeriodo = true;
        int selindex_new;
        int selindex_old;
        clsUser UserP;

        #region Listas
        List<string> _periodos = new List<string>();
        List<string> _situacao = new List<string>();
      
        
        #endregion

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            abrepagina("/Menu.xaml");
        }
        

        //metodos

        private void EscreCurso()
        {
            
            
            
            foreach (clsUser pUser in (Application.Current as App).user)
            {
                UserP = pUser;
                peristeDados();



                
                _situacao.Add(pUser.nome);
                
                
                //nome = nome do curso
            }
            lpkCurso.ItemsSource = _situacao;
            
            if ((Application.Current as App).user[selindex_new].situacao == "ATIVO")
            {
                txtsituacao.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
                txtsituacao.Foreground = new SolidColorBrush(Colors.Red);
            this.txtsituacao.Text = (Application.Current as App).user[selindex_new].situacao;
            ctrPeriodo = false;
        }//escreve curso na listpicker

        //private void EscrePerido()
        //{
        //    if (ctrPeriodo)
        //    {
        //        //REMOVE
        //        foreach (clsPeriodos pperiodo in (Application.Current as App).user[selindex_old].periodos)
        //        {
        //            _periodos.Remove(pperiodo.periodo);

        //        }

        //        //PEGA
        //        foreach (clsPeriodos pperiodo in (Application.Current as App).user[selindex_new].periodos)
        //        {
        //            _periodos.Add(pperiodo.periodo);


        //        }

        //        selindex_old = selindex_new;
        //    }
        //}//escreve periodo



        //eventos
        private void abrepagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            (Application.Current as App).curso = lpkCurso.SelectedIndex;
            abrepagina("/Notas2.xaml");
        }

        private void lpkCurso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClsGlobal.ctDB == true)
            {
                foreach (Curso  c in CursoRepositorio.GetCurso())
                {
                    this.txtsituacao.Text = c.situacao;
                    if (c.situacao == "ATIVO")
                    {
                        txtsituacao.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        txtsituacao.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }

            }
            else {
                this.txtsituacao.Text = (Application.Current as App).user[lpkCurso.SelectedIndex].situacao;

                if ((Application.Current as App).user[lpkCurso.SelectedIndex].situacao == "ATIVO")
                {
                    txtsituacao.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                    txtsituacao.Foreground = new SolidColorBrush(Colors.Red);
            }
        }


        public void peristeDados() {

            persisteCurso();
            persistPeriodos();

            
        
        }

        private void persisteCurso()
        {
            Curso c = new Curso();
            c.id = UserP.id;
            c.nome = UserP.nome;
            c.situacao = UserP.situacao;
            ClsGlobal.IdCurso = UserP.id;
            CursoRepositorio.create(c);
            
            
        }

        public void persistPeriodos()
        {
            var periodos = from periodo in UserP.periodos select periodo;

            foreach (var p in periodos)
	        {
                Periodo per = new Periodo
                {
                    IdCurso = UserP.id,
                    periodo = p.periodo
                    
                };
                

                foreach (var d in p.disciplinas)
                {
                    Disciplina disc = new Disciplina
                    {
                        idPeriodo = p.periodo,
                        id = d.id,
                        nome = d.nome,
                        grauFinal = d.grauFinal,


                    };
                    
                    foreach (var g in d.graus)
                    {
                        Graus grau = new Graus
                        {
                           idDisciplina = d.id,
                            nome = g.nome,
                            nota = g.nota
                        };
                        GrausRepositorio.create(grau);
                        
                    }
                    DisciplinaRepositorio.create(disc);
                    
                }


                PeriodoRepositorio.create(per);
                
		 
	        }

        }

        public  void EscreCursoDB() 
        {
            List<string> _situacaoDB = new List<string>();
            foreach (Curso c in CursoRepositorio.GetCurso())
            {
                ClsGlobal.IdCurso = c.id;

                    _situacaoDB.Add(c.nome);

                    if (c.situacao == "ATIVO")
                {
                    txtsituacao.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                    txtsituacao.Foreground = new SolidColorBrush(Colors.Red);
                this.txtsituacao.Text = c.situacao;
                
            }
            lpkCurso.ItemsSource = _situacaoDB;
            

        }

        public void verificaDB()
        {
            if (ClsGlobal.ctDB == true)
            {
                EscreCursoDB();
            }
            else {
                EscreCurso();
            }
        
        }
    
    }

    
}