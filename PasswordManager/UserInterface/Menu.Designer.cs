
namespace UserInterface
{
    partial class Menu
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
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnCreditCards = new System.Windows.Forms.Button();
            this.btnPasswords = new System.Windows.Forms.Button();
            this.btnBreaches = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCategories
            // 
            this.btnCategories.Location = new System.Drawing.Point(18, 19);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(228, 43);
            this.btnCategories.TabIndex = 0;
            this.btnCategories.Text = "Categorias";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.BtnCategories_Click);
            // 
            // btnCreditCards
            // 
            this.btnCreditCards.Location = new System.Drawing.Point(18, 117);
            this.btnCreditCards.Name = "btnCreditCards";
            this.btnCreditCards.Size = new System.Drawing.Size(228, 41);
            this.btnCreditCards.TabIndex = 1;
            this.btnCreditCards.Text = "Tarjetas de Credito";
            this.btnCreditCards.UseVisualStyleBackColor = true;
            this.btnCreditCards.Click += new System.EventHandler(this.BtnCreditCards_Click);
            // 
            // btnPasswords
            // 
            this.btnPasswords.Location = new System.Drawing.Point(18, 68);
            this.btnPasswords.Name = "btnPasswords";
            this.btnPasswords.Size = new System.Drawing.Size(228, 43);
            this.btnPasswords.TabIndex = 2;
            this.btnPasswords.Text = "Contraseñas";
            this.btnPasswords.UseVisualStyleBackColor = true;
            this.btnPasswords.Click += new System.EventHandler(this.BtnPasswords_Click);
            // 
            // btnBreaches
            // 
            this.btnBreaches.Location = new System.Drawing.Point(18, 164);
            this.btnBreaches.Name = "btnBreaches";
            this.btnBreaches.Size = new System.Drawing.Size(228, 42);
            this.btnBreaches.TabIndex = 3;
            this.btnBreaches.Text = "Data Breaches";
            this.btnBreaches.UseVisualStyleBackColor = true;
            this.btnBreaches.Click += new System.EventHandler(this.BtnBreaches_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBreaches);
            this.Controls.Add(this.btnPasswords);
            this.Controls.Add(this.btnCreditCards);
            this.Controls.Add(this.btnCategories);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(265, 234);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnCreditCards;
        private System.Windows.Forms.Button btnPasswords;
        private System.Windows.Forms.Button btnBreaches;
    }
}
