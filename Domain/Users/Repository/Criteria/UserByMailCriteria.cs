using System.Linq.Expressions;
using Domain.Shared.Base;

namespace Domain;

public class UserByMailCriteria : Criteria<User>
{
    public UserByMailCriteria(UserMail mail) : base(user => user.Mail == mail)
    {
    }
}
