using QuikRide.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuikRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage, IContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        public void PrepareForDispose()
        {
        }
    }
}