using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPayPaquetes
{
    public partial class FormCient : Form
    {
        private dbconx dbclass = new dbconx();
        public FormCient()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void printTick_PrintPage(object sender, PrintPageEventArgs e)
        {
            string ticket = "codigo paquete : " + txtCodigoPaquete.Text + "\n Fecha/hora : " +
                DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string turno = dbclass.genTurno().ToString();
            Font fuenteX = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Point);
            Font fuenteW = new Font("Times New Roman", 50, FontStyle.Bold, GraphicsUnit.Point);
            Font fuenteY = new Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point);
            e.Graphics.DrawString("EasyPay Ticket", fuenteX, Brushes.Black, new RectangleF(0, 10, 300, 20));
            e.Graphics.DrawString(turno, fuenteX, Brushes.Black, new RectangleF(0, 35, 300, 20));
            e.Graphics.DrawString(ticket, fuenteY, Brushes.Black, new RectangleF(0, 120, 250, 250));

        }
        private void printDoc_PrintPage(object sender, PrintPageEventArgs pe)
        {
            DataTable formulario = dbclass.creaFormularios(txtCodigoPaquete.Text);
            string prntform = dbclass.dtString(formulario);            
            Font fuenteX = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Point);
            Font fuenteY = new Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point);
            pe.Graphics.DrawString("Formulario de ordenes", fuenteX, Brushes.Black, new RectangleF(0, 10, 300, 20));
            pe.Graphics.DrawString(prntform, fuenteY, Brushes.Black, new RectangleF(0, 35, 250, 600));

        }
        
        private void btnBuscarCodPaqute_Click(object sender, EventArgs e)
        {
            if (respuestaPantalla(txtCodigoPaquete.Text) == true)
            {
                PrintDocument pDoc = new PrintDocument();
                PrinterSettings confiPrint = new PrinterSettings();
                
                printDoc.DefaultPageSettings.PaperSize = new PaperSize("A7", 74, 105);
                printDoc.PrinterSettings = confiPrint;
                printDoc.Print();
                printDoc.PrintPage += printDoc_PrintPage;
                ////  configurado con 2 printers diferentes // em mi caso solo prueba con 1
                printTick.DefaultPageSettings.PaperSize = new PaperSize("A7", 74, 105);
                printTick.PrinterSettings = confiPrint;
                printTick.Print();
                printTick.PrintPage += printDoc_PrintPage;
            }
                     
             
        }
        private bool respuestaPantalla(string codigoPaquete)
        {
            bool exito = false;
            string msg = dbclass.cunsultaDB(codigoPaquete);
            string pantalla;
            
            switch (msg)
            {

                case "exito":
                    {
                        pantalla = "Retire su ticket   ";
                        exito = true;
                    }
                    break;
                case "noValido":
                    {
                        pantalla = "Por favor revise su codigo y digite nuevamente";
                        
                    }
                    break;
                case "retirado":
                    {
                        pantalla = "Este orden ha sido procesada";
                    }
                    break;
                default:
                    {
                        pantalla = "No es posible retirar su ticket";
                    }
                    break;
            }
            MessageBox.Show(pantalla);
            return exito;
        }

       
    }
}
