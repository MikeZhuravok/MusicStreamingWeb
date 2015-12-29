using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStreamingWeb.Models.Comparer
{
    public class SongComparer : IEqualityComparer<Song>
    {
        public bool Equals(Song x, Song y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Song obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}