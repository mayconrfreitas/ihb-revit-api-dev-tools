using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IHB_RevitApiDevTools.Helpers.UI
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class IHB_ProgressBar : Window, IDisposable
    {
        public bool IsClosed { get; private set; }
        private Task taskDoEvent { get; set; }

        /// <summary>
        /// Construtor da ProgressBar.
        /// PS: User ProgressBar.Update() no fim do loop para atualizar a barra.
        /// </summary>
        /// <param name="title">Título que aparece na barra de títulos da janela</param>
        /// <param name="msg">Mensagem para aparecer sobre a barra de carregamento</param>
        /// <param name="maximum">Número de registros a serem carregados (geralmente usar a contagem da lista a ser iterada)</param>
        public IHB_ProgressBar(string title = "", string msg = "", double maximum = 100)
        {
            InitializeComponent();
            InitializeSize();
            this.Focus();
            this.Title = title;
            this.txtMessage.Text = msg;
            this.progressBar.Maximum = maximum;
            this.Closed += (s, e) =>
            {
                IsClosed = true;
            };
        }


        #region Funcionamento da Janela

        public void move_window(object sender, MouseButtonEventArgs e)
        {
            IHB_Methods.move_window(this, sender, e);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            IHB_Methods.btnClose_Click(this, sender, e);
        }

        #endregion Funcionamento da Janela



        public void Dispose()
        {
            if (!IsClosed) Close();
        }

        public bool Update(double value = 1.0)
        {
            UpdateTaskDoEvent();
            if (this.progressBar.Value + value >= progressBar.Maximum)
            {
                progressBar.Maximum += value;
            }
            progressBar.Value += value;
            return IsClosed;
        }

        private void UpdateTaskDoEvent()
        {
            if (taskDoEvent == null) taskDoEvent = GetTaskUpdateEvent();
            if (taskDoEvent.IsCompleted)
            {
                Show();
                DoEvents();
                taskDoEvent = null;
            }
        }

        private Task GetTaskUpdateEvent()
        {
            return Task.Run(async () => { await Task.Delay(500); });
        }

        private void DoEvents()
        {
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        }

        private void InitializeSize()
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.Topmost = true;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
