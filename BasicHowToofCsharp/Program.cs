using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicHowToofCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostName = Dns.GetHostName();
            Console.WriteLine("HostName: " + hostName);

            var hostname = Dns.GetHostByName(hostName);
            var ip = hostname.AddressList;
            Console.WriteLine("IP Address  :" + ip[0].ToString());

            string emailId = "agnihotriketan@gmail.com";
            Console.WriteLine("check" + emailId + "is valid email Id");

            var urlPattern = "http(s)?://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?";
            var emailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(emailId, emailPattern))
                Console.WriteLine("valid Email");
            else
                Console.WriteLine("Invalid Email");

            var x = SendMail("kagnihotri@tavisca.com", "codelogin10@gmail.com", "xxx@gmail.com", "test", "test");

            Console.ReadLine();
        }

        public static string SendMail(string toList, string from, string ccList, string subject, string body)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("*****@gmail.com", "******");

                smtpClient.Send(message);
                msg = "Successful<BR>";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
