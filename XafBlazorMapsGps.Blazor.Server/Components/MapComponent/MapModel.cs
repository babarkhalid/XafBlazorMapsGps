using DevExpress.ExpressApp.Blazor.Components.Models;

namespace XafBlazorMapsGps.Blazor.Server.Components.MapComponent
{
    /// <summary>
    /// In this class, declare properties that describe your component and its interaction with a user.
    /// </summary>
    public class MapModel : ComponentModelBase
    {

        public double Latitude
        {
            get => GetPropertyValue<double>();
            set => SetPropertyValue(value);
        }

        public double Longitude
        {
            get => GetPropertyValue<double>();
            set => SetPropertyValue(value);
        }
    }
}
