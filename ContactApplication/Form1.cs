using Microsoft.Office.Interop.Excel;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ContactApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frmAbout = new AboutForm();
            frmAbout.ShowDialog();

        }

        private void типыКонтактовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactTypeForm form = new ContactTypeForm();
            form.MdiParent = this;
            form.Show();
        }

        private void отчетToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app =
        new Microsoft.Office.Interop.Excel.Application();

            app.Visible = true;

            Workbook wb = app.Workbooks.Add();
            Worksheet ws = wb.Worksheets[1];

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\copil\Notebook.mdf;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select [Name] as 'Имя', [Surname] as 'Фамилия',
            (select count(*) from Contacts C where C.PersonId = P.id ) as 'Всего контактов'
            from Persons P", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            ws.Cells[1, 1].Value = reader.GetName(0);
            ws.Cells[1, 2].Value = reader.GetName(1);
            ws.Cells[1, 3].Value = reader.GetName(2);

            int i = 2;
            while (reader.Read())
            {
                ws.Cells[i, 1].Value = reader[0];
                ws.Cells[i, 2].Value = reader[1];
                ws.Cells[i, 3].Value = reader[2];
                i++;
            }

            reader.Close();
            conn.Close();

        }

        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonListForm form = new PersonListForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}
