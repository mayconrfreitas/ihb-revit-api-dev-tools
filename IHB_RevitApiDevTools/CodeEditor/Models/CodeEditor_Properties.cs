using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHB_RevitApiDevTools.CodeEditor.Models
{
    public static class CodeEditor_Properties
    {



        public const string baseCode =
@"#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExternalService;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;
using System.Windows;
using System.IO;
#endregion Libraries


namespace IHB
{
    [Autodesk.Revit.Attributes.Transaction(TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(RegenerationOption.Manual)]
    public class MyCommand : IExternalCommand
    {

        #region Private Variables

        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;

        #endregion Private Variables


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;

            try
            {
                // Write your code down here...
                TaskDialog.Show(" + "\"Test\", \"Hello World!\"" + @"); 

            }
            catch (Exception e)
            {
                //Shows a message with the error body
                TaskDialog.Show(" + "\"Error\"" + @", e.Message);
                return Result.Failed;
            }


            return Result.Succeeded;

        }
    }
}";
    }
}
