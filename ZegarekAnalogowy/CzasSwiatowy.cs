using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZegarekAnalogowy
{
    public partial class CzasSwiatowy : Form
    {
        public CzasSwiatowy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OknoGlowne.tekst = comboBox.Text;
            switch (comboBox.Text)
            {
                case "Londyn": OknoGlowne.zmianaCzasu = -1; break;
                case "Nowy Jork": OknoGlowne.zmianaCzasu = -6; break;
                case "Buenos Aires": OknoGlowne.zmianaCzasu = -5; break;
                case "Brasilia": OknoGlowne.zmianaCzasu = -5; break;
                case "Pekin": OknoGlowne.zmianaCzasu = 6; break;
                case "Sydney": OknoGlowne.zmianaCzasu = 8; break;
                case "Tokio": OknoGlowne.zmianaCzasu = 7; break;
                case "Polska": OknoGlowne.zmianaCzasu = 0; break;
            }

            this.Close();
            
        }
    }
}
