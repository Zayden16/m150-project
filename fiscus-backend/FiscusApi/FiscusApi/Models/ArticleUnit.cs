﻿using System.Text.Json.Serialization;

namespace FiscusApi.Models
{
    public class ArticleUnit
    {
        [JsonPropertyName("Id")]
        public int ArticleUnit_Id { get; set; }

        [JsonPropertyName("Text")]
        public string ArticleUnit_Text { get; set; }
    }
}
