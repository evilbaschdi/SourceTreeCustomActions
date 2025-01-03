using System.Diagnostics;
using JetBrains.Annotations;

namespace SourceTreeCustomActions.Internal;

/// <inheritdoc />
public class GitProcess : IProcess
{
    private readonly IStringWrapper _path;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="path"></param>
    public GitProcess([NotNull] IStringWrapper path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

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