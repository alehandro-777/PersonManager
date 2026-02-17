using Newtonsoft.Json;
using PersonManager.UI.Api;
using System;
using System.Net.Http;
using System.Text;

namespace PersonManager.WinForms
{
    public partial class MainForm : Form
    {
        private readonly Client _httpClient = new Client("https://localhost:7045");
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridViewPersons_CellContentClick;
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            string nameFilter = txtSearchName.Text.Trim();

            try
            {
                // Make HTTP request
                var persons = await _httpClient.PersonsAllAsync(nameFilter);
                dataGridView1.DataSource = persons;
                this.AddDetailsButton();
            }
            catch (HttpRequestException ex)
            {
                // Network error
                MessageBox.Show($"Network error: {ex.Message}",
                                "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (JsonException ex)
            {
                // JSON parsing error
                MessageBox.Show($"Data processing error: {ex.Message}",
                                "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Other errors
                MessageBox.Show($"Unknown error: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridViewPersons_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Details")
            {
                var person = (PersonListDto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Загружаем детали через WebAPI
                ShowPersonDetails(person.PersonId);
            }
        }

        private async void ShowPersonDetails(int personId)
        {
            try
            {
                // Send HTTP request
                PersonDetailDto? personDetail = await _httpClient.PersonsGETAsync(personId);
                if (personDetail != null)
                {
                    // Open details form
                    var detailsForm = new PersonDetailsForm(personDetail);
                    detailsForm.ShowDialog();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}",
                                "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Data processing error: {ex.Message}",
                                "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unknown error: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            var selectedPerson = row.DataBoundItem as PersonListDto;

            if (selectedPerson == null) return;

            PersonUpdateDto? updateDto = new PersonUpdateDto
            {
                Name = selectedPerson.Name,
                Vorname = selectedPerson.Vorname
            };


            try
            {
                await _httpClient.PersonsPUTAsync(selectedPerson.PersonId, updateDto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("API-Verbindung fehlgeschlagen: " + ex.Message);
            }
        }

        private void AddDetailsButton()
        {
            if (!dataGridView1.Columns.Contains("Details"))
            {
                var buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "Details";
                buttonColumn.HeaderText = "Aktion";
                buttonColumn.Text = "Delails";
                buttonColumn.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(buttonColumn);
            }
        }

    }

}
