
namespace UserInterface
{
    partial class ChangePassword
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
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtActualPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtRepeatNewPassword = new System.Windows.Forms.TextBox();
            this.lblActualPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblRepeatNewPassword = new System.Windows.Forms.Label();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(23, 251);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(256, 45);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Text = "Cambiar";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 19);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(124, 45);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtActualPassword
            // 
            this.txtActualPassword.Location = new System.Drawing.Point(24, 104);
            this.txtActualPassword.Name = "txtActualPassword";
            this.txtActualPassword.Size = new System.Drawing.Size(254, 20);
            this.txtActualPassword.TabIndex = 2;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(24, 150);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(254, 20);
            this.txtNewPassword.TabIndex = 3;
            // 
            // txtRepeatNewPassword
            // 
            this.txtRepeatNewPassword.Location = new System.Drawing.Point(24, 196);
            this.txtRepeatNewPassword.Name = "txtRepeatNewPassword";
            this.txtRepeatNewPassword.Size = new System.Drawing.Size(253, 20);
            this.txtRepeatNewPassword.TabIndex = 4;
            // 
            // lblActualPassword
            // 
            this.lblActualPassword.AutoSize = true;
            this.lblActualPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualPassword.Location = new System.Drawing.Point(17, 81);
            this.lblActualPassword.Name = "lblActualPassword";
            this.lblActualPassword.Size = new System.Drawing.Size(145, 20);
            this.lblActualPassword.TabIndex = 5;
            this.lblActualPassword.Text = "Contraseña Actual:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(17, 127);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(145, 20);
            this.lblNewPassword.TabIndex = 6;
            this.lblNewPassword.Text = "Nueva Contraseña:";
            // 
            // lblRepeatNewPassword
            // 
            this.lblRepeatNewPassword.AutoSize = true;
            this.lblRepeatNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatNewPassword.Location = new System.Drawing.Point(17, 173);
            this.lblRepeatNewPassword.Name = "lblRepeatNewPassword";
            this.lblRepeatNewPassword.Size = new System.Drawing.Size(201, 20);
            this.lblRepeatNewPassword.TabIndex = 7;
            this.lblRepeatNewPassword.Text = "Repetir Nueva Contraseña:";
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(21, 229);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMsg.TabIndex = 8;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.lblRepeatNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblActualPassword);
            this.Controls.Add(this.txtRepeatNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtActualPassword);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChangePassword);
            this.Name = "ChangePassword";
            this.Size = new System.Drawing.Size(299, 333);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtActualPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtRepeatNewPassword;
        private System.Windows.Forms.Label lblActualPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblRepeatNewPassword;
        private System.Windows.Forms.Label lblErrorMsg;
    }
}
