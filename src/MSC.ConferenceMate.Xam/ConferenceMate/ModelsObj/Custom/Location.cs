using GalaSoft.MvvmLight;

namespace QuikRide.ModelsObj
{
    public partial class Location : ObservableObject
    {
        public string AddressDisplay
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return $"{AddressLine1} {AddressLine2}, {City}";
                }
                else
                {
                    return $"{Name}, {AddressLine1} {AddressLine2}, {City}";
                }
            }
        }
    }
}