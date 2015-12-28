using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreaming.Data.Models
{
    public class Playlist : Entity
    {
        [Required]
        public string UserId { set; get; }
        //[Required]
        //public 

        public virtual List<SongInPlaylist> SongsInPlaylist { set; get; }
        public virtual ApplicationUser User { set; get; }

    }
}