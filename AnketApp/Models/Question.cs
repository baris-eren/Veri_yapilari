using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar
using Newtonsoft.Json;  // JSON işlemleri için gerekli
using System.Linq;


namespace AnketApp.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
    }
}
