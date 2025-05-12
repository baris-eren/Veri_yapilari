using System;
using System.Collections.Generic;

namespace AnketApp.Models
{
    public class Vote
    {
        public int SurveyId { get; set; }
        public string[] Answers { get; set; }
        public string Username { get; set; }
    }
}
