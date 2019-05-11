using QuikRide.Interfaces;
using Xamarin.Forms.Xaml;

namespace QuikRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : IContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }

        public void PrepareForDispose()
        {
        }
    }
}