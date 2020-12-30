namespace DSharpPlus
{
    /// <summary>
    /// Represents an interaction's type.
    /// </summary>
    public enum InteractionType : int
    {
        /// <summary>
        /// Indicates that this is a ping interaction.
        /// </summary>
        Ping = 1,
        
        /// <summary>
        /// Indicates that this is a command interaction.
        /// </summary>
        ApplicationCommand = 2,
    }
}