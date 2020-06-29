using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace Microsoft.VisualStudio.Shell.Hierarchy
{
    public interface ISolution : IVsSolution, IVsSolution2, IVsSolution3, IVsSolution4, IVsSolution5, IVsSolution6, IVsSolution7, IVsSolution8
    {
    }
    public partial class SolutionWrapper : IVsSolution, IVsSolution2, IVsSolution3, IVsSolution4, IVsSolution5, IVsSolution6, IVsSolution7, IVsSolution8
    {
        private readonly IVsSolution _solution;
        private readonly IVsSolution2 _solution2;
        private readonly IVsSolution3 _solution3;
        private readonly IVsSolution4 _solution4;
        private readonly IVsSolution5 _solution5;
        private readonly IVsSolution6 _solution6;
        private readonly IVsSolution7 _solution7;
        private readonly IVsSolution8 _solution8;

        public SolutionWrapper() :
                this(GlobalServices.Solution,
                    GlobalServices.Solution2,
                    GlobalServices.Solution3,
                    GlobalServices.Solution4,
                    GlobalServices.Solution5,
                    GlobalServices.Solution6,
                    GlobalServices.Solution7,
                    GlobalServices.Solution8)
        {
        }

        public SolutionWrapper(
            IVsSolution solution,
            IVsSolution2 solution2 = null,
            IVsSolution3 solution3 = null,
            IVsSolution4 solution4 = null,
            IVsSolution5 solution5 = null,
            IVsSolution6 solution6 = null,
            IVsSolution7 solution7 = null,
            IVsSolution8 solution8 = null
)
        {
            _solution = solution;
            _solution2 = solution2;
            _solution3 = solution3;
            _solution4 = solution4;
            _solution5 = solution5;
            _solution6 = solution6;
            _solution7 = solution7;
            _solution8 = solution8;
        }

        public virtual bool AddNewProjectAsSibling
        {
            get
            {
                GetProperty(SolutionPropertyID.AddNewProjectAsSibling, out object value);
                return (bool)value;
            }
        }

        public virtual bool DeferredSaveSolution
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.DeferredSaveSolution, out object value);
                return (bool)value;
            }
        }

        public virtual int FaultedProjectCount
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.FaultedProjectCount, out object value);
                return (int)value;
            }
        }

        public virtual int FileDefaultCodePage
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.FileDefaultCodePage, out object value);
                return (int)value;
            }
        }

        public virtual bool IsInBackgroundIdleLoadProjectBatch
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsInBackgroundIdleLoadProjectBatch, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsInSyncDemandLoadProjectBatch
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsInSyncDemandLoadProjectBatch, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsOpeningProjectUserInitiated
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsOpeningProjectUserInitiated, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsOpenNotificationPending
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsOpenNotificationPending, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSavingOnClose
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSavingOnClose, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionClosing
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionClosing, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionDirty
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionDirty, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionFullyLoaded
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionFullyLoaded, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionInEndRetargetingBatch
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionInEndRetargetingBatch, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionNodeHidden
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionNodeHidden, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionOpen
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionOpen, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionOpening
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionOpening, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionOpeningDocs
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionOpeningDocs, out object value);
                return (bool)value;
            }
        }

        public virtual bool IsSolutionSaveAsRequired
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.IsSolutionSaveAsRequired, out object value);
                return (bool)value;
            }
        }

        public virtual string LAST
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.LAST, out object value);
                return (string)value;
            }
        }

        public virtual string NewProjectDlgPreferredLanguage
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.NewProjectDlgPreferredLanguage, out object value);
                return (string)value;
            }
        }

        public virtual int NoFrameworkDialogState
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.NoFrameworkDialogState, out object value);
                return (int)value;
            }
        }

        public virtual int ProjectCount
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.ProjectCount, out object value);
                return (int)value;
            }
        }

        public virtual int ProjectLoadSecurityDialogState
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.ProjectLoadSecurityDialogState, out object value);
                return (int)value;
            }
        }

        public virtual string RegisteredProjExtns
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.RegisteredProjExtns, out object value);
                return (string)value;
            }
        }

        public virtual bool SimplifiedConfigurations
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SimplifiedConfigurations, out object value);
                return (bool)value;
            }
        }

        public virtual string SolutionBaseName
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionBaseName, out object value);
                return (string)value;
            }
        }

        public virtual string SolutionDirectory
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionDirectory, out object value);
                return (string)value;
            }
        }

        public virtual string SolutionExplorerCaption
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionExplorerCaption, out object value);
                return (string)value;
            }
        }

        public virtual string SolutionFileExt
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionFileExt, out object value);
                return (string)value;
            }
        }

        public virtual string SolutionFileName
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionFileName, out object value);
                return (string)value;
            }
        }

        public virtual string SolutionNodeCaption
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionNodeCaption, out object value);
                return (string)value;
            }
        }

        public virtual string SolutionPropertyPages
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionPropertyPages, out object value);
                return (string)value;
            }
        }

        public virtual bool SolutionUserFileCreatedOnThisComputer
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionUserFileCreatedOnThisComputer, out object value);
                return (bool)value;
            }
        }

        public virtual object SolutionViewModel
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.SolutionViewModel, out object value);
                return value;
            }
        }

        public virtual string UserOptionsFileName
        {
            get
            {
                _solution.GetProperty(SolutionPropertyID.UserOptionsFileName, out object value);
                return (string)value;
            }
        }

        public virtual string UserOptsFileExt
        {
            get
            {
                return GetProperty<string>(SolutionPropertyID.UserOptsFileExt);
            }
            set
            {
                if (!ErrorHandler.Succeeded(SetProperty(SolutionPropertyID.UserOptsFileExt, value)))
                {
                }
            }
        }

        public T GetProperty<T>(int property)
        {
            GetProperty(property, out object value);
            return (T)value;
        }

        public int GetProjectEnum(uint grfEnumFlags, ref Guid rguidEnumOnlyThisType, out IEnumHierarchies ppenum)
        {
            return _solution.GetProjectEnum(grfEnumFlags, ref rguidEnumOnlyThisType, out ppenum);
        }

        public int CreateProject(ref Guid rguidProjectType, string lpszMoniker, string lpszLocation, string lpszName, uint grfCreateFlags, ref Guid iidProject, out IntPtr ppProject)
        {
            return _solution.CreateProject(ref rguidProjectType, lpszMoniker, lpszLocation, lpszName, grfCreateFlags, ref iidProject, out ppProject);
        }

        public int GenerateUniqueProjectName(string lpszRoot, out string pbstrProjectName)
        {
            return _solution.GenerateUniqueProjectName(lpszRoot, out pbstrProjectName);
        }

        public int GetProjectOfGuid(ref Guid rguidProjectID, out IVsHierarchy ppHierarchy)
        {
            return _solution.GetProjectOfGuid(ref rguidProjectID, out ppHierarchy);
        }

        public int GetGuidOfProject(IVsHierarchy pHierarchy, out Guid pguidProjectID)
        {
            return _solution.GetGuidOfProject(pHierarchy, out pguidProjectID);
        }

        public int GetSolutionInfo(out string pbstrSolutionDirectory, out string pbstrSolutionFile, out string pbstrUserOptsFile)
        {
            return _solution.GetSolutionInfo(out pbstrSolutionDirectory, out pbstrSolutionFile, out pbstrUserOptsFile);
        }

        public int AdviseSolutionEvents(IVsSolutionEvents pSink, out uint pdwCookie)
        {
            return _solution.AdviseSolutionEvents(pSink, out pdwCookie);
        }

        public int UnadviseSolutionEvents(uint dwCookie)
        {
            return _solution.UnadviseSolutionEvents(dwCookie);
        }

        public int SaveSolutionElement(uint grfSaveOpts, IVsHierarchy pHier, uint docCookie)
        {
            return _solution.SaveSolutionElement(grfSaveOpts, pHier, docCookie);
        }

        public int CloseSolutionElement(uint grfCloseOpts, IVsHierarchy pHier, uint docCookie)
        {
            return _solution.CloseSolutionElement(grfCloseOpts, pHier, docCookie);
        }

        public int GetProjectOfProjref(string pszProjref, out IVsHierarchy ppHierarchy, out string pbstrUpdatedProjref, VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            return _solution.GetProjectOfProjref(pszProjref, out ppHierarchy, out pbstrUpdatedProjref, puprUpdateReason);
        }

        public int GetProjrefOfProject(IVsHierarchy pHierarchy, out string pbstrProjref)
        {
            return _solution.GetProjrefOfProject(pHierarchy, out pbstrProjref);
        }

        public int GetProjectInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            return _solution.GetProjectInfoOfProjref(pszProjref, propid, out pvar);
        }

        public int AddVirtualProject(IVsHierarchy pHierarchy, uint grfAddVPFlags)
        {
            return _solution.AddVirtualProject(pHierarchy, grfAddVPFlags);
        }

        public int GetItemOfProjref(string pszProjref, out IVsHierarchy ppHierarchy, out uint pitemid, out string pbstrUpdatedProjref, VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            return _solution.GetItemOfProjref(pszProjref, out ppHierarchy, out pitemid, out pbstrUpdatedProjref, puprUpdateReason);
        }

        public int GetProjrefOfItem(IVsHierarchy pHierarchy, uint itemid, out string pbstrProjref)
        {
            return _solution.GetProjrefOfItem(pHierarchy, itemid, out pbstrProjref);
        }

        public int GetItemInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            return _solution.GetItemInfoOfProjref(pszProjref, propid, out pvar);
        }

        public int GetProjectOfUniqueName(string pszUniqueName, out IVsHierarchy ppHierarchy)
        {
            return _solution.GetProjectOfUniqueName(pszUniqueName, out ppHierarchy);
        }

        public int GetUniqueNameOfProject(IVsHierarchy pHierarchy, out string pbstrUniqueName)
        {
            return _solution.GetUniqueNameOfProject(pHierarchy, out pbstrUniqueName);
        }

        public int GetProperty(int propid, out object pvar)
        {
            return _solution.GetProperty(propid, out pvar);
        }

        public int SetProperty(int propid, object var)
        {
            return _solution.SetProperty(propid, var);
        }

        public int OpenSolutionFile(uint grfOpenOpts, string pszFilename)
        {
            return _solution.OpenSolutionFile(grfOpenOpts, pszFilename);
        }

        public int QueryEditSolutionFile(out uint pdwEditResult)
        {
            return _solution.QueryEditSolutionFile(out pdwEditResult);
        }

        public int CreateSolution(string lpszLocation, string lpszName, uint grfCreateFlags)
        {
            return _solution.CreateSolution(lpszLocation, lpszName, grfCreateFlags);
        }

        public int GetProjectFactory(uint dwReserved, Guid pguidProjectType, string pszMkProject, out IVsProjectFactory ppProjectFactory)
        {
            return _solution2.GetProjectFactory(dwReserved, pguidProjectType, pszMkProject, out ppProjectFactory);
        }

        public int GetProjectTypeGuid(uint dwReserved, string pszMkProject, out Guid pguidProjectType)
        {
            return _solution.GetProjectTypeGuid(dwReserved, pszMkProject, out pguidProjectType);
        }

        public int OpenSolutionViaDlg(string pszStartDirectory, int fDefaultToAllProjectsFilter)
        {
            return _solution.OpenSolutionViaDlg(pszStartDirectory, fDefaultToAllProjectsFilter);
        }

        public int AddVirtualProjectEx(IVsHierarchy pHierarchy, uint grfAddVPFlags, ref Guid rguidProjectID)
        {
            return _solution.AddVirtualProjectEx(pHierarchy, grfAddVPFlags, ref rguidProjectID);
        }

        public int QueryRenameProject(IVsProject pProject, string pszMkOldName, string pszMkNewName, uint dwReserved, out int pfRenameCanContinue)
        {
            return _solution.QueryRenameProject(pProject, pszMkOldName, pszMkNewName, dwReserved, out pfRenameCanContinue);
        }

        public int OnAfterRenameProject(IVsProject pProject, string pszMkOldName, string pszMkNewName, uint dwReserved)
        {
            return _solution.OnAfterRenameProject(pProject, pszMkOldName, pszMkNewName, dwReserved);
        }

        public int RemoveVirtualProject(IVsHierarchy pHierarchy, uint grfRemoveVPFlags)
        {
            return _solution.RemoveVirtualProject(pHierarchy, grfRemoveVPFlags);
        }

        public int CreateNewProjectViaDlg(string pszExpand, string pszSelect, uint dwReserved)
        {
            return _solution.CreateNewProjectViaDlg(pszExpand, pszSelect, dwReserved);
        }

        public int GetVirtualProjectFlags(IVsHierarchy pHierarchy, out uint pgrfAddVPFlags)
        {
            return _solution.GetVirtualProjectFlags(pHierarchy, out pgrfAddVPFlags);
        }

        public int GenerateNextDefaultProjectName(string pszBaseName, string pszLocation, out string pbstrProjectName)
        {
            return _solution.GenerateNextDefaultProjectName(pszBaseName, pszLocation, out pbstrProjectName);
        }

        public int GetProjectFilesInSolution(uint grfGetOpts, uint cProjects, string[] rgbstrProjectNames, out uint pcProjectsFetched)
        {
            return _solution.GetProjectFilesInSolution(grfGetOpts, cProjects, rgbstrProjectNames, out pcProjectsFetched);
        }

        public int CanCreateNewProjectAtLocation(int fCreateNewSolution, string pszFullProjectFilePath, out int pfCanCreate)
        {
            return _solution.CanCreateNewProjectAtLocation(fCreateNewSolution, pszFullProjectFilePath, out pfCanCreate);
        }

        public int UpdateProjectFileLocation(IVsHierarchy pHierarchy)
        {
            return _solution2.UpdateProjectFileLocation(pHierarchy);
        }

        public int GetProjectFactory(uint dwReserved, Guid[] pguidProjectType, string pszMkProject, out IVsProjectFactory ppProjectFactory)
        {
            return _solution.GetProjectFactory(dwReserved, pguidProjectType, pszMkProject, out ppProjectFactory);
        }

        public int GetProjectFactory(uint dwReserved, ref Guid pguidProjectType, string pszMkProject, out IVsProjectFactory ppProjectFactory)
        {
            return _solution2.GetProjectFactory(dwReserved, ref pguidProjectType, pszMkProject, out ppProjectFactory);
        }

        public int CreateNewProjectViaDlgEx(string pszDlgTitle, string pszTemplateDir, string pszExpand, string pszSelect, string pszHelpTopic, uint cnpvdeFlags, IVsBrowseProjectLocation pBrowse)
        {
            return _solution3.CreateNewProjectViaDlgEx(pszDlgTitle, pszTemplateDir, pszExpand, pszSelect, pszHelpTopic, cnpvdeFlags, pBrowse);
        }

        public int GetUniqueUINameOfProject(IVsHierarchy pHierarchy, out string pbstrUniqueName)
        {
            return _solution3.GetUniqueUINameOfProject(pHierarchy, out pbstrUniqueName);
        }

        public int CheckForAndSaveDeferredSaveSolution(int fCloseSolution, string pszMessage, string pszTitle, uint grfFlags)
        {
            return _solution3.CheckForAndSaveDeferredSaveSolution(fCloseSolution, pszMessage, pszTitle, grfFlags);
        }

        public int UpdateProjectFileLocationForUpgrade(string pszCurrentLocation, string pszUpgradedLocation)
        {
            return _solution3.UpdateProjectFileLocationForUpgrade(pszCurrentLocation, pszUpgradedLocation);
        }

        public int WriteUserOptsFile()
        {
            return _solution4.WriteUserOptsFile();
        }

        public int IsBackgroundSolutionLoadEnabled(out bool pfIsEnabled)
        {
            return _solution4.IsBackgroundSolutionLoadEnabled(out pfIsEnabled);
        }

        public int EnsureProjectsAreLoaded(uint cProjects, Guid[] guidProjects, uint grfFlags)
        {
            return _solution4.EnsureProjectsAreLoaded(cProjects, guidProjects, grfFlags);
        }

        public int EnsureProjectIsLoaded(ref Guid guidProject, uint grfFlags)
        {
            return _solution4.EnsureProjectIsLoaded(ref guidProject, grfFlags);
        }

        public int EnsureSolutionIsLoaded(uint grfFlags)
        {
            return _solution4.EnsureSolutionIsLoaded(grfFlags);
        }

        public int ReloadProject(ref Guid guidProjectID)
        {
            return _solution4.ReloadProject(ref guidProjectID);
        }

        public int UnloadProject(ref Guid guidProjectID, uint dwUnloadStatus)
        {
            return _solution4.UnloadProject(ref guidProjectID, dwUnloadStatus);
        }

        public void ResolveFaultedProjects(uint cHierarchies, IVsHierarchy[] rgHierarchies, IVsPropertyBag pProjectFaultResolutionContext, out uint pcResolved, out uint pcFailed)
        {
            _solution5.ResolveFaultedProjects(cHierarchies, rgHierarchies, pProjectFaultResolutionContext, out pcResolved, out pcFailed);
        }

        public Guid GetGuidOfProjectFile(string pszProjectFile)
        {
            return _solution5.GetGuidOfProjectFile(pszProjectFile);
        }

        public int SetProjectParent(IVsHierarchy pProject, IVsHierarchy pParent)
        {
            return _solution6.SetProjectParent(pProject, pParent);
        }

        public int AddNewProjectFromTemplate(string szTemplatePath, Array rgCustomParams, string szTargetFramework, string szDestinationFolder, string szProjectName, IVsHierarchy pParent, out IVsHierarchy ppNewProj)
        {
            return _solution6.AddNewProjectFromTemplate(szTemplatePath, rgCustomParams, szTargetFramework, szDestinationFolder, szProjectName, pParent, out ppNewProj);
        }

        public int AddExistingProject(string szFullPath, IVsHierarchy pParent, out IVsHierarchy ppNewProj)
        {
            return _solution6.AddExistingProject(szFullPath, pParent, out ppNewProj);
        }

        public int BrowseForExistingProject(string szDialogTitle, string szStartupLocation, Guid preferedProjectType, out string pbstrSelected)
        {
            return _solution6.BrowseForExistingProject(szDialogTitle, szStartupLocation, preferedProjectType, out pbstrSelected);
        }

        public void OpenFolder(string folderPath)
        {
            _solution7.OpenFolder(folderPath);
        }

        public void CloseFolder(string folderPath)
        {
            _solution7.CloseFolder(folderPath);
        }

        public bool IsSolutionLoadDeferred()
        {
            return _solution7.IsSolutionLoadDeferred();
        }

        public bool IsDeferredProjectLoadAllowed(string projectFullPath)
        {
            return _solution7.IsDeferredProjectLoadAllowed(projectFullPath);
        }

        public int AdviseSolutionEventsEx(ref Guid guidCallerId, object pSink, out uint pdwCookie)
        {
            return _solution8.AdviseSolutionEventsEx(ref guidCallerId, pSink, out pdwCookie);
        }

        public int BatchProjectAction(uint action, uint dwFlags, uint dwNumProjects, Guid[] rgProjects, out IVsBatchProjectActionContext pContext)
        {
            return _solution8.BatchProjectAction(action, dwFlags, dwNumProjects, rgProjects, out pContext);
        }

        public int IsBatchProjectActionBlocking(uint action, uint dwFlags, uint dwNumProjects, Guid[] rgProjects, out int pfIsBlocking)
        {
            return _solution8.IsBatchProjectActionBlocking(action, dwFlags, dwNumProjects, rgProjects, out pfIsBlocking);
        }

        public int GetCurrentBatchProjectAction(out IVsBatchProjectActionContext pContext)
        {
            return _solution8.GetCurrentBatchProjectAction(out pContext);
        }
    }
}
