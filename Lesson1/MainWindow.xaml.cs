using Lesson1.Model;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Lesson1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var personJson = File.ReadAllText("Some path");
        var person = JsonSerializer.Deserialize<Person>(personJson);

        FirstNameTextBox.Text = person.FirstName;
        LastNameTextBox.Text = person.LastName;
        PatronymicTextBox.Text = person.Patronymic;
    }

    private void Button_Click_SaveData(object sender, RoutedEventArgs e)
    {
        ErrorResultFirstName.Text = string.Empty;
        ErrorResultLastName.Text = string.Empty;
        ErrorResultPatronymic.Text = string.Empty;

        if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
        {
            ErrorResultFirstName.Text = "Некорректное имя";
            return;
        }

        if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
        {
            ErrorResultLastName.Text = "Некорректная фамилия";
            return;
        }

        var patronymic = PatronymicTextBox.Text.Trim();
        if (PatronymicTextBox.Text == string.Empty || patronymic.Length > 0)
        {
            var person = new Person
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Patronymic = PatronymicTextBox.Text,
            };

            File.WriteAllText("Some path", JsonSerializer.Serialize(person));

            //Сохраняю данные
        }
        else if (patronymic == string.Empty)
        {
            ErrorResultPatronymic.Text = "Некорректное отчество";
            return;
        }
    }
}