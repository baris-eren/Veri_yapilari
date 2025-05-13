using System.Collections.Generic;
public class SurveyResponse
{

    public int SurveyId { get; set; }
    public List<string> Answers { get; set; }
    public string Username { get; set; }
}
