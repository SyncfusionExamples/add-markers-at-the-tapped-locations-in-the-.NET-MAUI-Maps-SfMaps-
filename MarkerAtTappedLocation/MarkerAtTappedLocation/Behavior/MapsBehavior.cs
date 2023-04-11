using Syncfusion.Maui.Maps;

namespace MarkerAtTappedLocation
{
    public class MapsBehavior : Behavior<ContentPage>
    {
        private MapTileLayer tileLayer;
        private MapMarker marker;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.tileLayer = bindable.FindByName<MapTileLayer>("tileLayer");
            this.tileLayer.Tapped += TileLayer_Tapped;
            this.marker = bindable.FindByName<MapMarker>("marker");
        }

        private void TileLayer_Tapped(object sender, Syncfusion.Maui.Maps.TappedEventArgs e)
        {
            var location = tileLayer.GetLatLngFromPoint(e.Position);
            marker.Latitude = location.Latitude;
            marker.Longitude = location.Longitude;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.tileLayer != null)
            {
                this.tileLayer.Tapped -= TileLayer_Tapped;
            }

            this.tileLayer = null;
            this.marker = null;
        }
    }
}
