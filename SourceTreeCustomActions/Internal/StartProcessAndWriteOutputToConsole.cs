namespace SourceTreeCustomActions.Internal;

/// <inheritdoc />
public class StartProcessAndWriteOutputToConsole : IStartProcessAndWriteOutput
{
    /// <inheritdoc />
    public void RunFor([NotNull] Process process)
    {
        ArgumentNullException.ThrowIfNull(process);

        process.Start();
        Console.WriteLine($"{process.StartInfo.Arguments}...");
        Console.WriteLine(process.StandardOutput.ReadToEnd().Trim());
    }
}