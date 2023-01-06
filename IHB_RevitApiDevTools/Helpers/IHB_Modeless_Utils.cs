using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IHB_RevitApiDevTools.Helpers
{


    /// <summary>
    /// First, this is the enumeration of each command triggered in the MainWindow (modeless dialog).
    /// </summary>
    public enum RequestId : int
    {
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        Command01 = 1,

        /// <summary>
        /// 
        /// </summary>
        Command02 = 2,

        /// <summary>
        /// 
        /// </summary>
        Command03 = 3,

        /// <summary>
        /// 
        /// </summary>
        Command04 = 4,

        /// <summary>
        /// 
        /// </summary>
        Command05 = 5,

        /// <summary>
        /// 
        /// </summary>
        Command06 = 6,

        /// <summary>
        /// 
        /// </summary>
        Command07 = 7,

        /// <summary>
        /// 
        /// </summary>
        Command08 = 8,

        /// <summary>
        /// 
        /// </summary>
        Command09 = 9,

        /// <summary>
        /// 
        /// </summary>
        Command10 = 10,

        /// <summary>
        /// 
        /// </summary>
        Command11 = 11,

        /// <summary>
        /// 
        /// </summary>
        Command12 = 12,

        /// <summary>
        /// 
        /// </summary>
        Command13 = 13

    }








    /// <summary>
    /// This is the class that will take the user command by the RequestId enum 
    /// and make the request once the RequestHandler identifies it while the external event is being raised.
    /// </summary>
    public class Request
    {
        private int m_request = (int)RequestId.None;

        public RequestId Take()
        {
            return (RequestId)Interlocked.Exchange(ref m_request, (int)RequestId.None);
        }

        public void Make(RequestId request)
        {
            Interlocked.Exchange(ref m_request, (int)request);
        }
    }







    /// <summary>
    /// Classe para passar dados para os comandos executados pelas janelas modais.
    /// </summary>
    public class DataHandler
    {
        public List<Element> ListaElementos { get; set; }


        public ExternalCommandData commandData { get; set; }
        public string message { get; set; }
        public ElementSet elementSet { get; set; }




    }







    /// <summary>
    /// This is the class that will implement the IExternalEventHandler interface
    /// to handle all commands started by user action in the MainWindow (modeless dialog) 
    /// as Requests listed in an enumeration used by the Request class.
    /// Also here we will define all the methods that will build the application functionality using the Revit API.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RequestHandler : IExternalEventHandler
    {

        public string GetName()
        {
            /* This method is needed to identify this event handler. */
            return "Request Handler";
        }

        //Transfere dados entre as classess
        public DataHandler dataHandler { get; set; }

        delegate void Method(UIDocument uiDoc, Document doc); // first, a delegate to save us from repeating the UIApplication as argument for commands endless times

        public Request Request { get; } = new Request(); // instantiating the Request class, which will take the commands by the user by indentifying its RequestId 

        public void Execute(UIApplication app)
        {
            try
            {
                /* Based on the command started by the user in the MainWindow, 
                 these Switch cases will use the Take method from the Request class to execute the chosen command by its RequestId. */

                switch (Request.Take())
                {
                    case RequestId.None:
                        {
                            return;  // no request to handle
                        }
                    case RequestId.Command01:
                        {
                            GeneralMethod(app, Method_Command01);
                            break;
                        }
                    case RequestId.Command02:
                        {
                            GeneralMethod(app, Method_Command02);
                            break;
                        }
                    case RequestId.Command03:
                        {
                            GeneralMethod(app, Method_Command03);
                            break;
                        }
                    case RequestId.Command04:
                        {
                            GeneralMethod(app, Method_Command04);
                            break;
                        }
                    case RequestId.Command05:
                        {
                            GeneralMethod(app, Method_Command05);
                            break;
                        }
                    case RequestId.Command06:
                        {
                            GeneralMethod(app, Method_Command06);
                            break;
                        }
                    case RequestId.Command07:
                        {
                            GeneralMethod(app, Method_Command07);
                            break;
                        }
                    case RequestId.Command08:
                        {
                            GeneralMethod(app, Method_Command08);
                            break;
                        }
                    case RequestId.Command09:
                        {
                            GeneralMethod(app, Method_Command09);
                            break;
                        }
                    case RequestId.Command10:
                        {
                            GeneralMethod(app, Method_Command10);
                            break;
                        }
                    case RequestId.Command11:
                        {
                            GeneralMethod(app, Method_Command11);
                            break;
                        }
                    case RequestId.Command12:
                        {
                            GeneralMethod(app, Method_Command12);
                            break;
                        }
                    case RequestId.Command13:
                        {
                            GeneralMethod(app, Method_Command13);
                            break;
                        }
                    default:
                        {
                            TaskDialog.Show("Erro", "Nenhum Request válido foi dado.");
                            break;
                        }
                }
            }
            finally
            {
                //App.thisApp.WakeWindowUp(); // keeping the dilaog active after a request
            }
            return;
        }


        //----MAIN METHOD----------------------------------------------------------------------------------------

        private void GeneralMethod(UIApplication app, Method method)
        {
            /* This method will be used in the Execute method above. 
             We just need to exchange the second argument instance (delegate) for each case in the Switch cases. */

            UIDocument uiDoc = app.ActiveUIDocument;

            Document doc = uiDoc.Document;

            method(uiDoc, doc); // using that useful Delegate Method we declared in the beginning to refer to each command method in each respective case
        }


        //----METHODS TO EXECUTE THROUGH DELEGATE----------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiDoc"></param>
        /// <param name="doc"></param>
        private void Method_Command01(UIDocument uiDoc, Document doc)
        {
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="uiDoc"></param>
        /// <param name="doc"></param>
        private void Method_Command02(UIDocument uiDoc, Document doc)
        {
            
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiDoc"></param>
        /// <param name="doc"></param>
        private void Method_Command03(UIDocument uiDoc, Document doc)
        {

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiDoc"></param>
        /// <param name="doc"></param>
        private void Method_Command04(UIDocument uiDoc, Document doc)
        {
            
        }

        private void Method_Command05(UIDocument uiDoc, Document doc)
        {


        }

        private void Method_Command06(UIDocument uiDoc, Document doc)
        {

        }

        private void Method_Command07(UIDocument uiDoc, Document doc)
        {

        }

        private void Method_Command08(UIDocument uiDoc, Document doc)
        {

        }

        private void Method_Command09(UIDocument uiDoc, Document doc)
        {

        }

        private void Method_Command10(UIDocument uiDoc, Document doc)
        {

        }

        private void Method_Command11(UIDocument uiDoc, Document doc)
        {

        }

        private void Method_Command12(UIDocument uiDoc, Document doc)
        {

        }

        private void Method_Command13(UIDocument uiDoc, Document doc)
        {

        }


    }


}
