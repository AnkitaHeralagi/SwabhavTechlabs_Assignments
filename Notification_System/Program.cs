using System;
using Notification_System;

namespace Notification_System
{
    //Delegate
    public delegate void Notify(string message);

    class Program
    {
        static void Main()
        {
            NotificationManager manager = new NotificationManager();

            // Build notification pipeline
            Notify notificationPipeline = null;

            notificationPipeline += manager.SendEmail;
            notificationPipeline += manager.SendSMS;
            notificationPipeline += manager.SendWhatsApp;

            Console.WriteLine("======== Notification System ========");

            // First notification
            ExecuteNotification(notificationPipeline, "Order Placed");

            Console.WriteLine($"\nActive Channels: {notificationPipeline?.GetInvocationList().Length}");

            // Modify pipeline
            Console.WriteLine("\n-- Removing SMS Channel --");
            notificationPipeline -= manager.SendSMS;

            // Second notification
            ExecuteNotification(notificationPipeline, "Order Shipped");

            Console.WriteLine($"\nActive Channels: {notificationPipeline?.GetInvocationList().Length}");
        }

        static void ExecuteNotification(Notify pipeline, string message)
        {
            Console.WriteLine($"\nProcessing Notification: {message}");
            pipeline?.Invoke(message);
        }
    }
}