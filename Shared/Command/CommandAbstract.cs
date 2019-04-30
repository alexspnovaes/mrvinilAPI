using FluentValidation.Results;
using System;

namespace Shared.Command
{
    public abstract class CommandAbstract : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        protected CommandAbstract()
        {
            Timestamp = DateTime.Now;
        }
    }
}