﻿using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace OpenAI.Extensions
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Attempts to get the event data from the string data.
        /// Returns false once the stream is done.
        /// </summary>
        /// <param name="streamData">Raw stream data.</param>
        /// <param name="eventData">Parsed stream data.</param>
        /// <returns>True, if the stream is not done. False if stream is done.</returns>
        public static bool TryGetEventStreamData(this string streamData, out string eventData)
        {
            const string dataTag = "data: ";
            eventData = string.Empty;

            if (streamData.StartsWith(dataTag))
            {
                var data = streamData.Substring(dataTag.Length);
                eventData = data.Trim();
            }

            const string doneTag = "[DONE]";
            return eventData != doneTag;
        }

        public static StringContent ToJsonStringContent(this string json, bool debug)
        {
            const string jsonContent = "application/json";

            if (debug)
            {
                Console.WriteLine(json);
            }

            return new StringContent(json, Encoding.UTF8, jsonContent);
        }

        public static string ToSnakeCase(string @string)
        {
            return string.IsNullOrEmpty(@string)
                ? @string
                : string.Concat(
                    @string.Select((x, i) => i > 0 && char.IsUpper(x)
                        ? string.Format("_{0}", x)
                        : x.ToString())).ToLower();
        }
    }
}
