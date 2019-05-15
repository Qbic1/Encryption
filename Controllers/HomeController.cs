using Encryption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Encryption.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        private Dictionary<Char, Char> replaces = new Dictionary<char, char>();

        public HomeController()
        {
            IEnumerable<Replace> dbReplaces = db.Replaces;
            foreach (var r in dbReplaces)
            {
                replaces.Add(r.OldSymbol[0], r.NewSymbol[0]);
            }
        }

        private string Encrypt(string text)
        {
            char[] temp = text.ToCharArray();
            StringBuilder sb = new StringBuilder(string.Empty);
            foreach (char c in temp)
                sb.Append(replaces.ContainsKey(c) ? replaces[c] : c);
            return sb.ToString();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddMessage(Message message)
        {
            message.DT = DateTime.Now;
            db.Messages.Add(message);
            db.SaveChanges();
            message.Text = Encrypt(message.Text);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMessages()
        {
            List<Message> messages = db.Messages.ToList<Message>();

            foreach (var m in messages)
            {
                m.Text = Encrypt(m.Text);
            }

            return Json(messages, JsonRequestBehavior.AllowGet);
        }
    }
}