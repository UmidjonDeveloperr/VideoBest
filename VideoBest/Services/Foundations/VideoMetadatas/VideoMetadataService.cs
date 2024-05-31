using Shared.Models;
using VideoBest.Brokers.Storages;

namespace VideoBest.Services.Foundations.VideoMetadatas
{
	public class VideoMetadataService : IVideoMetadataService
	{
		private readonly IStorageBroker storageBroker;

		public VideoMetadataService(IStorageBroker storageBroker)
		{
			this.storageBroker = storageBroker;
		}

		public async ValueTask<VideoMetadata> AddVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await this.storageBroker.InsertVideoMetadataAsync(videoMetadata);

		public IQueryable<VideoMetadata> RetrieveAllVideoMetadatas() =>
			this.storageBroker.SelectAllVideoMetadatas();

		public async ValueTask<VideoMetadata> RetrieveVideoMetadataByIdAsync(Guid Id) =>
			await this.storageBroker.SelectVideoMetadataByIdAsync(Id);

		public async ValueTask<VideoMetadata> ModifyVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await this.storageBroker.UpdateVideoMetadataAsync(videoMetadata);

		public async ValueTask<VideoMetadata> RemoveVideoMetadataAsync(Guid Id)
		{
			VideoMetadata gettingVideoMetadata =
				await this.storageBroker.SelectVideoMetadataByIdAsync(Id);

			return await this.storageBroker.DeleteVideoMetadataAsync(gettingVideoMetadata);
		}
	}
}
