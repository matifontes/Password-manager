namespace UserInterface
{
    partial class ShowDataBreachesHistory
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPasswords = new System.Windows.Forms.Label();
            this.dgvPasswords = new System.Windows.Forms.DataGridView();
            this.lblCreditCards = new System.Windows.Forms.Label();
            this.dgvCreditCards = new System.Windows.Forms.DataGridView();
            this.btnModify = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditCards)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(29, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 29);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Data breaches de la fecha: ";
            // 
            // lblPasswords
            // 
            this.lblPasswords.AutoSize = true;
            this.lblPasswords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswords.Location = new System.Drawing.Point(30, 88);
            this.lblPasswords.Name = "lblPasswords";
            this.lblPasswords.Size = new System.Drawing.Size(111, 20);
            this.lblPasswords.TabIndex = 6;
            this.lblPasswords.Text = "Contraseñas";
            // 
            // dgvPasswords
            // 
            this.dgvPasswords.AllowUserToAddRows = false;
            this.dgvPasswords.AllowUserToDeleteRows = false;
            this.dgvPasswords.AllowUserToResizeColumns = false;
            this.dgvPasswords.AllowUserToResizeRows = false;
            this.dgvPasswords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasswords.Location = new System.Drawing.Point(34, 111);
            this.dgvPasswords.MultiSelect = false;
            this.dgvPasswords.Name = "dgvPasswords";
            this.dgvPasswords.ReadOnly = true;
            this.dgvPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasswords.Size = new System.Drawing.Size(464, 130);
            this.dgvPasswords.TabIndex = 7;
            // 
            // lblCreditCards
            // 
            this.lblCreditCards.AutoSize = true;
            this.lblCreditCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCards.Location = new System.Drawing.Point(30, 290);
            this.lblCreditCards.Name = "lblCreditCards";
            this.lblCreditCards.Size = new System.Drawing.Size(159, 20);
            this.lblCreditCards.TabIndex = 8;
            this.lblCreditCards.Text = "Tarjetas de credito";
            // 
            // dgvCreditCards
            // 
            this.dgvCreditCards.AllowUserToAddRows = false;
            this.dgvCreditCards.AllowUserToDeleteRows = false;
            this.dgvCreditCards.AllowUserToResizeColumns = false;
            this.dgvCreditCards.AllowUserToResizeRows = false;
            this.dgvCreditCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCreditCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditCards.Location = new System.Drawing.Point(34, 313);
            this.dgvCreditCards.MultiSelect = false;
            this.dgvCreditCards.Name = "dgvCreditCards";
            this.dgvCreditCards.ReadOnly = true;
            this.dgvCreditCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditCards.Size = new System.Drawing.Size(464, 128);
            this.dgvCreditCards.TabIndex = 9;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(423, 247);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(31, 252);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 11;
            // 
            // ShowDataBreachesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 489);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.dgvCreditCards);
            this.Controls.Add(this.lblCreditCards);
            this.Controls.Add(this.dgvPasswords);
            this.Controls.Add(this.lblPasswords);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowDataBreachesHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPasswords;
        private System.Windows.Forms.DataGridView dgvPasswords;
        private System.Windows.Forms.Label lblCreditCards;
        private System.Windows.Forms.DataGridView dgvCreditCards;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label lblMsg;
    }
}