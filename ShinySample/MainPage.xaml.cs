namespace ShinySample;

public partial class MainPage : ContentPage
{
    private readonly GeoLocationTrackingService geoLocationTrackingService;
    
    public MainPage(GeoLocationTrackingService geoLocationTrackingService)
    {
        InitializeComponent();
    }

    private Task OnGpsStopClicked(object? sender, EventArgs e)
    {
        return this.geoLocationTrackingService.StopListeningForLocationUpdatesAsync();
    }

    private Task OnGpsStartClicked(object? sender, EventArgs e)
    {
        return this.geoLocationTrackingService.StartListeningForLocationUpdatesAsync();
    }
}