using ConferenceMate.Interfaces;
using Xamarin.Forms.Xaml;

namespace ConferenceMate.Views
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