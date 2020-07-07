using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XFWithUnitTest.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocation();
    }
}
