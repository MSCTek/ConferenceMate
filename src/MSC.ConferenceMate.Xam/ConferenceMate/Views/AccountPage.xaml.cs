using ConferenceMate.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceMate.Views
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