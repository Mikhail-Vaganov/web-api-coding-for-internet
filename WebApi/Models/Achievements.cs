using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApi.Models
{
    public class Achievements : DbEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Cost { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public int CharacterId { get; set; }
    }
}