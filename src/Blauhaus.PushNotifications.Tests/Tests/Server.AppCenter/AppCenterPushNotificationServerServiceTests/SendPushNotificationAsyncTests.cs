using System.Threading.Tasks;
using Blauhaus.PushNotifications.Server.AppCenter.Service;
using Blauhaus.PushNotifications.Tests.Mocks;
using Blauhaus.Tests.Helpers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Blauhaus.PushNotifications.Tests.Tests.Server.AppCenter.AppCenterPushNotificationServerServiceTests
{
    public class SendPushNotificationAsyncTests : BaseUnitTest<AppCenterPushNotificationServerService>
    {
        private HttpClientServiceMockBuilder _mockHttpClientService;


        [SetUp]
        public void OnSetup()
        {
            Cleanup();
            _mockHttpClientService = new HttpClientServiceMockBuilder();
        }

        protected override AppCenterPushNotificationServerService ConstructSut()
        {
            return new AppCenterPushNotificationServerService(
                _mockHttpClientService.Object,
                Mock.Of<ILogger>());
        }

        [Test]
        public async Task SHOULD()
        {

            //Arrange


            //Act


            //Assert
        }
    }
}