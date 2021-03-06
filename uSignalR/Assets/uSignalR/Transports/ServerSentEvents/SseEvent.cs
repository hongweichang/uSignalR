﻿using System;

namespace uSignalR.Transports.ServerSentEvents
{
    public class SseEvent
    {
        public SseEvent(EventType type, string data)
        {
            Type = type;
            Data = data;
        }

        public EventType Type { get; private set; }
        public string Data { get; private set; }

        public static bool TryParse(string line, out SseEvent sseEvent)
        {
            sseEvent = null;

            if (line.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            {
                string data = line.Substring("data:".Length).Trim();
                sseEvent = new SseEvent(EventType.Data, data);
                return true;
            }
            if (line.StartsWith("id:", StringComparison.OrdinalIgnoreCase))
            {
                string data = line.Substring("id:".Length).Trim();
                sseEvent = new SseEvent(EventType.Id, data);
                return true;
            }

            return false;
        }
    }
}