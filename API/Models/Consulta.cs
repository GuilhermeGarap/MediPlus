using System.Security.Cryptography.X509Certificates;
using API.Models;

namespace API.Models;

public class Consulta
{
    public int? ConsultaId { get; set; }
    public Paciente? Paciente { get; set; }
    public int? PacienteId { get; set; }
    public string? ConsultaData { get; set; }
    public DateTime? ConsultaCriadoEm { get; set; } = DateTime.Now;
    public string? ConsultaNotas { get; set; }




}
