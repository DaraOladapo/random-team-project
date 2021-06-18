using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using TeamAssignment;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<AppSettings> options)
        {
            Configuration = options.Value;
        }
        private AppSettings Configuration;
        public async Task<IActionResult> Index()
        {
            var teamsAndPeople = JsonConvert.DeserializeObject<List<Team>>(await new HttpClient().GetStringAsync($"{Configuration.TeamAssignmentServiceURL}/teamassignment/get-all"));
            var FormModel = new FormModel();
            ViewBag.Teams = teamsAndPeople;
            return View(FormModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(FormModel formModel)
        {
            var name = formModel.Name;
            string jsonTransport = JsonConvert.SerializeObject(name);
            var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
            var httpResponse = await new HttpClient().PostAsync($"{Configuration.TeamAssignmentServiceURL}/teamassignment/assign", jsonPayload);
            return httpResponse.StatusCode == HttpStatusCode.OK ? RedirectToAction("Index"):RedirectToAction("Error");
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}
