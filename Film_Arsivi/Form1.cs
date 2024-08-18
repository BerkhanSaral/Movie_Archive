using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Film_Arsivi
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-LO1OC4N\SQLEXPRESS01;Initial Catalog=FilmArsivim;Integrated Security=True");
        public void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("select ad,link from tblfilmler", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("insert into tblfilmler (ad,katagori,link) values (@ad,@katagori,@link)", baglan);
            cmd.Parameters.AddWithValue("@ad", txtFilmAd.Text);
            cmd.Parameters.AddWithValue("@katagori", txtKatagori.Text);
            cmd.Parameters.AddWithValue("@link", txtLink.Text);
            cmd.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("film listenize eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView.SelectedCells[0].RowIndex;
            string link = dataGridView.Rows[secilen].Cells[1].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void btnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("bu proje ben tarafindan 27 ocak 2024 de yapilmaya calisilda", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {

            
            TamEkran tamEkran = new TamEkran();
            tamEkran.film=txtLink.Text;

            /*
            int secilen = dataGridView.SelectedCells[0].RowIndex;
            string link = dataGridView.Rows[secilen].Cells[3].Value.ToString();
            */
            tamEkran.Show();
            


        }

        private void btnRenkDegistir_Click(object sender, EventArgs e)
        {

            //  string[] renk = { "mavi", "siyah", "kirmizi", "pembe", "turuncu", "beyaz", "yesil" };
            int[] sayac = { 0, 1, 2, 3, 4, 5, 6 };
            Random random = new Random();
            int no = random.Next(0, sayac.Length);
       
            switch (no)
            {
                case 1:
                    this.BackColor = Color.White;
                    break;
                case 2:
                    this.BackColor = Color.Black;
                    break;
                case 3:
                    this.BackColor = Color.Blue;
                    break;
                case 4:
                    this.BackColor = Color.Pink;
                    break;
                case 5:
                    this.BackColor = Color.Orange;
                    break;
                case 6:
                    this.BackColor = Color.Red;
                    break;
                case 7:
                    this.BackColor = Color.Honeydew;
                    break;
            }
            

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
