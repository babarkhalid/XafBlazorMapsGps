using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor;
using Microsoft.JSInterop;
using XafBlazorMapsGps.Blazor.Server.Components.MapComponent;
using XafBlazorMapsGps.Module.BusinessObjects;

namespace XafBlazorMapsGps.Blazor.Server.Controllers
{
    public class GetMapLocationController : ObjectViewController<DetailView, Location>
    {
        private SimpleAction saGetLocation;
        private MapUpdateInvokeHelper mapUpdateInvokeHelper;

        public GetMapLocationController()
        {
            saGetLocation = new SimpleAction(this, nameof(saGetLocation), DevExpress.Persistent.Base.PredefinedCategory.Edit)
            {
                Caption = "Get Location"
            };

            saGetLocation.Execute += SaGetLocation_Execute;
        }
        private void SaGetLocation_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject is Location location)
            {
                var JSRuntime = ((BlazorApplication)Application).ServiceProvider.GetRequiredService<IJSRuntime>();
                JSRuntime.InvokeVoidAsync("showGeolocation", DotNetObjectReference.Create(mapUpdateInvokeHelper));
            }
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            mapUpdateInvokeHelper = new MapUpdateInvokeHelper(SetLocationValues);
        }

        private void SetLocationValues(UpdateItem updateItem)
        {
            if (View.CurrentObject is Location location)
            {
                location.Latitude = updateItem.Latitude;
                location.Longitude = updateItem.Longitude;
            }
        }
    }
}
