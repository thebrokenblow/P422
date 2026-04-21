namespace Lesson3.ViewModel;

public class MyViewModel
{
    private string firstName;

    public string FirstName
    {
        get
        {
            return firstName;
        }
        set 
        {
            firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            lastName = value;
        }
    }
}
