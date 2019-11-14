using System.Threading.Tasks;

namespace Blauhaus.Push.Common.Abstractions
{
    public interface IPushNotificationClientService
    {
        Task<string> GetDeviceIdAsync();
    }
}