namespace SourceTreeCustomActions.Internal;

/// <inheritdoc />
public class GitCommands(
    [NotNull] IProcess git,
    [NotNull] IStartProcessAndWriteOutput startProcessAndWriteOutput)
    : IGitCommands
{
    private readonly IProcess _git = git ?? throw new ArgumentNullException(nameof(git));
    private readonly IStartProcessAndWriteOutput _startProcessAndWriteOutput = startProcessAndWriteOutput ?? throw new ArgumentNullException(nameof(startProcessAndWriteOutput));

    /// <inheritdoc />
    public void RunFor(params string[] commands)
    {
        foreach (var command in commands)
        {
            var gitCommand = _git.ValueFor(command);
            _startProcessAndWriteOutput.RunFor(gitCommand);
        }
    }
}