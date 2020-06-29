namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    /// <summary>
    /// Defines the <see cref="IRepositoryGeneratorServices" />.
    /// </summary>
    public interface IRepositoryGeneratorServices
    {
        /// <summary>
        /// Gets the Replace.
        /// </summary>
        IReplacementsService Replace { get; }

        /// <summary>
        /// Gets the Opener.
        /// </summary>
        IRepositoryOpener Opener { get; }

        /// <summary>
        /// Gets the Downloader.
        /// </summary>
        IRepositoryDownloader Downloader { get; }

        /// <summary>
        /// Gets the Expander.
        /// </summary>
        IRepositoryExpander Expander { get; }
    }
}
