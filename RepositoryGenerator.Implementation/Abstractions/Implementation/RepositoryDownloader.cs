namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="RepositoryDownloader" />.
    /// </summary>
    [Export(typeof(IRepositoryDownloader))]
    public class RepositoryDownloader : IRepositoryDownloader
    {
        /// <summary>
        /// The DownloadFileAsync.
        /// </summary>
        /// <param name="address">The address<see cref="string"/>.</param>
        /// <param name="fileName">The fileName<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DownloadFileAsync(string address, string fileName)
        {
            WebClient client = new WebClient();

            try
            {
                client.DownloadFile(address, fileName);
            }
            catch (WebException ex)
            {
                Debug.Print(ex.Message);
            }

            await Task.CompletedTask;
        }
    }
}
