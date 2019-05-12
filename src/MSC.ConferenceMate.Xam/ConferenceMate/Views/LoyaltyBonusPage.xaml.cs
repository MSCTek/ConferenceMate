using ConferenceMate.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoyaltyBonusPage : ContentPage, IContentPage
    {
        public LoyaltyBonusPage()
        {
            InitializeComponent();
        }

        public void PrepareForDispose()
        {
        }
    }
}