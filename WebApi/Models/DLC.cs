using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApi.Models
{
    public class DLC : DbEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDownloaded { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public int AccountId { get; set; }
    }
}