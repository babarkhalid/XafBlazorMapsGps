using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using XafBlazorMapsGps.Module.BusinessObjects;

namespace XafBlazorMapsGps.Blazor.Server.Components.MapComponent
{
    public interface IModelMapDetailViewItemBlazor : IModelViewItem { }

    [ViewItem(typeof(IModelMapDetailViewItemBlazor))]
    public class MapViewItem : ViewItem, IComplexViewItem
    {
        public class MapHolder : IComponentContentHolder
        {
            public MapHolder(MapModel componentModel, MapViewItem viewItem)
            {
                ComponentModel = componentModel;
                MapViewItem = viewItem;
            }
            public MapModel ComponentModel { get; }
            public MapViewItem MapViewItem { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, MapRenderer.Create(ComponentModel, MapViewItem));
        }

        private XafApplication application;

        public MapViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id)
        {

        }

        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        protected override void OnControlCreated()
        {
            if (Control is MapHolder holder)
            {

            }
            base.OnControlCreated();
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (Control is MapHolder holder)
            {

            }
            base.BreakLinksToControl(unwireEventsOnly);
        }
        protected override object CreateControlCore()
        {
            MapModel mapModel = new MapModel();
            Location location = CurrentObject != null ? CurrentObject as Location : null;
            if (location != null)
            {
                location.Latitude = 0;
                location.Longitude = 0;
            }
            mapModel.Latitude = 0; mapModel.Longitude = 0;
            return new MapHolder(mapModel, this);
        }
    }
}
