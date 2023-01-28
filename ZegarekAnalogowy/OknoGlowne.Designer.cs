namespace ZegarekAnalogowy
{
    partial class OknoGlowne
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prędkośćSekundnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wolnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szybkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorSekundnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czasNaSwiecieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcjeToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prędkośćSekundnikaToolStripMenuItem,
            this.kolorSekundnikaToolStripMenuItem,
            this.czasNaSwiecieToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // prędkośćSekundnikaToolStripMenuItem
            // 
            this.prędkośćSekundnikaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wolnoToolStripMenuItem,
            this.szybkoToolStripMenuItem});
            this.prędkośćSekundnikaToolStripMenuItem.Name = "prędkośćSekundnikaToolStripMenuItem";
            this.prędkośćSekundnikaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.prędkośćSekundnikaToolStripMenuItem.Text = "Prędkość sekundnika";
            // 
            // wolnoToolStripMenuItem
            // 
            this.wolnoToolStripMenuItem.Name = "wolnoToolStripMenuItem";
            this.wolnoToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.wolnoToolStripMenuItem.Text = "Wolno";
            this.wolnoToolStripMenuItem.Click += new System.EventHandler(this.wolnoToolStripMenuItem_Click);
            // 
            // szybkoToolStripMenuItem
            // 
            this.szybkoToolStripMenuItem.Checked = true;
            this.szybkoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.szybkoToolStripMenuItem.Name = "szybkoToolStripMenuItem";
            this.szybkoToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.szybkoToolStripMenuItem.Text = "Szybko";
            this.szybkoToolStripMenuItem.Click += new System.EventHandler(this.szybkoToolStripMenuItem_Click);
            // 
            // kolorSekundnikaToolStripMenuItem
            // 
            this.kolorSekundnikaToolStripMenuItem.Name = "kolorSekundnikaToolStripMenuItem";
            this.kolorSekundnikaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.kolorSekundnikaToolStripMenuItem.Text = "Kolor sekundnika...";
            this.kolorSekundnikaToolStripMenuItem.Click += new System.EventHandler(this.kolorSekundnikaToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // czasNaSwiecieToolStripMenuItem
            // 
            this.czasNaSwiecieToolStripMenuItem.Name = "czasNaSwiecieToolStripMenuItem";
            this.czasNaSwiecieToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.czasNaSwiecieToolStripMenuItem.Text = "Czas światowy";
            this.czasNaSwiecieToolStripMenuItem.Click += new System.EventHandler(this.czasNaSwiecieToolStripMenuItem_Click);
            // 
            // OknoGlowne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(162, 143);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OknoGlowne";
            this.ShowInTaskbar = false;
            this.Text = "Zegar analogowy";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OknoGlowne_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OknoGlowne_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OknoGlowne_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OknoGlowne_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OknoGlowne_MouseMove);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem prędkośćSekundnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wolnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szybkoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorSekundnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czasNaSwiecieToolStripMenuItem;
    }
}

