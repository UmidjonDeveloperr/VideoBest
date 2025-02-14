﻿using Shared.Models;

namespace VideoBest.Brokers.Storages
{
	public partial interface IStorageBroker
	{
		ValueTask<VideoMetadata> InsertVideoMetadataAsync(VideoMetadata videoMetadata);
		IQueryable<VideoMetadata> SelectAllVideoMetadatas();
		ValueTask<VideoMetadata> SelectVideoMetadataByIdAsync(Guid videoMetadataId);
		ValueTask<VideoMetadata> UpdateVideoMetadataAsync(VideoMetadata videoMetadata);
		ValueTask<VideoMetadata> DeleteVideoMetadataAsync(VideoMetadata videoMetadata);
	}
}
