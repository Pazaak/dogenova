namespace Dogenova
{
    partial class mode_selection
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.automaticButton = new System.Windows.Forms.Button();
            this.manualButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.automaticButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.manualButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.quitButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.32468F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.67533F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 154);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // automaticButton
            // 
            this.automaticButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.automaticButton.Location = new System.Drawing.Point(149, 3);
            this.automaticButton.Name = "automaticButton";
            this.automaticButton.Size = new System.Drawing.Size(140, 109);
            this.automaticButton.TabIndex = 1;
            this.automaticButton.Text = "Automatic";
            this.automaticButton.UseVisualStyleBackColor = true;
            this.automaticButton.Click += new System.EventHandler(this.automaticButton_Click);
            // 
            // manualButton
            // 
            this.manualButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manualButton.Location = new System.Drawing.Point(3, 3);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(140, 109);
            this.manualButton.TabIndex = 0;
            this.manualButton.Text = "Manual";
            this.manualButton.UseVisualStyleBackColor = true;
            this.manualButton.Click += new System.EventHandler(this.manualButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quitButton.Location = new System.Drawing.Point(149, 118);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(140, 33);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // mode_selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 154);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "mode_selection";
            this.Text = "Mode Selection";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button automaticButton;
        private System.Windows.Forms.Button manualButton;
        private System.Windows.Forms.Button quitButton;
    }
}