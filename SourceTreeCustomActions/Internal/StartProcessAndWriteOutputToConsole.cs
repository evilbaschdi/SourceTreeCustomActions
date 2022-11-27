using System.Diagnostics;
using JetBrains.Annotations;

namespace SourceTreeCustomActions.Internal;

/// <inheritdoc />
public class StartProcessAndWriteOutputToConsole : IStartProcessAndWriteOutput
{
    /// <inheritdoc />
    public void RunFor([NotNull] Process process)
    {
        if (process == null)
        {
            throw new ArgumentNullException(nameof(process));
        }

        process.Start();
        Console.WriteLine(process.StartInfo.Arguments + "...");
        Console.WriteLine(process.StandardOutput.ReadToEnd().Trim());
    }
}