// // -----------------------------------------------------------------------
// // <copyright file="IReplacementsService.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IReplacementsService" />.
    /// </summary>
    public interface IReplacementsService
    {
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="parameters">The parameters<see cref="IRepositoryGeneratorParameters"/>.</param>
        /// <returns>The <see cref="Dictionary{string, string}"/>.</returns>
        Dictionary<string, string> Create(IRepositoryGeneratorParameters parameters);

        /// <summary>
        /// The Replace.
        /// </summary>
        /// <param name="input">The input<see cref="string"/>.</param>
        /// <param name="replacements">The replacements<see cref="Dictionary{string, string}"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string Replace(string input, Dictionary<string, string> replacements);
    }
}
