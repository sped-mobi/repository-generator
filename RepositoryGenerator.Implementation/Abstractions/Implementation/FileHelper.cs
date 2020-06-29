namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using System.ComponentModel.Composition;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="FileHelper" />.
    /// </summary>
    [Export(typeof(IFileHelper))]
    public class FileHelper : IFileHelper
    {
        /// <summary>
        /// The CopyDirectory.
        /// </summary>
        /// <param name="source">The source<see cref="string"/>.</param>
        /// <param name="destination">The destination<see cref="string"/>.</param>
        /// <param name="overwrite">The overwrite<see cref="bool"/>.</param>
        /// <param name="deleteSourceOnCompletion">The deleteSourceOnCompletion<see cref="bool"/>.</param>
        public void CopyDirectory(string source, string destination, bool overwrite = false, bool deleteSourceOnCompletion = false)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            if (!dir.Exists)
                throw new DirectoryNotFoundException(source);

            var dirs = dir.GetDirectories();

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string targetPath = Path.Combine(destination, file.Name);
                //Logger.Log($"Copying {file.Name} to {targetPath}");
                file.CopyTo(targetPath, overwrite);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destination, subdir.Name);
                CopyDirectory(subdir.FullName, temppath, overwrite, deleteSourceOnCompletion);
            }
        }

        /// <summary>
        /// The DeleteIfExists.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        public void DeleteIfExists(string path)
        {
            if (IsDirectory(path))
            {
                Directory.Delete(path, true);
            }
            else
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// The IsDirectory.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool IsDirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }
}
