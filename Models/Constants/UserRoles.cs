namespace GestaoFreela.Models.Constants;

public static class UserRoles
{
    public const string Admin = "admin";
    public const string Cliente = "cliente";
    public const string Freelancer = "freelancer";
    
    public static readonly string[] AllRoles = { Admin, Cliente, Freelancer };
}
