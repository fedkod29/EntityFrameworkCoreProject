using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestResultDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel_Reservation_Booking_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient client = new HttpClient();

        public ObservableCollection<GETGuestsResultDTO> Guests { get; set; } 
            = new ObservableCollection<GETGuestsResultDTO>();

        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7117/api/guests/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();

            DataContext = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e) => this.Close();
        
        private async void Button_Click_Delete(object sender, RoutedEventArgs e) 
        {
            var selectedItem = GuestsGrid.SelectedItem as GETGuestsResultDTO;
            if (selectedItem == null)
            {
                // No item selected, handle the error
                return;
            }

            var response = await client.DeleteAsync($"Deleting_Guest_By_Id_Async/{selectedItem.ID}");
            ReturnGuests();

            if (response.IsSuccessStatusCode)
            {
                // Data updated successfully, perform any necessary actions (e.g., refresh grid, show success message)
            }
            else
            {
                // Handle the error (e.g., show error message)
            }
        }

        private async Task ReturnGuests()
        {
            var response = await client.GetStringAsync("Return_all_Guest_Async");
            var result = JsonConvert.DeserializeObject<IEnumerable<GETGuestsResultDTO>>(response);

            Guests.Clear();
            foreach (var guest in result) 
            { 
                Guests.Add(guest); 
            }
        }

        private async void Loaded_Guests(object sender, RoutedEventArgs e)
        {
            await ReturnGuests();
        }

        private async void Button_Click_Insert_Guest(object sender, RoutedEventArgs e)
        {
            await InsertGuest();
            ClearForm();
            await ReturnGuests();
        }

        private async Task InsertGuest()
        {
            var guest = new INSERGuestResultDTO
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Mobile = txtMobile.Text,
                Details = txtDetails.Text
            };

            var json = JsonConvert.SerializeObject(guest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Inser_Guest_Async", content);
            if (response.IsSuccessStatusCode)
            {
                // Insertion successful, perform any additional actions if needed
            }
            else
            {
                // Insertion failed, handle the error appropriately
            }
        }

        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtDetails.Text = string.Empty;
        }
        private async void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            var selectedItem = GuestsGrid.SelectedItem as GETGuestsResultDTO;

            if (selectedItem == null)
            {
                // No item selected, handle the error
                return;
            }

            // Create an instance of the UPDATEGuestResultDTO and populate it with the data from the selected item
            var updateGuestResultDTO = new UPDATEGuestResultDTO
            {
                ID = selectedItem.ID,
                FirstName = txtUpdateFirstName.Text,
                LastName = txtUpdateLastName.Text,
                Email = txtUpdateEmail.Text,
                Mobile = txtUpdateMobile.Text,
                Details = txtUpdateDetails.Text
            };

            // Call the UpdateGuestAsync method from the controller
            var response = await client.PutAsJsonAsync("Update_Guest_Async", updateGuestResultDTO);

            ReturnGuests();

            if (response.IsSuccessStatusCode)
            {
                // Data updated successfully, perform any necessary actions (e.g., refresh grid, show success message)
            }
            else
            {
                // Handle the error (e.g., show error message)
            }
        }
    }
}
