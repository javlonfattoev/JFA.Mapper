namespace JFA.Mapper.Sample.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public string[] Children { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string EmailAddress { get; set; }
}