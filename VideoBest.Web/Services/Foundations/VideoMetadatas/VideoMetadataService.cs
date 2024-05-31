using Shared.Models;
using System.Net.Http.Json;

namespace VideoBest.Web.Services.Foundations.VideoMetadatas
{
    public class VideoMetadataService
    {
        private readonly HttpClient httpClient;

        public VideoMetadataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<VideoMetadata>> GetVideoMetadatasAsync()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/VideoMetadata");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<VideoMetadata>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<VideoMetadata>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}
