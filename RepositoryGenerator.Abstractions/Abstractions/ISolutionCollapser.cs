namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ISolutionCollapser" />.
    /// </summary>
    public interface ISolutionCollapser
    {
        /// <summary>
        /// The CollapseSolutionAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task CollapseSolutionAsync();
    }
}
