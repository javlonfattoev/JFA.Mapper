using JFA.Mapper.Sample.Models;

var user = new User(1, "Csharp", true, new[] { "NET", "Azure" }, "csharp")
{
    Phone = 12, 
    Email = "jfa@fattoev.uz"
};

var config = new JFA.Mapper.MapperConfig();
config.Map("Email", "EmailAddress");
config.Map<User, UserDto>(u => u.Id, dto => dto.Age);

var userDto = user.To<UserDto>(config);

Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(userDto));

// Speed test

var users = Enumerable.Range(0, 100000).Select(_ => new User(1, "user", false, new[] { "list1" }, "username"));

Console.WriteLine($"Users created : {users.Count()}");

var stopwatch = new System.Diagnostics.Stopwatch();
stopwatch.Start();

var usersDto = users.Select(u => u.To<UserDto>()).ToList();

stopwatch.Stop();
Console.WriteLine($"Users mapped : {usersDto.Count}, " + stopwatch.Elapsed.Milliseconds + " ms");
