using Microsoft.Extensions.Logging;
using Shiny.Locations;

namespace ShinySample.Delegate
{
#if ANDROID
#endif

  /// <summary>
  /// Delegate for the shiny gps.
  /// </summary>
  public partial class MyGpsDelegate : GpsDelegate
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MyGpsDelegate"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public MyGpsDelegate(ILogger<MyGpsDelegate> logger)
      : base(logger)
    {
      this.MinimumTime = TimeSpan.FromMinutes(1);
    }

    /// <inheritdoc />
    protected override Task OnGpsReading(GpsReading reading)
    {
      this.Logger.LogInformation($"GPS reading: {reading}");
      return Task.CompletedTask;
    }
  }
}
