using System;
using System.Linq;
using System.Text.RegularExpressions;
using NotificationChannelParser.Models;

namespace NotificationChannelParser.Services
{
    public class NotificationParser
    {
        public interface INotificationParser
        {
            string Parse(string title);
        }

        public class NotificationParser : INotificationParser
        {
            public string Parse(string title)
            {
                if (string.IsNullOrEmpty(title))
                    return "No channels found";

                // Extract all tags within square brackets
                var matches = Regex.Matches(title, @"\[(.*?)\]");

                // Process valid channels
                var channels = matches
                    .Select(m => m.Groups[1].Value.ToUpper())
                    .Where(tag => NotificationChannel.ValidChannels.Contains(tag))
                    .OrderBy(tag => tag)
                    .ToList();

                return channels.Any()
                    ? $"Receive channels: {string.Join(", ", channels)}"
                    : "No valid channels found";
            }
        }
    }
}   

