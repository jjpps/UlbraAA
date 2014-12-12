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

namespace UlbraAA_C_
{
    public partial class NotasFinal : PhoneApplicationPage
    {
        public NotasFinal()
        {
            InitializeComponent();
            verificaDB();
        }

        //listas
        #region Listas
        List<clsUser> user;
        List<string> lstNotas = new List<string>();
        List<string> lstNotasDB = new List<string>();
        
        #endregion

        //variaveis

        int curso;
        int periodo;
        int cadeira;


        //metodos
        void getAula()
        {
            txtNome.Text = user[curso].periodos[periodo].disciplinas[cadeira].nome;
            txtGfinal.Text = (Application.Current as App).user[(Application.Current as App).curso].periodos[(Application.Current as App).periodo].disciplinas[(Application.Current as App).cadeira].grauFinal.ToString();

            foreach (clsGraus _grau in user[curso].periodos[periodo].disciplinas[cadeira].graus)
            {
                lstNotas.Add(_grau.nome + ": " + _grau.nota.ToString());
            }

            lstNotasGral.ItemsSource = lstNotas;

        }
        void getAulaDB()
        {
            
            //grau finall
            
            foreach (Graus g in GrausRepositorio.GetGraus(ClsGlobal.IdDisciplina.ToString()))
            {
                lstNotasDB.Add(g.nome + ":" + g.nota.ToString());
            }
            lstNotasGral.ItemsSource = lstNotasDB;

        

        }

        public void verificaDB()
        {
            if (ClsGlobal.ctDB == true)
            {
                getAulaDB();
            }
            else
            {
                #region Preenche as Lists
                user = (Application.Current as App).user;
                periodo = (Application.Current as App).periodo;
                cadeira = (Application.Current as App).cadeira;
                curso = (Application.Current as App).curso;
                #endregion
                getAula();
            }
        }
    }
}