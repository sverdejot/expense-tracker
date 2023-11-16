using Domain.Shared.Base;

namespace Domain;

public class UserNotFoundException : DomainException
{
    public UserNotFoundException(UserMail mail) : base($"The user with mail [{mail.Value}] has not been found in the database.")
    {
    }

    public UserNotFoundException(UserId id) : base($"The user with id [{id.Value}] has not been found in the database.")
    {
    }
}
