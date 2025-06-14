namespace Fiap.Web.WattsOff.Models
{

    public class Dispositivo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public bool StatusLigado { get; set; } = false;
    }

}
