using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GestaoFreela.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    [StringLength(18)]
    public string CpfCnpj { get; set; } = string.Empty;
    
    [Required]
    [StringLength(20)]
    public string Telefone { get; set; } = string.Empty;
    
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}