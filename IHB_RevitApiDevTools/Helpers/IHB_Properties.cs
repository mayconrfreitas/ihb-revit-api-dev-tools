﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IHB_RevitApiDevTools.Helpers
{
    public static class IHB_Properties
    {

        #region IHB General
        /// <summary>
        /// Revit version.
        /// </summary>
        #if Revit2020
        public const string RevitVersion = "2020";
        #elif Revit2022
        public const string RevitVersion = "2022";
        #elif Revit2023
        public const string RevitVersion = "2023";
        #endif

        /// <summary>
        /// IHB logo in base 64.
        /// https://onlinepngtools.com/resize-png
        /// </summary>
        public static string myLogo64 = "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";
        public const int logoWidth = 116;
        public const int logoHeight = 56;


        //Assembly information
        internal const string AssemblyTitle = "IHB_RevitApiDevTools";
        internal const string AssemblyDescription = "Revit " + IHB_Properties.RevitVersion + " addin.";
        internal const string AssemblyCompany = "I Have BIM";
        internal const string AssemblyProduct  = "I Have BIM Revit C# .NET Add-In";

        /// <summary>
        /// Use this in .addin, on VendorId field and in Extensible Storage.
        /// </summary>
        internal const string VendorId = "br.com.ihavebim";



        /// <summary>
        /// Windows user
        /// </summary>
        internal static string CurrentWindowsUser = IHB_Methods.GetWindowsCurrentUser();


        /// <summary>
        /// User's Documents folder path
        /// </summary>
        public static string MyDocumentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// User's roaming folder path
        /// </summary>
        public static string AppDataRoamingFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// IHB folder path
        /// </summary>
        public static string IHBFolderPath = Path.Combine(IHB_Properties.AppDataRoamingFolderPath, "IHB");


        /// <summary>
        /// IHB DirectoryInfo.
        /// Must be associated during Revit inicialization.
        /// </summary>
        internal static DirectoryInfo IHBFolder;



        /// <summary>
        /// IHB Journal file.
        /// </summary>
        internal static string IHBJournalFilePath = Path.Combine(IHBFolderPath, "IHBJornal.ihb");


        /// <summary>
        /// C# base file to save IHB code editor content.
        /// </summary>
        internal static string IHBCsharpBaseFile = Path.Combine(IHBFolderPath, "IHBCsharpBaseFile.cs");




        #endregion IHB General





        public static double Feet = 304.8;






        #region Revit


        /// <summary>
        /// Current revit user
        /// </summary>
        public static string RevitUsername;

        /// <summary>
        /// Revit UI Controlled Application
        /// </summary>
        public static UIControlledApplication uiControlledApplication;


        /// <summary>
        /// Revit.ini file, from folder AppData/Roaming
        /// </summary>
        public static string RevitINIFilePath = IHB_Properties.AppDataRoamingFolderPath + $@"\Autodesk\Revit\Autodesk Revit {IHB_Properties.RevitVersion}\Revit.ini";


        #endregion Revit

    }
}
