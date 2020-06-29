// // -----------------------------------------------------------------------
// // <copyright file="IRepositoryOpener.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRepositoryOpener" />.
    /// </summary>
    public interface IRepositoryOpener
    {
        /// <summary>
        /// The OpenRepositoryAsync.
        /// </summary>
        /// <param name="solutionFilePath">The solutionFilePath<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task OpenRepositoryAsync(string solutionFilePath);
    }
}
