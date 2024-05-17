namespace CurrencyConvertor.API.Helpers
{
    public static class RetryPolicy
    {
        public static async Task<HttpResponseMessage> ExecuteAsync(Func<Task<HttpResponseMessage>> action, int maxRetries = 3)
        {
            int retries = 0;
            var response = new HttpResponseMessage();
            while (retries < maxRetries)
            {
                response = await action();
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                retries++;
                await Task.Delay(TimeSpan.FromSeconds(2));
            }

            return response;
        }
    }

}
