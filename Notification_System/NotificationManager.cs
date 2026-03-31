using System;
using System.Collections.Generic;
using System.Text;

namespace Notification_System
{
    internal class NotificationManager
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email Sent: {message}");
        }

        public void SendSMS(string message)
        {
            Console.WriteLine($"SMS Sent: {message}");
        }

        public void SendWhatsApp(string message)
        {
            Console.WriteLine($"WhatsApp Sent: {message}");
        }
    }
}
