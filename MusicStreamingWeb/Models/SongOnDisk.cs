using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStreamingWeb.Models
{
    public class SongOnDisk
    {
        public int Id { set; get; }
        public string Path { set; get; }

        public string Format { set; get; }
        public string Artist { set; get; }
        public string Name { set; get; }
        
    }
}