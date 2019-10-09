using AngleSharp.Html.Dom;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCWebSite.Test
{
    [TestFixture]
    public class ProductControllerTests
    {
        private APIWebApplicationFactory Factory { get; set; }
        private HttpClient Client { get; set; }

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            Factory = new APIWebApplicationFactory();
            Client = Factory.CreateClient();
        }

        [Test]
        public async Task ListProductsButtonNew_ThenTheResultIsOk()
        {
            var result = await Client.GetAsync("/product/list");
            var content = await HtmlHelpers.GetDocumentAsync(result);
            var newProductButton = content.QuerySelector("[name='new-product-button']") as IHtmlAnchorElement;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.AreEqual("text/html; charset=utf-8", result.Content.Headers.ContentType.ToString());
            Assert.NotNull(newProductButton);
            Assert.AreEqual("New Product", newProductButton.Text);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}