using System;

namespace qccl.toolbox.mail
{
    public class smtpclient
    {
        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="clientaddress">The clientaddress.</param>
        /// <param name="usessl">if set to <c>true</c> [usessl].</param>
        /// <param name="to">To.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="ishtml">if set to <c>true</c> [ishtml].</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Smpt Host
        /// or
        /// Smpt Sender
        /// or
        /// Smpt Receiver
        /// or
        /// Smpt Subject
        /// or
        /// Smpt Body</exception>
        public static string SendMail(string host, int port, string clientaddress, bool usessl, string to, string subject, string body, bool ishtml)
        {
            try
            {
                if (string.IsNullOrEmpty(host))
                    throw new ArgumentNullException("Smpt Host");
                if (string.IsNullOrEmpty(clientaddress))
                    throw new ArgumentNullException("Smpt Sender");
                if (string.IsNullOrEmpty(to))
                    throw new ArgumentNullException("Smpt Receiver");
                if (string.IsNullOrEmpty(subject))
                    throw new ArgumentNullException("Smpt Subject");
                if (string.IsNullOrEmpty(body))
                    throw new ArgumentNullException("Smpt Body");

                System.Net.Mail.SmtpClient Mail = new System.Net.Mail.SmtpClient();

                Mail.Host = host;
                Mail.Port = 25;
                Mail.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                Mail.UseDefaultCredentials = true;
                Mail.EnableSsl = usessl;

                System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage();
                myMail.Subject = subject;

                myMail.From = new System.Net.Mail.MailAddress(clientaddress);
                myMail.To.Add(new System.Net.Mail.MailAddress(to));

                myMail.IsBodyHtml = ishtml;
                myMail.Body = body;

                Mail.Send(myMail);
                return true.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
