namespace GitClientCustomActions.Internal;

/// <inheritdoc />
public class GitProcess(IStringWrapper path) : IProcess
{
    private readonly IStringWrapper _path = path ?? throw new ArgumentNullException(nameof(path));

    /// <inheritdoc />
    public Process ValueFor([NotNull] string argument)
    {
        ArgumentNullException.ThrowIfNull(argument);

        const int maxRetries = 3;
        const int delayMs = 3000; // 3 seconds delay

        var process = default(Process);

        for (var attempt = 1; attempt <= maxRetries; attempt++)
        {
            process = new Process
                      {
                          StartInfo = new ProcessStartInfo
                                      {
                                          FileName = "git",
                                          Arguments = argument,
                                          WorkingDirectory = _path.Value,
                                          UseShellExecute = false,
                                          RedirectStandardOutput = true,
                                          RedirectStandardError = true,
                                          CreateNoWindow = true
                                      }
                      };

            // Start the process
            process.Start();

            // Capture the output and error streams and write them to the console
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(output))
            {
                Console.Out.Write(output);
            }

            if (!string.IsNullOrEmpty(error))
            {
                Console.Error.Write(error);
            }

            process.WaitForExit();

            // If the command execution was successful, return the process
            if (process.ExitCode == 0)
            {
                return process;
            }

            // Wait before retrying
            if (attempt >= maxRetries)
            {
                continue;
            }

            Console.WriteLine($"[Attempt {attempt} failed. Waiting 3 seconds for the next attempt...]");
            Thread.Sleep(delayMs);
        }

        // Return the final process object (even if all attempts failed)
        return process;
    }
}