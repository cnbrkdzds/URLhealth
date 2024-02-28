using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace URLhealth.UTILITIES.MailManager
{
    public class MailOperations
    {
        public static bool SendMail(string alici, string baslik, string body)
        {
            try
            {
                string mail = "xxxxx"; //gönderen mail

                string subject = "";
                if (body == null)
                    body = "";
                subject = baslik;

                string host = "***";//mail gönderecek ana bilgisayar(server
                int port = 587; //maillerin çıkış yapacağı port=kapı
                string login = "****";
                string pass = "****";

                MailMessage e_posta = new MailMessage();
                e_posta.From = new MailAddress(mail, "URLhealthAPP");

                string[] aliciMailleri = null;
                if (alici != "")
                {
                    aliciMailleri = alici.Replace(" ", "").Split(',');
                }
                if (aliciMailleri != null)
                {
                    foreach (string m in aliciMailleri)
                    {
                        //kontrol varmış burda aq ondan boş geçmiş az önce
                        e_posta.To.Add(m);
                    }
                }
                e_posta.Subject = subject;
                e_posta.IsBodyHtml = true;
                e_posta.Body = body;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential(login, pass);
                smtp.Port = port;
                smtp.Host = host;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                //smtp.TargetName = "STARTTLS/smtp.office365.com";
                smtp.Send(e_posta);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
