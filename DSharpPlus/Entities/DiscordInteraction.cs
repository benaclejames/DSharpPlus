using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.Net;
using Newtonsoft.Json;

namespace DSharpPlus.Entities
{
    /// <summary>
    /// Represents a Discord interaction event.
    /// </summary>
    public class DiscordInteraction : SnowflakeObject, IEquatable<DiscordInteraction>
    {
        public class InteractionParameters
        {
            public class SingleParam
            {
                [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
                public string Value { get; internal set; }
                
                [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
                public string Key { get; internal set; }
            }

            public class InteractionMember
            {
                [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
                public DiscordUser User;
            }

            [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
            public List<SingleParam> Options { get; internal set; }
            
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string InteractionName { get; internal set; }
            
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string InteractionId { get; internal set; }
        }
        
        /// <summary>
        /// Read-only property. Currently always set to 1.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get; internal set; }
        
        /// <summary>
        /// Gets the type of this interaction.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public InteractionType Type { get; internal set; }
        
        /// <summary>
        /// Gets the continuation token to use for responding to the interaction.
        /// </summary>
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string ContinuationToken { get; internal set; }
        
        /// <summary>
        /// Gets the entity that triggered the interaction.
        /// </summary>
        [JsonProperty("member", NullValueHandling = NullValueHandling.Ignore)]
        public InteractionParameters.InteractionMember Instigator { get; internal set; }

        /// <summary>
        /// Gets the ID of the guild where this interaction was invoked.
        /// </summary>
        [JsonProperty("guild_id", NullValueHandling = NullValueHandling.Ignore)]
        public ulong GuildId { get; internal set; }
        
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public InteractionParameters Params { get; internal set; }
        
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; internal set; }

        public async Task Respond(DiscordInteractionResponse response)
        {
            await this.Discord.ApiClient.RespondToInteractionAsync(ID, ContinuationToken, response);
        }
        
        public bool Equals(DiscordInteraction e)
        {
            if (ReferenceEquals(e, null))
                return false;

            if (ReferenceEquals(this, e))
                return true;

            return this.Id == e.Id; //&& this.ChannelId == e.ChannelId;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DiscordInteraction);
        }

    }
}