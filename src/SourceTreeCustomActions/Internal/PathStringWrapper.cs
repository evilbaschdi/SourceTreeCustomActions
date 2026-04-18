namespace SourceTreeCustomActions.Internal;

/// <inheritdoc />
public class PathStringWrapper(
    [NotNull] string pathToWrap) : IStringWrapper
{
    /// <inheritdoc />
    public string Value { get; } = pathToWrap ?? throw new ArgumentNullException(nameof(pathToWrap));
}