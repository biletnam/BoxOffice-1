namespace BoxOffice
{
	partial class MainMenu
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
			this.cb_Movie = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_SelectSeats = new System.Windows.Forms.Button();
			this.dTPicker_Sessao = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_Title = new System.Windows.Forms.TextBox();
			this.txt_Runtime = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btn_InsertMovie = new System.Windows.Forms.Button();
			this.btn_Insert_Movie = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(58, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Filme:";
			// 
			// cb_Movie
			// 
			this.cb_Movie.FormattingEnabled = true;
			this.cb_Movie.Location = new System.Drawing.Point(98, 61);
			this.cb_Movie.Name = "cb_Movie";
			this.cb_Movie.Size = new System.Drawing.Size(341, 21);
			this.cb_Movie.TabIndex = 1;
			this.cb_Movie.SelectedIndexChanged += new System.EventHandler(this.cb_Movie_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Data da Sessão:";
			// 
			// btn_SelectSeats
			// 
			this.btn_SelectSeats.Location = new System.Drawing.Point(310, 102);
			this.btn_SelectSeats.Name = "btn_SelectSeats";
			this.btn_SelectSeats.Size = new System.Drawing.Size(129, 23);
			this.btn_SelectSeats.TabIndex = 4;
			this.btn_SelectSeats.Text = "Seleccionar Lugares";
			this.btn_SelectSeats.UseVisualStyleBackColor = true;
			this.btn_SelectSeats.Click += new System.EventHandler(this.btn_SelectSeats_Click);
			// 
			// dTPicker_Sessao
			// 
			this.dTPicker_Sessao.Location = new System.Drawing.Point(98, 26);
			this.dTPicker_Sessao.Name = "dTPicker_Sessao";
			this.dTPicker_Sessao.Size = new System.Drawing.Size(200, 20);
			this.dTPicker_Sessao.TabIndex = 5;
			this.dTPicker_Sessao.ValueChanged += new System.EventHandler(this.On_Date_Selection);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cb_Movie);
			this.groupBox1.Controls.Add(this.dTPicker_Sessao);
			this.groupBox1.Controls.Add(this.btn_SelectSeats);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(454, 149);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Seleccionar Sessão:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txt_Runtime);
			this.groupBox2.Controls.Add(this.txt_Title);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.btn_InsertMovie);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(505, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(454, 159);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Inserir Filme:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Título:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Duração:";
			// 
			// txt_Title
			// 
			this.txt_Title.Location = new System.Drawing.Point(63, 23);
			this.txt_Title.Name = "txt_Title";
			this.txt_Title.Size = new System.Drawing.Size(371, 20);
			this.txt_Title.TabIndex = 3;
			// 
			// txt_Runtime
			// 
			this.txt_Runtime.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txt_Runtime.Location = new System.Drawing.Point(63, 61);
			this.txt_Runtime.Name = "txt_Runtime";
			this.txt_Runtime.Size = new System.Drawing.Size(71, 20);
			this.txt_Runtime.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(140, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "minutos";
			// 
			// btn_InsertMovie
			// 
			this.btn_InsertMovie.Location = new System.Drawing.Point(305, 102);
			this.btn_InsertMovie.Name = "btn_InsertMovie";
			this.btn_InsertMovie.Size = new System.Drawing.Size(129, 23);
			this.btn_InsertMovie.TabIndex = 4;
			this.btn_InsertMovie.Text = "Inserir Filme";
			this.btn_InsertMovie.UseVisualStyleBackColor = true;
			this.btn_InsertMovie.Click += new System.EventHandler(this.btn_Insert_Movie_Click);
			// 
			// btn_Insert_Movie
			// 
			this.btn_Insert_Movie.Location = new System.Drawing.Point(305, 102);
			this.btn_Insert_Movie.Name = "btn_Insert_Movie";
			this.btn_Insert_Movie.Size = new System.Drawing.Size(129, 23);
			this.btn_Insert_Movie.TabIndex = 4;
			this.btn_Insert_Movie.Text = "Inserir Filme";
			this.btn_Insert_Movie.UseVisualStyleBackColor = true;
			this.btn_Insert_Movie.Click += new System.EventHandler(this.btn_SelectSeats_Click);
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 558);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainMenu";
			this.Text = "MainMenu";
			this.Load += new System.EventHandler(this.MainMenu_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cb_Movie;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_SelectSeats;
		private System.Windows.Forms.DateTimePicker dTPicker_Sessao;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txt_Runtime;
		private System.Windows.Forms.TextBox txt_Title;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btn_Insert_Movie;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_InsertMovie;
	}
}