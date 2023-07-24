using Microsoft.JSInterop;

namespace XafBlazorMapsGps.Blazor.Server.Components.MapComponent
{
    public class MapUpdateInvokeHelper
    {
        private Action<UpdateItem> updateLocation;
        public MapUpdateInvokeHelper(Action<UpdateItem> updateLocation)
        {
            this.updateLocation = updateLocation;
        }

        [JSInvokable]
        public void UpdateLocation(UpdateItem param)
        {
            this.updateLocation.Invoke(param);
        }
    }

    public class UpdateItem
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
