using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFWithUnitTest.Services
{
    public class LocationService : ILocationService
    {
        private Location _cachedLocation = null;

        public async Task<Location> GetLocation()
        {
            if (_cachedLocation != null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    _cachedLocation = await SilentGetLocation();
                });
            }
            else
            {
                _cachedLocation = await SilentGetLocation();
            }

            return _cachedLocation;
        }

        private async Task<Location> SilentGetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Lowest);
                var location = await Geolocation.GetLocationAsync(request);

                return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }
    }
}
