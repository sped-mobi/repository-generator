namespace Microsoft.VisualStudio.RepositoryGenerator.UI
{
    //public static class RepositoryFactory
    //{
    //    public static RepositoryInfrastructure Create()
    //    {
    //        Repository model = new Repository();
    //        RepositoryViewModel viewModel = new RepositoryViewModel(model);
    //        NewRepositoryDialog view = new NewRepositoryDialog(viewModel);
    //        return new RepositoryInfrastructure(model, viewModel, view);
    //    }
    //}


    public static class RepositoryGeneratorParametersFactory
    {
        public static RepositoryGeneratorParametersInfrastructure Create()
        {
            var viewModel = new RepositoryGeneratorParameters();
            var view = new NewRepositoryDialog(viewModel);
            return new RepositoryGeneratorParametersInfrastructure(viewModel, view);
        }
    }
}