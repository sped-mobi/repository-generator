namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell.Interop;
    using System.ComponentModel.Composition;

    /// <summary>
    /// Defines the <see cref="VsDTE2" />.
    /// </summary>
    [Export(typeof(DTE2))]
    public class VsDTE2 : DTE2
    {
        /// <summary>
        /// Defines the _dte.
        /// </summary>
        private readonly DTE2 _dte;

        /// <summary>
        /// Initializes a new instance of the <see cref="VsDTE2"/> class.
        /// </summary>
        /// <param name="dte">The dte<see cref="DTE2"/>.</param>
        public VsDTE2(DTE2 dte)
        {
            _dte = dte;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="VsDTE2"/> class from being created.
        /// </summary>
        [ImportingConstructor]
        private VsDTE2()
            : this(GetService<SDTE, DTE2>())
        {
        }

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

        /// <summary>
        /// The Quit.
        /// </summary>
        public void Quit()
        {
            _dte.Quit();
        }

        /// <summary>
        /// The GetObject.
        /// </summary>
        /// <param name="Name">The Name<see cref="string"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetObject(string Name)
        {
            return _dte.GetObject(Name);
        }

        /// <summary>
        /// The OpenFile.
        /// </summary>
        /// <param name="ViewKind">The ViewKind<see cref="string"/>.</param>
        /// <param name="FileName">The FileName<see cref="string"/>.</param>
        /// <returns>The <see cref="Window"/>.</returns>
        public Window OpenFile(string ViewKind, string FileName)
        {
            return _dte.OpenFile(ViewKind, FileName);
        }

        /// <summary>
        /// The ExecuteCommand.
        /// </summary>
        /// <param name="CommandName">The CommandName<see cref="string"/>.</param>
        /// <param name="CommandArgs">The CommandArgs<see cref="string"/>.</param>
        public void ExecuteCommand(string CommandName, string CommandArgs = "")
        {
            _dte.ExecuteCommand(CommandName, CommandArgs);
        }

        /// <summary>
        /// The LaunchWizard.
        /// </summary>
        /// <param name="VSZFile">The VSZFile<see cref="string"/>.</param>
        /// <param name="ContextParams">The ContextParams<see cref="object[]"/>.</param>
        /// <returns>The <see cref="wizardResult"/>.</returns>
        public wizardResult LaunchWizard(string VSZFile, ref object[] ContextParams)
        {
            return _dte.LaunchWizard(VSZFile, ref ContextParams);
        }

        /// <summary>
        /// The SatelliteDllPath.
        /// </summary>
        /// <param name="Path">The Path<see cref="string"/>.</param>
        /// <param name="Name">The Name<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string SatelliteDllPath(string Path, string Name)
        {
            return _dte.SatelliteDllPath(Path, Name);
        }

        /// <summary>
        /// The GetThemeColor.
        /// </summary>
        /// <param name="Element">The Element<see cref="vsThemeColors"/>.</param>
        /// <returns>The <see cref="uint"/>.</returns>
        public uint GetThemeColor(vsThemeColors Element)
        {
            return _dte.GetThemeColor(Element);
        }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public string Name
        {
            get
            {
                return _dte.Name;
            }
        }

        /// <summary>
        /// Gets the FileName.
        /// </summary>
        public string FileName
        {
            get
            {
                return _dte.FileName;
            }
        }

        /// <summary>
        /// Gets the Version.
        /// </summary>
        public string Version
        {
            get
            {
                return _dte.Version;
            }
        }

        /// <summary>
        /// Gets the CommandBars.
        /// </summary>
        public object CommandBars
        {
            get
            {
                return _dte.CommandBars;
            }
        }

        /// <summary>
        /// Gets the Windows.
        /// </summary>
        public Windows Windows
        {
            get
            {
                return _dte.Windows;
            }
        }

        /// <summary>
        /// Gets the Events.
        /// </summary>
        public Events Events
        {
            get
            {
                return _dte.Events;
            }
        }

        /// <summary>
        /// Gets the AddIns.
        /// </summary>
        public AddIns AddIns
        {
            get
            {
                return _dte.AddIns;
            }
        }

        /// <summary>
        /// Gets the MainWindow.
        /// </summary>
        public Window MainWindow
        {
            get
            {
                return _dte.MainWindow;
            }
        }

        /// <summary>
        /// Gets the ActiveWindow.
        /// </summary>
        public Window ActiveWindow
        {
            get
            {
                return _dte.ActiveWindow;
            }
        }

        /// <summary>
        /// Gets or sets the DisplayMode.
        /// </summary>
        public vsDisplay DisplayMode
        {
            get
            {
                return _dte.DisplayMode;
            }

            set
            {
                _dte.DisplayMode = value;
            }
        }

        /// <summary>
        /// Gets the Solution.
        /// </summary>
        public Solution Solution
        {
            get
            {
                return _dte.Solution;
            }
        }

        /// <summary>
        /// Gets the Commands.
        /// </summary>
        public Commands Commands
        {
            get
            {
                return _dte.Commands;
            }
        }

        /// <summary>
        /// The get_Properties.
        /// </summary>
        /// <param name="Category">The Category<see cref="string"/>.</param>
        /// <param name="Page">The Page<see cref="string"/>.</param>
        /// <returns>The <see cref="Properties"/>.</returns>
        public Properties get_Properties(string Category, string Page)
        {
            return _dte.get_Properties(Category, Page);
        }

        /// <summary>
        /// Gets the SelectedItems.
        /// </summary>
        public SelectedItems SelectedItems
        {
            get
            {
                return _dte.SelectedItems;
            }
        }

        /// <summary>
        /// Gets the CommandLineArguments.
        /// </summary>
        public string CommandLineArguments
        {
            get
            {
                return _dte.CommandLineArguments;
            }
        }

        /// <summary>
        /// The get_IsOpenFile.
        /// </summary>
        /// <param name="ViewKind">The ViewKind<see cref="string"/>.</param>
        /// <param name="FileName">The FileName<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool get_IsOpenFile(string ViewKind, string FileName)
        {
            return _dte.get_IsOpenFile(ViewKind, FileName);
        }

        /// <summary>
        /// Gets the DTE.
        /// </summary>
        public DTE DTE
        {
            get
            {
                return _dte.DTE;
            }
        }

        /// <summary>
        /// Gets the LocaleID.
        /// </summary>
        public int LocaleID
        {
            get
            {
                return _dte.LocaleID;
            }
        }

        /// <summary>
        /// Gets the WindowConfigurations.
        /// </summary>
        public WindowConfigurations WindowConfigurations
        {
            get
            {
                return _dte.WindowConfigurations;
            }
        }

        /// <summary>
        /// Gets the Documents.
        /// </summary>
        public Documents Documents
        {
            get
            {
                return _dte.Documents;
            }
        }

        /// <summary>
        /// Gets the ActiveDocument.
        /// </summary>
        public Document ActiveDocument
        {
            get
            {
                return _dte.ActiveDocument;
            }
        }

        /// <summary>
        /// Gets the Globals.
        /// </summary>
        public Globals Globals
        {
            get
            {
                return _dte.Globals;
            }
        }

        /// <summary>
        /// Gets the StatusBar.
        /// </summary>
        public StatusBar StatusBar
        {
            get
            {
                return _dte.StatusBar;
            }
        }

        /// <summary>
        /// Gets the FullName.
        /// </summary>
        public string FullName
        {
            get
            {
                return _dte.FullName;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether UserControl.
        /// </summary>
        public bool UserControl
        {
            get
            {
                return _dte.UserControl;
            }

            set
            {
                _dte.UserControl = value;
            }
        }

        /// <summary>
        /// Gets the ObjectExtenders.
        /// </summary>
        public ObjectExtenders ObjectExtenders
        {
            get
            {
                return _dte.ObjectExtenders;
            }
        }

        /// <summary>
        /// Gets the Find.
        /// </summary>
        public Find Find
        {
            get
            {
                return _dte.Find;
            }
        }

        /// <summary>
        /// Gets the Mode.
        /// </summary>
        public vsIDEMode Mode
        {
            get
            {
                return _dte.Mode;
            }
        }

        /// <summary>
        /// Gets the ItemOperations.
        /// </summary>
        public ItemOperations ItemOperations
        {
            get
            {
                return _dte.ItemOperations;
            }
        }

        /// <summary>
        /// Gets the UndoContext.
        /// </summary>
        public UndoContext UndoContext
        {
            get
            {
                return _dte.UndoContext;
            }
        }

        /// <summary>
        /// Gets the Macros.
        /// </summary>
        public Macros Macros
        {
            get
            {
                return _dte.Macros;
            }
        }

        /// <summary>
        /// Gets the ActiveSolutionProjects.
        /// </summary>
        public object ActiveSolutionProjects
        {
            get
            {
                return _dte.ActiveSolutionProjects;
            }
        }

        /// <summary>
        /// Gets the MacrosIDE.
        /// </summary>
        public DTE MacrosIDE
        {
            get
            {
                return _dte.MacrosIDE;
            }
        }

        /// <summary>
        /// Gets the RegistryRoot.
        /// </summary>
        public string RegistryRoot
        {
            get
            {
                return _dte.RegistryRoot;
            }
        }

        /// <summary>
        /// Gets the Application.
        /// </summary>
        public DTE Application
        {
            get
            {
                return _dte.Application;
            }
        }

        /// <summary>
        /// Gets the ContextAttributes.
        /// </summary>
        public ContextAttributes ContextAttributes
        {
            get
            {
                return _dte.ContextAttributes;
            }
        }

        /// <summary>
        /// Gets the SourceControl.
        /// </summary>
        public SourceControl SourceControl
        {
            get
            {
                return _dte.SourceControl;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether SuppressUI.
        /// </summary>
        public bool SuppressUI
        {
            get
            {
                return _dte.SuppressUI;
            }

            set
            {
                _dte.SuppressUI = value;
            }
        }

        /// <summary>
        /// Gets the Debugger.
        /// </summary>
        public EnvDTE.Debugger Debugger
        {
            get
            {
                return _dte.Debugger;
            }
        }

        /// <summary>
        /// Gets the Edition.
        /// </summary>
        public string Edition
        {
            get
            {
                return _dte.Edition;
            }
        }

        /// <summary>
        /// Gets the ToolWindows.
        /// </summary>
        public ToolWindows ToolWindows
        {
            get
            {
                return _dte.ToolWindows;
            }
        }
    }
}
