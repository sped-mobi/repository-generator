namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    /// <summary>
    /// Defines the <see cref="IRepositoryGeneratorParameters" />.
    /// </summary>
    public interface IRepositoryGeneratorParameters
    {
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the Output.
        /// </summary>
        string Output { get; set; }

        /// <summary>
        /// Gets or sets the ProjectName.
        /// </summary>
        string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the RepositoryName.
        /// </summary>
        string RepositoryName { get; set; }

        /// <summary>
        /// Gets or sets the RepositoryStyle.
        /// </summary>
        RepositoryStyle RepositoryStyle { get; set; }

        /// <summary>
        /// Gets or sets the RootNamespace.
        /// </summary>
        string RootNamespace { get; set; }

        /// <summary>
        /// Gets or sets the SdkXmlLocation.
        /// </summary>
        SdkXmlElementLocation SdkXmlLocation { get; set; }

        /// <summary>
        /// Gets or sets the SolutionName.
        /// </summary>
        string SolutionName { get; set; }

        /// <summary>
        /// Gets or sets the TargetFramework.
        /// </summary>
        TargetFramework TargetFramework { get; set; }
    }
}
