using ConferenceMate.Interfaces;
using Xamarin.Forms.Xaml;

namespace ConferenceMate.Views
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