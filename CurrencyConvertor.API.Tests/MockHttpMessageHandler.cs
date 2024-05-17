using System.Net;

namespace CurrencyConvertor.API.Tests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{""base"":""EUR"",""date"":""2021-04-30"",""rates"":{""USD"":1.2}}")
            };
            return await Task.FromResult(response);
        }
    }
}
