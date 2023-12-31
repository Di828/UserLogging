﻿namespace UserLogging.Models.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public PossibleActions.PossibleAction[]? UserActions { get; set; }
    }
}
