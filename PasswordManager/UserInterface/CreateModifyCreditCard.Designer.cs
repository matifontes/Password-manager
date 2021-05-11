
namespace UserInterface
{
    partial class CreateModifyCreditCard
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCCVCode = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.operationPanel = new System.Windows.Forms.Panel();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtCCVCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(27, 30);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(76, 18);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Categoria:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(27, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nombre:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(27, 110);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 18);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Tipo:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(27, 149);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(66, 18);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Número:";
            // 
            // lblCCVCode
            // 
            this.lblCCVCode.AutoSize = true;
            this.lblCCVCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCVCode.Location = new System.Drawing.Point(27, 191);
            this.lblCCVCode.Name = "lblCCVCode";
            this.lblCCVCode.Size = new System.Drawing.Size(95, 18);
            this.lblCCVCode.TabIndex = 4;
            this.lblCCVCode.Text = "Código CCV:";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiryDate.Location = new System.Drawing.Point(27, 232);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(93, 18);
            this.lblExpiryDate.TabIndex = 5;
            this.lblExpiryDate.Text = "Vencimiento:";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(27, 275);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(52, 18);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Notas:";
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(141, 30);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(176, 21);
            this.cmbCategories.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(141, 68);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 8;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(141, 111);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(176, 20);
            this.txtType.TabIndex = 9;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(141, 150);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(176, 20);
            this.txtNumber.TabIndex = 10;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(141, 275);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(176, 82);
            this.txtNote.TabIndex = 13;
            // 
            // operationPanel
            // 
            this.operationPanel.Location = new System.Drawing.Point(0, 394);
            this.operationPanel.Name = "operationPanel";
            this.operationPanel.Size = new System.Drawing.Size(364, 50);
            this.operationPanel.TabIndex = 14;
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.CustomFormat = "MM/yyyy";
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiryDate.Location = new System.Drawing.Point(143, 235);
            this.dtpExpiryDate.MaxDate = new System.DateTime(2035, 1, 1, 0, 0, 0, 0);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(174, 20);
            this.dtpExpiryDate.TabIndex = 12;
            this.dtpExpiryDate.Value = new System.DateTime(2021, 5, 10, 0, 0, 0, 0);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(27, 367);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 16;
            // 
            // txtCCVCode
            // 
            this.txtCCVCode.Location = new System.Drawing.Point(141, 192);
            this.txtCCVCode.Name = "txtCCVCode";
            this.txtCCVCode.Size = new System.Drawing.Size(176, 20);
            this.txtCCVCode.TabIndex = 11;
            // 
            // CreateModifyCreditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 444);
            this.Controls.Add(this.txtCCVCode);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.operationPanel);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.lblCCVCode);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateModifyCreditCard";
            this.Text = "CreditCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblCCVCode;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Panel operationPanel;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtCCVCode;
    }
}