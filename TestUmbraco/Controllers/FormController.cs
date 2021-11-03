using System;
using System.Net.Mail;
using System.Web.Mvc;
using TestUmbraco.Models;
using Umbraco.Web.Mvc;

namespace TestUmbraco.Controllers
{
  public class FormController : SurfaceController
  {
    public FormController(): base()
    { }

    [HttpPost]
    public ActionResult Submit(ContactFormModel model)
    {
      if (!ModelState.IsValid)
      {
        return CurrentUmbracoPage();
      }

      try
      {
        using (var client = new SmtpClient())
        {
          var msg = new MailMessage();
          msg.Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}";
          msg.To.Add("ndrwpetrenko@gmail.com");
          client.Send(msg);
        }
        return RedirectToCurrentUmbracoPage("submit=true");
      }
      catch (Exception e)
      {
        throw e;
      }

    }
  }
}
