﻿namespace Domain.Notification
{
    public class NotificationContext
    {
        private readonly List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();
        public bool HasErrors => _errors.Any();

        public NotificationContext()
        {
            _errors = new List<string>();
        }

        public NotificationContext AddNotification(string message)
        {
            _errors.Add(message);
            return this;
        }

        public NotificationContext AssertArgumentIsMinimumLengthOrLess(decimal value, int minimum, string message)
        {
            if (value <= minimum)
            {
                AddNotification(message);
            }
            return this;
        }

        public NotificationContext AssertArgumentNotNull(object? object1, string message)
        {
            if (object1 == null)
            {
                AddNotification(message);
            }
            return this;
        }

        public NotificationContext AssertArgumentNotNullOrWhiteSpace(string stringValue, string message)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                AddNotification(message);
            }
            return this;
        }

        public NotificationContext AssertArgumentEnumInvalidValue(Enum value, Enum invalidValue, string message)
        {
            if (value == invalidValue)
            {
                AddNotification(message);
            }
            return this;
        }

        public NotificationContext AssertArgumentEnumNotEqual(Enum value, Enum invalidValue, string message)
        {
            if (value == invalidValue)
            {
                AddNotification(message);
            }
            return this;
        }
    }
}

