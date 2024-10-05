using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;


namespace WebApplication10.Controllers
{
    public class TestController : Controller
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question
            {
                Text = "Какой язык используется для разработки ASP.NET?",
                Answers = new List<string> { "C#", "Python", "Java", "Ruby" },
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Text = "Что такое MVC?",
                Answers = new List<string> { "Модель-Вид-Контроллер", "Модель-Вид-Компонент", "Модуль-Вид-Контроллер", "Модель-Вид-Компьютер" },
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Text = "Какой элемент используется для передачи данных в представление?",
                Answers = new List<string> { "ViewBag", "ViewData", "Model", "Все вышеперечисленное" },
                CorrectAnswerIndex = 3
            },
            new Question
            {
                Text = "Какой метод HTTP используется для отправки данных на сервер?",
                Answers = new List<string> { "GET", "POST", "PUT", "DELETE" },
                CorrectAnswerIndex = 1
            },
            new Question
            {
                Text = "Какой фреймворк используется для создания REST API в .NET?",
                Answers = new List<string> { "ASP.NET MVC", "ASP.NET Web API", "ASP.NET Core", "Blazor" },
                CorrectAnswerIndex = 1
            },
            new Question
            {
                Text = "Какой метод используется для отображения представления в контроллере?",
                Answers = new List<string> { "ViewResult()", "RenderView()", "ShowView()", "DisplayView()" },
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Text = "Что такое Razor?",
                Answers = new List<string> { "Язык программирования", "Синтаксис для создания представлений", "Фреймворк", "Библиотека" },
                CorrectAnswerIndex = 1
            }
        };

        public IActionResult Index1()
        {
            return View(_questions);
        }

        [HttpPost]
        public IActionResult SubmitAnswers(List<int> selectedAnswers)
        {
            int score = 0;

            for (int i = 0; i < selectedAnswers.Count; i++)
            {
                if (selectedAnswers[i] == _questions[i].CorrectAnswerIndex)
                {
                    score++;
                }
            }

            ViewBag.Score = score;
            ViewBag.TotalQuestions = _questions.Count;

            return View("Result");
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}
