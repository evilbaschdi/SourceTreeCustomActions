using System;
using JetBrains.Annotations;

namespace SourceTreeCustomActions.Internal
{
    /// <inheritdoc />
    public class PathStringWrapper : IStringWrapper
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="pathToWrap"></param>
        public PathStringWrapper([NotNull] string pathToWrap)
        {
            Value = pathToWrap ?? throw new ArgumentNullException(nameof(pathToWrap));
        }

        /// <inheritdoc />
        public string Value { get; }
    }
}