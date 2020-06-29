// // -----------------------------------------------------------------------
// // <copyright file="RepositoryOpener.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using EnvDTE80;
    using Microsoft.VisualStudio.PlatformUI;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using System.ComponentModel.Composition;
    using System.IO;
    using Task = System.Threading.Tasks.Task;

    /// <summary>
    /// Defines the <see cref="RepositoryOpener" />.
    /// </summary>
    [Export(typeof(IRepositoryOpener))]
    public class RepositoryOpener : IRepositoryOpener
    {
        /// <summary>
        /// Defines the _addToCurrent.
        /// </summary>
        private const uint _addToCurrent = (uint)__VSSLNOPENOPTIONS.SLNOPENOPT_AddToCurrent;

        /// <summary>
        /// Defines the _collapser.
        /// </summary>
        private readonly ISolutionCollapser _collapser;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryOpener"/> class.
        /// </summary>
        /// <param name="collapser">The collapser<see cref="ISolutionCollapser"/>.</param>
        [ImportingConstructor]
        public RepositoryOpener(
            [Import] ISolutionCollapser collapser)
        {
            _collapser = collapser;
        }

        /// <summary>
        /// The OpenRepositoryAsync.
        /// </summary>
        /// <param name="solutionFilePath">The solutionFilePath<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task OpenRepositoryAsync(string solutionFilePath)
        {
            if (File.Exists(solutionFilePath))
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

                Solution2.OpenSolutionFile(_addToCurrent, solutionFilePath);

                Solution4.EnsureSolutionIsLoaded((uint)__VSBSLFLAGS.VSBSLFLAGS_None);

                Solution2.SaveSolutionElement((uint)__VSSLNSAVEOPTIONS.SLNSAVEOPT_ForceSave, null, 0);

                await _collapser.CollapseSolutionAsync();
            }
            else
            {
                MessageDialog.Show("Solution File Error", $"The soution file {solutionFilePath} does not exist.", MessageDialogCommandSet.Ok);
            }
        }

        /// <summary>
        /// Gets the DTE.
        /// </summary>
        private static DTE2 DTE => GetService<SDTE, DTE2>();

        /// <summary>
        /// Gets the Solution2.
        /// </summary>
        private static IVsSolution2 Solution2 => GetService<SVsSolution, IVsSolution2>();

        /// <summary>
        /// Gets the Solution4.
        /// </summary>
        private static IVsSolution4 Solution4 => GetService<SVsSolution, IVsSolution4>();

        /// <summary>
        /// The GetService.
        /// </summary>
        /// <typeparam name="TService">.</typeparam>
        /// <typeparam name="TServiceInterface">.</typeparam>
        /// <returns>The <see cref="TServiceInterface"/>.</returns>
        private static TServiceInterface GetService<TService, TServiceInterface>()
        {
            return (TServiceInterface)Shell.Package.GetGlobalService(typeof(TService));
        }
    }
}
