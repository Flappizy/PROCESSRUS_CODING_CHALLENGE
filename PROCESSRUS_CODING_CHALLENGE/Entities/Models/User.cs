using Microsoft.AspNetCore.Identity;
using PROCESSRUS_CODING_CHALLENGE.Enums;

namespace PROCESSRUS_CODING_CHALLENGE.Entities.Models;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public AccountType AccountType { get; set; }
}
