using Shared.Command;
using Shared.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Shared.Notifications
{
    public class DomainNotificationHandler
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public bool Handle(DomainNotification message)
        {
            _notifications.Add(message);
            return true; 
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}