// See https://aka.ms/new-console-template for more information
namespace TeleprompterConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello world");

        var lines = ReadFrom("sampleQuotes.txt");
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            if (!string.IsNullOrWhiteSpace(line))
            {
                RunTeleprompter().Wait();
            }

        }
    }

    /// <summary> 
    /// Reads the file and returns each line
    /// </summary>
    /// <param name="file">
    /// File that is read
    /// </param> 
    /// <returns>Returns each line as a string</returns>
    static IEnumerable<string> ReadFrom(string file)
    {
        string? line;
        using (var reader = File.OpenText(file))
        {
            while ((line = reader.ReadLine()) != null)
            {
                var words = line.Split(' ');
                var lineLength =0;

                foreach (var word in words)
                {
                    yield return word + " ";
                    lineLength += word.Length + 1;
                    if(lineLength>70)
                    {
                        yield return Environment.NewLine;
                        lineLength = 0;
                    }
                }
                yield return Environment.NewLine;
            }
        }
    }
    /// <summary> 
    /// Runs in background, sends a signal when to show next word
    /// </summary>
    /// <returns>A flag to show next word</returns>
    /// <param name="config">
    /// The TelePrompterConfig object is passed in order to get Delay in millisecounds.
    /// </param> 
    private static async Task ShowTeleprompter(TelePrompterConfig config)
    {
        var words = ReadFrom("sampleQuotes.txt");
        foreach (var word in words)
        {
            Console.WriteLine(word);
            if (!string.IsNullOrWhiteSpace(word))
            {
                await Task.Delay(config.DelayInMilliseconds);
            }
        }
        config.SetDone();
    }

    /// <summary> 
    /// Gets the input from the user
    /// </summary>
    /// <returns>Returns config with changed delay Times</returns>
    /// <param name="config">
    /// A TelePropterConfig object used in order to increase/descrease or finish telpromter
    /// </param> 
    private static async Task GetInput(TelePrompterConfig config)
    {
        Action work = () =>
        {
            do {
                var key = Console.ReadKey(true);
                if (key.KeyChar == '>')
                {
                    config.UpdateDelay(-10);
                }
                else if (key.KeyChar == '<')
                {
                    config.UpdateDelay(10);
                }
                else if (key.KeyChar == 'X' || key.KeyChar == 'x')
                {
                    config.SetDone();
                }
            } while (!config.Done);
        };
        await Task.Run(work);
    }
    /// <summary> 
    /// Runs Teleprompter in background
    /// </summary>
    /// <returns>A flag onw when to show next item</returns>
    private static async Task RunTeleprompter()
    {
        var config = new TelePrompterConfig();
        var displayTask = ShowTeleprompter(config);

        var speedTask = GetInput(config);
        await Task.WhenAny(displayTask, speedTask);

    }
}


