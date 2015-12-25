using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingWeb.Models
{
    public class Song : Entity
    {
        [Required]
        public string Artist { set; get; }
        [Required]
        public string Name { set; get; }

        public byte[] File { set; get; }
    }
}