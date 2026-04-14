using System.Windows;
using System.Windows.Controls;

namespace Lesson2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _correctFirstAnswer = "Н.М. Карамзин";
    private string _correctSecondAnswer = "Началом промышленного переворота";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is not CheckBox checkBox)
        {
            return;
        }

        PatronymicTextFiled.Text = string.Empty;

        if (!checkBox.IsChecked.HasValue)
        {
            return;
        }

        PatronymicTextFiled.IsEnabled = !checkBox.IsChecked.Value;
    }


    private void RadioButton_FirstQuestion_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton radioButton)
        {
            return;
        }

        var result = radioButton.Content;

        if (_correctFirstAnswer.Equals(result))
        {
            MessageBox.Show("Правильно");
        }
    }

    private void RadioButton_SecondQuestion_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton radioButton)
        {
            return;
        }

        var result = radioButton.Content;

        if (_correctSecondAnswer.Equals(result))
        {
            MessageBox.Show("Правильно");
        }
    }
}