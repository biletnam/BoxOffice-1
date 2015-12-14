namespace BoxOffice
{
	partial class FormClientInfo
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_Name = new System.Windows.Forms.TextBox();
			this.txt_Contact = new System.Windows.Forms.TextBox();
			this.btn_Insert = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(54, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Telefone:";
			// 
			// txt_Name
			// 
			this.txt_Name.Location = new System.Drawing.Point(98, 29);
			this.txt_Name.Name = "txt_Name";
			this.txt_Name.Size = new System.Drawing.Size(225, 20);
			this.txt_Name.TabIndex = 0;
			this.txt_Name.TextChanged += new System.EventHandler(this.txt_Name_TextChanged);
			// 
			// txt_Contact
			// 
			this.txt_Contact.Location = new System.Drawing.Point(98, 54);
			this.txt_Contact.Name = "txt_Contact";
			this.txt_Contact.Size = new System.Drawing.Size(225, 20);
			this.txt_Contact.TabIndex = 1;
			this.txt_Contact.TextChanged += new System.EventHandler(this.txt_Contact_TextChanged);
			// 
			// btn_Insert
			// 
			this.btn_Insert.Enabled = false;
			this.btn_Insert.Location = new System.Drawing.Point(170, 80);
			this.btn_Insert.Name = "btn_Insert";
			this.btn_Insert.Size = new System.Drawing.Size(75, 23);
			this.btn_Insert.TabIndex = 2;
			this.btn_Insert.Text = "Inserir";
			this.btn_Insert.UseVisualStyleBackColor = true;
			this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(248, 80);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 2;
			this.btn_Cancel.Text = "Cancelar";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// FormClientInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 139);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Insert);
			this.Controls.Add(this.txt_Contact);
			this.Controls.Add(this.txt_Name);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormClientInfo";
			this.Text = "FormClientInfo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_Name;
		private System.Windows.Forms.TextBox txt_Contact;
		private System.Windows.Forms.Button btn_Insert;
		private System.Windows.Forms.Button btn_Cancel;
	}
}