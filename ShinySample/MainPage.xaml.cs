namespace ShinySample;

public partial class MainPage : ContentPage
{
    private readonly GeoLocationTrackingService geoLocationTrackingService;
    
    public MainPage(GeoLocationTrackingService geoLocationTrackingService)
    {
        this.geoLocationTrackingService = geoLocationTrackingService;
        InitializeComponent();
    }

    private void OnGpsStopClicked(object? sender, EventArgs e)
    {
        this.geoLocationTrackingService.StopListeningForLocationUpdatesAsync();
    }

    private void OnGpsStartClicked(object? sender, EventArgs e)
    {
        this.geoLocationTrackingService.StartListeningForLocationUpdatesAsync();
    }
}