using System;
using System.Collections.Concurrent;

namespace OpenFaceOffline.EventManager
{
    public class EventManager
    {
        private readonly ConcurrentDictionary<string, ConcurrentBag<Action<string>>> _eventListeners = new ConcurrentDictionary<string, ConcurrentBag<Action<string>>>();
        private static readonly Lazy<EventManager> _lazy = new Lazy<EventManager>(() => new EventManager());

        public static EventManager Instance => _lazy.Value;

        public void On(string eventName, Action<string> callback)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentException("Event name cannot be null or empty.", nameof(eventName));
            }

            _eventListeners.GetOrAdd(eventName, _ => new ConcurrentBag<Action<string>>()).Add(callback);
        }

        public void Emit(string eventName, Object? data)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentException("Event name cannot be null or empty.", nameof(eventName));
            }

            if (data == null)
            {
                data = "";
            }
            if (_eventListeners.TryGetValue(eventName, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.Invoke(data.ToString());
                }
            }
            else
            {
                // Log a warning or error message here
                Console.WriteLine($@"No listeners found for event: {eventName}");
            }
        }
    }

}