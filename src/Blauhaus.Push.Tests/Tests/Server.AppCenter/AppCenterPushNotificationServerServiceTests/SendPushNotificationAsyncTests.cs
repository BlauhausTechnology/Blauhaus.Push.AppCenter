using System.Linq;
using System.Threading;
using Blauhaus.Push.Server.AppCenter.Service;
using Blauhaus.Push.Tests.Mocks;
using Blauhaus.Tests.Helpers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Blauhaus.Common.Config.AppCenter.Server;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.Push.Common.Notifications;
using HttpClientService.Core.Request;

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

        private class TestConfig : BaseAppCenterServerConfig
        {
            public TestConfig() : base("organizationName", "apiToken")
            {
                AppNames[RuntimePlatform.Android] = "androidAppName";
                AppNames[RuntimePlatform.iOS] = "iosAppName";
                AppNames[RuntimePlatform.UWP] = "uwpAppName";
            }
        }


        [Test]
        public async Task SHOULD_call_http_client_using_correct_endpoint_and_appname_for_target_platform()
        {

            //Arrange
            var notification = new PushNotification
            {
                Title = "Test",
                TargetDevicePlatform = RuntimePlatform.UWP
            };


            //Act
            await Sut.SendPushNotificationAsync(notification, new TestConfig());

            //Assert
            _mockHttpClientService.Mock.Verify(x => x.PostAsync<string, IHttpRequestWrapper<string>>(It.Is<IHttpRequestWrapper<string>>(y => 
                y.Endpoint == "https://api.appcenter.ms/v0.1/apps/organizationName/uwpAppName/push/notifications" &&
                y.RequestHeaders["X-API-Token"] == "apiToken" &&
                y.Request == notification.ToAppCenterJsonString()), CancellationToken.None));
        }
    }
}