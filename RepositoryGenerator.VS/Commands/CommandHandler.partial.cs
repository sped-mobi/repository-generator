using Microsoft.VisualStudio.RepositoryGenerator.Abstractions;
using Microsoft.VisualStudio.RepositoryGenerator.UI;
using Microsoft.VisualStudio.Shell;
using System;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace Microsoft.VisualStudio.RepositoryGenerator.Commands
{
    internal partial class CommandHandler
    {
        public override void OnExecuteNewRepositoryCommand(object sender, EventArgs e)
        {
            ThreadHelper.JoinableTaskFactory.Run(OnExecuteNewRepositoryCommandAsync);
        }

        public async Task OnExecuteNewRepositoryCommandAsync()
        {

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            IRepositoryGenerator repositoryGenerator = MefComponents.GetRepositoryGenerator();

            var infra = RepositoryGeneratorParametersFactory.Create();
            var window = infra.View;
            var dialogResult = window.ShowModal();
            if (dialogResult == true)
            {
                var model = infra.ViewModel;

                await repositoryGenerator.CreateRepositoryAsync(model, new CancellationToken());
            }
        }
    }
}
