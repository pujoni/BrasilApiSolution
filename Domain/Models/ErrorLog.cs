﻿namespace Domain.Models
{
    public class ErrorLog
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime Date { get; set; }
    }

}
