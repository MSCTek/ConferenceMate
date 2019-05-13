using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSC.CM.XaSh.Views
{
    public partial class AnnouncementsPage : ContentPage
    {
        public AnnouncementsPage()
        {
            InitializeComponent();
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string catName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // This works because route names are unique in this application.
            //await Shell.Current.GoToAsync($"catdetails?name={catName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}