// // -----------------------------------------------------------------------
// // <copyright file="IRepositoryGenerator.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRepositoryGenerator" />.
    /// </summary>
    public interface IRepositoryGenerator
    {
        /// <summary>
        /// Gets the Services.
        /// </summary>
        IRepositoryGeneratorServices Services { get; }

        /// <summary>
        /// The CreateRepositoryAsync.
        /// </summary>
        /// <param name="parameters">The parameters<see cref="IRepositoryGeneratorParameters"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task CreateRepositoryAsync(IRepositoryGeneratorParameters parameters, CancellationToken cancellationToken = default);
    }
}
