namespace UserInterface
{
    partial class ListStrengthPasswords
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(43, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 25);
            this.lblTitle.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(48, 96);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(368, 176);
            this.dgvList.TabIndex = 1;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(327, 291);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(89, 31);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(48, 291);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 31);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // ListStrengthPasswords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.lblTitle);
            this.Name = "ListStrengthPasswords";
            this.Size = new System.Drawing.Size(452, 335);
            this.Load += new System.EventHandler(this.ListStrengthPasswords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnBack;
    }
}
