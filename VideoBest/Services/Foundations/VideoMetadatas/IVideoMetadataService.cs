using Shared.Models;

namespace VideoBest.Services.Foundations.VideoMetadatas
{
	public interface IVideoMetadataService
	{
		ValueTask<VideoMetadata> AddVideoMetadataAsync(VideoMetadata videoMetadata);
		IQueryable<VideoMetadata> RetrieveAllVideoMetadatas();
		ValueTask<VideoMetadata> RetrieveVideoMetadataByIdAsync(Guid videoMetadataId);
		ValueTask<VideoMetadata> ModifyVideoMetadataAsync(VideoMetadata videoMetadata);
		ValueTask<VideoMetadata> RemoveVideoMetadataAsync(Guid videoMetadataId);
	}
}
