using Autodesk.Revit.UI;
using IHB_RevitApiDevTools.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Autodesk.Revit.DB;
using IHB_RevitApiDevTools.CodeEditor.Models;
using IHB_RevitApiDevTools.CodeEditor.Commands;

namespace IHB_RevitApiDevTools.CodeEditor.Views
{
    /// <summary>
    /// Interaction logic for CodeEditor_UI.xaml
    /// </summary>
    public partial class CodeEditor_UI : Window
    {

        public bool run;
        public ExternalCommandData commandData;
        public string message;
        public ElementSet elementSet;
        private readonly string baseCode = CodeEditor_Properties.baseCode;

        public CodeEditor_UI(string Title, ExternalCommandData _commandData, ref string _message, ElementSet _elementSet)
        {
            this.run = false;
            commandData = _commandData;
            message = _message;
            elementSet = _elementSet;

            string base64_logo = IHB_Properties.myLogo64;
            System.Drawing.Image img_logo = System.Drawing.Image.FromStream(new MemoryStream(Convert.FromBase64String(base64_logo)));

            InitializeComponent();

            IHB_Properties.IHBFolder = IHB_Methods.GetIHBFolder();
            string text = "";
            if (!File.Exists(IHB_Properties.IHBCsharpBaseFile))
            {
                using (StreamWriter sw = new StreamWriter(IHB_Properties.IHBCsharpBaseFile))
                {
                    sw.WriteLine(baseCode);
                    text = baseCode;
                }
            }

            using (StreamReader reader = new StreamReader(IHB_Properties.IHBCsharpBaseFile))
            {
                text = reader.ReadToEnd();
            }


            if (text == "")
            {
                using (StreamWriter sw = new StreamWriter(IHB_Properties.IHBCsharpBaseFile))
                {
                    sw.WriteLine(baseCode);
                    text = baseCode;
                }
            }

            this.logo.Source = IHB_Methods.BitmapToBitmapSource(IHB_Methods.ResizeImage(img_logo, IHB_Properties.logoWidth, IHB_Properties.logoHeight));

            this.textEditor.Text = text;


            this.ListBxTitle.Text = Title;

            Loaded += MainWindow_Loaded;
        }



        #region Funcionamento da Janela
        public void move_window(object sender, MouseButtonEventArgs e)
        {
            IHB_Methods.move_window(this, sender, e);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            IHB_Methods.btnAbout_Click(sender, e);
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            IHB_Methods.btnHelp_Click(sender, e);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            IHB_Methods.btnClose_Click(this, sender, e);
        }




        #endregion Funcionamento da Janela



        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;
        }


        private void btnMain_Click(object sender, RoutedEventArgs e)
        {

            string src = this.textEditor.Text;


            try
            {
                Result codeResult = ScriptRunner.RunScript(src, commandData, ref message, elementSet);
            }
            catch (Exception f)
            {
                TaskDialog.Show("Erro", f.Message);
            }

            this.Focus();
            //this.run = true;
            //this.Close();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(IHB_Properties.IHBCsharpBaseFile))
            {
                sw.WriteLine(this.textEditor.Text);
            }

            string text = "";
            using (StreamReader reader = new StreamReader(IHB_Properties.IHBCsharpBaseFile))
            {
                text = reader.ReadToEnd();
            }

            if (text == "" && this.textEditor.Text != "")
            {
                TaskDialog.Show("Error", "No code was saved!");
            }
            else
            {
                TaskDialog.Show("Success", "Code successfully saved!");
            }
            this.Focus();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.textEditor.Text = this.baseCode;
        }

        
    }
}
