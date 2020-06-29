// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGeneratorParameters.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions
{
    using System.Windows;

    /// <summary>
    /// Defines the <see cref="InfrastructureBase{TViewModel, TView}" />.
    /// </summary>
    /// <typeparam name="TViewModel">.</typeparam>
    /// <typeparam name="TView">.</typeparam>
    public abstract class InfrastructureBase<TViewModel, TView> : IInfrastructure<TViewModel, TView>
        where TViewModel : ObservableObject
        where TView : Window
    {
        /// <summary>
        /// Gets the ViewModel.
        /// </summary>
        public abstract TViewModel ViewModel { get; }

        /// <summary>
        /// Gets the View.
        /// </summary>
        public abstract TView View { get; }
    }
}
