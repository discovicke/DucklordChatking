using System.Numerics;
using ChatClient.Core;
using Raylib_cs;
using Shared;

namespace ChatClient.UI.Components;

public class ChatMessage
{
    private readonly MessageDTO message;
    private readonly string displayText;
    private readonly float maxWidth;
    private readonly List<string> wrappedLines;

    public float Height { get; private set; }
    private const float Padding = 10f;
    private const float LineSpacing = 18f;
    private const float FontSize = 14f;

    public ChatMessage(MessageDTO message, float maxWidth)
    {
        this.message = message;
        this.maxWidth = maxWidth - (Padding * 2);

        string sender = string.IsNullOrWhiteSpace(message.Sender) ? "Unknown Duck" : message.Sender;
        string timestamp = message.Timestamp.ToLocalTime().ToString("HH:mm");
        string header = $"{timestamp} - {sender}:";

        wrappedLines = new List<string>();

        // Wrap header
        wrappedLines.AddRange(WrapText(header, ResourceLoader.BoldFont));

        // Wrap content
        wrappedLines.AddRange(WrapText(message.Content ?? "", ResourceLoader.RegularFont));

        // Total height
        Height = wrappedLines.Count * LineSpacing + (Padding * 2);
    }

    private List<string> WrapText(string text, Font font)
    {
        var lines = new List<string>();
        var words = text.Split(' ');
        string currentLine = "";

        foreach (var word in words)
        {
            string testLine = string.IsNullOrEmpty(currentLine) ? word : currentLine + " " + word;
            var size = Raylib.MeasureTextEx(font, testLine, FontSize, 0.5f);

            if (size.X > maxWidth && !string.IsNullOrEmpty(currentLine))
            {
                lines.Add(currentLine);
                currentLine = word;
            }
            else
            {
                currentLine = testLine;
            }
        }

        if (!string.IsNullOrEmpty(currentLine))
            lines.Add(currentLine);

        return lines;
    }
}