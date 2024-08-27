namespace ExcursionesPescaEntities
{
    public class ExcursionMar : Excursion
    {
        public int TamañoBarco { get; set; }
        public int ProfundidadPesca { get; set; }
        public bool TieneCatering { get; set; }

        public override string ObtenerDescripcion()
        {
            return $"{base.ObtenerDescripcion()} - {TamañoBarco} - {ProfundidadPesca} - {TieneCatering}";
        }
    }
}
