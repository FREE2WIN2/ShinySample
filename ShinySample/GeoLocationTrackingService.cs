using Microsoft.Extensions.Logging;
using Shiny.Locations;

namespace ShinySample
{
  public class GeoLocationTrackingService 
  {
    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<GeoLocationTrackingService> logger;

    /// <summary>
    /// The geo coord client.
    /// </summary>
    private readonly IGpsManager gpsManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="GeoLocationTrackingService"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="gpsManager">The shiny gps manager.</param>
    public GeoLocationTrackingService(ILogger<GeoLocationTrackingService> logger, IGpsManager gpsManager)
    {
      this.logger = logger;
      this.gpsManager = gpsManager;
    }

    public async Task StartListeningForLocationUpdatesAsync()
    {
      await this.StopListeningForLocationUpdatesAsync().ConfigureAwait(true);

      var request = new GpsRequest()
      {
        DistanceFilterMeters = 50D,
        Accuracy = GpsAccuracy.High,
        BackgroundMode = GpsBackgroundMode.Realtime,
      };

      try
      {
        await this.gpsManager.RequestAccess(request).ConfigureAwait(false);
        await this.gpsManager.StartListener(request).ConfigureAwait(false);
      }
      catch (Exception e)
      {
        this.logger.LogError(e,"error starting listening for location updates.");
      }

      this.logger.LogInformation($"Listener started!");
    }

    public async Task StopListeningForLocationUpdatesAsync()
    {
      if (this.gpsManager.CurrentListener != null)
      {
        this.logger.LogInformation("Gps tracking stopped!");
        await this.gpsManager.StopListener().ConfigureAwait(false);
      }
    }
  }
}
