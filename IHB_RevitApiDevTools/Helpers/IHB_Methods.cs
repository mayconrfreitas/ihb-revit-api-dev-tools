using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using IHB_RevitApiDevTools.About;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using Autodesk.Forge;
using Autodesk.Forge.Model;
using System.Management;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using IHB_RevitApiDevTools.Helpers.UI;
using Autodesk.Revit.DB.Plumbing;
using System.Net.Http;
using System.Net.Http.Headers;
using IHB_RevitApiDevTools.Helpers;
using IHB_RevitApiDevTools.About.Views;

namespace IHB_RevitApiDevTools.Helpers
{
    public static class IHB_Methods
    {




        #region Debug and code utilities


        public static void DebugHere(string message="Debugging...",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null,
            params string[] args)
        {
            string concatArgs = args == null? "-": string.Join(" | ", args);
            TaskDialog.Show("DEBUG", $"Msg: {message}{Environment.NewLine}Args: {concatArgs}{Environment.NewLine}Code Line: {lineNumber} ({caller})");
        }


        /// <summary>
        /// Write information into IHB Journal.
        /// </summary>
        /// <param name="user">User that is running the command</param>
        /// <param name="command">Class where it's being executed, usually use the keyword: this</param>
        /// <param name="message">Message to be written into the Journal</param>
        internal static void WriteJournal(string user, Object command, string message)
        {
            WriteJournal(user, command, null, message);
        }

        /// <summary>
        /// Write information into IHB Journal.
        /// </summary>
        /// <param name="user">User that is running the command</param>
        /// <param name="nameCommand">Class where it's being executed (whitin Static Classes write the name of the class where the command is being used)</param>
        /// <param name="message">Message to be written into the Journal</param>
        internal static void WriteJournal(string user, string nameCommand, string message)
        {
            WriteJournal(user, null, nameCommand, message);
        }


        /// <summary>
        /// Write information into IHB Journal.
        /// </summary>
        /// <param name="user">User that is running the command</param>
        /// <param name="command">Class where it's being executed, usually use the keyword: this</param>
        /// <param name="nameCommand">Class where it's being executed (whitin Static Classes write the name of the class where the command is being used)</param>
        /// <param name="message">Message to be written into the Journal</param>
        internal static void WriteJournal(string user, Object command, string nameCommand, string message)
        {
            try
            {
                string filePath = IHB_Properties.IHBJournalFilePath;
                string body = "";
                if (System.IO.File.Exists(filePath))
                {
                    using (StreamReader read = System.IO.File.OpenText(filePath))
                    {
                        string txt = read.ReadToEnd();
                        body += txt;
                    }
                }

                JournalFile register = null;
                if (command != null)
                {
                    register = new JournalFile(user, command, message);
                }
                else
                {
                    register = new JournalFile(user, nameCommand, message);
                }

                body += $"{register.Date} {register.Time} - Command: {register.Command} (User: {register.User}){Environment.NewLine}       Message: ` {register.Message} `{Environment.NewLine}";

                using (StreamWriter file = System.IO.File.CreateText(filePath))
                {
                    file.WriteLine(body);
                }

            }
            catch
            {
                Debug.WriteLine("Fail to write to the Journal");
            }
        }



        #endregion Debug and code utilities









        #region Images

        public static Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
        {
            //BitmapImage bitmapImage = new BitmapImage(
            // new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Convert a Bitmap to a BitmapSource
        /// </summary>
        public static BitmapSource BitmapToBitmapSource(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();

            BitmapSource retval;

            try
            {
                retval = Imaging.CreateBitmapSourceFromHBitmap(
                  hBitmap, IntPtr.Zero, Int32Rect.Empty,
                  BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }
            return retval;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(
          System.Drawing.Image image,
          int width,
          int height)
        {
            var destRect = new System.Drawing.Rectangle(
              0, 0, width, height);

            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution,
              image.VerticalResolution);

            using (var g = Graphics.FromImage(destImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destRect, 0, 0, image.Width,
                      image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        /// <summary>
        /// Scale down large icon to desired size for Revit 
        /// ribbon button, e.g., 32 x 32 or 16 x 16
        /// </summary>
        public static BitmapSource ScaledIcon(
          BitmapImage large_icon,
          int w,
          int h)
        {
            return BitmapToBitmapSource(ResizeImage(
              BitmapImageToBitmap(large_icon), w, h));
        }

        #endregion Images










        #region Windows funcionality

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg,
                int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void move_window(Window that, object sender = null, MouseButtonEventArgs e = null)
        {
            ReleaseCapture();
            SendMessage(new WindowInteropHelper(that).Handle,
                WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }


        public static void btnAbout_Click(object sender = null, RoutedEventArgs e = null)
        {
            AboutWnd aboutWnd = new AboutWnd();
            aboutWnd.ShowDialog();
        }


        public static void btnHelp_Click(object sender = null, RoutedEventArgs e = null)
        {
            //TODO: Implement help
        }


        public static void btnClose_Click(Window that, object sender = null, RoutedEventArgs e = null)
        {
            that.Close();
        }



        /// <summary>
        /// Used in modeless windows to remain in foreground during the execution.
        /// </summary>
        /// <param name="window">Window to remain in foreground.</param>
        public static void MakeRevitParent(Window window)
        {
            IntPtr revitHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;

            System.Windows.Interop.WindowInteropHelper helper = new System.Windows.Interop.WindowInteropHelper(window);
            helper.Owner = revitHandle;
        }


        /// <summary>
        /// Execute commands from modeless windows
        /// </summary>
        /// <param name="dataHandler">DataHandler with the command data.</param>
        /// <param name="m_Handler">RequestHandler.</param>
        /// <param name="m_ExEvent">External event.</param>
        /// <param name="request">command ID.</param>
        public static void MakeRequest(DataHandler dataHandler, RequestHandler m_Handler, ExternalEvent m_ExEvent, RequestId request)
        {
            /* As seen above this method is used to handle and raise the commands requested by the user as external events for Revit. */
            m_Handler.dataHandler = dataHandler;
            m_Handler.Request.Make(request); // uses the Make method of the Request class instantiated in the RequestHandler class to identify the command started by the user
            m_ExEvent.Raise(); // raises the command requested as an external event for Revit and the Execute method in the handler can finally be done
        }



        /// <summary>
        /// Verify is window is opened.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        #endregion Windows funcionality










        #region Windows, files, folders, etc


        /// <summary>
        /// Get IHB folder in User/AppData/Roaming if exists, else, create.
        /// </summary>
        /// <returns></returns>
        internal static DirectoryInfo GetIHBFolder()
        {
            return System.IO.Directory.CreateDirectory(IHB_Properties.IHBFolderPath);
        }


        /// <summary>
        /// Get current Windows user
        /// </summary>
        /// <returns></returns>
        internal static string GetWindowsCurrentUser()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            string userNameVariable = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
            string userName = userNameVariable.Contains("\\") ? userNameVariable.Split('\\')[1] : userNameVariable;

            return userName;
        }




        /// <summary>
        ///Copy some content to windows clipboard (Ctrl + C).
        /// </summary>
        /// <param name="content">Conteúdo a ser copiado</param>
        public static void CopyToClipboard(string content)
        {
            Clipboard.SetText(content);
        }


        /// <summary>
        /// Get current Revit file size
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static double GetCurrentRevitFileSize(Document doc)
        {
            double fileSize;
            string filePath = doc.PathName;
            try
            {
                if (filePath.StartsWith("BIM 360://") || filePath.StartsWith("ACC"))
                {
                    // (Konrad) For BIM 360 files, we can just pull the file size from local cached file.
                    // It's pretty much what is stored in the web, so will work for our purpose.
                    var fileName = doc.WorksharingCentralGUID + ".rvt";
                    var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var collaborationDir = Path.Combine(localAppData,
                        "Autodesk\\Revit\\Autodesk Revit " + doc.Application.VersionNumber, "CollaborationCache");

                    var file = Directory.GetFiles(collaborationDir, fileName, SearchOption.AllDirectories)
                        .FirstOrDefault(x => new FileInfo(x).Directory?.Name != "CentralCache");
                    if (file == null) return 0.0;

                    var fileInfo = new FileInfo(file);
                    fileSize = fileInfo.Length;
                }
                else
                {
                    var fileInfo = new FileInfo(filePath);
                    fileSize = fileInfo.Length;
                }

                
            }
            catch (Exception ex)
            {
                fileSize = 0.0;
                // do some loggin, throw an exception
            }

            return fileSize / 1024; //MB
        }

        #endregion  Windows, files, folders, etc











        #region Proccess, cmd, etc



        /// <summary>
        /// Create a new CMD process and execute a command line.
        /// </summary>
        /// <param name="command">Command to be executed by CMD.</param>
        /// <param name="cmdKey">'k' to keep CMD opened after executing the comand and 'c' to close.</param>
        public static void WriteToCmd(string command, string cmdKey="k")
        {

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.Arguments = $"/{cmdKey} {command}";
            cmd.Start();
        }


        /// <summary>
        /// Get the process by name and window title when exists an opened window.
        /// </summary>
        /// <param name="processName">Process name. Standard name to CMD.</param>
        /// <param name="windowTitle">Windows name. Standard name to CMD.</param>
        /// <returns>Returns the process, if identified, and null if not.</returns>
        public static Process GetProcessByName(string processName="cmd", string windowTitle="prompt")
        {
            Process[] processos = Process.GetProcesses();
            Process processo = null;
            foreach (Process p in processos)
            {
                if (p.ProcessName.ToLower().Replace(" ","").Contains(processName.ToLower().Replace(" ", ""))
                    && p.MainWindowTitle.ToLower().Replace(" ", "").Contains(windowTitle.ToLower().Replace(" ", "")))
                {
                    processo = p;
                    break;
                }
            }

            return processo;
        }


        #endregion Proccess, cmd, etc










        #region Math



        /// <summary>
        /// Vector between to points
        /// </summary>
        /// <param name="endPt">Towards the vector points</param>
        /// <param name="startPt">Origin of the Vector</param>
        /// <returns>XYZ Vector</returns>
        public static XYZ VectorBetween2Points(XYZ endPt, XYZ startPt)
        {
            double x = endPt.X - startPt.X;
            double y = endPt.Y - startPt.Y;
            double z = endPt.Z - startPt.Z;

            XYZ vector = new XYZ(x, y, z);

            return vector;
        }


        /// <summary>
        /// Returns the vector length or magnitude.
        /// </summary>
        /// <param name="vector">XYZ vector</param>
        /// <returns>A double with the vector's magnitude</returns>
        public static double CalculateVectorLength(XYZ vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2) + Math.Pow(vector.Z, 2));
        }


        /// <summary>
        /// Normalize the vector.
        /// </summary>
        /// <param name="vector">XYZ vector</param>
        /// <returns>A new Vector normalized</returns>
        public static XYZ NormalizeVector(XYZ vector)
        {
            double length = IHB_Methods.CalculateVectorLength(vector);

            double x = vector.X / length;
            double y = vector.Y / length;
            double z = vector.Z / length;

            XYZ normalized = new XYZ(x, y, z);

            return normalized;
        }



        /// <summary>
        /// Move a point along distance in a vector's direction.
        /// </summary>
        /// <param name="point">Point to be moved</param>
        /// <param name="vector">Vector</param>
        /// <param name="distance">Distance to move the point</param>
        /// <param name="isVectorNormalized">True is the vector is normalized. Standard value is false.</param>
        /// <returns>Returns the XYZ point relocated</returns>
        public static XYZ MovePointAlongVectorByDistance(XYZ point, XYZ vector, double distance, bool isVectorNormalized = false)
        {
            XYZ normalized = isVectorNormalized ? vector: IHB_Methods.NormalizeVector(vector);

            XYZ newPt = point + (normalized * distance);

            return newPt;
        }


        /// <summary>
        /// Project a point onto a surface.
        /// </summary>
        /// <param name="pt">Point to be projected</param>
        /// <param name="planeOrigin">Origin of the plane where the point will be projected</param>
        /// <param name="planeNormal">Normal of the plane where the point will be projected</param>
        /// <returns></returns>
        public static XYZ ProjectPointOntoPlane(XYZ pt, XYZ planeOrigin, XYZ planeNormal)
        {
            XYZ projPt = pt - (pt - planeOrigin).DotProduct(planeNormal) * planeNormal;
            return projPt;
        }


        /// <summary>
        /// Calculate the distance between 2 points
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>Returns the distance on Revit's internal unit (feet). NEEDS TO CONVERT TO PROJECT'S UNIT</returns>
        public static double DistancePoint2Point(XYZ p1, XYZ p2)
        {
            double _x1 = p1.X;
            double _x2 = p2.X;

            double _y1 = p1.Y;
            double _y2 = p2.Y;

            double _z1 = p1.Z;
            double _z2 = p2.Z;

            double calc = Math.Sqrt(Math.Pow((_x1 - _x2), 2) + Math.Pow((_y1 - _y2), 2) + Math.Pow((_z1 - _z2), 2));

            return calc;
        }



        /// <summary>
        /// Verify if the points are the same according to a tolerance
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <param name="tolerance">Tolerance</param>
        /// <returns>Returns true or false</returns>
        public static bool IsSamePoint(XYZ p1, XYZ p2, double tolerance = 0.001)
        {
            if (IHB_Methods.DistancePoint2Point(p1, p2) < tolerance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Find the closest point
        /// </summary>
        /// <param name="point">Base point</param>
        /// <param name="points">List of points to be evaluated</param>
        /// <returns>The closest point XYZ</returns>
        public static XYZ ClosestPoint(XYZ point, List<XYZ> points)
        {
            XYZ cPt = null;
            double preDist = 99999999999;
            if (points.Count > 0)
            {
                foreach (XYZ pt in points)
                {
                    if (IHB_Methods.DistancePoint2Point(point, pt) < preDist)
                    {
                        preDist = IHB_Methods.DistancePoint2Point(point, pt);
                        cPt = pt;
                    }
                }
            }

            return cPt;
        }

        /// <summary>
        /// Find the closest point
        /// </summary>
        /// <param name="curve">Base curve</param>
        /// <param name="points">List of points to be evaluated</param>
        /// <returns>The closest point XYZ</returns>
        public static XYZ ClosestPoint(Curve curve, List<XYZ> points)
        {
            XYZ cPt = null;

            XYZ startPt = curve.GetEndPoint(0);
            XYZ endPt = curve.GetEndPoint(1);

            XYZ cStartPt = ClosestPoint(startPt, points);
            double dist_cStartPt = IHB_Methods.DistancePoint2Point(startPt, cStartPt);
            XYZ cEndPt = ClosestPoint(endPt, points);
            double dist_cEndPT = IHB_Methods.DistancePoint2Point(endPt, cEndPt);

            if (dist_cStartPt > dist_cEndPT)
            {
                cPt = cEndPt;
            }
            else
            {
                cPt = cStartPt;
            }

            return cPt;
        }

        /// <summary>
        /// Find the closest point
        /// </summary>
        /// <param name="pPoints">Base list of points</param>
        /// <param name="points">List of points to be evaluated</param>
        /// <returns>The closest point XYZ</returns>
        public static XYZ ClosestPoint(List<XYZ> pPoints, List<XYZ> points)
        {
            XYZ cPt = null;
            double preDist = 99999999999;
            try
            {
                foreach (XYZ point in pPoints)
                {
                    foreach (XYZ pt in points)
                    {
                        if (IHB_Methods.DistancePoint2Point(point, pt) < preDist)
                        {
                            preDist = IHB_Methods.DistancePoint2Point(point, pt);
                            cPt = pt;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return cPt;
        }




        #endregion Math











        #region Revit Methods








        /// <summary>
        /// Convert Length to internal unit
        /// </summary>
        /// <param name="doc">Current Revit Document</param>
        /// <param name="value">Value to be converted</param>
        /// <returns>Double converted to internal units</returns>
        public static double ConvertLengthToInternalUnits(Document doc, double value)
        {
            #if Revit2022 || Revit2023
            return UnitUtils.ConvertToInternalUnits(value, doc.GetUnits().GetFormatOptions(SpecTypeId.Length).GetSymbolTypeId());
            #else
            return UnitUtils.ConvertToInternalUnits(value, doc.GetUnits().GetFormatOptions(UnitType.UT_Length).DisplayUnits);
            #endif
        }




        /// <summary>
        /// Verify if the element belongs to a certain category
        /// </summary>
        /// <param name="element">Element to be verified</param>
        /// <param name="builtInCategory">BuiltInCategory</param>
        /// <returns>REturns true or false</returns>
        public static bool MatchCategory(Element element, BuiltInCategory builtInCategory)
        {
            if (element != null)
            {
                try
                {
                    if (element.Category.Id.IntegerValue == (int)builtInCategory)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    if (element.Id.IntegerValue == (int)builtInCategory)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }




        /// <summary>
        /// REturn a list of connectrs from the element
        /// </summary>
        /// <param name="element">Current element</param>
        /// <returns>List of connectors in class ConnectorSet.</returns>
        public static ConnectorSet GetConnectors(Element element)
        {
            ConnectorSet connectorSet = new ConnectorSet();
            try
            {
                FamilyInstance familyInstance = element as FamilyInstance;
                connectorSet = familyInstance.MEPModel.ConnectorManager.Connectors;
            }
            catch (Exception e)
            {
                try
                {
                    MEPCurve mepCurve = element as MEPCurve;
                    connectorSet = mepCurve.ConnectorManager.Connectors;
                }
                catch (Exception f) { }

            }
            return connectorSet;
        }


        /// <summary>
        /// Return a list of elements connected to the current element
        /// </summary>
        /// <param name="doc">Current Revit Document</param>
        /// <param name="element">Current element</param>
        /// <returns>List of elements, quando there's something connected, or null, when nothing is connected.</returns>
        public static List<Element> GetAllRefs(Document doc, Element element)
        {
            ConnectorSet connectorSet = IHB_Methods.GetConnectors(element);

            List<Element> refs = new List<Element>();
            if (!connectorSet.IsEmpty)
            {
                foreach (Connector connector in connectorSet)
                {
                    Element connectedElement = IHB_Methods.GetAllRefsFromConnector(doc, connector);
                    refs.Add(connectedElement);
                }
            }

            return refs;
        }

        /// <summary>
        /// Return a list of elements connected to the current connector
        /// </summary>
        /// <param name="doc">Current Revit Document</param>
        /// <param name="connector">Current connector</param>
        /// <returns>List of elements, quando there's something connected, or null, when nothing is connected</returns>
        public static Element GetAllRefsFromConnector(Document doc, Connector connector)
        {
            List<Element> refs = new List<Element>();
            try
            {
                ConnectorSet conRefs = connector.AllRefs;
                foreach (Connector con in conRefs)
                {
                    if (con.Owner.Id.IntegerValue != connector.Owner.Id.IntegerValue
                        && con.ConnectorType != ConnectorType.Logical
                        && !doc.GetElement(con.Owner.Id).Category.Name.ToLower().Contains("insulation"))
                    {
                        Element owner = doc.GetElement(con.Owner.Id);
                        refs.Add(owner);
                    }
                }
            }
            catch (Exception e) { }

            if (refs.Count <= 0)
            {
                return null;
            }
            else
            {
                return refs[0];
            }
        }


        /// <summary>
        /// Highlight elements in the model
        /// </summary>
        /// <param name="uidoc">Current Revit UI Document</param>
        /// <param name="elements">List of elements to be highlighted</param>
        /// <param name="zoom2Fit">True to zoom to fit elements, false otherwise</param>
        public static void HighlightElements(UIDocument uidoc, List<Element> elements, bool zoom2Fit = true)
        {
            if (elements.Count > 0)
            {
                ICollection<ElementId> ids = new List<ElementId>();

                foreach (Element element in elements)
                {
                    if (element != null)
                    {
                        ElementId id = element.Id;
                        Element ele = uidoc.Document.GetElement(id);

                        if (ele != null)
                        {
                            ids.Add(id);
                        }
                    }
                }

                uidoc.Selection.SetElementIds(ids);
                if (zoom2Fit)
                {
                    uidoc.ShowElements(ids);
                }
                
            }
            else
            {
                ElementId invalid = ElementId.InvalidElementId;
                List<ElementId> invalidList = new List<ElementId>();
                invalidList.Add(invalid);
                uidoc.Selection.SetElementIds(invalidList);
            }
            
        }






        #region Extensible Storage

        /// <summary>
        /// Pega a Schema pelo nome
        /// </summary>
        /// <param name="schemaName">Nome da schema</param>
        /// <returns>Retorna a Schema desejada ou null, caso ela não seja encontrada</returns>
        public static Schema GetSchemaByName(string schemaName)
        {
            Schema schema = null;

            List<Schema> schemas = Schema.ListSchemas().ToList();

            if (schemas != null && schemas.Count > 0)
            {
                foreach (Schema sc in schemas)
                {
                    if (sc.SchemaName == schemaName)
                    {
                        schema = sc;
                        break;
                    }
                }
            }

            return schema;
        }

        public static void SetSchemaFieldValue<T>(Schema schema, string fieldName, T data, Element element)
        {
            Field field = schema.GetField(fieldName);

            Entity entity = new Entity(schema);
            entity.Set(field, data);

            element.SetEntity(entity);
        }

        public static Schema AssignFieldToSchema<T>(SchemaBuilder schemaBuilder, string fieldName, string fieldDocumentation = "")
        {
            schemaBuilder = IHB_Methods.AssignFieldToSchemaBuilder(schemaBuilder, typeof(T), fieldName, fieldDocumentation);
            Schema schema = schemaBuilder.Finish();

            return schema;
        }


        /// <summary>
        /// Adiciona um field ao Schema Builder.
        /// </summary>
        /// <param name="schemaBuilder">O Schema builder atual</param>
        /// <param name="type">O tipo de dado que o Field irá receber. Quando partir de um Field existente, usar field.ValueType, quando partir do zero, usar typeof(string), por exemplo</param>
        /// <param name="fieldName">Nome do Field</param>
        /// <param name="fieldDocumentation">Documentação do Filed</param>
        /// <returns>Retorna o Schema Builder atualizado ou o schema builder anterior, caso o tipo de dado do field a ser adicionado não seja aceito.</returns>
        public static SchemaBuilder AssignFieldToSchemaBuilder(SchemaBuilder schemaBuilder, Type type, string fieldName, string fieldDocumentation = "")
        {
            SchemaBuilder preSchemaBuilder = schemaBuilder; //Backup do schema builder caso o tipo de dado do campo não seja aceito

            FieldBuilder fieldBuilder = null;

            try
            {
                //The supported types are Boolean, Byte, Int16, Int32, Float, Double, ElementId, GUID, String, XYZ, UV and Entity.
                if (type == typeof(bool) || type == typeof(Boolean))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(bool));
                }
                else if (type == typeof(byte) || type == typeof(Byte))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(byte));
                }
                else if (type == typeof(int) || type == typeof(Int16) || type == typeof(Int32))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(int));
                }
                else if (type == typeof(float))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(float));
                }
                else if (type == typeof(double) || type == typeof(Double))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(double));
                }
                else if (type == typeof(ElementId))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(ElementId));
                }
                else if (type == typeof(Guid))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(Guid));
                }
                else if (type == typeof(string) || type == typeof(String))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(string));
                }
                else if (type == typeof(XYZ))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(XYZ));
                }
                else if (type == typeof(UV))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(UV));
                }
                else if (type == typeof(Entity))
                {
                    fieldBuilder = schemaBuilder.AddSimpleField(fieldName, typeof(Entity));
                }

                if (fieldBuilder != null)
                {
                    fieldBuilder.SetDocumentation(fieldDocumentation);

                    return schemaBuilder;
                }
                else
                {
                    return preSchemaBuilder;
                }
            }
            catch (Exception e)
            {
                return preSchemaBuilder;
            }
        }




        /// <summary>
        /// Retorna o valor de um campo da Schema com base em seu nome.
        /// </summary>
        /// <param name="schemaName">Nome da schema</param>
        /// <param name="fieldName">Nome do campo</param>
        /// <returns>Retorna o valor do campo, quando encontrado.</returns>
        public static T GetFieldValueFromName<T>(string schemaName, string fieldName, Element element)
        {
            T value = default(T);
            Schema schema = IHB_Methods.GetSchemaByName(schemaName);
            if (schema != null)
            {
                Entity entity = element.GetEntity(schema);
                try
                {
                    value = entity.Get<T>(schema.GetField(fieldName));
                }
                catch (Exception e) { }
            }

            return value;
        }


        public static T GetFieldValue<T>(Field field, Element element)
        {
            T value = default;

            Schema schema = field.Schema;
            if (schema != null)
            {
                Entity entity = element.GetEntity(schema);
                try
                {
                    value = entity.Get<T>(field);
                }
                catch (Exception e) { }
            }

            return value;
        }



        #endregion Extensible Storage




        #endregion Revit






        #region Strings

        public static string RemoverAcentuacao(this string text, bool toLower = false)
        {
            string result = new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            if (toLower)
            {
                return result.ToLower();
            }
            else
            {
                return result;
            }
        }

        public static List<string> SplitString(string text, string separator)
        {
            if (separator.Length > 1)
            {
                return text.Split(new[] { separator }, StringSplitOptions.None).ToList();
            }
            else
            {
                char sep = separator[0];
                return text.Split(sep).ToList();
            }
        }

        public static List<string> SplitString(string text, char separator)
        {
            return text.Split(separator).ToList();
        }

        #endregion







        #region Json

        public static T JsonStringToClass<T>(string value)
        {
            T obj = JsonConvert.DeserializeObject<T>(value);

            return obj;
        }

        public static List<T> JsonStringToClassList<T>(string value)
        {
            List<T> listaObj = JsonConvert.DeserializeObject<List<T>>(value);

            return listaObj;
        }


        public static string JsonClassToString<T>(T data)
        {
            string jsonString = JsonConvert.SerializeObject(data);

            return jsonString;
        }

        public static string JsonClassToString<T>(List<T> dataList)
        {
            string jsonString = JsonConvert.SerializeObject(dataList);

            return jsonString;
        }


        #endregion Json







        #region Arrays


        /// <summary>
        /// Retorna os valores únicos de uma lista tipo T
        /// </summary>
        /// <typeparam name="T">Tipo de dado da lista (string, int, double, ...) - identificado automaticamente </typeparam>
        /// <param name="list">Lista a ser usada para pegar os valores únicos</param>
        /// <returns>Retorna uma List de T, onde T é o tipo de dado contido pela lista original</returns>
        public static List<T> UniqueItems<T>(List<T> list)
        {
            List<T> unique = new HashSet<T>(list).ToList();
            return unique;
        }


        #endregion Arrays






        #region Excel


        public static ExcelWorksheet GetWorkSheet(ExcelPackage package, string workSheetName)
        {
            ExcelWorksheet worksheet = null;

            ExcelWorksheets worksheets = package.Workbook.Worksheets;
            foreach (ExcelWorksheet ws in worksheets)
            {
                if (workSheetName == ws.Name)
                {
                    worksheet = ws;
                    break;
                }
            }

            if (worksheet == null)
            {
                worksheet = worksheets.Add(workSheetName);
                package.Save();
            }

            return worksheet;
        }

        public static void WriteXLS(string FilePath, string workSheetName, List<List<string>> dados, int startRow = 1, int startColumn = 1, string clearRange = "A1:Z10000")
        {
            bool erro = false;
            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {

                ExcelWorksheet worksheet = IHB_Methods.GetWorkSheet(package, workSheetName);
                int maxRows = worksheet.Dimension == null ? startRow + 1 : worksheet.Dimension.Rows;

                try
                {
                    worksheet.Cells[clearRange].Clear();
                }
                catch (Exception e)
                {
                    for (int r = startRow; r <= maxRows; r++)
                    {
                        try
                        {
                            for (int c = 1; c <= 36; c++)
                            {
                                worksheet.Cells[r, c].Value = "";
                            }
                        }
                        catch (Exception f)
                        {
                            break;
                        }
                    }

                }

                int i = startRow;
                foreach (List<string> linha in dados)
                {
                    try
                    {
                        for (int j = startColumn; j <= linha.Count; j++)
                        {
                            worksheet.Cells[i, j].Value = linha[j];
                        }
                    }
                    catch (Exception e)
                    {
                        erro = true;
                        TaskDialog.Show("Erro", e.Message);
                    }
                    finally
                    {
                        i++;
                    }
                }

                if (!erro)
                {
                    try
                    {
                        //File.WriteAllBytes(FilePath, package.GetAsByteArray());
                        package.Save();
                        TaskDialog.Show("Sucesso", "Planilha preenchida com sucesso!");
                        System.Diagnostics.Process.Start(FilePath);
                    }
                    catch (Exception e)
                    {
                        erro = true;
                        TaskDialog.Show("Erro", e.Message);
                    }

                }

            }
        }

        public static List<List<string>> ReadXLS(string FilePath, string workSheetName, int startRow = 1, int startColumn = 1)
        {
            string result = "";

            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = IHB_Methods.GetWorkSheet(package, workSheetName);

                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count

                List<List<string>> dados = new List<List<string>>();
                for (int row = startRow; row <= rowCount; row++)
                {
                    List<string> linha = new List<string>();
                    string value = "";
                    for (int col = startColumn; col <= colCount; col++)
                    {
                        //Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value?.ToString().Trim());
                        result += " Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value?.ToString().Trim() + Environment.NewLine;
                        value += worksheet.Cells[row, col].Value?.ToString().Replace(" ", "");
                        linha.Add(worksheet.Cells[row, col].Value?.ToString().Trim());
                        
                    }
                    if (value != "" && value.Replace(" ", "").Length > 0)
                    {
                        dados.Add(linha);
                    }
                }

                return dados;
            }
        }

        #endregion Excel


    }
}
