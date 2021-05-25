namespace UserInterface
{
    partial class DataBreach
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Data Breaches";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.Location = new System.Drawing.Point(39, 72);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(131, 20);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Texto expuesto";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(318, 345);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(99, 36);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "Verificar";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(43, 345);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(99, 36);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(43, 106);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(374, 175);
            this.txtBox.TabIndex = 4;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(318, 287);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(99, 36);
            this.btnReadFile.TabIndex = 5;
            this.btnReadFile.Text = "LeerArchivo";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // DataBreach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "DataBreach";
            this.Size = new System.Drawing.Size(451, 398);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Button btnReadFile;
    }
}
