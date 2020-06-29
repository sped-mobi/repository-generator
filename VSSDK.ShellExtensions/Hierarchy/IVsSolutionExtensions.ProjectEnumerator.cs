using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.VisualStudio.Shell.Hierarchy
{
    public static partial class IVsSolutionExtensions
    {
        private class ProjectEnumerator : IEnumerable<IVsHierarchy>
        {
            private readonly IVsSolution _solution;
            private static Guid _nullGuid = Guid.Empty;

            public ProjectEnumerator(IVsSolution solution)
            {
                _solution = solution;
            }

            public IEnumerator<IVsHierarchy> GetEnumerator()
            {
                return new Enumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new Enumerator(this);
            }

            public IVsHierarchy FindProject(string projectName)
            {
                IVsHierarchy retVal = null;
                Enumerator enumerator = new Enumerator(this);
                while (enumerator.MoveNext())
                {
                    IVsHierarchy hierarchy = enumerator.Current;
                    var wrapper = new ProjectWrapper(hierarchy);

                    if (wrapper.Name == projectName)
                    {
                        retVal = hierarchy;
                        break;
                    }
                }
                return retVal;
            }

            private class Enumerator : IEnumerator<IVsHierarchy>
            {
                private readonly IVsHierarchy[] _items;
                private int _index;

                public Enumerator(ProjectEnumerator enumerator)
                {
                    _items = GetHierarchies(enumerator._solution);
                    _index = -1;
                }

                public IVsHierarchy this[int index]
                {
                    get
                    {
                        if (index < Count)
                        {
                            return _items[_index];
                        }

                        return null;
                    }
                }

                public IVsHierarchy Current
                {
                    get
                    {
                        if (_index < Count)
                        {
                            return _items[_index];
                        }

                        return null;
                    }
                }

                public int Count => _items.Length;

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    _index++;
                    return _index < Count;
                }

                public void Reset()
                {
                    _index = -1;
                }

                private static IVsHierarchy[] GetHierarchies(IVsSolution solution)
                {
                    List<IVsHierarchy> list = new List<IVsHierarchy>();

                    var hr = solution.GetProjectEnum((uint)__VSENUMPROJFLAGS.EPF_ALLPROJECTS, ref _nullGuid, out IEnumHierarchies penum);
                    if (ErrorHandler.Succeeded(hr)
                        && (penum != null))
                    {
                        var rgelt = new IVsHierarchy[1];
                        while (penum.Next(1, rgelt, out uint fetched) == 0
                               && fetched == 1)
                        {
                            list.Add(rgelt[0]);
                        }
                    }

                    return list.ToArray();
                }
            }
        }
    }
}
