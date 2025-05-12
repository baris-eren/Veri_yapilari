using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AnketApp.Models;
using AnketApp.Data;
using System.Linq;

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
            return View(surveys);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Survey survey)
        {
            var surveys = _store.LoadSurveys();
            surveys.Add(survey);
            _store.SaveSurveys(surveys);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Fill(int id)
        {
            var survey = _store.LoadSurveys().FirstOrDefault(s => s.Id == id);
            return View(survey);
        }

        [HttpPost]
        public IActionResult Fill(int id, string[] answers)
        {
            var survey = _store.LoadSurveys().FirstOrDefault(s => s.Id == id);
            if (survey == null) return RedirectToAction("Index");

            var vote = new Vote { SurveyId = id, Answers = answers };
            var votes = _store.LoadVotes();
            votes.Add(vote);
            _store.SaveVotes(votes);

            return RedirectToAction("Index");
        }
    }
}
