using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTester
{
    public static class Program
    {
        public const string Arcade = "https://codeload.github.com/sped-mobi/arcade/zip/master";

        private static StringBuilder Builder;
        private static ClipboardWriter Writer;

        private static Type[] ShellPropertyIDTypes = new Type[]
{
            typeof(__VSSPROPID),
            typeof(__VSSPROPID2),
            typeof(__VSSPROPID3),
            typeof(__VSSPROPID4),
            typeof(__VSSPROPID5),
            typeof(__VSSPROPID6),
            typeof(__VSSPROPID7),
            typeof(__VSSPROPID8),
};

        private static Type[] ProjectPropertyIDTypes = new Type[]
        {
            typeof(__VSHPROPID),
            typeof(__VSHPROPID2),
            typeof(__VSHPROPID3),
            typeof(__VSHPROPID4),
            typeof(__VSHPROPID5),
            typeof(__VSHPROPID6),
            typeof(__VSHPROPID7),
            typeof(__VSHPROPID8),
        };

        private static Type[] SolutionPropertyIDTypes = new Type[]
        {
            typeof(__VSPROPID),
            typeof(__VSPROPID2),
            typeof(__VSPROPID3),
            typeof(__VSPROPID4),
            typeof(__VSPROPID5),
            typeof(__VSPROPID6),
            typeof(__VSPROPID7),
            typeof(__VSPROPID8),
        };

        [STAThread]
        public static void Main()
        {
            Before();

            GenerateEnumWrapperClass("SolutionPropertyID", "int", SolutionPropertyIDTypes, FilterByName);
            GenerateEnumWrapperClass("ProjectPropertyID", "int", ProjectPropertyIDTypes, FilterByName);
            GenerateEnumWrapperClass("ShellPropertyID", "int", ShellPropertyIDTypes, FilterByName);

            After();
        }

        private static bool FilterByName(string key)
        {
            if (key.StartsWith("FIRST") || key == "NIL" || key == "LAST")
                return false;
            return true;
        }

        private static void GenerateProjectPropertyIDClass()
        {
            WriteLine();
            WriteLine($"public static class ProjectPropertyID");
            using (OpenBlock())
            {
                var dict = GetEnumMaps(ProjectPropertyIDTypes).OrderBy(x => x.Key);

                foreach (var kvp in dict)
                {
                    string key = kvp.Key;
                    int value = kvp.Value;

                    if (key.StartsWith("FIRST") || key == "NIL" || key == "LAST")
                        continue;

                    WriteLine();
                    WriteLine($"public const int {key} = {value};");
                }
            }
        }

        private static void GenerateEnumWrapperClass(string className, string underlyingTypeName, Type[] types, Predicate<string> predicate)
        {
            WriteLine();
            WriteLine($"public static class {className}");
            using (OpenBlock())
            {
                var dict = GetEnumMaps(types).OrderBy(x => x.Key);
                foreach (var kvp in dict)
                {
                    string key = kvp.Key;
                    int value = kvp.Value;
                    if (predicate(key))
                    {
                        WriteLine();
                        WriteLine($"public const {underlyingTypeName} {key} = {value};");
                    }
                }
            }
        }

        private static Dictionary<string, int> GetEnumMaps(Type[] types)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (Type type in types)
                AddDictionaryEntries(type, dictionary);
            return dictionary;
        }

        private static void AddDictionaryEntries(Type type, Dictionary<string, int> dictionary)
        {
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type).ToArray<int>();

            for (int i = 0; i < names.Length; i++)
            {
                var name = names[i];
                int index = name.IndexOf('_') + 1;
                name = name.Substring(index);
                var value = values[i];
                if (!dictionary.ContainsKey(name))
                {
                    dictionary[name] = value;
                }
            }
        }

        private static void ProcessType(Type type)
        {
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type).ToArray<int>();

            for (int i = 0; i < names.Length; i++)
            {
                var name = names[i];

                int index = name.IndexOf('_') + 1;
                name = name.Substring(index);

                var value = values[i];
                WriteLine($"public const uint {name} = {value};");
            }
        }

        private static void After()
        {
            Writer.Clip();
            Console.WriteLine(Builder);
            Console.ReadKey();
        }

        private static void Before()
        {
            Builder = new StringBuilder();
            Writer = ClipboardWriter.CreateForStringBuilder(Builder);
        }

        private static void Write(string value)
        {
            Writer.Write(value);
        }

        private static void WriteLine(string value)
        {
            Writer.WriteLine(value);
        }

        private static void WriteLine()
        {
            Writer.WriteLine();
        }

        private static IDisposable OpenBlock()
        {
            return Writer.OpenBlock();
        }

        private static T[] ToArray<T>(this Array array)
        {
            T[] retVal = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                var item = array.GetValue(i);
                retVal[i] = (T)item;
            }

            return retVal;
        }
    }

}
