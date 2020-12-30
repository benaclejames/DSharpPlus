using DSharpPlus.Entities;

namespace DSharpPlus.EventArgs
{
    public class InteractionTriggeredEventArgs : DiscordEventArgs
    {
        /// <summary>
            /// Gets the guild for which the update occurred.
            /// </summary>
            public DiscordInteraction Interaction { get; internal set; }

            internal InteractionTriggeredEventArgs() : base() { }
    }
}