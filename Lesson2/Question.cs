namespace Lesson2;

public class Question
{
    public string TextQuestion { get; }

    private Dictionary<string, bool> _isCorrectByAnswer;

    public Question(string textQuestion, Dictionary<string, bool> isCorrectByAnswer)
    {
        TextQuestion = textQuestion;
        _isCorrectByAnswer = isCorrectByAnswer;
    }

    public bool IsCorrectByAnswer(List<string> answer)
    {
        for (int i = 0; i < answer.Count; i++)
        {
            if (!_isCorrectByAnswer[answer[i]])
            {
                return false;
            }
        }

        return true;
    }
}
