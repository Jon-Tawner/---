
namespace MyFirstApp
{
	partial class FLogIn
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
			this.buttonLogin = new System.Windows.Forms.Button();
			this.PassField = new System.Windows.Forms.TextBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.LoginField = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.StoreButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.buttonLogin);
			this.panel1.Controls.Add(this.PassField);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.LoginField);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(531, 450);
			this.panel1.TabIndex = 1;
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
			this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
			// 
			// buttonLogin
			// 
			this.buttonLogin.BackColor = System.Drawing.SystemColors.ControlDark;
			this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonLogin.FlatAppearance.BorderSize = 0;
			this.buttonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
			this.buttonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
			this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.buttonLogin.Location = new System.Drawing.Point(160, 291);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(230, 87);
			this.buttonLogin.TabIndex = 7;
			this.buttonLogin.Text = "Вход";
			this.buttonLogin.UseVisualStyleBackColor = false;
			this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
			// 
			// PassField
			// 
			this.PassField.Font = new System.Drawing.Font("Microsoft JhengHei UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PassField.Location = new System.Drawing.Point(133, 187);
			this.PassField.Name = "PassField";
			this.PassField.Size = new System.Drawing.Size(286, 49);
			this.PassField.TabIndex = 6;
			this.PassField.UseSystemPasswordChar = true;
			this.PassField.Enter += new System.EventHandler(this.PassField_Enter);
			this.PassField.Leave += new System.EventHandler(this.PassField_Leave);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::MyFirstApp.Properties.Resources.Lock;
			this.pictureBox2.Location = new System.Drawing.Point(65, 187);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(45, 47);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			// 
			// LoginField
			// 
			this.LoginField.Font = new System.Drawing.Font("Microsoft JhengHei UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginField.Location = new System.Drawing.Point(133, 122);
			this.LoginField.Multiline = true;
			this.LoginField.Name = "LoginField";
			this.LoginField.Size = new System.Drawing.Size(286, 47);
			this.LoginField.TabIndex = 4;
			this.LoginField.Enter += new System.EventHandler(this.LoginField_Enter);
			this.LoginField.Leave += new System.EventHandler(this.LoginField_Leave);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::MyFirstApp.Properties.Resources.User;
			this.pictureBox1.Location = new System.Drawing.Point(65, 122);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(45, 47);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Controls.Add(this.StoreButton);
			this.panel2.Controls.Add(this.closeButton);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(531, 85);
			this.panel2.TabIndex = 0;
			// 
			// StoreButton
			// 
			this.StoreButton.Location = new System.Drawing.Point(-12, -5);
			this.StoreButton.Name = "StoreButton";
			this.StoreButton.Size = new System.Drawing.Size(89, 31);
			this.StoreButton.TabIndex = 8;
			this.StoreButton.Text = "Магазин";
			this.StoreButton.UseVisualStyleBackColor = true;
			this.StoreButton.Click += new System.EventHandler(this.StoreButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.AutoSize = true;
			this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.closeButton.Location = new System.Drawing.Point(497, 0);
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
			this.label1.Size = new System.Drawing.Size(531, 85);
			this.label1.TabIndex = 1;
			this.label1.Text = "Авторизация";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
			this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
			// 
			// FLogIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 450);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FLogIn";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.FLogIn_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.TextBox PassField;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.TextBox LoginField;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label closeButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button StoreButton;
	}
}