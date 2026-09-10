namespace DependencyInversion;

internal interface IMessageSender
{
    /// <summary>
    /// Sends a message through the configured delivery channel.
    /// </summary>
    /// <param name="recipient">The destination of the message.</param>
    /// <param name="message">The message body.</param>
    void Send(string recipient, string message);
}