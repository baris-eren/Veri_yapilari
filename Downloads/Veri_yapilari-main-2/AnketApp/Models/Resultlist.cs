using System.Collections.Generic;
using System.Linq;

public class Result
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuestionResult> Questions { get; set; }
}

public class QuestionResult
{
    public string QuestionText { get; set; }
    public List<string> Options { get; set; }
    public List<int> Votes { get; set; }
}
