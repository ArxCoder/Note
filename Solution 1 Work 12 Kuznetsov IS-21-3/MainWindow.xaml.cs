using Solution_1_Work_12_Kuznetsov_IS_21_3.NewFolder1;
using Solution_1_Work_12_Kuznetsov_IS_21_3.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
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

namespace Solution_1_Work_12_Kuznetsov_IS_21_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\Notes.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private BindingList<Note> Notes;
        private File_Input_Output fileService;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileService = new File_Input_Output(PATH);
            try
            {
                Notes = fileService.LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); this.Close(); }
            DealsList.ItemsSource = Notes;
            Notes.ListChanged += Notes_ListChanged;
        }

        private void Notes_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted 
                || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileService.SaveData(sender);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); this.Close(); }
            }
        }
    }
}