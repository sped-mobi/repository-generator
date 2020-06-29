using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace Microsoft.VisualStudio.Shell.Hierarchy
{
    public class ProjectWrapper : IVsHierarchy
    {
        private readonly IVsHierarchy _hierarchy;
        private const uint _root = HierarchyConstants.VSITEMID_ROOT;

        public string Name
        {
            get
            {
                return GetProperty<string>(ProjectPropertyID.Name);
            }
            set
            {
                SetProperty(ProjectPropertyID.Name, value);
            }
        }

        public object ExtObject
        {
            get
            {
                return GetProperty(ProjectPropertyID.ExtObject);
            }
        }

        public string ProjectDirectory
        {
            get
            {
                return GetProperty<string>(ProjectPropertyID.ProjectDir);
            }
            set
            {
                SetProperty(ProjectPropertyID.ProjectDir, value);
            }
        }

        public Guid ProjectGuid
        {
            get
            {
                return GetGuidProperty(ProjectPropertyID.ProjectIDGuid);
            }
            set
            {
                SetGuidProperty(ProjectPropertyID.ProjectIDGuid, value);
            }
        }

        public Guid ProjectTypeGuid
        {
            get
            {
                return GetGuidProperty(ProjectPropertyID.ProjectType);
            }
            set
            {
                SetGuidProperty(ProjectPropertyID.ProjectType, value);
            }
        }

        public void SetProperty(int propid, object value)
        {
            if (!ErrorHandler.Succeeded(SetProperty(_root, propid, value)))
            {
            }
        }

        public object GetProperty(int propid)
        {
            GetProperty(_root, propid, out object value);
            return value;
        }

        public T GetProperty<T>(int propid)
        {
            return (T)GetProperty(propid);
        }

        public ProjectWrapper(IVsHierarchy hierarchy)
        {
            _hierarchy = hierarchy;
        }

        public int SetSite(OLE.Interop.IServiceProvider psp)
        {
            return _hierarchy.SetSite(psp);
        }

        public int GetSite(out OLE.Interop.IServiceProvider ppSP)
        {
            return _hierarchy.GetSite(out ppSP);
        }

        public int QueryClose(out int pfCanClose)
        {
            return _hierarchy.QueryClose(out pfCanClose);
        }

        public int Close()
        {
            return _hierarchy.Close();
        }

        public Guid GetGuidProperty(int propid)
        {
            GetGuidProperty(_root, propid, out Guid guid);
            return guid;
        }

        public void SetGuidProperty(int propid, Guid value)
        {
            SetGuidProperty(_root, propid, ref value);
        }

        public int GetGuidProperty(uint itemid, int propid, out Guid pguid)
        {
            return _hierarchy.GetGuidProperty(itemid, propid, out pguid);
        }

        public int SetGuidProperty(uint itemid, int propid, ref Guid rguid)
        {
            return _hierarchy.SetGuidProperty(itemid, propid, ref rguid);
        }

        public int GetProperty(uint itemid, int propid, out object pvar)
        {
            return _hierarchy.GetProperty(itemid, propid, out pvar);
        }

        public int SetProperty(uint itemid, int propid, object var)
        {
            return _hierarchy.SetProperty(itemid, propid, var);
        }

        public int GetNestedHierarchy(uint itemid, ref Guid iidHierarchyNested, out IntPtr ppHierarchyNested, out uint pitemidNested)
        {
            return _hierarchy.GetNestedHierarchy(itemid, ref iidHierarchyNested, out ppHierarchyNested, out pitemidNested);
        }

        public int GetCanonicalName(uint itemid, out string pbstrName)
        {
            return _hierarchy.GetCanonicalName(itemid, out pbstrName);
        }

        public int ParseCanonicalName(string pszName, out uint pitemid)
        {
            return _hierarchy.ParseCanonicalName(pszName, out pitemid);
        }

        public int Unused0()
        {
            return _hierarchy.Unused0();
        }

        public int AdviseHierarchyEvents(IVsHierarchyEvents pEventSink, out uint pdwCookie)
        {
            return _hierarchy.AdviseHierarchyEvents(pEventSink, out pdwCookie);
        }

        public int UnadviseHierarchyEvents(uint dwCookie)
        {
            return _hierarchy.UnadviseHierarchyEvents(dwCookie);
        }

        public int Unused1()
        {
            return _hierarchy.Unused1();
        }

        public int Unused2()
        {
            return _hierarchy.Unused2();
        }

        public int Unused3()
        {
            return _hierarchy.Unused3();
        }

        public int Unused4()
        {
            return _hierarchy.Unused4();
        }
    }
}
