namespace ExcursionesPescaEntities
{
    public class Excursion
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int Duracion { get; set; }
        public int Precio { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public List<EquipoPesca> EquiposPesca { get; set; }

        public virtual string ObtenerDescripcion() {
            return $"{Codigo} - {Nombre} - {Ubicacion} - {Duracion}";
        }
    }
}
