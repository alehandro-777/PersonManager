using Newtonsoft.Json;
using PersonManager.API.DTO;
using System;
using System.Net.Http;
using System.Text;

namespace PersonManager.WinForms
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public MainForm()
        {
            InitializeComponent();

            //dataGridView1.AutoGenerateColumns = false;

            dataGridView1.CellContentClick += dataGridViewPersons_CellContentClick;

            _httpClient.BaseAddress = new Uri("https://localhost:7045/");
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            string nameFilter = txtSearchName.Text.Trim();
            string url = "api/persons";

            if (!string.IsNullOrEmpty(nameFilter))
                url += $"?name={nameFilter}";

            try
            {
                // Make HTTP request
                var response = await _httpClient.GetAsync(url);

                // Check for successful status
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    // Deserialize
                    var persons = JsonConvert.DeserializeObject<List<PersonListDto>>(json);

                    dataGridView1.DataSource = persons;

                    this.AddDetailsButton();
                }
                else
                {
                    MessageBox.Show($"Server error: {(int)response.StatusCode} {response.ReasonPhrase}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                var response = await _httpClient.GetAsync($"api/persons/{personId}");

                // Check if response is successful
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON
                    var personDetail = JsonConvert.DeserializeObject<PersonDetailDto>(json);

                    if (personDetail != null)
                    {
                        // Open details form
                        var detailsForm = new PersonDetailsForm(personDetail);
                        detailsForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No details found for this person.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"Server error: {(int)response.StatusCode} {response.ReasonPhrase}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var updateDto = new PersonUpdateDto
            {
                Name = selectedPerson.Name,
                Vorname = selectedPerson.Vorname
            };

            var json = JsonConvert.SerializeObject(updateDto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PutAsync($"api/persons/{selectedPerson.PersonId}", content);

                if (!response.IsSuccessStatusCode)
                    MessageBox.Show("Fehler beim Speichern der Person");
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
