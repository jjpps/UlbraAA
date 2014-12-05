using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UlbraAA_C_.Resources;
using UlbraAA_C_.Classes;
using Microsoft.Phone.Tasks;

namespace UlbraAA_C_
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            verifica();
           

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (verifica() == true)
            {

                NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));

            }
        }


        //variaveis
        bool cgu = true;
        bool senha = true;
        bool campos;
       public string Vcgu;
        public string Vsenha;
        public static bool control;

       
        //objeto da clase isolatedstoresettings
        AppSettings ls = new AppSettings();

        //instancia objeto da classe clsConexao
         clsConexao conecta = new clsConexao();
        


        //metodos
        
        public void abrepagina(string destino)
        {
            
            grdForm.Visibility = Visibility.Visible;
            progressBar.Visibility = Visibility.Collapsed;
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));
        }//metodo abre pagina

        private void txtcgu_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (cgu == true)
            {
                txtcgu.Text = "";
                cgu = false;
            }

        }//metodo limpa txtcgu

        private void txtsenha_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (senha == true)
            {
                txtsenha.Password = "";
                senha = false;
            }
        }//metodo limpa txtsenha


        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            abrepagina("/help.xaml");
        }//abre pagina help

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)//metodo de click appbar
        {
            bool campos;
            campos = checarCampos();
            if (campos == false)
            {
                MessageBox.Show("Por favor, preencha todos campos corretamente!");
            }
            else 
            {

                if (chkSelecionado.IsChecked == true)
                {
                    
                    control = true;
                    grdForm.Visibility = Visibility.Collapsed;
                    progressBar.Visibility = Visibility.Visible;
                    Vcgu = txtcgu.Text;
                    Vsenha = txtsenha.Password;
                    conecta.Get_Hash(Vcgu, Vsenha);
                    
                    

              
                }
                else {
                    grdForm.Visibility = Visibility.Collapsed;
                    progressBar.Visibility = Visibility.Visible;
                    Vcgu = txtcgu.Text;
                    Vsenha = txtsenha.Password;
                    conecta.Get_Hash(Vcgu, Vsenha);
                    control = false;
                }
                
                
                
              
              
                

            }
        }


        public bool verifica() {
           string a = AppSettings.CarregarSetting();
           if (a != "")
           {
               conecta.Get_aula(a);
               conecta.Get_User(a);
               return true;
               
           }

           return false;
        }


       


        private bool checarCampos()
        {
            bool campos = true;

            if (txtsenha.Password == "")
            {
                campos = false;
            }
            if (txtcgu.Text == "")
            {
                campos = false;
            }

            return campos;
        }//Checa os campos

       

        
            

           
        

        




    }


}