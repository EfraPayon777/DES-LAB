namespace AUTENTICACION_Y_AUTORIZACION_EN_.NET.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public Marca Marca { get; set; } = null!;
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
