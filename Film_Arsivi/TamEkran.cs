using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Film_Arsivi
{
    public partial class TamEkran : Form
    {
        public TamEkran()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-LO1OC4N\SQLEXPRESS01;Initial Catalog=FilmArsivim;Integrated Security=True");
        public string film;
        private void TamEkran_Load(object sender, EventArgs e)
        {
            this.Text = film.ToString();
            this.WindowState = FormWindowState.Maximized;
            webBrowser1.Navigate(film);
        }
    }
}
