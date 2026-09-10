namespace StudyPresentation;

/// <summary>Renders consistently formatted, interactive console slides.</summary>
internal static class ConsolePresentation
{
    /// <summary>Displays a lesson and runs its demonstration at the presenter's pace.</summary>
    public static void ShowLesson(Lesson lesson)
    {
        Console.Clear();
        Write(new string('-', 60), ConsoleColor.DarkCyan);
        Write(lesson.Title, ConsoleColor.Cyan);
        WriteSection("Definition", lesson.Definition, ConsoleColor.Yellow);
        WriteSection("Key applied in this code", lesson.KeyApplied, ConsoleColor.Green);
        WriteSection("When to use it", lesson.WhenToUse, ConsoleColor.DarkGreen);

        if (lesson.BadDesignSample is not null)
        {
            Write("Bad design", ConsoleColor.Red);
            Write(lesson.BadDesignSample.Trim(), ConsoleColor.DarkRed);
            Wait("Press any key to see the correct design.");
        }

        Write("Code to discuss", ConsoleColor.Magenta);
        Write(lesson.CodeSample.Trim(), ConsoleColor.Gray);
        Wait("Press any key to run the example.");
        Write("Live result", ConsoleColor.Blue);
        lesson.Demonstration();
        Wait("Press any key to continue.");
    }

    /// <summary>Writes a labeled explanation in the selected color.</summary>
    public static void WriteSection(string label, string content, ConsoleColor color)
    {
        Write($"{label}:", color);
        Write(content, ConsoleColor.White);
    }

    /// <summary>Writes a colored line and restores the default console color.</summary>
    public static void Write(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>Waits for a key press without echoing the key.</summary>
    public static void Wait(string message)
    {
        Console.WriteLine();
        Write(message, ConsoleColor.DarkYellow);
        Console.ReadKey(intercept: true);
    }
}

/// <summary>Contains the content and executable demonstration for one presentation slide.</summary>
internal sealed record Lesson(
    string Title,
    string Definition,
    string KeyApplied,
    string WhenToUse,
    string CodeSample,
    Action Demonstration,
    string? BadDesignSample = null);