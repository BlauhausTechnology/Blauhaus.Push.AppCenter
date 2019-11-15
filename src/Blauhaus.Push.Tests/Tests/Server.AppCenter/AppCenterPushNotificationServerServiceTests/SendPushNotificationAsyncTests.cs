using Blauhaus.Push.Server.AppCenter.Service;
using Blauhaus.Push.Tests.Mocks;
using Blauhaus.Tests.Helpers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Blauhaus.Push.Tests.Tests.Server.AppCenter.AppCenterPushNotificationServerServiceTests
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
                Mock.Of<ILogger<AppCenterPushNotificationServerService>>());
        }

        //[Test]
        //public async Task SHOULD()
        //{

        //    //Arrange


        //    //Act


        //    //Assert
        //}
    }
}