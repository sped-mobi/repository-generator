// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGeneratorParameters.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    /// <summary>
    /// Defines the RepositoryStyle.
    /// </summary>
    public enum RepositoryStyle
    {
        /// <summary>
        /// Defines the Default.
        /// </summary>
        Default,

        /// <summary>
        /// Defines the OpenApiWebsite.
        /// </summary>
        OpenApiWebsite,

        /// <summary>
        /// Defines the NuGetPackage.
        /// </summary>
        NuGetPackage,

        /// <summary>
        /// Defines the VisualStudioExtension.
        /// </summary>
        VisualStudioExtension
    }
}
