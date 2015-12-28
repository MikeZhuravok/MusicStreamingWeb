using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreaming.Data.Models
{
    public class Song : Entity
    {
        [Required]
        public string Title { set; get; }
        //    public byte[] File { set; get; }
        [Required]
        public string Url { set; get; }
        [Required]
        public string Artist { set; get; }
        public string Format { set; get; }

    }
}