using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxOffice
{
	public partial class FormClientInfo : Form
	{
		private Client client;

		public Client Client
		{
			get { return client; }
			set { client = value; }
		}

		public FormClientInfo()
		{
			InitializeComponent();
		}

		private void btn_Insert_Click(object sender, EventArgs e)
		{
			this.client = new Client();
			this.client.Name = txt_Name.Text;
			this.client.Contact = txt_Contact.Text;

			this.DialogResult = DialogResult.OK;
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.client = null;

			this.DialogResult = DialogResult.Cancel;
		}

		private void txt_Name_TextChanged(object sender, EventArgs e)
		{
			Validate_Data();
		}

		private void txt_Contact_TextChanged(object sender, EventArgs e)
		{
			Validate_Data();
		}

		/// <summary>
		/// Check if the client info has ben inserted and enables button to validate
		/// </summary>
		private void Validate_Data()
		{
			if (txt_Name.Text != "" && txt_Contact.Text != "")
				btn_Insert.Enabled = true;
			else
				btn_Insert.Enabled = false;
		}

		
	}
}
