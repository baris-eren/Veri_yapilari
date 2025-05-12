using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar
using Newtonsoft.Json;  // JSON işlemleri için gerekli
using System.Linq;


namespace AnketApp.Models
{
    public class Vote
    {
        public int SurveyId { get; set; }
        public string[] Answers { get; set; }
    }
}
