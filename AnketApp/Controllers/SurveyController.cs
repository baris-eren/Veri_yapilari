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

        // GET: Survey
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

        // GET: Survey/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Survey/Create
        [HttpPost]
        public IActionResult Create(Survey survey)
        {
            var surveys = _store.LoadSurveys();
            surveys.Add(survey);
            _store.SaveSurveys(surveys);
            return RedirectToAction("Index");
        }

        // GET: Survey/Fill/{id}
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

        // POST: Survey/Fill/{id}
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

            // Oyu kaydet
            var vote = new Vote { SurveyId = id, Answers = answers, Username = username };
            var votes = _store.LoadVotes();
            votes.Add(vote);
            _store.SaveVotes(votes);

            return RedirectToAction("Index");
        }
    }
}
