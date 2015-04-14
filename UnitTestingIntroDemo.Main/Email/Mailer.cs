using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingIntroDemo.Main.Email
{
    public class Mailer
    {
        public virtual void Send(string from, string to, string subject, string message)
        {
            Console.WriteLine(string.Format("Sending email to '{0}'", to));
        }
    }
}
