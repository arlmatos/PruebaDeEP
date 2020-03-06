namespace EasyPayPaquetes
{
    partial class FormCient
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscarCodPaqute = new System.Windows.Forms.Button();
            this.txtCodigoPaquete = new System.Windows.Forms.TextBox();
            this.llblCodigoPaquete = new System.Windows.Forms.Label();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printTick = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // btnBuscarCodPaqute
            // 
            this.btnBuscarCodPaqute.Location = new System.Drawing.Point(69, 87);
            this.btnBuscarCodPaqute.Name = "btnBuscarCodPaqute";
            this.btnBuscarCodPaqute.Size = new System.Drawing.Size(86, 34);
            this.btnBuscarCodPaqute.TabIndex = 0;
            this.btnBuscarCodPaqute.Text = "Imprimir Ticket";
            this.btnBuscarCodPaqute.UseVisualStyleBackColor = true;
            this.btnBuscarCodPaqute.Click += new System.EventHandler(this.btnBuscarCodPaqute_Click);
            // 
            // txtCodigoPaquete
            // 
            this.txtCodigoPaquete.Location = new System.Drawing.Point(54, 50);
            this.txtCodigoPaquete.MaxLength = 12;
            this.txtCodigoPaquete.Name = "txtCodigoPaquete";
            this.txtCodigoPaquete.Size = new System.Drawing.Size(117, 20);
            this.txtCodigoPaquete.TabIndex = 1;
            // 
            // llblCodigoPaquete
            // 
            this.llblCodigoPaquete.AutoSize = true;
            this.llblCodigoPaquete.Location = new System.Drawing.Point(32, 21);
            this.llblCodigoPaquete.Name = "llblCodigoPaquete";
            this.llblCodigoPaquete.Size = new System.Drawing.Size(162, 13);
            this.llblCodigoPaquete.TabIndex = 2;
            this.llblCodigoPaquete.Text = "Ingrese el codigo de su paquete:";
            this.llblCodigoPaquete.Click += new System.EventHandler(this.label1_Click);
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // printTick
            // 
            this.printTick.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printTick_PrintPage);
            // 
            // FormCient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 148);
            this.Controls.Add(this.llblCodigoPaquete);
            this.Controls.Add(this.txtCodigoPaquete);
            this.Controls.Add(this.btnBuscarCodPaqute);
            this.Name = "FormCient";
            this.Text = "Formulario de Paqueteria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarCodPaqute;
        private System.Windows.Forms.TextBox txtCodigoPaquete;
        private System.Windows.Forms.Label llblCodigoPaquete;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Drawing.Printing.PrintDocument printTick;
    }
}

