﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ALevelSample.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        [JsonProperty(PropertyName = "pantone_value")]
        public string Pantone_value { get; set; }
    }
}
