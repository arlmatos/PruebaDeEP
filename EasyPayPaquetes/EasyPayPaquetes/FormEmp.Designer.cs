namespace EasyPayPaquetes
{
    partial class FormEmp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtllamadoventanilla = new System.Windows.Forms.TextBox();
            this.btnllamado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtllamadoventanilla
            // 
            this.txtllamadoventanilla.Location = new System.Drawing.Point(12, 12);
            this.txtllamadoventanilla.Name = "txtllamadoventanilla";
            this.txtllamadoventanilla.Size = new System.Drawing.Size(169, 20);
            this.txtllamadoventanilla.TabIndex = 0;
            // 
            // btnllamado
            // 
            this.btnllamado.Location = new System.Drawing.Point(248, 12);
            this.btnllamado.Name = "btnllamado";
            this.btnllamado.Size = new System.Drawing.Size(124, 23);
            this.btnllamado.TabIndex = 1;
            this.btnllamado.Text = "llamado a ventanilla";
            this.btnllamado.UseVisualStyleBackColor = true;
            this.btnllamado.Click += new System.EventHandler(this.btnllamado_Click);
            // 
            // FormEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 235);
            this.Controls.Add(this.btnllamado);
            this.Controls.Add(this.txtllamadoventanilla);
            this.Name = "FormEmp";
            this.Text = "FormEmp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtllamadoventanilla;
        private System.Windows.Forms.Button btnllamado;
    }
}