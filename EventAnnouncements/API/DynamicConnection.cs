using Exiled.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EventAnnouncements.API
{
    public static class DynamicConnection
    {
        private static Assembly _exiledAssembly = Loader.GetPlugin("Exiled.Events").Assembly;

        private static Type[] _eventTypes = _exiledAssembly.GetTypes()
            .Where(t => t.Namespace == "Exiled.Events.Handlers")
            .ToArray();

        private static Dictionary<EventInfo, Delegate> _delegates = new Dictionary<EventInfo, Delegate>();
        private static Dictionary<Type, string> _eventArgsToName = new Dictionary<Type, string>();

        public static void HelperNoArgs(string eventName)
        {
            Plugin.Instance.Config.Announcements.TryAnnounce(eventName);
        }

        public static void Helper(string eventName, EventArgs eventArgs)
        {
            Plugin.Instance.Config.Announcements.TryAnnounce(eventName);
        }

        public static void HelperGeneric<T>(T eventArgs)
            where T : EventArgs
        {
            Helper(_eventArgsToName[eventArgs.GetType()], eventArgs);
        }

        public static void CreateConnection(string eventName)
        {
            foreach (Type eventType in _eventTypes)
            {
                EventInfo eventInfo = eventType.GetEvent(eventName);
                if (eventInfo != null)
                {
                    if (_delegates.ContainsKey(eventInfo))
                        return;

                    List<Type> args = new List<Type>();

                    foreach (ParameterInfo p in eventInfo.EventHandlerType.GetMethod("Invoke").GetParameters())
                    {
                        args.Add(p.ParameterType);
                    }

                    if (args.Count > 0)
                    {
                        MethodInfo mi = typeof(DynamicConnection).GetMethod("HelperGeneric");
                        Delegate del = Delegate.CreateDelegate(eventInfo.EventHandlerType, mi.MakeGenericMethod(args.ToArray()));

                        _eventArgsToName.Add(args[0], eventName);
                        eventInfo.AddEventHandler(null, del);
                        _delegates.Add(eventInfo, del);
                    }
                    else
                    {
                        Exiled.Events.Events.CustomEventHandler delegateForMehtod = () => HelperNoArgs(eventName);

                        eventInfo.AddEventHandler(null, delegateForMehtod);
                        _delegates.Add(eventInfo, delegateForMehtod);
                    }

                    return;
                }
            }
        }

        public static void DisconnectFromEvent(string eventName)
        {
            foreach (Type eventType in _eventTypes)
            {
                EventInfo eventInfo = eventType.GetEvent(eventName);

                if (eventInfo != null && _delegates.TryGetValue(eventInfo, out Delegate d))
                {
                    eventInfo.RemoveEventHandler(null, d);
                    _delegates.Remove(eventInfo);

                    List<Type> args = new List<Type>();

                    foreach (ParameterInfo p in eventInfo.EventHandlerType
                        .GetMethod("Invoke").GetParameters())
                    {
                        args.Add(p.ParameterType);
                    }

                    if (args.Count > 0)
                        _eventArgsToName.Remove(args[0]);

                    break;
                }
            }
        }
    }
}
