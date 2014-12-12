using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlbraAA_C_
{
    class AppSettings
    {
        

        public static string CarregarSetting() {
           
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            string hash="";
                if (IsolatedStorageSettings.ApplicationSettings.Contains("md5"))
                {
                    hash = IsolatedStorageSettings.ApplicationSettings["md5"] as string;

                }
                return hash;
            
            
            
            

        }
        public static void Salvar(string hash){
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains("md5"))
            {
                settings.Add("md5", hash);
            }
            else
            {
                settings["md5"] = hash;
            }
            settings.Save();
        
        
        }

        public static void remove()
        {
            IsolatedStorageSettings.ApplicationSettings.Remove("md5");
        }

    }
}
