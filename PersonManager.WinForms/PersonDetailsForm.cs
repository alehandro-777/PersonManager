using PersonManager.UI.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PersonManager.WinForms
{
    public partial class PersonDetailsForm : Form
    {
        private PersonDetailDto _person;

        public PersonDetailsForm(PersonDetailDto person)
        {
            InitializeComponent();
            _person = person;
            LoadData();
        }

        private void LoadData()
        {
            lblName.Text = $"{_person.Vorname} {_person.Name}";

            // Заполняем адреса через DTO
            dataGridViewAddresses.DataSource = _person.Anschriften
                .Select(a => new
                {
                    a.Postleitzahl,
                    a.Ort,
                    a.Strasse,
                    a.Hausnummer
                }).ToList();

            // Заполняем телефоны через DTO
            dataGridViewPhones.DataSource = _person.Telefonnummern
                .Select(t => new { t.Nummer })
                .ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }


}
