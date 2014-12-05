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

namespace UlbraAA_C_
{
    public partial class aulas : PhoneApplicationPage
    {
        public aulas()
        {
            InitializeComponent();
            escreveAula();
        }

        #region listas
        List<string> _dias = new List<string>();
        List<string> __disciplinas = new List<string>();
        List<string> _predio = new List<string>();
        List<string> _diasemana = new List<string>();
        List<string> _sala = new List<string>(); 
        #endregion//listas

        #region Preenche as listas
        String[] _disciplinas = { };
        String[] predio = { };
        String[] diasemana = { };
        String[] sala = { }; 
        #endregion

        public void escreveAula()
        {
            _dias.Add("Selecione Seu Dia");
            foreach (clsAula aula_aula in (Application.Current as App).aula)
            {
                _dias.Add(aula_aula.dia);
                __disciplinas.Add(aula_aula.disciplina);
                _predio.Add(aula_aula.predio);
                _diasemana.Add(aula_aula.dia);
                _sala.Add(aula_aula.sala);
            }
            this.lpkCampo.ItemsSource = _dias; //alimenta a listPicker
        } //alimenta as listas


        private void lpkCampo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpkCampo.SelectedItem != "Selecione Seu Dia")
            {
                int selindex = lpkCampo.SelectedIndex - 1;
                this.txtDisciplina.Text = __disciplinas[selindex];
                this.txtpredio.Text = _predio[selindex];
                this.txtdia.Text = _diasemana[selindex];
                this.txtsala.Text = _sala[selindex];
            }
            else
            {
                this.txtDisciplina.Text = "";
                this.txtpredio.Text = "";
                this.txtdia.Text = "";
                this.txtsala.Text = "";
            }
        }//selection change ListPicker


        //eventos

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            abrepagina("/Info.xaml");
        }
        private void abrepagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));
        }




    }
}