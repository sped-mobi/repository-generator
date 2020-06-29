
using Microsoft.VisualStudio.RepositoryGenerator.Abstractions;

namespace Microsoft.VisualStudio.RepositoryGenerator.UI
{
    //public class RepositoryInfrastructure
    //{
    //    public RepositoryInfrastructure(Repository model, RepositoryViewModel viewModel, NewRepositoryDialog view)
    //    {
    //        Model = model ?? throw new ArgumentNullException(nameof(model));
    //        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    //        View = view ?? throw new ArgumentNullException(nameof(view));
    //    }

    //    public Repository Model { get; }

    //    public RepositoryViewModel ViewModel { get; }

    //    public NewRepositoryDialog View { get; }
    //}


    public sealed class RepositoryGeneratorParametersInfrastructure : InfrastructureBase<RepositoryGeneratorParameters, NewRepositoryDialog>
    {
        public RepositoryGeneratorParametersInfrastructure(RepositoryGeneratorParameters viewModel, NewRepositoryDialog view)
        {
            ViewModel = viewModel;
            View = view;
        }

        public override RepositoryGeneratorParameters ViewModel { get; }
        public override NewRepositoryDialog View { get; }
    }
}