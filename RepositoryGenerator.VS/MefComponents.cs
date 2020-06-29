// // -----------------------------------------------------------------------
// // <copyright file="MefComponents.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------


using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.RepositoryGenerator.Abstractions;

namespace Microsoft.VisualStudio.RepositoryGenerator
{
    public static class MefComponents
    {
        public static TServiceInterface GetService<TService, TServiceInterface>()
        {
            return (TServiceInterface)Shell.Package.GetGlobalService(typeof(TService));
        }

        public static TServiceInterface GetComponentModelService<TServiceInterface>() where TServiceInterface : class
        {
            return ComponentModel.GetService<TServiceInterface>();
        }

        public static IComponentModel ComponentModel
            => GetService<SComponentModel, IComponentModel>();


        public static IRepositoryGenerator GetRepositoryGenerator()
            => GetComponentModelService<IRepositoryGenerator>();


    }
}