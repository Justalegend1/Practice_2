using System;
using System.Windows.Forms;

namespace ContactApplication
{
    public partial class PersonEditForm : Form
    {
        public PersonEditForm()
        {
            InitializeComponent();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
            this.contactsTableAdapter.Fill(this.notebookDataSet.Contacts);
            this.contactTypeTableAdapter.Fill(this.notebookDataSet.ContactType);
            personsBindingSource.AddNew();
        }
        public PersonEditForm(int index)
        { 
        InitializeComponent();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
            this.contactsTableAdapter.Fill(this.notebookDataSet.Contacts);
            this.contactTypeTableAdapter.Fill(this.notebookDataSet.ContactType);
            personsBindingSource.Position = index;

        }
        private void personsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.notebookDataSet);

        }

        private void PersonEditForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "notebookDataSet.ContactType". При необходимости она может быть перемещена или удалена.
            //this.contactTypeTableAdapter.Fill(this.notebookDataSet.ContactType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "notebookDataSet.Contacts". При необходимости она может быть перемещена или удалена.
            //this.contactsTableAdapter.Fill(this.notebookDataSet.Contacts);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "notebookDataSet.Persons". При необходимости она может быть перемещена или удалена.
            //this.personsTableAdapter.Fill(this.notebookDataSet.Persons);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            personsBindingSource.EndEdit();
            personsTableAdapter.Update(notebookDataSet.Persons);
            contactsTableAdapter.Update(notebookDataSet.Contacts);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            personsBindingSource.EndEdit();
            personsTableAdapter.Update(notebookDataSet.Persons);
            contactsTableAdapter.Update(notebookDataSet.Contacts);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
