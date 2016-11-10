namespace MoveThing
{
    partial class Form1
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
            this.playArea = new System.Windows.Forms.PictureBox();
            this.txtInventory = new System.Windows.Forms.TextBox();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.playArea)).BeginInit();
            this.SuspendLayout();
            // 
            // playArea
            // 
            this.playArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.playArea.Location = new System.Drawing.Point(22, 28);
            this.playArea.Name = "playArea";
            this.playArea.Size = new System.Drawing.Size(1021, 1072);
            this.playArea.TabIndex = 0;
            this.playArea.TabStop = false;
            // 
            // txtInventory
            // 
            this.txtInventory.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInventory.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtInventory.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtInventory.Location = new System.Drawing.Point(1036, 0);
            this.txtInventory.Multiline = true;
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.ReadOnly = true;
            this.txtInventory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInventory.Size = new System.Drawing.Size(167, 1097);
            this.txtInventory.TabIndex = 2;
            this.txtInventory.WordWrap = false;
            this.txtInventory.Enter += new System.EventHandler(this.txtInventory_Enter);
            // 
            // txtHistory
            // 
            this.txtHistory.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtHistory.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtHistory.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtHistory.Location = new System.Drawing.Point(0, 920);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistory.Size = new System.Drawing.Size(1036, 177);
            this.txtHistory.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1036, 13);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1203, 1097);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.txtInventory);
            this.Controls.Add(this.playArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.playArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox playArea;
        private System.Windows.Forms.TextBox txtInventory;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.TextBox textBox1;
    }
}

