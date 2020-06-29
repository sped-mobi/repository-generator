namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRepositoryDownloader" />.
    /// </summary>
    public interface IRepositoryDownloader
    {
        /// <summary>
        /// The DownloadFileAsync.
        /// </summary>
        /// <param name="address">The address<see cref="string"/>.</param>
        /// <param name="fileName">The fileName<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DownloadFileAsync(string address, string fileName);
    }
}
