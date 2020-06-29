using Microsoft.VisualStudio.RepositoryGenerator.Commands;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Microsoft.VisualStudio.RepositoryGenerator.Abstractions.dll")]

namespace Microsoft.VisualStudio.RepositoryGenerator.Packaging
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidSymbols.PackageString)]
    public sealed class RepositoryGeneratorPackage : AsyncPackage, IVsInstalledProduct
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);

            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            //Logger.Initialize(this, "Repository Generator");

            var service = await GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            var handler = new CommandHandler();
            CommandRegistrar.RegisterCommands(service, handler);

        }

        public int IdBmpSplash(out uint pIdBmp)
        {
            pIdBmp = 0U;
            return 0;
        }

        public int OfficialName(out string pbstrName)
        {
            pbstrName = "Repository Generator Package";
            return 0;
        }

        public int ProductID(out string pbstrPID)
        {
            pbstrPID = "Repository Generator";
            return 0;
        }

        public int ProductDetails(out string pbstrProductDetails)
        {
            pbstrProductDetails = "Generates a new repository.";
            return 0;
        }

        public int IdIcoLogoForAboutbox(out uint pIdIco)
        {
            pIdIco = 57077U;
            return 0;
        }
    }
}
