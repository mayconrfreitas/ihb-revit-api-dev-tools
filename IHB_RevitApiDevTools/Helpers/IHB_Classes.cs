using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using CefSharp;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Media;

namespace IHB_RevitApiDevTools.Helpers
{


    #region Setup
    
    /// <summary>
    /// Class to receive / write information into IHB Journal
    /// </summary>
    internal class JournalFile
    {
        /// <summary>
        /// Record date (yyyy-MM-dd)
        /// </summary>
        internal string Date;

        /// <summary>
        /// Record time (HH-mm-ss)
        /// </summary>
        internal string Time;

        /// <summary>
        /// Autodesk user that ran the command
        /// </summary>
        internal string User;

        /// <summary>
        /// Name of the class executed
        /// </summary>
        internal string Command;

        /// <summary>
        /// Message to be registered
        /// </summary>
        internal string Message;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="user">User that is running the command</param>
        /// <param name="command">Class where it's being executed, usually use the keyword: this</param>
        /// <param name="message">Message to be written into the Journal</param>
        internal JournalFile(string user, Object command, string message)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Time = DateTime.Now.ToString("HH:mm:ss");
            User = user;
            Command = command.GetType().Name.ToString();
            Message = message;
        }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="user">User that is running the command</param>
        /// <param name="commandName">Class where it's being executed (whitin Static Classes write the name of the class where the command is being used)</param>
        /// <param name="message">Message to be written into the Journal</param>
        internal JournalFile(string user, string commandName, string message)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Time = DateTime.Now.ToString("HH:mm:ss");
            User = user;
            Command = commandName;
            Message = message;
        }
    }


    #endregion Setup




    public class SelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
    {
        private BuiltInCategory _builtInCategory;
        private List<BuiltInCategory> _builtInCategoryList;
        private bool _allowReference;
        private bool multiCategories = false;

        public SelectionFilter(BuiltInCategory builtInCategory, bool allowReference = true)
        {
            this._builtInCategory = builtInCategory;
            this._allowReference = allowReference;
            this.multiCategories = false;
        }

        public SelectionFilter(List<BuiltInCategory> builtInCategoryList, bool allowReference = true)
        {
            this._builtInCategoryList = builtInCategoryList;
            this._allowReference = allowReference;
            this.multiCategories = true;
        }

        public bool AllowElement(Element elem)
        {
            if (this.multiCategories)
            {
                foreach (BuiltInCategory builtInCategory in this._builtInCategoryList)
                {
                    if (IHB_Methods.MatchCategory(elem, builtInCategory)) return true;
                }
            }
            else
            {
                if (IHB_Methods.MatchCategory(elem, this._builtInCategory)) return true;
            }

            return false;
            
        }


        public bool AllowReference(Reference reference, XYZ position)
        {
            return _allowReference;
        }
    }



    public static class RevitColors
    {
        public static Autodesk.Revit.DB.Color Red = new Autodesk.Revit.DB.Color(255, 0, 0);
        public static Autodesk.Revit.DB.Color Yellow = new Autodesk.Revit.DB.Color(255, 255, 0);
        public static Autodesk.Revit.DB.Color Green = new Autodesk.Revit.DB.Color(0, 255, 0);
        public static Autodesk.Revit.DB.Color Cyan = new Autodesk.Revit.DB.Color(0, 255, 255);
        public static Autodesk.Revit.DB.Color Blue = new Autodesk.Revit.DB.Color(0, 0, 255);
        public static Autodesk.Revit.DB.Color Magenta = new Autodesk.Revit.DB.Color(255, 0, 255);

        public static Autodesk.Revit.DB.Color DarkGreen = new Autodesk.Revit.DB.Color(0, 138, 7);
        public static Autodesk.Revit.DB.Color Orange = new Autodesk.Revit.DB.Color(255, 130, 20);
        public static Autodesk.Revit.DB.Color Brown = new Autodesk.Revit.DB.Color(102, 48, 0);

        public static Autodesk.Revit.DB.Color White = new Autodesk.Revit.DB.Color(255, 255, 255);
        public static Autodesk.Revit.DB.Color LightGray = new Autodesk.Revit.DB.Color(192, 192, 192);
        public static Autodesk.Revit.DB.Color DarkGray = new Autodesk.Revit.DB.Color(101, 101, 101);
        public static Autodesk.Revit.DB.Color Black = new Autodesk.Revit.DB.Color(0, 0, 0);
        
        public static Autodesk.Revit.DB.Color GenerateRandomColor()
        {
            Random rnd = new Random();
            Autodesk.Revit.DB.Color randomColor = new Autodesk.Revit.DB.Color((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

            return randomColor;
        }
    }


    public class RevitFillPatterns
    {
        public List<FillPatternElement> FillPatterns { get; private set; }
        public RevitFillPatterns(Document doc)
        {
            FillPatterns = new List<FillPatternElement>();

            List<FillPatternElement> fillPatternList = new FilteredElementCollector(doc)
                .WherePasses(new ElementClassFilter(typeof(FillPatternElement)))
                .ToElements()
                .Cast<FillPatternElement>()
                .ToList();

            this.FillPatterns = fillPatternList;
        }

        public ElementId GetSolidPatternId()
        {
            ElementId solidFillPatternId = null;

            foreach (FillPatternElement fp in FillPatterns)
            {
                if (fp.GetFillPattern().IsSolidFill)
                {
                    solidFillPatternId = fp.Id;
                    break;
                }
            }

            return solidFillPatternId;
        }
    }







    #region External classes


    /// <summary>
    /// Chromium RequestHandler
    /// </summary>
    public class RequestHandlerChromium : IRequestHandler
    {
        public IResponse responseChromium { get; private set; }
        public bool CanGetCookies(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request)
        {
            return true;
        }

        public bool CanSetCookie(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
        {
            return true;
        }

        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return true;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            throw new NotImplementedException();
        }

        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            return false;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            return CefReturnValue.Continue;
        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            return false;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return true;
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {
            throw new NotImplementedException();
        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            return true; ;
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
            throw new NotImplementedException();
        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {
            throw new NotImplementedException();
        }

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            throw new NotImplementedException();
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
            throw new NotImplementedException();
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            responseChromium = response;
            return true;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return true;
        }
    }





    public static class UIHelper
    {
        /// <summary>
        /// Finds a parent of a given item on the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="child">A direct or indirect child of the queried item.</param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, a null reference is being returned.</returns>
        public static T FindThisVisualParent<T>(DependencyObject child)
          where T : DependencyObject
        {
            // get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            // we’ve reached the end of the tree
            if (parentObject == null) return null;

            // check if the parent matches the type we’re looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                // use recursion to proceed with next level
                return FindThisVisualParent<T>(parentObject);
            }
        }
    }


    public static class AsyncHelpers
    {
        /// <summary>
        /// Execute's an async Task<T> method which has a void return value synchronously
        /// </summary>
        /// <param name="task">Task<T> method to execute</param>
        public static void RunSync(Func<Task> task)
        {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            synch.Post(async _ =>
            {
                try
                {
                    await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();

            SynchronizationContext.SetSynchronizationContext(oldContext);
        }

        /// <summary>
        /// Execute's an async Task<T> method which has a T return type synchronously
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="task">Task<T> method to execute</param>
        /// <returns></returns>
        public static T RunSync<T>(Func<Task<T>> task)
        {
            var oldContext = SynchronizationContext.Current;
            var synch = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synch);
            T ret = default(T);
            synch.Post(async _ =>
            {
                try
                {
                    ret = await task();
                }
                catch (Exception e)
                {
                    synch.InnerException = e;
                    throw;
                }
                finally
                {
                    synch.EndMessageLoop();
                }
            }, null);
            synch.BeginMessageLoop();
            SynchronizationContext.SetSynchronizationContext(oldContext);
            return ret;
        }

        private class ExclusiveSynchronizationContext : SynchronizationContext
        {
            private bool done;
            public Exception InnerException { get; set; }
            readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
            readonly Queue<Tuple<SendOrPostCallback, object>> items =
                new Queue<Tuple<SendOrPostCallback, object>>();

            public override void Send(SendOrPostCallback d, object state)
            {
                throw new NotSupportedException("We cannot send to our same thread");
            }

            public override void Post(SendOrPostCallback d, object state)
            {
                lock (items)
                {
                    items.Enqueue(Tuple.Create(d, state));
                }
                workItemsWaiting.Set();
            }

            public void EndMessageLoop()
            {
                Post(_ => done = true, null);
            }

            public void BeginMessageLoop()
            {
                while (!done)
                {
                    Tuple<SendOrPostCallback, object> task = null;
                    lock (items)
                    {
                        if (items.Count > 0)
                        {
                            task = items.Dequeue();
                        }
                    }
                    if (task != null)
                    {
                        task.Item1(task.Item2);
                        if (InnerException != null) // the method threw an exeption
                        {
                            throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
                        }
                    }
                    else
                    {
                        workItemsWaiting.WaitOne();
                    }
                }
            }

            public override SynchronizationContext CreateCopy()
            {
                return this;
            }
        }
    }


    public sealed class DynamicJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            return type == typeof(object) ? new DynamicJsonObject(dictionary) : null;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
        }

        #region Nested type: DynamicJsonObject

        private sealed class DynamicJsonObject : DynamicObject
        {
            private readonly IDictionary<string, object> _dictionary;

            public DynamicJsonObject(IDictionary<string, object> dictionary)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");
                _dictionary = dictionary;
            }

            public override string ToString()
            {
                var sb = new StringBuilder("{");
                ToString(sb);
                return sb.ToString();
            }

            private void ToString(StringBuilder sb)
            {
                var firstInDictionary = true;
                foreach (var pair in _dictionary)
                {
                    if (!firstInDictionary)
                        sb.Append(",");
                    firstInDictionary = false;
                    var value = pair.Value;
                    var name = pair.Key;
                    if (value is string)
                    {
                        sb.AppendFormat("{0}:\"{1}\"", name, value);
                    }
                    else if (value is IDictionary<string, object>)
                    {
                        new DynamicJsonObject((IDictionary<string, object>)value).ToString(sb);
                    }
                    else if (value is ArrayList)
                    {
                        sb.Append(name + ":[");
                        var firstInArray = true;
                        foreach (var arrayValue in (ArrayList)value)
                        {
                            if (!firstInArray)
                                sb.Append(",");
                            firstInArray = false;
                            if (arrayValue is IDictionary<string, object>)
                                new DynamicJsonObject((IDictionary<string, object>)arrayValue).ToString(sb);
                            else if (arrayValue is string)
                                sb.AppendFormat("\"{0}\"", arrayValue);
                            else
                                sb.AppendFormat("{0}", arrayValue);

                        }
                        sb.Append("]");
                    }
                    else
                    {
                        sb.AppendFormat("{0}:{1}", name, value);
                    }
                }
                sb.Append("}");
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (!_dictionary.TryGetValue(binder.Name, out result))
                {
                    // return null to avoid exception.  caller can check for null this way...
                    result = null;
                    return true;
                }

                result = WrapResultObject(result);
                return true;
            }

            public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
            {
                if (indexes.Length == 1 && indexes[0] != null)
                {
                    if (!_dictionary.TryGetValue(indexes[0].ToString(), out result))
                    {
                        // return null to avoid exception.  caller can check for null this way...
                        result = null;
                        return true;
                    }

                    result = WrapResultObject(result);
                    return true;
                }

                return base.TryGetIndex(binder, indexes, out result);
            }

            private static object WrapResultObject(object result)
            {
                var dictionary = result as IDictionary<string, object>;
                if (dictionary != null)
                    return new DynamicJsonObject(dictionary);

                var arrayList = result as ArrayList;
                if (arrayList != null && arrayList.Count > 0)
                {
                    return arrayList[0] is IDictionary<string, object>
                        ? new List<object>(arrayList.Cast<IDictionary<string, object>>().Select(x => new DynamicJsonObject(x)))
                        : new List<object>(arrayList.Cast<object>());
                }

                return result;
            }
        }

        #endregion Nested type: DynamicJsonObject
    }






    #endregion Classes Externas








}
