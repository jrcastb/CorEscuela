using System;

namespace CorEscuela.Entidades
{
    //puede heredar pero no crear instancias
    public abstract class ObjetoEscuelaBase
    {
        public string Nombre { get; set; }
        public string UniqueID { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueID = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return $"{Nombre}, {UniqueID}";
        }
    }
}