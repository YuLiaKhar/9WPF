using Microsoft.Win32;
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

namespace Wpf8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> style = new List<string>() { "Светлая тема", "Темная тема" };
            styleBox.ItemsSource = style;
            styleBox.SelectionChanged += ThemeChanged;
            styleBox.SelectedIndex = 0;
        }

        private void ThemeChanged(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble((sender as ComboBox).SelectedItem as string);
            if (textBox != null)
            {
                textBox.FontSize = fontSize;
            }
        }

        private void textBold_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.SetValue(TextBox.FontWeightProperty, FontWeights.Bold);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.SetValue(TextBox.FontStyleProperty, FontStyles.Italic);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.SetValue(TextBox.TextDecorationsProperty, TextDecorations.Underline);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.SetValue(TextBox.ForegroundProperty, Brushes.Black);
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                if (textBox != null)
                {
                    textBox.SetValue(TextBox.ForegroundProperty, Brushes.Red);
                }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textBox != null && textBox.Text.Length != 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}
