using Domain.Shared.Base;

namespace Domain;

public class User : AggregateRoot<User>
{
    public UserId Id { get; private set; }

    public UserMail Mail { get; private set; }

    protected User(UserId id, UserMail mail) 
    {
        Id = id;
        Mail = mail;
    }

    public static User Create(UserId id, UserMail mail)
    {
        var user = new User(id, mail);

        user.RecordEvent(new UserCreatedEvent(id.Value, mail.Value));

        return user;
    }
}
