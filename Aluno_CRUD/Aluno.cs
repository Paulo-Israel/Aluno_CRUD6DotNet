using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Aluno
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Para garantir que o Id é gerado pelo banco
    public int Id { get; set; }

    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Notas { get; set; }
}
