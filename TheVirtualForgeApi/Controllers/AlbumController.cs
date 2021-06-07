using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheVirtualForgeApi.ApplicationCore.DTO;
using TheVirtualForgeApi.ApplicationCore.Models;
using TheVirtualForgeApi.ApplicationCore.Services;

namespace TheVirtualForgeApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AlbumController : BaseController
    {
        private readonly ILogger<AlbumController> _logger;
        private readonly IAlbumRepository albumRepository;

        public AlbumController(ILogger<AlbumController> logger, IAlbumRepository  albumRepository)
        {
            _logger = logger;
            this.albumRepository = albumRepository;
        }
        [HttpGet("album")]
        public async Task<ActionResult> GetAlbums([FromQuery] string title, [FromQuery] string artistName)
        {
            _logger.LogInformation("Getting album");
            var response = await albumRepository.GetItemsAsync(title, artistName);
            if (response.Count()==0)return DataResponse<List<AlbumDTO>>(null);
            return DataResponse<List<AlbumDTO>>(response);
        }

        [HttpDelete("album/{Id:int}")]
        public async Task<ActionResult> DeleteAlbums([FromRoute] int Id)
        {
            _logger.LogInformation("Deleting album ");
            return DataResponse<bool>(await albumRepository.DeleteItemAsync(Id));
        }

        [HttpPut("album")]
        public async Task<ActionResult> PutAlbum([FromBody] Album album)
        {
            _logger.LogInformation("Updating album ");
            return DataResponse<Album>(await albumRepository.UpdateItemAsync(album));
        }
        [HttpPost("album")]
        public async Task<ActionResult> PostAlbum([FromBody] Album album)
        {
            _logger.LogInformation("creating new album ");
            return DataResponse<int>(await albumRepository.AddItemAsync(album), nameof(PostAlbum),201);
        }
    }
}
