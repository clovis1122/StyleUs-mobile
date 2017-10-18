using System;
using Prism.Events;

namespace StyleUs.Events
{
    public class onLoginEvent : PubSubEvent<bool> { }
    public class displayMessage : PubSubEvent<string> {}
}
