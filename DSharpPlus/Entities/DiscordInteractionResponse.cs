using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSharpPlus.Entities
{
    public sealed class DiscordInteractionResponse
    {
        public DiscordInteractionResponse(string content = null, DiscordEmbed embed = null)
        {
            ResponseData = new InteractionResponseData(false, content, embed);
            Type = 4;
        }
        
        public class InteractionResponseData
        {
            public InteractionResponseData(bool tts, string content, DiscordEmbed embed)
            {
                TTS = tts;
                Content = content ?? "";
                Embeds = new List<DiscordEmbed>();
                if (embed != null)
                    Embeds.Add(embed);
                AllowedMentions = new List<string>();
            }
            
            [JsonProperty("tts", NullValueHandling = NullValueHandling.Ignore)]
            public bool TTS { get; internal set; }
            
            [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
            public string Content { get; internal set; }
            
            [JsonProperty("embeds", NullValueHandling = NullValueHandling.Ignore)]
            public List<DiscordEmbed> Embeds { get; internal set; }
            
            [JsonProperty("allowed_mentions", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> AllowedMentions { get; internal set; }
        }
        
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int Type { get; internal set; }
        
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public InteractionResponseData ResponseData { get; internal set; }
    }
}