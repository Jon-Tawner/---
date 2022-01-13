
namespace MyFirstApp
{
	partial class FStore
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.LogIn = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.numb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.NameSportEquip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listView = new System.Windows.Forms.ListView();
			this.updateLV = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.updateLV);
			this.panel1.Controls.Add(this.listView);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(528, 431);
			this.panel1.TabIndex = 2;
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
			this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Controls.Add(this.LogIn);
			this.panel2.Controls.Add(this.closeButton);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(528, 85);
			this.panel2.TabIndex = 0;
			// 
			// LogIn
			// 
			this.LogIn.Location = new System.Drawing.Point(0, 0);
			this.LogIn.Name = "LogIn";
			this.LogIn.Size = new System.Drawing.Size(87, 31);
			this.LogIn.TabIndex = 4;
			this.LogIn.Text = "Войти";
			this.LogIn.UseVisualStyleBackColor = true;
			this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
			// 
			// closeButton
			// 
			this.closeButton.AutoSize = true;
			this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.closeButton.Location = new System.Drawing.Point(498, 0);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(30, 29);
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "Х";
			this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
			this.closeButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
			this.closeButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(528, 85);
			this.label1.TabIndex = 1;
			this.label1.Text = "Товары";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
			this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
			// 
			// numb
			// 
			this.numb.Text = "№";
			this.numb.Width = 45;
			// 
			// NameSportEquip
			// 
			this.NameSportEquip.Text = "Название инвентаря";
			this.NameSportEquip.Width = 292;
			// 
			// Cost
			// 
			this.Cost.Text = "Стоимость в час, р";
			this.Cost.Width = 161;
			// 
			// listView
			// 
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numb,
            this.NameSportEquip,
            this.Cost});
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(12, 91);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(504, 267);
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			// 
			// updateLV
			// 
			this.updateLV.Location = new System.Drawing.Point(12, 364);
			this.updateLV.Name = "updateLV";
			this.updateLV.Size = new System.Drawing.Size(504, 55);
			this.updateLV.TabIndex = 5;
			this.updateLV.Text = "Обновить";
			this.updateLV.UseVisualStyleBackColor = true;
			this.updateLV.Click += new System.EventHandler(this.updateLV_Click);
			// 
			// FStore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 431);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FStore";
			this.Text = "FStore";
			this.Load += new System.EventHandler(this.FStore_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label closeButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button LogIn;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader numb;
		private System.Windows.Forms.ColumnHeader NameSportEquip;
		private System.Windows.Forms.ColumnHeader Cost;
		private System.Windows.Forms.Button updateLV;
	}
}