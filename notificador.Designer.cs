namespace App_Final_Restaurante
{
    partial class notificador
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpErrores = new System.Windows.Forms.GroupBox();
            this.rdbStock = new System.Windows.Forms.RadioButton();
            this.rdbFalla = new System.Windows.Forms.RadioButton();
            this.rdbDemora = new System.Windows.Forms.RadioButton();
            this.btnEnviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpErrores.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(428, 63);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notificar Errores";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(379, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 33);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpErrores
            // 
            this.grpErrores.Controls.Add(this.btnEnviar);
            this.grpErrores.Controls.Add(this.rdbDemora);
            this.grpErrores.Controls.Add(this.rdbFalla);
            this.grpErrores.Controls.Add(this.rdbStock);
            this.grpErrores.Location = new System.Drawing.Point(-2, 69);
            this.grpErrores.Name = "grpErrores";
            this.grpErrores.Size = new System.Drawing.Size(428, 208);
            this.grpErrores.TabIndex = 22;
            this.grpErrores.TabStop = false;
            // 
            // rdbStock
            // 
            this.rdbStock.AutoSize = true;
            this.rdbStock.Location = new System.Drawing.Point(146, 32);
            this.rdbStock.Name = "rdbStock";
            this.rdbStock.Size = new System.Drawing.Size(94, 17);
            this.rdbStock.TabIndex = 0;
            this.rdbStock.TabStop = true;
            this.rdbStock.Text = "Falta de Stock";
            this.rdbStock.UseVisualStyleBackColor = true;
            // 
            // rdbFalla
            // 
            this.rdbFalla.AutoSize = true;
            this.rdbFalla.Location = new System.Drawing.Point(146, 66);
            this.rdbFalla.Name = "rdbFalla";
            this.rdbFalla.Size = new System.Drawing.Size(141, 17);
            this.rdbFalla.TabIndex = 1;
            this.rdbFalla.TabStop = true;
            this.rdbFalla.Text = "Falla dentro de la cocina";
            this.rdbFalla.UseVisualStyleBackColor = true;
            // 
            // rdbDemora
            // 
            this.rdbDemora.AutoSize = true;
            this.rdbDemora.Location = new System.Drawing.Point(146, 101);
            this.rdbDemora.Name = "rdbDemora";
            this.rdbDemora.Size = new System.Drawing.Size(123, 17);
            this.rdbDemora.TabIndex = 2;
            this.rdbDemora.TabStop = true;
            this.rdbDemora.Text = "Demora en la cocina";
            this.rdbDemora.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnEnviar.Location = new System.Drawing.Point(146, 145);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(141, 39);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // notificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(425, 273);
            this.ControlBox = false;
            this.Controls.Add(this.grpErrores);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "notificador";
            this.Text = "notificador";
            this.Load += new System.EventHandler(this.notificador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpErrores.ResumeLayout(false);
            this.grpErrores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpErrores;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RadioButton rdbDemora;
        private System.Windows.Forms.RadioButton rdbFalla;
        private System.Windows.Forms.RadioButton rdbStock;
    }
}