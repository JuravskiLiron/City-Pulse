namespace CityPulse.Domain.Models;

public class User
{
    private User(Guid id, string userName, string passwordHash, string userFullname, string phone)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        UserFullname = userFullname;
        Phone = phone;
    }
    
    protected User() { }

    public Guid Id { get; set; }

    public string UserName { get; private set; }

    public string PasswordHash { get; set; }
    
    public string UserFullname { get; private set; }
    public string Phone { get; private set; }

    public static User Create(Guid id, string userName, string passwordHash,string userFullname, string phone)
    {
        return new User(id, userName, passwordHash,userFullname, phone);
    }
}


