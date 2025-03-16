namespace SourceTreeCustomActions.Internal;

/// <inheritdoc />
public class GitProcess(
    [NotNull] IStringWrapper path) : IProcess
{
    private readonly IStringWrapper _path = path ?? throw new ArgumentNullException(nameof(path));

    /// <inheritdoc />
    public Process ValueFor([NotNull] string argument)
    {
        ArgumentNullException.ThrowIfNull(argument);

        return new()
               {
                   StartInfo = new()
                               {
                                   FileName = "git",
                                   Arguments = argument,
                                   WorkingDirectory = _path.Value,
                                   UseShellExecute = false,
                                   RedirectStandardOutput = true,
                                   CreateNoWindow = true
                               }
               };
    }
}