using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IHB_RevitApiDevTools.CodeEditor.Commands
{
    public class ScriptRunner
    {
        public static Result RunScript(string scriptCode, ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider();

            //configure parameters
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.IncludeDebugInformation = false;
            string reference;
            // Set reference to current assembly - this reference is a hack for the example..
            //MessageBox.Show(Assembly.GetExecutingAssembly().Location);
            reference = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(reference);
            //parameters.ReferencedAssemblies.Add(reference + "\\CompileScriptExample.exe");
            //parameters.ReferencedAssemblies.Add(reference + "\\IHB_RevitApiDevTools.dll");

            #region Add GetReferencedAssemblies
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var nameAssemblies = new Dictionary<string, Assembly>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assemblyNames.Any(e => e.Name == assembly.GetName().Name))
                {
                    nameAssemblies[assembly.GetName().Name] = assembly;
                }
            }
            foreach (var keyAssembly in nameAssemblies)
            {

                //MessageBox.Show($"Assembly: {keyAssembly.Key}\nLocation: {keyAssembly.Value.Location}");
                parameters.ReferencedAssemblies.Add(keyAssembly.Value.Location);
            }
            #endregion

            //compile
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, new string[] { scriptCode });

            if (results.Errors.Count == 0)
            {
                //IStringManipulator compiledScript = (IStringManipulator)FindInterface(results.CompiledAssembly, "IStringManipulator");
                IExternalCommand compiledScript = (IExternalCommand)FindInterface(results.CompiledAssembly, "IExternalCommand");
                return compiledScript.Execute(commandData, ref message, elements);//run the script, pass the string param..
            }
            else
            {
                foreach (CompilerError anError in results.Errors)
                {
                    MessageBox.Show(anError.ErrorText);
                }
                //handle compilation errors here
                //..use results.errors collection
                throw new Exception("Compilation error...");
            }
        }

        private static object FindInterface(Assembly anAssembly, string interfaceName)
        {
            // find our interface type..
            foreach (Type aType in anAssembly.GetTypes())
            {
                if (aType.GetInterface(interfaceName, true) != null)
                    return anAssembly.CreateInstance(aType.FullName);
            }
            return null;
        }
    }
}
