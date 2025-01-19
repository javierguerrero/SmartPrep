using Catalog.Service.Application.Dtos;
using Catalog.Service.Application.Interfaces;
using Catalog.Service.Domain.Entities;
using Catalog.Service.Infrastructure.Http.Results;

namespace Catalog.Service.Application.Services
{
    public partial class CatalogApplicationService : ICatalogApplicationService
    {
        public async Task<List<SongDto>> GetSongsAsync()
        {
            var songsFromRepo = await _unitOfWork.Songs.GetSongsAsync();
            var songs = _mapper.Map<List<SongDto>>(songsFromRepo);

            return songs;
        }

        public async Task<SongDto> GetSongBySongIdAsync(Guid songId)
        {
            var songFromRepo = await _unitOfWork.Songs.GetSongAsync(songId);

            if (songFromRepo is null)
            {
                return null;
            }

            var song = _mapper.Map<SongDto>(songFromRepo);
            return song;
        }

        public async Task<SongDto> CreateSongAsync(SongForCreationDto song)
        {
            var songEntity = _mapper.Map<Song>(song);
            await _unitOfWork.Songs.AddSongAsync(songEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("There was an error saving a song");
            }

            var songToReturn = _mapper.Map<SongDto>(songEntity);
            return songToReturn;
        }

        public async Task<bool?> DeleteSongAsync(Guid songId)
        {
            var songFromRepo = await _unitOfWork.Songs.GetSongAsync(songId);
            if (songFromRepo is null)
            {
                return null;
            }

            await _unitOfWork.Songs.DeleteSongAsync(songFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting song {songId} failed on save");
            }

            return true;
        }

        public async Task<UpdateSongResult> UpdateSongAsync(Guid songId, SongForUpdateDto song)
        {
            UpdateSongResult result = new();
            var songFromRepo = await _unitOfWork.Songs.GetSongAsync(songId);

            if (songFromRepo is null)
            {
                var songToAdd = _mapper.Map<Song>(song);
                songToAdd.SongId = songId;

                await _unitOfWork.Songs.AddSongAsync(songToAdd);

                if (!await _unitOfWork.SaveAsync())
                {
                    throw new Exception($"Upserting song {songId} failed on save");
                }

                result.SongUpserted = _mapper.Map<SongDto>(songToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(song, songFromRepo);
            await _unitOfWork.Songs.UpdateSongAsync(songFromRepo);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Update song {songId} failed on save");
            }

            result.Success = true;
            return result;
        }

        public async Task<bool> SongExistsAsync(Guid songId)
        {
            return await _unitOfWork.Songs.SongExists(songId);
        }
    }
}