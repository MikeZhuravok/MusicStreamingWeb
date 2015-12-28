using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreaming.WebApi.Models
{
    public class Entity
    {

        [Required]
        public int Id { set; get; }
    }
}