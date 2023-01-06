using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using IHB_RevitApiDevTools.Helpers;
using System;

namespace IHB_RevitApiDevTools.Help.Commands
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class OpenHelp : IExternalCommand
    {

        #region Private Variables

        private UIApplication uiapp;
        private UIDocument uidoc;
        private Application app;
        private Document doc;

        #endregion Private Variables


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;

            try
            {
                IHB_Methods.btnHelp_Click();
            }
            catch (Exception e)
            {

                string msg = e.Message;
                string error = e.Message + "\n" + e.StackTrace;

                TaskDialog taskDialog = new TaskDialog("ERROR");
                taskDialog.MainInstruction = msg;
                taskDialog.ExpandedContent = error;

                taskDialog.Show();


                #region Journal
                //TEMP:==========================================================================
                //TMP:                          REGISTRO NO JOURNAL
                //TEMP:==========================================================================
                IHB_Methods.WriteJournal(
                    doc.Application.Username?.ToString() ?? "",
                    this,
                    msg + "\n" + error
                    );
                //TEMP:==========================================================================
                #endregion Journal

                return Result.Failed;
            }


            return Result.Succeeded;

        }
    }
}
