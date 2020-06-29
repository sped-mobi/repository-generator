
using Microsoft.VisualStudio.RepositoryGenerator.Abstractions;

namespace Microsoft.VisualStudio.RepositoryGenerator.UI
{
    public class RepositoryGeneratorParameters : ObservableObject, IRepositoryGeneratorParameters
    {
        private string _repositoryName;
        private string _solutionName;
        private string _projectName;
        private string _rootNamespace;
        private SdkXmlElementLocation _sdkXmlLocation;
        private RepositoryStyle _repositoryStyle;
        private TargetFramework _targetFramework;
        private string _description;
        private string _output;

        public string RepositoryName
        {
            get
            {
                return _repositoryName;
            }
            set
            {
                SetProperty(ref _repositoryName, value);
            }
        }

        public string SolutionName
        {
            get
            {
                return _solutionName;
            }
            set
            {
                SetProperty(ref _solutionName, value);
            }
        }

        public string ProjectName
        {
            get
            {
                return _projectName;
            }
            set
            {
                SetProperty(ref _projectName, value);
            }
        }

        public string RootNamespace
        {
            get
            {
                return _rootNamespace;
            }
            set
            {
                SetProperty(ref _rootNamespace, value);
            }
        }

        public SdkXmlElementLocation SdkXmlLocation
        {
            get
            {
                return _sdkXmlLocation;
            }
            set
            {
                SetProperty(ref _sdkXmlLocation, value);
            }
        }

        public RepositoryStyle RepositoryStyle
        {
            get
            {
                return _repositoryStyle;
            }
            set
            {
                SetProperty(ref _repositoryStyle, value);
            }
        }

        public TargetFramework TargetFramework
        {
            get
            {
                return _targetFramework;
            }
            set
            {
                SetProperty(ref _targetFramework, value);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        public string Output
        {
            get
            {
                return _output;
            }
            set
            {
                SetProperty(ref _output, value);
            }
        }
    }

    //public class RepositoryViewModel : ViewModelBase
    //{
    //    public RepositoryViewModel()
    //    {
    //        _model = new Repository();
    //    }

    //    public RepositoryViewModel(Repository model)
    //    {
    //        _model = model ?? throw new ArgumentNullException(nameof(model));
    //    }

    //    private readonly Repository _model;


    //    public string RepositoryName
    //    {
    //        get
    //        {
    //            return _model.RepositoryName;
    //        }
    //        set
    //        {
    //            if (_model.RepositoryName != value)
    //            {
    //                _model.RepositoryName = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string SolutionName
    //    {
    //        get
    //        {
    //            return _model.SolutionName;
    //        }
    //        set
    //        {
    //            if (_model.SolutionName != value)
    //            {
    //                _model.SolutionName = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string ProjectName
    //    {
    //        get
    //        {
    //            return _model.ProjectName;
    //        }
    //        set
    //        {
    //            if (_model.ProjectName != value)
    //            {
    //                _model.ProjectName = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string RootNamespace
    //    {
    //        get
    //        {
    //            return _model.RootNamespace;
    //        }
    //        set
    //        {
    //            if (_model.RootNamespace != value)
    //            {
    //                _model.RootNamespace = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string SdkXmlLocation
    //    {
    //        get
    //        {
    //            return _model.SdkXmlLocation;
    //        }
    //        set
    //        {
    //            if (_model.SdkXmlLocation != value)
    //            {
    //                _model.SdkXmlLocation = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string RepositoryStyle
    //    {
    //        get
    //        {
    //            return _model.RepositoryStyle;
    //        }
    //        set
    //        {
    //            if (_model.RepositoryStyle != value)
    //            {
    //                _model.RepositoryStyle = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string TargetFramework
    //    {
    //        get
    //        {
    //            return _model.TargetFramework;
    //        }
    //        set
    //        {
    //            if (_model.TargetFramework != value)
    //            {
    //                _model.TargetFramework = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string Description
    //    {
    //        get
    //        {
    //            return _model.Description;
    //        }
    //        set
    //        {
    //            if (_model.Description != value)
    //            {
    //                _model.Description = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }

    //    public string Output
    //    {
    //        get
    //        {
    //            return _model.Output;
    //        }
    //        set
    //        {
    //            if (_model.Output != value)
    //            {
    //                _model.Output = value;
    //                OnPropertyChaged();
    //            }
    //        }
    //    }


    //}
}