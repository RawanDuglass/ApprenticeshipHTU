using Microsoft.AspNetCore.Identity;

namespace ProjectHTU.Entities;

public class Person : IdentityUser
{
    public string firstName { get; set; }
    public string secondName { get; set; }
    public string thiredName { get; set; }
    public string lastName { get; set; }
    public string fullName => $"{firstName} {lastName}"; // if i want full name $"{firstName}  {secondName}  {thiredName}  {lastName}"

}
