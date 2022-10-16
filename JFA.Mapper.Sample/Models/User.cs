namespace JFA.Mapper.Sample.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public string[] Children { get; set; }
    public string UserName { get; set; }
    public int Phone { get; set; }
    public string Email { get; set; }


    public User(int id, string name, bool isAdmin, string[] children, string userName)
    {
        Id = id;
        Name = name;
        IsAdmin = isAdmin;
        Children = children;
        UserName = userName;
    }
}