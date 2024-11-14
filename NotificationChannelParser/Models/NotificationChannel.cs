using System.Collections.Generic;

namespace NotificationChannelParser.Models
{
    public class NotificationChannel
    {
        public static readonly string Backend           = "BE";
        public static readonly string Frontend          = "FE";
        public static readonly string QualityAssurance  = "QA";
        public static readonly string Urgent            = "URGENT";

        public static readonly HashSet<string> ValidChannels = new()
        {
            Backend,
            Frontend,
            QualityAssurance,
            Urgent
        };
    }
}