using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XFTextpadApp.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocation();
    }
}
