namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using System.ComponentModel.Composition;

    /// <summary>
    /// Defines the <see cref="RepositoryGeneratorServices" />.
    /// </summary>
    [Export(typeof(IRepositoryGeneratorServices))]
    public class RepositoryGeneratorServices : IRepositoryGeneratorServices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryGeneratorServices"/> class.
        /// </summary>
        /// <param name="replace">The replace<see cref="IReplacementsService"/>.</param>
        /// <param name="opener">The opener<see cref="IRepositoryOpener"/>.</param>
        /// <param name="downloader">The downloader<see cref="IRepositoryDownloader"/>.</param>
        /// <param name="expander">The expander<see cref="IRepositoryExpander"/>.</param>
        [ImportingConstructor]
        public RepositoryGeneratorServices(
            [Import] IReplacementsService replace,
            [Import] IRepositoryOpener opener,
            [Import] IRepositoryDownloader downloader,
            [Import] IRepositoryExpander expander)
        {
            Replace = replace;
            Opener = opener;
            Downloader = downloader;
            Expander = expander;
        }

        /// <summary>
        /// Gets the Replace.
        /// </summary>
        public IReplacementsService Replace { get; }

        /// <summary>
        /// Gets the Opener.
        /// </summary>
        public IRepositoryOpener Opener { get; }

        /// <summary>
        /// Gets the Downloader.
        /// </summary>
        public IRepositoryDownloader Downloader { get; }

        /// <summary>
        /// Gets the Expander.
        /// </summary>
        public IRepositoryExpander Expander { get; }
    }
}
