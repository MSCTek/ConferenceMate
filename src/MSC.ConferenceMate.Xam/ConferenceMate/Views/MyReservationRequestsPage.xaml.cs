using QuikRide.Interfaces;
using Xamarin.Forms.Xaml;

namespace QuikRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyReservationRequestsPage : IContentPage
    {
        public MyReservationRequestsPage()
        {
            InitializeComponent();
        }

        public void PrepareForDispose()
        {
        }
    }
}