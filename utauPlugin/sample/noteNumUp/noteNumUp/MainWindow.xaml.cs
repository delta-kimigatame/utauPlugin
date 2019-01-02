using System;
using System.Windows;
using utauPlugin;

namespace noteNumUp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private UtauPlugin utauPlugin;
        string[] args = Environment.GetCommandLineArgs();
        public MainWindow()
        {
            InitializeComponent();
            utauPlugin = new UtauPlugin(args[1]);
            utauPlugin.Input();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Note note in utauPlugin.note)
            {
                note.SetNoteNum(note.GetNoteNum() + 1);
            }
            utauPlugin.Output();
            Close();
        }
    }
}
