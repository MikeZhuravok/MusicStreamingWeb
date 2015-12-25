using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingWeb.Models
{
    public class Entity
    {

        [Required]
        public int ID { set; get; }
    }
}