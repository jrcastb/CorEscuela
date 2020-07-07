namespace CorEscuela.Entidades
{
    //En las interfaces no hay modificadores de acceso, todos deben ser publicos
    //por lo tanto no se especifican
    public interface ILugar
    {
        string Direccion { get; set; }
        void LimpiarLugar();
    }
    //Cuando son interfaces no hereda comportamientos, hereda un contrato
    //es un contrato porque dice que cosas debe cumplir
}