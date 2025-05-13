using System;
using System.Collections.Generic;  
using Newtonsoft.Json; 
using System.Linq;


namespace AnketApp.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
    }
}
