namespace AUTENTICACION_Y_AUTORIZACION_EN_.NET.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int ModeloId { get; set; }
        public int Anio { get; set; }

        public Modelo Modelo { get; set; } = null!;
    }
}
