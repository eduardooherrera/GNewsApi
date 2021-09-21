namespace apiGNews.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Posts
    {
        [JsonProperty("totalArticles")]
        public long TotalArticles { get; set; }

        [JsonProperty("articles")]
        public Post[] Post { get; set; }
    }

    public partial class Post
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("publishedAt")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Post
    {
        public static Post FromJson(string json) => JsonConvert.DeserializeObject<Post>(json, apiGNews.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Post self) => JsonConvert.SerializeObject(self, apiGNews.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public partial class miniPost
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public Uri Img { get; set; }

        [JsonProperty("hide")]
        public bool hide { get; set; }
    }
}

