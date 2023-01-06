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

namespace IHB_RevitApiDevTools.Helpers.UI
{
    /// <summary>
    /// Interaction logic for BLS_SimplePromptInput.xaml
    /// </summary>
    public partial class BLS_SimplePromptInput : Window
    {
        private string _Title;

        /// <summary>
        /// Construtor da janela.
        /// </summary>
        /// <param name="Title">Título de única linha (não usar quebra de linha)</param>
        public BLS_SimplePromptInput(string Title = "Input:")
        {
            _Title = Title;

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();

            this.message.Text = _Title;
            this.prompt.Focus();

            
        }

        public void move_window(object sender, MouseButtonEventArgs e)
        {
            IHB_Methods.move_window(this, sender, e);
        }


        //TODO: Descomentar linha abaixo para que a janela inicialize na posição onde se encontra o ponteiro do mouse
        //protected override void OnContentRendered(EventArgs e)
        //{
        //    base.OnContentRendered(e);
        //    MoveBottomLeftEdgeOfWindowToMousePosition();
        //}

        private void MoveBottomLeftEdgeOfWindowToMousePosition()
        {
            var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            var mouse = transform.Transform(GetMousePosition());
            Left = mouse.X;
            Top = mouse.Y - ActualHeight;
        }

        public System.Windows.Point GetMousePosition()
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new System.Windows.Point(point.X, point.Y);
        }

        //private void Window_MouseMove(object sender, MouseEventArgs e)
        //{
        //    System.Drawing.Point position = System.Windows.Forms.Cursor.Position;
        //    double pX = position.X;
        //    double pY = position.Y;

        //    Left = pX;
        //    Top = pY - ActualHeight;
        //}


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }

            if (e.Key == Key.Escape)
            {
                this.prompt.Text = "";
                this.Close();
            }
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            this.prompt.Focus();
        }
    }
}
