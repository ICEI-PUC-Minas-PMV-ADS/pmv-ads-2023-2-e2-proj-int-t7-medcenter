using medcenter_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace medcenter_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Empresas()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendContact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["message"] = "Informações Inválidas!";
                return View("Empresas", model);
            }

            var emailMessage = new MailMessage();
            emailMessage.Subject = "Contato de " + model.Name;
            emailMessage.From = new MailAddress("bruno.n.vs@hotmail.com");
            emailMessage.To.Add("bruno.n.vs@hotmail.com");
            emailMessage.IsBodyHtml = true;

            emailMessage.Body = "<p>Nome da Empresa: " + model.Name + "</p> <p>Nome Completo: " + model.Name2 + "</p>" + 
                "<p>Telefone com DDD: " + model.Phone + "</p>" + "<p>E-mail: " + model.Email + "</p>";

            var client = new SmtpClient("smtp-mail.outlook.com", 587);
        
                client.Credentials = new NetworkCredential("bruno.n.vs@hotmail.com", "p!zZa456123");
                client.EnableSsl = true;
               
            try {
                client.Send(emailMessage);
            } catch (Exception ex) {
                ViewData["message"] = "Falha ao enviar mensagem : " + ex.Message;
            }


            return View("SendContact");
        }

    }
}