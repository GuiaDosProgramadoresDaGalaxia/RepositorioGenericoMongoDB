using GerenciadorMongo.Apresentacao.ViewModels.Aplicacao;
using System.Windows;

namespace GerenciadorMongo.Apresentacao.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
