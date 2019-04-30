using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shared
{
    public abstract class Message 
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}