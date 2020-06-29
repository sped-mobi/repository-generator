// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGeneratorParameters.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Windows;

    /// <summary>
    /// Defines the <see cref="IInfrastructure{TViewModel, TView}" />.
    /// </summary>
    /// <typeparam name="TViewModel">.</typeparam>
    /// <typeparam name="TView">.</typeparam>
    public interface IInfrastructure<TViewModel, TView>
        where TViewModel : ObservableObject
        where TView : Window
    {
        /// <summary>
        /// Gets the ViewModel.
        /// </summary>
        TViewModel ViewModel { get; }

        /// <summary>
        /// Gets the View.
        /// </summary>
        TView View { get; }
    }
}
