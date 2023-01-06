using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using IHB_RevitApiDevTools.CodeEditor.Views;
using IHB_RevitApiDevTools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHB_RevitApiDevTools.CodeEditor.Commands
{
    [Transaction(TransactionMode.Manual)]
    //[Regeneration(RegenerationOption.Manual)]
    public class CodeEditor : IExternalCommand
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Application app;
        private Document doc;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region Doc / App / UI
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
            #endregion


            CodeEditor_UI codeEditor = new CodeEditor_UI("IHB Code Editor", commandData, ref message, elements);

            codeEditor.Show();
            IHB_Methods.MakeRevitParent(codeEditor);


            return Result.Succeeded;
        }
    }
}
