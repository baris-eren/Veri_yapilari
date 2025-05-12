using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar

namespace AnketApp.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }
}
