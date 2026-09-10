namespace StudyPresentation;

internal static class Program
{
    /// <summary>Displays the menu that selects an interactive study track.</summary>
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            ConsolePresentation.Write("============================================================", ConsoleColor.Cyan);
            ConsolePresentation.Write("                 SOFTWARE DESIGN STUDY MENU", ConsoleColor.Cyan);
            ConsolePresentation.Write("============================================================", ConsoleColor.Cyan);
            Console.WriteLine("1. SOLID principles");
            Console.WriteLine("2. Design patterns");
            Console.WriteLine("0. Exit");
            Console.Write("Select a study track: ");

            switch (Console.ReadKey(intercept: true).KeyChar)
            {
                case '1':
                    SolidPresenter.Run();
                    break;
                case '2':
                    PatternsPresenter.Run();
                    break;
                case '0':
                    return;
                default:
                    ConsolePresentation.Wait("Invalid selection. Press any key to try again.");
                    break;
            }
        }
    }
}