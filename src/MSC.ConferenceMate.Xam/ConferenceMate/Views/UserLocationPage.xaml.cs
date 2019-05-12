using ConferenceMate.Interfaces;
using Xamarin.Forms.Xaml;

namespace ConferenceMate.Views
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