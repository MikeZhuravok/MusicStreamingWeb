using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingWeb.Models
{
    public class SongInPlaylist : Entity
    {
        [Required]
        public int PlaylistId { set; get; }
        [Required]
        public int SongId { set; get; }

        public virtual Playlist Playlist { set; get; }
        public virtual Song Song { set; get; }

    }
}