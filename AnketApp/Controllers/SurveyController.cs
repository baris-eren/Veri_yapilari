using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AnketApp.Models;
using AnketApp.Data;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json; 
using System.IO;


namespace AnketApp.Controllers
{
    public class SurveyController : Controller
    {
        private readonly JsonStore _store;

        public SurveyController(JsonStore store)
        {
            _store = store;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var surveys = _store.LoadSurveys();
            var votes = _store.LoadVotes();

            var surveyVoteCount = surveys.ToDictionary(
                s => s.Id, 
                s => votes.Count(v => v.SurveyId == s.Id)
            );

            var priorityQueue = new PriorityQueue<Survey, int>(
                comparer: Comparer<int>.Create((x, y) => y.CompareTo(x)) // Azalan sıralama
            );

            foreach (var survey in surveys)
            {
                priorityQueue.Enqueue(survey, surveyVoteCount[survey.Id]);
            }

            var sortedSurveys = new List<Survey>();
            while (priorityQueue.Count > 0)
            {
                sortedSurveys.Add(priorityQueue.Dequeue());
            }

            return View(sortedSurveys);
        }

        
        [HttpGet]
        public IActionResult Fill(int id)
        {
            var survey = _store.LoadSurveys().FirstOrDefault(s => s.Id == id);
            if (survey == null)
            {
                return RedirectToAction("Index");
            }

            return View(survey);
        }

        [HttpPost]
        public IActionResult Fill(int id, string[] answers)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var username = HttpContext.Session.GetString("User");  // Kullanıcı adını session'dan al
            var surveys = _store.LoadSurveys();
            var survey = surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return RedirectToAction("Index");

            var votes = _store.LoadVotes();
            var votedUsers = new HashSet<string>(
                votes
                    .Where(v => v.SurveyId == id)
                    .Select(v => v.Username)
            );

            if (votedUsers.Contains(username))
            {
                TempData["Mesaj"] = "Bu ankete zaten oy verdiniz!";
                return RedirectToAction("Index");
            }

            var vote = new Vote
            {
                SurveyId = id,
                Answers = answers,
                Username = username
            };

            votes.Add(vote);
            _store.SaveVotes(votes);

            TempData["Mesaj"] = "Oylamanız başarıyla kaydedildi!";
            return RedirectToAction("Index");
        }

        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "bin", "Debug", "net8.0", "votes.json");
        [HttpGet]
        public IActionResult Results()
        {
            var surveyResponses = GetSurveyResponsesFromJson(filePath);
            return View(surveyResponses);
        }

        private List<SurveyResponse> GetSurveyResponsesFromJson(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<SurveyResponse>();
            }

            var json = System.IO.File.ReadAllText(filePath);
            var surveyResponses = JsonConvert.DeserializeObject<List<SurveyResponse>>(json);
            return surveyResponses;
        }
        [HttpGet]
        public IActionResult Resultlist()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var surveys = _store.LoadSurveys();
            var votes = _store.LoadVotes();

            var surveyVoteCount = surveys.ToDictionary(
                s => s.Id, 
                s => votes.Count(v => v.SurveyId == s.Id)
            );

            var priorityQueue = new PriorityQueue<Survey, int>(
                comparer: Comparer<int>.Create((x, y) => y.CompareTo(x))
            );

            foreach (var survey in surveys)
            {
                priorityQueue.Enqueue(survey, surveyVoteCount[survey.Id]);
            }

            var sortedSurveys = new List<Survey>();
            while (priorityQueue.Count > 0)
            {
                sortedSurveys.Add(priorityQueue.Dequeue());
            }

            return View(sortedSurveys);
        }
        
    }
}
