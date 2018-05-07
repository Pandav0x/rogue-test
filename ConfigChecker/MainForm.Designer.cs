namespace GamePadDetector
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GamePadList = new System.Windows.Forms.ListBox();
            this.ButtonsTB = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.capasTB = new System.Windows.Forms.TextBox();
            this.mappingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GamePadList
            // 
            this.GamePadList.FormattingEnabled = true;
            this.GamePadList.Location = new System.Drawing.Point(12, 13);
            this.GamePadList.Name = "GamePadList";
            this.GamePadList.Size = new System.Drawing.Size(172, 420);
            this.GamePadList.TabIndex = 1;
            this.GamePadList.SelectedIndexChanged += new System.EventHandler(this.GamePadList_SelectedIndexChanged);
            // 
            // ButtonsTB
            // 
            this.ButtonsTB.AcceptsReturn = true;
            this.ButtonsTB.AcceptsTab = true;
            this.ButtonsTB.CausesValidation = false;
            this.ButtonsTB.Location = new System.Drawing.Point(190, 13);
            this.ButtonsTB.Multiline = true;
            this.ButtonsTB.Name = "ButtonsTB";
            this.ButtonsTB.ReadOnly = true;
            this.ButtonsTB.ShortcutsEnabled = false;
            this.ButtonsTB.Size = new System.Drawing.Size(216, 420);
            this.ButtonsTB.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // capasTB
            // 
            this.capasTB.Location = new System.Drawing.Point(412, 13);
            this.capasTB.Multiline = true;
            this.capasTB.Name = "capasTB";
            this.capasTB.ReadOnly = true;
            this.capasTB.Size = new System.Drawing.Size(187, 420);
            this.capasTB.TabIndex = 2;
            // 
            // mappingBtn
            // 
            this.mappingBtn.Location = new System.Drawing.Point(606, 13);
            this.mappingBtn.Name = "mappingBtn";
            this.mappingBtn.Size = new System.Drawing.Size(75, 23);
            this.mappingBtn.TabIndex = 4;
            this.mappingBtn.Text = "Try to Map";
            this.mappingBtn.UseVisualStyleBackColor = true;
            this.mappingBtn.Click += new System.EventHandler(this.mappingBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mappingBtn);
            this.Controls.Add(this.capasTB);
            this.Controls.Add(this.GamePadList);
            this.Controls.Add(this.ButtonsTB);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox GamePadList;
        private System.Windows.Forms.TextBox ButtonsTB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox capasTB;
        private System.Windows.Forms.Button mappingBtn;
    }
}

