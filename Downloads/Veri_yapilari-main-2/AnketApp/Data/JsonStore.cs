using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using AnketApp.Models;

namespace AnketApp.Data
{
    public class JsonStore
    {
        private readonly string _surveyFile;
        private readonly string _userFile;
        private readonly string _voteFile;

        public JsonStore()
        {
            
            _surveyFile = Path.Combine(AppContext.BaseDirectory, "surveys.json");
            _userFile = Path.Combine(AppContext.BaseDirectory, "users.json");
            _voteFile = Path.Combine(AppContext.BaseDirectory, "votes.json");
        }

        public List<Survey> LoadSurveys()
        {
            if (!File.Exists(_surveyFile)) return new List<Survey>();
            var json = File.ReadAllText(_surveyFile);
            return JsonConvert.DeserializeObject<List<Survey>>(json) ?? new List<Survey>();
        }

        public void SaveSurveys(List<Survey> surveys)
        {
            var json = JsonConvert.SerializeObject(surveys, Formatting.Indented);
            File.WriteAllText(_surveyFile, json);
        }

        public List<User> LoadUsers()
        {
            if (!File.Exists(_userFile)) return new List<User>();
            var json = File.ReadAllText(_userFile);
            return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
        }

        public void SaveUsers(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(_userFile, json);
        }

        public List<Vote> LoadVotes()
        {
            if (!File.Exists(_voteFile)) return new List<Vote>();
            var json = File.ReadAllText(_voteFile);
            return JsonConvert.DeserializeObject<List<Vote>>(json) ?? new List<Vote>();
        }

        public void SaveVotes(List<Vote> votes)
        {
            var json = JsonConvert.SerializeObject(votes, Formatting.Indented);
            File.WriteAllText(_voteFile, json);
        }
    }
}
