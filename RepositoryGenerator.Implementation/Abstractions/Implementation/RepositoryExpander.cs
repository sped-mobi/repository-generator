namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using Task = System.Threading.Tasks.Task;

    /// <summary>
    /// Defines the <see cref="RepositoryExpander" />.
    /// </summary>
    [Export(typeof(IRepositoryExpander))]
    public class RepositoryExpander : IRepositoryExpander
    {
        /// <summary>
        /// Defines the _fileHelper.
        /// </summary>
        private readonly IFileHelper _fileHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryExpander"/> class.
        /// </summary>
        /// <param name="fileHelper">The fileHelper<see cref="IFileHelper"/>.</param>
        [ImportingConstructor]
        public RepositoryExpander(
            [Import] IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        /// <summary>
        /// The ExpandFileAsync.
        /// </summary>
        /// <param name="zipFile">The zipFile<see cref="string"/>.</param>
        /// <param name="outputDirectory">The outputDirectory<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task ExpandFileAsync(string zipFile, string outputDirectory)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            string tempGuid = Guid.NewGuid().ToString("N");

            string tempZipDir =
                Path.Combine(Path.GetDirectoryName(zipFile), tempGuid);

            ZipFile.ExtractToDirectory(zipFile, tempZipDir);

            var firstDirectory = Directory.GetDirectories(tempZipDir).SingleOrDefault();

            try
            {
                _fileHelper.CopyDirectory(firstDirectory, outputDirectory, true, true);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

            if (Directory.Exists(tempZipDir))
                Directory.Delete(tempZipDir, true);

            if (File.Exists(zipFile))
                File.Delete(zipFile);
        }
    }
}
