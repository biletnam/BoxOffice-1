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
	public partial class FormScreen : Form
	{
		View_Session selectedView_Session = new View_Session(); // Saves the information about the currently selected
		List<Ticket> selected_tickets = new List<Ticket>();

		/// <summary>
		/// Launches the form
		/// </summary>
		/// <param name="view_Session">Session info for currently selected session</param>
		public FormScreen(View_Session view_Session)
		{
			InitializeComponent();
			selectedView_Session = view_Session;
			lbl_Movie_Title.Text = selectedView_Session.Title.ToString();
			lbl_Movie_Date.Text = selectedView_Session.Date.ToShortDateString();
			lbl_Session_Time.Text = selectedView_Session.StartTime.ToString(@"hh\:mm");
			lbl_Screen_Name.Text = selectedView_Session.Name;
			lbl_Movie_Runtime.Text = selectedView_Session.Runtime.ToString() + " min";
		}

		private void FormScreen_Load(object sender, EventArgs e)
		{
			Sala_Load();
		}

		/// <summary>
		/// Draws the room, painting the seats green, red or blue depending on free, occupied or reserved
		/// </summary>
		private void Sala_Load()
		{
			// List with seats disposition or selected Screen
			List<Seat> seats = BoxOfficeHelper.Select_Seats_byScreen(selectedView_Session.IdScreen);

			// List with tickets sold for selected session
			List<View_Ticket> tickets = BoxOfficeHelper.Select_Tickets_bySession(selectedView_Session.IdScreen, selectedView_Session.IdMovie, selectedView_Session.Date);

			if (seats != null)
			{
				// Verifies number and disposition of seats for selected screen, enables them for selection and paints them green.
				foreach (Seat seat in seats)
				{
					PaintSeat(seat);
				}
			}

			if (tickets != null)
			{
				foreach (View_Ticket vt in tickets)
				{
					Ticket ticket = new Ticket()
					{
						IdScreen = vt.IdScreen,
						Row = vt.Row,
						Number = vt.Number,
						IdMovie = vt.IdMovie,
						Date = vt.Date,
						IdClient = vt.IdClient
					};
					// paints occupied and reserved seats
					PaintSeat(ticket);
				}
			}
			
		}

		private void pictureBox_Click(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			bool newSelection = true;
			
			// example of the name to decompose: pictureBox_A_10
			string[] parts = pb.Name.Split('_');
			int row = int.Parse(parts[1]);
			int num = int.Parse(parts[2]);

			Ticket selected_ticket = new Ticket()
			{
				IdScreen = selectedView_Session.IdScreen,
				Row = row,
				Number = num,
				IdMovie = selectedView_Session.IdMovie,
				Date = selectedView_Session.Date,
				IdClient = null
			};

			foreach (Ticket ticket in selected_tickets)
			{
				if (ticket.Row == selected_ticket.Row && ticket.Number == selected_ticket.Number)
				{
					newSelection = false; // identifies as clicking in a selected seat => deselect this seat 
					break;
				}
			}

			PaintSeat(selected_ticket, newSelection); // paints the selected seat black or green

			if (newSelection)
				selected_tickets.Add(selected_ticket); // adds ticket to the list of selected tickets
			else
				selected_tickets.RemoveAll(ticket => (ticket.Row==selected_ticket.Row && ticket.Number == selected_ticket.Number)); // removes the ticket from the list of selected tickets
		}

		/// <summary>
		/// Verifies number and disposition of seats for selected screen, enables them for selection and paints them green.
		/// </summary>
		/// <param name="seat">Seat</param>
		private void PaintSeat(Seat seat)
		{
			bool disabled = false;

			string pbName = "pb_" + seat.Row + "_" + seat.Number; // creats label for picture box
			PictureBox pb = (PictureBox)this.Controls[pbName]; // points to the control with the name of the picture box

			disabled = BoxOfficeHelper.IsDisabledSeat(seat);

			if (pb != null) // if it's a seat on the selected screen
			{
				if (disabled)
					pb.Image = Properties.Resources.Seat_Disabled_Free;
				else
					pb.Image = Properties.Resources.Seat_Free;
				pb.Enabled = true; // enables the seats that are valid for selected screen
			}
		}

		/// <summary>
		/// Paints the seat blue or red for reserver or sold
		/// </summary>
		/// <param name="ticket">Ticket</param>
		private void PaintSeat(Ticket ticket)
		{
			bool disabled = false;
			Seat seat = new Seat() { IdScreen = ticket.IdScreen, Number = ticket.Number, Row = ticket.Row };

			string pbName = "pb_" + ticket.Row + "_" + ticket.Number; // cria o label do picture box
			PictureBox pb = (PictureBox)this.Controls[pbName]; // aponta para o controlo com o nome da picture box

			disabled = BoxOfficeHelper.IsDisabledSeat(seat);


			if (ticket.IdClient.HasValue)
			{
				if (disabled)
				{
					pb.Image = Properties.Resources.Seat_Disabled_Reserved;
					pb.Enabled = false; // TEMPORARIO  disables picture box because sit is already reserved
				}
				else
				{
					pb.Image = Properties.Resources.Seat_Reserved;
					pb.Enabled = false; // TEMPORARIO  disables picture box because sit is already reserved
				}
			}
			else
			{
				if (disabled)
				{
					pb.Image = Properties.Resources.Seat_Disabled_Occupied;
					pb.Enabled = false; // disables picture box because sit is already sold
				}
				else
				{
					pb.Image = Properties.Resources.Seat_Occupied;
					pb.Enabled = false; // disables picture box because sit is already sold
				}
				
			}
		}

		/// <summary>
		/// Paints the seat black when the user selects it and green if he cancels the seletin
		/// </summary>
		/// <param name="ticket">Ticket</param>
		/// <param name="selection">Selection - True, is seat is being selected by user</param>
		private void PaintSeat(Ticket ticket, bool selection)
		{
			bool disabled = false;
			Seat seat = new Seat() { IdScreen = ticket.IdScreen, Number = ticket.Number, Row = ticket.Row };

			string pbName = "pb_" + ticket.Row + "_" + ticket.Number; // cria o label do picture box
			PictureBox pb = (PictureBox)this.Controls[pbName]; // aponta para o controlo com o nome da picture box

			disabled = BoxOfficeHelper.IsDisabledSeat(seat); // checks if it's a disabled seat

			// paint the selected seat black
			if (selection)
			{
				if (disabled)
					pb.Image = Properties.Resources.Seat_Disabled_Selected;
				else
					pb.Image = Properties.Resources.Seat_Selected; 
			}
			else
			{
				if (disabled)
					pb.Image = Properties.Resources.Seat_Disabled_Free;
				else
					pb.Image = Properties.Resources.Seat_Free;
			}
		}

		/// <summary>
		/// Buys selecte tickets
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_BuyTickets_Click(object sender, EventArgs e)
		{
			Buy_Tickets();
		}

		/// <summary>
		/// Buys or Reserves selected tickets
		/// </summary>
		private void Buy_Tickets()
		{
			foreach (Ticket ticket in selected_tickets)
			{
				BoxOfficeHelper.Ticket_Insert(ticket);
			}
			selected_tickets.Clear(); // clears the list after inserting the tickets into the database
			Sala_Load(); // Re
		}

		private void btn_Reserve_Tickets_Click(object sender, EventArgs e)
		{
			int idClient;

			FormClientInfo formClientInfo = new FormClientInfo();
			if (formClientInfo.ShowDialog() == DialogResult.OK) // calls the form to select seats and passes the information regarding selected session
			{
				idClient = BoxOfficeHelper.Client_Insert(formClientInfo.Client);
				foreach (Ticket ticket in selected_tickets)
				{
					ticket.IdClient = idClient;
				}
				Buy_Tickets(); // Places a reservation instead of bouting, because we have attibuted an IdClient to each teicket
			}
			else
			{

			}



			

			formClientInfo.Dispose();
		}
	}
}
