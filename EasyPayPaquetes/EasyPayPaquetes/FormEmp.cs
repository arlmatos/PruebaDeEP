using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace EasyPayPaquetes
{
    public partial class FormEmp : Form
    {
        private dbconx dbcon = new dbconx();
        private SpeechSynthesizer voz = new SpeechSynthesizer();
        public string narrador;
        public FormEmp()
        {
            InitializeComponent();
            
            foreach (object o in voz.GetInstalledVoices())
            {
                var insvoz=(InstalledVoice)o;
                narrador= (insvoz.VoiceInfo.Name);
                break;
            }
            voz.Volume = 90;
            voz.Rate = 2;
            
        }

        private void btnllamado_Click(object sender, EventArgs e)
        {
            string llamado = txtllamadoventanilla.Text;
            string mensaje = dbcon.llamadaTurno(llamado);           
            voz.SelectVoice(this.narrador);
            voz.SpeakAsync("Turno numero " + mensaje);

        }
    }
}
