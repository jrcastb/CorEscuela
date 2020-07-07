using System;
using System.Diagnostics;
//[DebuggerDisplay("{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}")];
namespace CorEscuela.Entidades
{
    public class Evaluacion:ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }
        
        public override string ToString(){
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}