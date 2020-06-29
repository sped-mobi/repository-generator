namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRepositoryExpander" />.
    /// </summary>
    public interface IRepositoryExpander
    {
        /// <summary>
        /// The ExpandFileAsync.
        /// </summary>
        /// <param name="zipFile">The zipFile<see cref="string"/>.</param>
        /// <param name="outputDirectory">The outputDirectory<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task ExpandFileAsync(string zipFile, string outputDirectory);
    }
}
