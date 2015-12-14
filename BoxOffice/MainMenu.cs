using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxOffice
{
	public partial class MainMenu : Form
	{
		DataTable sessions = null; // Saves the information about sessions from last consult to Database = The ones that are available for selection by the user
		View_Session selectedView_Session = new View_Session(); // Saves the information about the currently selected/selectable session

		public MainMenu()
		{
			InitializeComponent();
		}

		private void MainMenu_Load(object sender, EventArgs e)
		{
			Populate_Movie_CBox(); // Coloca os filmes de hoje para escolha na movie box (escolha por defeito)
		}

		/// <summary>
		/// Places movies in cb_movie for selection
		/// </summary>
		private void Populate_Movie_CBox()
		{
			DateTime date = dTPicker_Sessao.Value.Date;
			sessions = BoxOfficeHelper.Select_Session_byDate(date);

			cb_Movie.Items.Clear(); // clears preious movie selection
			cb_Movie.Text = ""; // clears the last selection	

			foreach (DataRow row in sessions.Rows)
			{
				cb_Movie.Items.Add(row.ItemArray[0]); // index 0 = movie titles
			}

			if (cb_Movie.Items.Count > 0)
			{
				cb_Movie.SelectedIndex = 0; // pre-selects the first movie, in case it exists (=> automaticaly runs On_Movie_Selection)
			}
			else
				btn_SelectSeats.Enabled = false; // disables to button to go to seat selection because no session is selected
		}

		/// <summary>
		/// Repopulates the movie box when date is changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void On_Date_Selection(object sender, EventArgs e)
		{
			Populate_Movie_CBox();
		}

		/// <summary>
		/// Saves the information from the movie on selectedView_Session and enables the button to go to Seat Selection
		/// </summary>
		private void On_Movie_Selection()
		{
			string movieTitle = (string)cb_Movie.SelectedItem;

			foreach (DataRow row in sessions.Rows)
			{
				if ((string)row.ItemArray[0] == movieTitle)			// saves the current session information
				{
					selectedView_Session.Title = (string)row.ItemArray[0];
					selectedView_Session.Runtime = (int)row.ItemArray[1];
					selectedView_Session.Name = (string)row.ItemArray[2];
					selectedView_Session.NumberOfSeats = (int)row.ItemArray[3];
					selectedView_Session.IdMovie = (int)row.ItemArray[4];
					selectedView_Session.IdScreen = (int)row.ItemArray[5];
					selectedView_Session.Date = (DateTime)row.ItemArray[6];
					selectedView_Session.StartTime = (TimeSpan)row.ItemArray[7];
					btn_SelectSeats.Enabled = true; // enables the button to go to seat selection
					break;
				}
			}
		}

		private void cb_Movie_SelectedIndexChanged(object sender, EventArgs e)
		{
			On_Movie_Selection();
		}

		/// <summary>
		/// Launches FormScreen for the selected Session
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_SelectSeats_Click(object sender, EventArgs e)
		{
			FormScreen formScreen = new FormScreen(selectedView_Session);
			formScreen.ShowDialog(); // calls the form to select seats and passes the information regarding selected session
		}

		/// <summary>
		/// Inserts a movie into the database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Insert_Movie_Click(object sender, EventArgs e)
		{
			Movie movie = new Movie();
			int id;

			if (txt_Title.Text != "" && txt_Runtime.Text != "")
			{
				try
				{
					movie.Title = txt_Title.Text;
					movie.Runtime = int.Parse(txt_Runtime.Text);
					id = BoxOfficeHelper.Movie_Insert(movie);
					if (id > 0)
						MessageBox.Show("Filme Inserido com sucesso", "Filme inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else
						MessageBox.Show("A inserção do filme falhou", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception)
				{
					MessageBox.Show("Duração tem de ser um número inteiro", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Dados Inválidos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
	}
}
