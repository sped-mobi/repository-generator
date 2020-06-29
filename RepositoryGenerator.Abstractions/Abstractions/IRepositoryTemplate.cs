namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IRepositoryTemplate" />.
    /// </summary>
    public interface IRepositoryTemplate
    {
        /// <summary>
        /// Gets the Replacements.
        /// </summary>
        IReadOnlyList<Replacement> Replacements { get; }
    }

    /// <summary>
    /// Defines the <see cref="Replacement" />.
    /// </summary>
    public class Replacement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Replacement"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        public Replacement(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the Value.
        /// </summary>
        public string Value { get; }
    }

    /// <summary>
    /// Defines the <see cref="RepositoryProject" />.
    /// </summary>
    public class RepositoryProject
    {
        /// <summary>
        /// Gets or sets the DirectoryName.
        /// </summary>
        public string DirectoryName { get; set; }

        /// <summary>
        /// Gets or sets the FileName.
        /// </summary>
        public string FileName { get; set; }
    }
}
