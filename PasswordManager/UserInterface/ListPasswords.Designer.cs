
namespace UserInterface
{
    partial class ListPasswordsPanel
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
            this.dgvPasswords = new System.Windows.Forms.DataGridView();
            this.btnAddPassword = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPasswords
            // 
            this.dgvPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasswords.Location = new System.Drawing.Point(19, 48);
            this.dgvPasswords.Name = "dgvPasswords";
            this.dgvPasswords.Size = new System.Drawing.Size(483, 199);
            this.dgvPasswords.TabIndex = 0;
            // 
            // btnAddPassword
            // 
            this.btnAddPassword.Location = new System.Drawing.Point(381, 253);
            this.btnAddPassword.Name = "btnAddPassword";
            this.btnAddPassword.Size = new System.Drawing.Size(121, 32);
            this.btnAddPassword.TabIndex = 1;
            this.btnAddPassword.Text = "Agregar";
            this.btnAddPassword.UseVisualStyleBackColor = true;
            this.btnAddPassword.Click += new System.EventHandler(this.BtnAddPassword_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(254, 255);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(121, 30);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(127, 255);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(121, 30);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Listado de Contraseñas";
            // 
            // Passwords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAddPassword);
            this.Controls.Add(this.dgvPasswords);
            this.Name = "Passwords";
            this.Size = new System.Drawing.Size(527, 316);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPasswords;
        private System.Windows.Forms.Button btnAddPassword;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
    }
}
