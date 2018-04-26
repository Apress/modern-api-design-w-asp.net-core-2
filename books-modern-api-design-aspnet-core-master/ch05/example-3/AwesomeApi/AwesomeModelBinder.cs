using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AwesomeApi
{
    public class AwesomeModelBinder : IModelBinder
    {
        private const string SUBSCRIPTION_KEY = "YOUR AZURE COGNITIVE SERVICES API KEY HERE";
        private const string SUBSCRIPTION_LOCATION = "YOUR AZURE COGNITIVE SERVICES API LOCATION HERE";

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            const string propertyName = "Photo";
            var valueProviderResult = bindingContext.ValueProvider.GetValue(propertyName);
            var base64Value = valueProviderResult.FirstValue;
            if (!string.IsNullOrEmpty(base64Value))
            {
                var bytes = Convert.FromBase64String(base64Value);
                var emotionResult = await GetEmotionResultAsync(bytes);
                var score = emotionResult.First().Scores;
                var result = new EmotionalPhotoDto
                {
                    Contents = bytes,
                    Scores = score
                };
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            await Task.FromResult(Task.CompletedTask);
        }

        private static async Task<EmotionResultDto[]> GetEmotionResultAsync(byte[] byteArray)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
            var uri = $"https://{SUBSCRIPTION_LOCATION}.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
            using (var content = new ByteArrayContent(byteArray))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                var response = await client.PostAsync(uri, content);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<EmotionResultDto[]>(responseContent);
                return result;
            }
        }
    }
}
