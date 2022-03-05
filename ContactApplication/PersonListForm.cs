using System;
using System.Windows.Forms;

namespace ContactApplication
{
    public partial class PersonListForm : Form
    {
        public PersonListForm()
        {
            InitializeComponent();
        }

        private void PersonListForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "notebookDataSet.Persons". При необходимости она может быть перемещена или удалена.
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PersonEditForm form = new PersonEditForm();
            form.ShowDialog();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PersonEditForm form = new PersonEditForm(personsBindingSource.Position);
            form.ShowDialog();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            personsBindingSource.RemoveCurrent();
            personsTableAdapter.Update(notebookDataSet.Persons);
           
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            PersonEditForm form = new PersonEditForm();
            form.ShowDialog();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            PersonEditForm form = new PersonEditForm(personsBindingSource.Position);
            form.ShowDialog();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            //personsBindingSource.RemoveCurrent();
        }
    }
}
