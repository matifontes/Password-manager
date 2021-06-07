namespace UserInterface
{
    partial class DataBreachesHistory
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
            this.dBreachesHistoryTitle = new System.Windows.Forms.Label();
            this.dBreachList = new System.Windows.Forms.ListBox();
            this.showBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dBreachesHistoryTitle
            // 
            this.dBreachesHistoryTitle.AutoSize = true;
            this.dBreachesHistoryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dBreachesHistoryTitle.Location = new System.Drawing.Point(30, 34);
            this.dBreachesHistoryTitle.Name = "dBreachesHistoryTitle";
            this.dBreachesHistoryTitle.Size = new System.Drawing.Size(380, 33);
            this.dBreachesHistoryTitle.TabIndex = 0;
            this.dBreachesHistoryTitle.Text = "Historial de data breaches";
            // 
            // dBreachList
            // 
            this.dBreachList.FormattingEnabled = true;
            this.dBreachList.Location = new System.Drawing.Point(36, 105);
            this.dBreachList.Name = "dBreachList";
            this.dBreachList.Size = new System.Drawing.Size(407, 264);
            this.dBreachList.TabIndex = 1;
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(344, 375);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(99, 40);
            this.showBtn.TabIndex = 2;
            this.showBtn.Text = "button1";
            this.showBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(208, 375);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(99, 40);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Volver";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // DataBreachesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.dBreachList);
            this.Controls.Add(this.dBreachesHistoryTitle);
            this.Name = "DataBreachesHistory";
            this.Size = new System.Drawing.Size(502, 463);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dBreachesHistoryTitle;
        private System.Windows.Forms.ListBox dBreachList;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Button backBtn;
    }
}
