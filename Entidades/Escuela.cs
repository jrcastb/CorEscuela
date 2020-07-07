using System;
using System.Collections.Generic;
using CorEscuela.Util;

namespace CorEscuela.Entidades
{
    public class Escuela:ObjetoEscuelaBase, ILugar
    {

        public int AñoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }

        public List<Curso> Cursos { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        /*constructor
        public Escuela(string nombre, int año){
            this.nombre = nombre;
            AñoDeCreacion = año;
        }*/
        //constructor con parametros opcionales
        public Escuela(string nombre, int año, TiposEscuela tipo,
                        string pais = "", string ciudad = "")
        {
            (Nombre, AñoDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \n Pais: {Pais}, Ciudad: {Ciudad}";
        }
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
            
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();  
            }
            
            Printer.WriteTitle($"Escuela {Nombre} limpia");
            Printer.Beep(1000, cantidad:3);
        }

    }
}