using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using IHB_RevitApiDevTools.CodeEditor.Views;
using IHB_RevitApiDevTools.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IHB_RevitApiDevTools.CodeEditor.Commands
{
    [Transaction(TransactionMode.Manual)]
    //[Regeneration(RegenerationOption.Manual)]
    public class CodePlayer : IExternalCommand
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Application app;
        private Document doc;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            #region Doc / App / UI
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
            #endregion


            string text = "";
            using (StreamReader reader = new StreamReader(IHB_Properties.IHBCsharpBaseFile))
            {
                text = reader.ReadToEnd();
            }

            if (text != "")
            {
                try
                {
                    Result codeResult = ScriptRunner.RunScript(text, commandData, ref message, elementSet);
                }
                catch (Exception f)
                {
                    TaskDialog.Show("Erro", f.Message);
                }
            }
            return Result.Succeeded;
        }
    }
}
