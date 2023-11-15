﻿using System;

namespace EM.Domain.General
{
    public class OperationStatus
    {
        public OperationStatus()
        {
            Status = true;    
        }

        public bool Status { get; set; }

        public string? Message { get; set; } = default(string);

        public object? Model { get; set; } = default;

        public Exception? Exception { get; set; } = default(Exception);
    }
}
