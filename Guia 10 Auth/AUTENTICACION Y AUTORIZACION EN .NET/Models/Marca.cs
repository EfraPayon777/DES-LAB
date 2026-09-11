namespace AUTENTICACION_Y_AUTORIZACION_EN_.NET.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
