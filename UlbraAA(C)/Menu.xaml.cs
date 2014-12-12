using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;


namespace UlbraAA_C_
{
    public partial class Menu : PhoneApplicationPage
    {
        public Menu()
        {
            //Thread.Sleep(2000);
            InitializeComponent();
            //prgBar.Visibility = Visibility.Collapsed;
            
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Terminate();
        }
        private void abrepagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));
        }//abre pagina


        private void image1_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ContentPanel.Visibility = Visibility.Collapsed;
            prgBar.Visibility = Visibility.Visible;
            if (ClsGlobal.ctDB == true) 
            {
                MessageBox.Show("Essa Função Não Esta Disponivel Em Modo Offline ");
                prgBar.Visibility = Visibility.Collapsed;
                ContentPanel.Visibility = Visibility.Visible;
            } else 
            {
                abrepagina("/aulas.xaml");
            }
           
        }


        private void textBlock1_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ContentPanel.Visibility = Visibility.Collapsed;
            prgBar.Visibility = Visibility.Visible;

            abrepagina("/Notas.xaml");
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            abrepagina("/Info.xaml");
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            AppSettings.remove();
            Application.Current.Terminate();

        }

       

       



    }
}