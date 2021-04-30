
namespace UserInterface
{
    partial class RegisterProfile
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
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblRepeatPassword = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnCreateProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(38, 44);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(262, 26);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "Ingrese nueva contraseña";
            // 
            // lblRepeatPassword
            // 
            this.lblRepeatPassword.AutoSize = true;
            this.lblRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatPassword.Location = new System.Drawing.Point(38, 127);
            this.lblRepeatPassword.Name = "lblRepeatPassword";
            this.lblRepeatPassword.Size = new System.Drawing.Size(346, 26);
            this.lblRepeatPassword.TabIndex = 1;
            this.lblRepeatPassword.Text = "Ingrese nuevamente la contraseña";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(42, 167);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(353, 20);
            this.textBox2.TabIndex = 3;
            // 
            // btnCreateProfile
            // 
            this.btnCreateProfile.Location = new System.Drawing.Point(261, 205);
            this.btnCreateProfile.Name = "btnCreateProfile";
            this.btnCreateProfile.Size = new System.Drawing.Size(134, 58);
            this.btnCreateProfile.TabIndex = 4;
            this.btnCreateProfile.Text = "Crear";
            this.btnCreateProfile.UseVisualStyleBackColor = true;
            // 
            // RegisterProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreateProfile);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblRepeatPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Name = "RegisterProfile";
            this.Size = new System.Drawing.Size(437, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblRepeatPassword;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnCreateProfile;
    }
}
