using System.ComponentModel.DataAnnotations;

namespace blazor_auto_indexed_db.Client.Models;

public class Customer
{
    [Key]
    [Required(ErrorMessage = "Favor informar o id!")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Favor informar o nome!")]
    [MinLength(3, ErrorMessage = "Favor informar pelo menos {1} caracteres!")]
    [MaxLength(50, ErrorMessage = "Favor informar no máximo {1} caracteres!")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Favor informar o e-mail!")]
    [EmailAddress(ErrorMessage = "Favor informar um e-mail válido!")]    
    [MaxLength(50, ErrorMessage = "Favor informar no máximo {1} caracteres!")]
    public string Email { get; set; } = string.Empty;
}
