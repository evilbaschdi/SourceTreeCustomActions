namespace GitClientCustomActions.Internal;

/// <inheritdoc />
public class StartProcessAndWriteOutputToConsole : IStartProcessAndWriteOutput
{
    /// <inheritdoc />
    public void RunFor([NotNull] Process process)
    {
        ArgumentNullException.ThrowIfNull(process);

        process.Start();
        Console.WriteLine($"{process.StartInfo.Arguments}...");
        var output = process.StandardOutput.ReadToEnd().Trim();
        var error = process.StandardError.ReadToEnd().Trim();
        
        if (!string.IsNullOrEmpty(output))
        {
            Console.WriteLine(output);
        }
        
        if (!string.IsNullOrEmpty(error))
        {
            Console.WriteLine(error);
        }
    }
}