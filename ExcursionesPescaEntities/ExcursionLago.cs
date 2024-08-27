using ExcursionesPescaEntities.Enums;

namespace ExcursionesPescaEntities
{
    public class ExcursionLago : Excursion
    {
        public EspecieLagoEnum EspeciePesca { get; set; }
        public bool TieneGuia { get; set; }

        public override string ObtenerDescripcion()
        {
            return $"{base.ObtenerDescripcion()} - {EquiposPesca.ToString()} - {TieneGuia}";
        }
    }
}
