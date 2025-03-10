﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Movies.Contracts.Responses
{
    public class HalResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Link> Links { get; set; } = new();
    }

    public class Link
    {
        public required string Href { get; init; }
        public required string Rel { get; init; }
        public required string Type { get; init; }
    }
}
