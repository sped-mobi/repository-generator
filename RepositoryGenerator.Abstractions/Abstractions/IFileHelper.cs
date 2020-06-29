namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    /// <summary>
    /// Defines the <see cref="IFileHelper" />.
    /// </summary>
    public interface IFileHelper
    {
        /// <summary>
        /// The DeleteIfExists.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        void DeleteIfExists(string path);

        /// <summary>
        /// The CopyDirectory.
        /// </summary>
        /// <param name="source">The source<see cref="string"/>.</param>
        /// <param name="destination">The destination<see cref="string"/>.</param>
        /// <param name="overwrite">The overwrite<see cref="bool"/>.</param>
        /// <param name="deleteSourceOnCompletion">The deleteSourceOnCompletion<see cref="bool"/>.</param>
        void CopyDirectory(string source, string destination, bool overwrite = false, bool deleteSourceOnCompletion = false);
    }
}
