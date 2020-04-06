using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace System_Abdalli_multisport.Controle
{
    class info
    {
        public static string Sport;
        public static string id;
        public static string TypeAcc;

        public string SPORTS
        {
            get { return Sport; }
            set { Sport = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string TYPEAccess
        {
            get { return TypeAcc; }
            set { TypeAcc = value; }
        }

    }
    
}
