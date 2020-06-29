
using System;
using System.ComponentModel.Composition;

namespace Microsoft.VisualStudio.Shell.Interop
{
    [Export(typeof(IVsSolution2))]
    internal class VsSolution2 : IVsSolution2
    {
        private readonly IVsSolution2 _solution;

        public VsSolution2(IVsSolution2 solution)
        {
            _solution = solution;
        }

        [ImportingConstructor]
        private VsSolution2()
            : this(solution: GlobalServices.Solution2)
        {
        }

        public int AddVirtualProject(IVsHierarchy pHierarchy, uint grfAddVPFlags)
        {
            return _solution.AddVirtualProject(pHierarchy, grfAddVPFlags);
        }

        public int AddVirtualProjectEx(IVsHierarchy pHierarchy, uint grfAddVPFlags, ref Guid rguidProjectID)
        {
            return _solution.AddVirtualProjectEx(pHierarchy, grfAddVPFlags, ref rguidProjectID);
        }

        public int AdviseSolutionEvents(IVsSolutionEvents pSink, out uint pdwCookie)
        {
            return _solution.AdviseSolutionEvents(pSink, out pdwCookie);
        }

        public int CanCreateNewProjectAtLocation(int fCreateNewSolution,
            string pszFullProjectFilePath,
            out int pfCanCreate)
        {
            return _solution.CanCreateNewProjectAtLocation(fCreateNewSolution, pszFullProjectFilePath, out pfCanCreate);
        }

        public int CloseSolutionElement(uint grfCloseOpts, IVsHierarchy pHier, uint docCookie)
        {
            return _solution.CloseSolutionElement(grfCloseOpts, pHier, docCookie);
        }

        public int CreateNewProjectViaDlg(string pszExpand, string pszSelect, uint dwReserved)
        {
            return _solution.CreateNewProjectViaDlg(pszExpand, pszSelect, dwReserved);
        }

        public int CreateProject(ref Guid rguidProjectType,
            string lpszMoniker,
            string lpszLocation,
            string lpszName,
            uint grfCreateFlags,
            ref Guid iidProject,
            out IntPtr ppProject)
        {
            return _solution.CreateProject(ref rguidProjectType,
                lpszMoniker,
                lpszLocation,
                lpszName,
                grfCreateFlags,
                ref iidProject,
                out ppProject);
        }

        public int CreateSolution(string lpszLocation, string lpszName, uint grfCreateFlags)
        {
            return _solution.CreateSolution(lpszLocation, lpszName, grfCreateFlags);
        }

        public int GenerateNextDefaultProjectName(string pszBaseName, string pszLocation, out string pbstrProjectName)
        {
            return _solution.GenerateNextDefaultProjectName(pszBaseName, pszLocation, out pbstrProjectName);
        }

        public int GenerateUniqueProjectName(string lpszRoot, out string pbstrProjectName)
        {
            return _solution.GenerateUniqueProjectName(lpszRoot, out pbstrProjectName);
        }

        public int GetGuidOfProject(IVsHierarchy pHierarchy, out Guid pguidProjectID)
        {
            return _solution.GetGuidOfProject(pHierarchy, out pguidProjectID);
        }

        public int GetItemInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            return _solution.GetItemInfoOfProjref(pszProjref, propid, out pvar);
        }

        public int GetItemOfProjref(string pszProjref,
            out IVsHierarchy ppHierarchy,
            out uint pitemid,
            out string pbstrUpdatedProjref,
            VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            return _solution.GetItemOfProjref(pszProjref,
                out ppHierarchy,
                out pitemid,
                out pbstrUpdatedProjref,
                puprUpdateReason);
        }

        public int GetProjectEnum(uint grfEnumFlags, ref Guid rguidEnumOnlyThisType, out IEnumHierarchies ppenum)
        {
            return _solution.GetProjectEnum(grfEnumFlags, ref rguidEnumOnlyThisType, out ppenum);
        }

        public int GetProjectFactory(uint dwReserved,
            Guid[] pguidProjectType,
            string pszMkProject,
            out IVsProjectFactory ppProjectFactory)
        {
            return _solution.GetProjectFactory(dwReserved, pguidProjectType, pszMkProject, out ppProjectFactory);
        }

        public int GetProjectFilesInSolution(uint grfGetOpts,
            uint cProjects,
            string[] rgbstrProjectNames,
            out uint pcProjectsFetched)
        {
            return _solution.GetProjectFilesInSolution(grfGetOpts,
                cProjects,
                rgbstrProjectNames,
                out pcProjectsFetched);
        }

        public int GetProjectInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            return _solution.GetProjectInfoOfProjref(pszProjref, propid, out pvar);
        }

        public int GetProjectOfGuid(ref Guid rguidProjectID, out IVsHierarchy ppHierarchy)
        {
            return _solution.GetProjectOfGuid(ref rguidProjectID, out ppHierarchy);
        }

        public int GetProjectOfProjref(string pszProjref,
            out IVsHierarchy ppHierarchy,
            out string pbstrUpdatedProjref,
            VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            return _solution.GetProjectOfProjref(pszProjref,
                out ppHierarchy,
                out pbstrUpdatedProjref,
                puprUpdateReason);
        }

        public int GetProjectOfUniqueName(string pszUniqueName, out IVsHierarchy ppHierarchy)
        {
            return _solution.GetProjectOfUniqueName(pszUniqueName, out ppHierarchy);
        }

        public int GetProjectTypeGuid(uint dwReserved, string pszMkProject, out Guid pguidProjectType)
        {
            return _solution.GetProjectTypeGuid(dwReserved, pszMkProject, out pguidProjectType);
        }

        public int GetProjrefOfItem(IVsHierarchy pHierarchy, uint itemid, out string pbstrProjref)
        {
            return _solution.GetProjrefOfItem(pHierarchy, itemid, out pbstrProjref);
        }

        public int GetProjrefOfProject(IVsHierarchy pHierarchy, out string pbstrProjref)
        {
            return _solution.GetProjrefOfProject(pHierarchy, out pbstrProjref);
        }

        public int GetProperty(int propid, out object pvar)
        {
            return _solution.GetProperty(propid, out pvar);
        }

        public int GetSolutionInfo(out string pbstrSolutionDirectory,
            out string pbstrSolutionFile,
            out string pbstrUserOptsFile)
        {
            return _solution.GetSolutionInfo(out pbstrSolutionDirectory, out pbstrSolutionFile, out pbstrUserOptsFile);
        }

        public int GetUniqueNameOfProject(IVsHierarchy pHierarchy, out string pbstrUniqueName)
        {
            return _solution.GetUniqueNameOfProject(pHierarchy, out pbstrUniqueName);
        }

        public int GetVirtualProjectFlags(IVsHierarchy pHierarchy, out uint pgrfAddVPFlags)
        {
            return _solution.GetVirtualProjectFlags(pHierarchy, out pgrfAddVPFlags);
        }

        public int OnAfterRenameProject(IVsProject pProject, string pszMkOldName, string pszMkNewName, uint dwReserved)
        {
            return _solution.OnAfterRenameProject(pProject, pszMkOldName, pszMkNewName, dwReserved);
        }

        public int OpenSolutionFile(uint grfOpenOpts, string pszFilename)
        {
            return _solution.OpenSolutionFile(grfOpenOpts, pszFilename);
        }

        public int OpenSolutionViaDlg(string pszStartDirectory, int fDefaultToAllProjectsFilter)
        {
            return _solution.OpenSolutionViaDlg(pszStartDirectory, fDefaultToAllProjectsFilter);
        }

        public int QueryEditSolutionFile(out uint pdwEditResult)
        {
            return _solution.QueryEditSolutionFile(out pdwEditResult);
        }

        public int QueryRenameProject(IVsProject pProject,
            string pszMkOldName,
            string pszMkNewName,
            uint dwReserved,
            out int pfRenameCanContinue)
        {
            return _solution.QueryRenameProject(pProject,
                pszMkOldName,
                pszMkNewName,
                dwReserved,
                out pfRenameCanContinue);
        }

        public int RemoveVirtualProject(IVsHierarchy pHierarchy, uint grfRemoveVPFlags)
        {
            return _solution.RemoveVirtualProject(pHierarchy, grfRemoveVPFlags);
        }

        public int SaveSolutionElement(uint grfSaveOpts, IVsHierarchy pHier, uint docCookie)
        {
            return _solution.SaveSolutionElement(grfSaveOpts, pHier, docCookie);
        }

        public int SetProperty(int propid, object var)
        {
            return _solution.SetProperty(propid, var);
        }

        public int UnadviseSolutionEvents(uint dwCookie)
        {
            return _solution.UnadviseSolutionEvents(dwCookie);
        }

        public int GetProjectFactory(uint dwReserved,
            ref Guid pguidProjectType,
            string pszMkProject,
            out IVsProjectFactory ppProjectFactory)
        {
            return _solution.GetProjectFactory(dwReserved, ref pguidProjectType, pszMkProject, out ppProjectFactory);
        }

        public int UpdateProjectFileLocation(IVsHierarchy pHierarchy)
        {
            return _solution.UpdateProjectFileLocation(pHierarchy);
        }
    }
}
