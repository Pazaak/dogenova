namespace Dogenova
{
    partial class automatic_scene
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.drop2 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.drop1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.runButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mageLabel = new System.Windows.Forms.Label();
            this.shooterLabel = new System.Windows.Forms.Label();
            this.soldierLabel = new System.Windows.Forms.Label();
            this.fighterLabel = new System.Windows.Forms.Label();
            this.hereticLabel = new System.Windows.Forms.Label();
            this.priestLabel = new System.Windows.Forms.Label();
            this.knightLabel = new System.Windows.Forms.Label();
            this.scoutLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.t2stdtimeLabel = new System.Windows.Forms.Label();
            this.t2mtimeLabel = new System.Windows.Forms.Label();
            this.t1stdtimeLabel = new System.Windows.Forms.Label();
            this.t1mtimeLabel = new System.Windows.Forms.Label();
            this.stdturnsLabel = new System.Windows.Forms.Label();
            this.mturnsLabel = new System.Windows.Forms.Label();
            this.t1ratioLabel = new System.Windows.Forms.Label();
            this.t2Label = new System.Windows.Forms.Label();
            this.t1Label = new System.Windows.Forms.Label();
            this.iterLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.64151F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.35849F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(518, 85);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.drop2);
            this.panel2.Location = new System.Drawing.Point(262, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 79);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Controller Team 2";
            // 
            // drop2
            // 
            this.drop2.FormattingEnabled = true;
            this.drop2.Items.AddRange(new object[] {
            "Random",
            "Classic",
            "Alfa-Beta"});
            this.drop2.Location = new System.Drawing.Point(6, 55);
            this.drop2.Name = "drop2";
            this.drop2.Size = new System.Drawing.Size(121, 21);
            this.drop2.TabIndex = 11;
            this.drop2.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.drop1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 79);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Controller Team 1";
            // 
            // drop1
            // 
            this.drop1.FormattingEnabled = true;
            this.drop1.Items.AddRange(new object[] {
            "Random",
            "Classic",
            "Alfa-Beta"});
            this.drop1.Location = new System.Drawing.Point(6, 55);
            this.drop1.Name = "drop1";
            this.drop1.Size = new System.Drawing.Size(121, 21);
            this.drop1.TabIndex = 11;
            this.drop1.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.runButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.stopButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.quitButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 407);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(518, 51);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // runButton
            // 
            this.runButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runButton.Location = new System.Drawing.Point(3, 3);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(166, 45);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton.Location = new System.Drawing.Point(175, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(166, 45);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quitButton.Location = new System.Drawing.Point(347, 3);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(168, 45);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 94);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(518, 307);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mageLabel);
            this.panel3.Controls.Add(this.shooterLabel);
            this.panel3.Controls.Add(this.soldierLabel);
            this.panel3.Controls.Add(this.fighterLabel);
            this.panel3.Controls.Add(this.hereticLabel);
            this.panel3.Controls.Add(this.priestLabel);
            this.panel3.Controls.Add(this.knightLabel);
            this.panel3.Controls.Add(this.scoutLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(262, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 301);
            this.panel3.TabIndex = 0;
            // 
            // mageLabel
            // 
            this.mageLabel.AutoSize = true;
            this.mageLabel.Location = new System.Drawing.Point(3, 0);
            this.mageLabel.Name = "mageLabel";
            this.mageLabel.Size = new System.Drawing.Size(104, 13);
            this.mageLabel.TabIndex = 6;
            this.mageLabel.Text = "Mage Win Ratio: 0%";
            // 
            // shooterLabel
            // 
            this.shooterLabel.AutoSize = true;
            this.shooterLabel.Location = new System.Drawing.Point(3, 52);
            this.shooterLabel.Name = "shooterLabel";
            this.shooterLabel.Size = new System.Drawing.Size(41, 13);
            this.shooterLabel.TabIndex = 10;
            this.shooterLabel.Text = "label13";
            // 
            // soldierLabel
            // 
            this.soldierLabel.AutoSize = true;
            this.soldierLabel.Location = new System.Drawing.Point(3, 78);
            this.soldierLabel.Name = "soldierLabel";
            this.soldierLabel.Size = new System.Drawing.Size(41, 13);
            this.soldierLabel.TabIndex = 12;
            this.soldierLabel.Text = "label15";
            // 
            // fighterLabel
            // 
            this.fighterLabel.AutoSize = true;
            this.fighterLabel.Location = new System.Drawing.Point(3, 91);
            this.fighterLabel.Name = "fighterLabel";
            this.fighterLabel.Size = new System.Drawing.Size(41, 13);
            this.fighterLabel.TabIndex = 13;
            this.fighterLabel.Text = "label16";
            // 
            // hereticLabel
            // 
            this.hereticLabel.AutoSize = true;
            this.hereticLabel.Location = new System.Drawing.Point(3, 13);
            this.hereticLabel.Name = "hereticLabel";
            this.hereticLabel.Size = new System.Drawing.Size(111, 13);
            this.hereticLabel.TabIndex = 7;
            this.hereticLabel.Text = "Heretic Win Ratio: 0%";
            // 
            // priestLabel
            // 
            this.priestLabel.AutoSize = true;
            this.priestLabel.Location = new System.Drawing.Point(3, 26);
            this.priestLabel.Name = "priestLabel";
            this.priestLabel.Size = new System.Drawing.Size(41, 13);
            this.priestLabel.TabIndex = 8;
            this.priestLabel.Text = "label11";
            // 
            // knightLabel
            // 
            this.knightLabel.AutoSize = true;
            this.knightLabel.Location = new System.Drawing.Point(3, 65);
            this.knightLabel.Name = "knightLabel";
            this.knightLabel.Size = new System.Drawing.Size(41, 13);
            this.knightLabel.TabIndex = 11;
            this.knightLabel.Text = "label14";
            // 
            // scoutLabel
            // 
            this.scoutLabel.AutoSize = true;
            this.scoutLabel.Location = new System.Drawing.Point(3, 39);
            this.scoutLabel.Name = "scoutLabel";
            this.scoutLabel.Size = new System.Drawing.Size(41, 13);
            this.scoutLabel.TabIndex = 9;
            this.scoutLabel.Text = "label12";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.t2stdtimeLabel);
            this.panel4.Controls.Add(this.t2mtimeLabel);
            this.panel4.Controls.Add(this.t1stdtimeLabel);
            this.panel4.Controls.Add(this.t1mtimeLabel);
            this.panel4.Controls.Add(this.stdturnsLabel);
            this.panel4.Controls.Add(this.mturnsLabel);
            this.panel4.Controls.Add(this.t1ratioLabel);
            this.panel4.Controls.Add(this.t2Label);
            this.panel4.Controls.Add(this.t1Label);
            this.panel4.Controls.Add(this.iterLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(253, 301);
            this.panel4.TabIndex = 1;
            // 
            // t2stdtimeLabel
            // 
            this.t2stdtimeLabel.AutoSize = true;
            this.t2stdtimeLabel.Location = new System.Drawing.Point(3, 117);
            this.t2stdtimeLabel.Name = "t2stdtimeLabel";
            this.t2stdtimeLabel.Size = new System.Drawing.Size(35, 13);
            this.t2stdtimeLabel.TabIndex = 9;
            this.t2stdtimeLabel.Text = "label6";
            // 
            // t2mtimeLabel
            // 
            this.t2mtimeLabel.AutoSize = true;
            this.t2mtimeLabel.Location = new System.Drawing.Point(3, 104);
            this.t2mtimeLabel.Name = "t2mtimeLabel";
            this.t2mtimeLabel.Size = new System.Drawing.Size(35, 13);
            this.t2mtimeLabel.TabIndex = 8;
            this.t2mtimeLabel.Text = "label5";
            // 
            // t1stdtimeLabel
            // 
            this.t1stdtimeLabel.AutoSize = true;
            this.t1stdtimeLabel.Location = new System.Drawing.Point(3, 91);
            this.t1stdtimeLabel.Name = "t1stdtimeLabel";
            this.t1stdtimeLabel.Size = new System.Drawing.Size(35, 13);
            this.t1stdtimeLabel.TabIndex = 7;
            this.t1stdtimeLabel.Text = "label4";
            // 
            // t1mtimeLabel
            // 
            this.t1mtimeLabel.AutoSize = true;
            this.t1mtimeLabel.Location = new System.Drawing.Point(3, 78);
            this.t1mtimeLabel.Name = "t1mtimeLabel";
            this.t1mtimeLabel.Size = new System.Drawing.Size(35, 13);
            this.t1mtimeLabel.TabIndex = 6;
            this.t1mtimeLabel.Text = "label3";
            // 
            // stdturnsLabel
            // 
            this.stdturnsLabel.AutoSize = true;
            this.stdturnsLabel.Location = new System.Drawing.Point(3, 65);
            this.stdturnsLabel.Name = "stdturnsLabel";
            this.stdturnsLabel.Size = new System.Drawing.Size(146, 13);
            this.stdturnsLabel.TabIndex = 5;
            this.stdturnsLabel.Text = "Standard deviation of turns: 0";
            // 
            // mturnsLabel
            // 
            this.mturnsLabel.AutoSize = true;
            this.mturnsLabel.Location = new System.Drawing.Point(3, 52);
            this.mturnsLabel.Name = "mturnsLabel";
            this.mturnsLabel.Size = new System.Drawing.Size(84, 13);
            this.mturnsLabel.TabIndex = 4;
            this.mturnsLabel.Text = "Mean of turns: 0";
            // 
            // t1ratioLabel
            // 
            this.t1ratioLabel.AutoSize = true;
            this.t1ratioLabel.Location = new System.Drawing.Point(3, 39);
            this.t1ratioLabel.Name = "t1ratioLabel";
            this.t1ratioLabel.Size = new System.Drawing.Size(125, 13);
            this.t1ratioLabel.TabIndex = 3;
            this.t1ratioLabel.Text = "Win Ratio of Team 1: 0%";
            // 
            // t2Label
            // 
            this.t2Label.AutoSize = true;
            this.t2Label.Location = new System.Drawing.Point(3, 26);
            this.t2Label.Name = "t2Label";
            this.t2Label.Size = new System.Drawing.Size(96, 13);
            this.t2Label.TabIndex = 2;
            this.t2Label.Text = "Wins by Team 2: 0";
            // 
            // t1Label
            // 
            this.t1Label.AutoSize = true;
            this.t1Label.Location = new System.Drawing.Point(3, 13);
            this.t1Label.Name = "t1Label";
            this.t1Label.Size = new System.Drawing.Size(96, 13);
            this.t1Label.TabIndex = 1;
            this.t1Label.Text = "Wins by Team 1: 0";
            // 
            // iterLabel
            // 
            this.iterLabel.AutoSize = true;
            this.iterLabel.Location = new System.Drawing.Point(3, 0);
            this.iterLabel.Name = "iterLabel";
            this.iterLabel.Size = new System.Drawing.Size(62, 13);
            this.iterLabel.TabIndex = 0;
            this.iterLabel.Text = "Iterations: 0";
            // 
            // automatic_scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "automatic_scene";
            this.Text = "Automatic Evaluation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drop2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drop1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label mageLabel;
        private System.Windows.Forms.Label shooterLabel;
        private System.Windows.Forms.Label soldierLabel;
        private System.Windows.Forms.Label fighterLabel;
        private System.Windows.Forms.Label hereticLabel;
        private System.Windows.Forms.Label priestLabel;
        private System.Windows.Forms.Label knightLabel;
        private System.Windows.Forms.Label scoutLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label stdturnsLabel;
        private System.Windows.Forms.Label mturnsLabel;
        private System.Windows.Forms.Label t1ratioLabel;
        private System.Windows.Forms.Label t2Label;
        private System.Windows.Forms.Label t1Label;
        private System.Windows.Forms.Label iterLabel;
        private System.Windows.Forms.Label t2stdtimeLabel;
        private System.Windows.Forms.Label t2mtimeLabel;
        private System.Windows.Forms.Label t1stdtimeLabel;
        private System.Windows.Forms.Label t1mtimeLabel;
    }
}