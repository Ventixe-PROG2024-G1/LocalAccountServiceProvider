﻿namespace LocalAccountServiceProvider.Data.Models
{
    public class AccountServiceResultRest
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? Result { get; set; }
    }
}