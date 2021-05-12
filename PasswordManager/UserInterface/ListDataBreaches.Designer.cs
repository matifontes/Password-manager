namespace UserInterface
{
    partial class ListDataBreaches
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
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvPasswords = new System.Windows.Forms.DataGridView();
            this.dgvCreditCards = new System.Windows.Forms.DataGridView();
            this.lblCreditCards = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditCards)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Resultado";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(396, 354);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 42);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // dgvPasswords
            // 
            this.dgvPasswords.AllowUserToAddRows = false;
            this.dgvPasswords.AllowUserToDeleteRows = false;
            this.dgvPasswords.AllowUserToResizeColumns = false;
            this.dgvPasswords.AllowUserToResizeRows = false;
            this.dgvPasswords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasswords.Location = new System.Drawing.Point(36, 75);
            this.dgvPasswords.Name = "dgvPasswords";
            this.dgvPasswords.ReadOnly = true;
            this.dgvPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasswords.Size = new System.Drawing.Size(478, 109);
            this.dgvPasswords.TabIndex = 2;
            // 
            // dgvCreditCards
            // 
            this.dgvCreditCards.AllowUserToAddRows = false;
            this.dgvCreditCards.AllowUserToDeleteRows = false;
            this.dgvCreditCards.AllowUserToResizeColumns = false;
            this.dgvCreditCards.AllowUserToResizeRows = false;
            this.dgvCreditCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCreditCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditCards.Location = new System.Drawing.Point(37, 224);
            this.dgvCreditCards.Name = "dgvCreditCards";
            this.dgvCreditCards.ReadOnly = true;
            this.dgvCreditCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditCards.Size = new System.Drawing.Size(477, 109);
            this.dgvCreditCards.TabIndex = 3;
            // 
            // lblCreditCards
            // 
            this.lblCreditCards.AutoSize = true;
            this.lblCreditCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCards.Location = new System.Drawing.Point(32, 196);
            this.lblCreditCards.Name = "lblCreditCards";
            this.lblCreditCards.Size = new System.Drawing.Size(159, 20);
            this.lblCreditCards.TabIndex = 4;
            this.lblCreditCards.Text = "Tarjetas de credito";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(33, 52);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(111, 20);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Contraseñas";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(520, 146);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 38);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // ListDataBreaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblCreditCards);
            this.Controls.Add(this.dgvCreditCards);
            this.Controls.Add(this.dgvPasswords);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTitle);
            this.Name = "ListDataBreaches";
            this.Size = new System.Drawing.Size(626, 419);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvPasswords;
        private System.Windows.Forms.DataGridView dgvCreditCards;
        private System.Windows.Forms.Label lblCreditCards;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnModify;
    }
}
