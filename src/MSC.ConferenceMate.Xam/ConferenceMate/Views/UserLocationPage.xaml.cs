using QuikRide.Interfaces;
using Xamarin.Forms.Xaml;

namespace QuikRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLocationPage : IContentPage
    {
        public UserLocationPage()
        {
            InitializeComponent();
        }

        public void PrepareForDispose()
        {
        }
    }
}