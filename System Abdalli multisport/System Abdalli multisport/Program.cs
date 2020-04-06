using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport.acceuil;
using System_Abdalli_multisport.formapp;

namespace System_Abdalli_multisport
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new AcceuilForm());
            Application.Run(new welcome());
            //Application.Run(new login());

        }
    }
}
