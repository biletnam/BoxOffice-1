using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
	public static class BoxOfficeHelper
	{
		public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\DataBase\TicketSalesManager.mdf;Integrated Security=True;Connect Timeout=30";

		/// <summary>
		/// Insert client into table Clients
		/// </summary>
		/// <param name="client">client info</param>
		/// <returns>Client.Id of inserted client. 0 if insertion fails.</returns>
		public static int Client_Insert(Client client)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null, sqlCommand2 = null;
			SqlTransaction sqlTransation = null;

			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				sqlTransation = sqlConnection.BeginTransaction();
				sqlCommand = new SqlCommand(@"INSERT INTO Clients 
											(Name, Contact) VALUES 
											(@name, @contact)", sqlConnection, sqlTransation);
				sqlCommand.Parameters.AddWithValue("@name", client.Name);
				sqlCommand.Parameters.AddWithValue("@contact", client.Contact);
				if (sqlCommand.ExecuteNonQuery() == 1)
				{
					sqlCommand2 = new SqlCommand(@"SELECT CONVERT(int, SCOPE_IDENTITY())",
																	sqlConnection,
																	sqlTransation);
					int id = (int)sqlCommand2.ExecuteScalar(); // Returns the client id from the newly created client
					sqlTransation.Commit();
					return id;

					/* ALTERNATIVA
					
					sqlCommand2 = new SqlCommand(@"SELECT @@IDENTITY",
														sqlConnection,
														sqlTransation);
					int id =  Convert.ToInt32(sqlCommand2.ExecuteScalar());
					sqlTransation.Commit();
					return id;
					*/
				}
				else
					return 0;
			}
			catch
			{
				sqlTransation.Rollback();
				return 0;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}

		/// <summary>
		/// Insert a movie in the database
		/// </summary>
		/// <param name="movie">Movie</param>
		/// <returns>Movie.Id if movie is inserted, 0 if insertion fails</returns>
		public static int Movie_Insert(Movie movie)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null, sqlCommand2 = null;
			SqlTransaction sqlTransation = null;

			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				sqlTransation = sqlConnection.BeginTransaction();
				sqlCommand = new SqlCommand(@"INSERT INTO Movies 
											(Title, Runtime) VALUES 
											(@title, @runtime)",
											sqlConnection, 
											sqlTransation);
				sqlCommand.Parameters.AddWithValue("@title", movie.Title);
				sqlCommand.Parameters.AddWithValue("@runtime", movie.Runtime);
				if (sqlCommand.ExecuteNonQuery() == 1)
				{
					sqlCommand2 = new SqlCommand(@"SELECT CONVERT(int, SCOPE_IDENTITY())",
																	sqlConnection,
																	sqlTransation);
					int id = (int)sqlCommand2.ExecuteScalar();  // Returns the movie id from the newly created movie
					sqlTransation.Commit();
					return id;
				}
				else
					return 0;
			}
			catch (Exception ex)
			{
				sqlTransation.Rollback();
				return 0;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}

		/// <summary>
		/// Select sessions for a given data
		/// </summary>
		/// <param name="date">data</param>
		/// <returns>Sessions on a given date (on screen A and B)</returns>
		public static DataTable Select_Session_byDate(DateTime date)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataAdapter sqlDataAdapter = null;

			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				sqlCommand = new SqlCommand(@"SELECT * FROM View_Sessions
											WHERE Date = @date", sqlConnection);

				sqlCommand.Parameters.AddWithValue("@date", date); // Tem de ir com os campos de time a zeros (usar versão .Today())

				sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				return dataTable;
			}
			catch (Exception)
			{ 
				return null;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}

		/// <summary>
		/// Selects a specific session
		/// </summary>
		/// <param name="idScreen">idScreen</param>
		/// <param name="idMovie">idMovie</param>
		/// <param name="date">date</param>
		/// <returns>Session info or null if session not found on DB</returns>
		public static View_Session Select_Session(int idScreen, int idMovie, DateTime date)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader sqlDataReader = null;
			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				sqlCommand = new SqlCommand(@"SELECT * FROM View_Sessions 
                                              WHERE IdScreen = @IdScreen 
                                              AND IdMovie = @IdMovie
                                              AND Date = @Date", sqlConnection);
				sqlCommand.Parameters.AddWithValue("@IdScreen", idScreen);
				sqlCommand.Parameters.AddWithValue("@IdMovie", idMovie);
				sqlCommand.Parameters.AddWithValue("@Date", date);
				sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.Read())
				{
					View_Session session = new View_Session()
					{
						Title = sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("Title")).Value,
						Runtime = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("Runtime")).Value,
						Name = sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("Name")).Value,
						NumberOfSeats = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("NumberOfSeats")).Value,
						IdMovie = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("IdMovie")).Value,
						IdScreen = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("IdScreen")).Value,
						Date = (DateTime)sqlDataReader.GetSqlValue(sqlDataReader.GetOrdinal("Date")),
						StartTime = (TimeSpan)sqlDataReader.GetSqlValue(sqlDataReader.GetOrdinal("StartTime")),
					};
					return session;
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}

		/// <summary>
		/// Select seats for a given screen
		/// </summary>
		/// <param name="idScreen">Screen</param>
		/// <returns>List of Seats that are part of that Screen (sala)</returns>
		public static List<Seat> Select_Seats_byScreen(int idScreen)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader sqlDataReader = null;

			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				sqlCommand = new SqlCommand(@"SELECT * FROM Seats
											WHERE IdScreen = @idScreen", sqlConnection);

				sqlCommand.Parameters.AddWithValue("@idScreen", idScreen); // Tem de ir com os campos de time a zeros (usar versão .Today())
				sqlDataReader = sqlCommand.ExecuteReader();

				List<Seat> seats = new List<Seat>();

				while (sqlDataReader.Read())
				{
					seats.Add(new Seat()
					{
						IdScreen = (int)sqlDataReader["IdScreen"],
						Row = (int)sqlDataReader["Row"],
						Number = (int)sqlDataReader["Number"],
						Disability = (bool)sqlDataReader["Disability"]
					});
				}
				return seats;
			}
			catch (Exception)
			{
				return null;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}

		/// <summary>
		/// Verifies if the seat is reserved for disabled person.
		/// </summary>
		/// <param name="seat">Seat</param>
		/// <returns>True for disabled. False for non diabled seat </returns>
		public static bool IsDisabledSeat(Seat seat)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;

			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				sqlCommand = new SqlCommand(@"SELECT Disability FROM Seats
											WHERE IdScreen = @idScreen AND Row=@row AND Number=@number", sqlConnection);

				sqlCommand.Parameters.AddWithValue("@idScreen", seat.IdScreen);
				sqlCommand.Parameters.AddWithValue("@row", seat.Row);
				sqlCommand.Parameters.AddWithValue("@number", seat.Number);

				return (bool)sqlCommand.ExecuteScalar();
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}

		/// <summary>
		/// Selects sold and reserved tickets for a given session
		/// </summary>
		/// <param name="idScreen">Screen</param>
		/// <param name="idMovie">filme</param>
		/// <param name="date">data</param>
		/// <returns>lista com todos os bilhetes de uma sessão</returns>
		public static List<View_Ticket> Select_Tickets_bySession(int idScreen, int idMovie, DateTime date)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader sqlDataReader = null;
			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				sqlCommand = new SqlCommand(@"SELECT * FROM View_Tickets 
                                              WHERE IdScreen = @IdScreen 
                                              AND IdMovie = @IdMovie
                                              AND Date = @Date", sqlConnection);
				sqlCommand.Parameters.AddWithValue("@IdScreen", idScreen);
				sqlCommand.Parameters.AddWithValue("@IdMovie", idMovie);
				sqlCommand.Parameters.AddWithValue("@Date", date);
				sqlDataReader = sqlCommand.ExecuteReader();
				List<View_Ticket> tickets = new List<View_Ticket>();
				while (sqlDataReader.Read())
				{
					tickets.Add(new View_Ticket()
					{
						// outra forma de obter os dados... que deve ser mais usada para quando temos possibilidade de ter valores a NULL
						Date = (DateTime)sqlDataReader.GetSqlValue(sqlDataReader.GetOrdinal("Date")),
						IdScreen = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("IdScreen")).Value,
						ScreenName = sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("ScreenName")).Value,
						Row = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("Row")).Value,
						Number = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("Number")).Value,
						Disability = sqlDataReader.GetSqlBoolean(sqlDataReader.GetOrdinal("Disability")).Value,
						IdMovie = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("IdMovie")).Value,
						Title = sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("Title")).Value,
						StartTime = (TimeSpan)sqlDataReader.GetSqlValue(sqlDataReader.GetOrdinal("StartTime")),
						Runtime = sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("Runtime")).Value,
						// os próximos campos da view podem ser null, por isso faz-se assim:
						IdClient = (sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("IdClient")).IsNull ? (int?)null : sqlDataReader.GetSqlInt32(sqlDataReader.GetOrdinal("IdClient")).Value),
						ClientName = (sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("ClientName")).IsNull ? "" : sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("ClientName")).Value),
						ClientContact = (sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("ClientContact")).IsNull ? "" : sqlDataReader.GetSqlString(sqlDataReader.GetOrdinal("ClientContact")).Value)
					});
				}
				return tickets;
			}
			catch (Exception)
			{
				return null;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}

		/// <summary>
		/// Inserts a ticket into the database
		/// </summary>
		/// <param name="ticket">Ticket</param>
		/// <returns>1 if insertion ok, 0 if insertion fail</returns>
		public static int Ticket_Insert(Ticket ticket)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;

			try
			{
				sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				if (ticket.IdClient == null)
				{
					sqlCommand = new SqlCommand(@"INSERT INTO Tickets 
											(IdScreen, Row, Number, IdMovie, Date) VALUES 
											(@idScreen, @row, @number, @idMovie, @date)", sqlConnection);
				}
				else
				{
					sqlCommand = new SqlCommand(@"INSERT INTO Tickets 
											(IdScreen, Row, Number, IdMovie, Date, IdClient) VALUES 
											(@idScreen, @row, @number, @idMovie, @date, @idClient)", sqlConnection);
					sqlCommand.Parameters.AddWithValue("@idClient", ticket.IdClient);
				}
				
				sqlCommand.Parameters.AddWithValue("@idScreen", ticket.IdScreen);
				sqlCommand.Parameters.AddWithValue("@row", ticket.Row);
				sqlCommand.Parameters.AddWithValue("@number", ticket.Number);
				sqlCommand.Parameters.AddWithValue("@idMovie", ticket.IdMovie);
				sqlCommand.Parameters.AddWithValue("@date", ticket.Date);					

				return sqlCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return 0;
			}
			finally
			{
				if (sqlCommand != null)
					sqlCommand.Dispose();
				if (sqlConnection != null)
					sqlConnection.Dispose();
			}
		}




	}
}
