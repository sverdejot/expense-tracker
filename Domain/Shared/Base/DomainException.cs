﻿namespace Domain.Shared.Base;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}
