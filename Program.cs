using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;
using CorEscuela.Util;
using static System.Console;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la Escuela");
            //Printer.Beep(2000, cantidad:10);
            ImprimirCursosEscuela(engine.Escuela);
             Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "JoseR");
            diccionario.Add(23, "Lorem Ipsum"); 

            foreach (var keyValuePair in diccionario)
            {
                WriteLine($"Key: {keyValuePair.Key}, Valor: {keyValuePair.Value}");
            }
            var dicTemp = engine.GetDiccionarioObjetos();
            engine.ImprimirDiccionario(dicTemp);
            /*var listaILugar = from obj in listaObjetos
                                where obj is ILugar
                                select (ILugar) obj;*/
            //"is" es para validar el tipo de objeto

            //"as" Si objeto lo puede tomar como alumno, va a retornar el alumno. Sino se puede, retornará null
            //engine.Escuela.LimpiarLugar();

        }
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos Escuela");

            if (escuela?.Cursos != null)// reemplaza escuela != null && escuela.Cursos != null
                foreach (var curso in escuela.Cursos)
                {
                    foreach (var evaluacion in curso.Alumnos)
                    {
                        Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueID}");
                    }
                }
            else
            {
                return;
            }

        }
        ///<SUMARY>
        /*private static bool Predicado(Curso curobj)//Función que apunta a un objeto until match
        {
            return curobj.Nombre == "301";
        }
        
            //Predicate<Curso> miAlgoritmo = Predicado;//Encapsulación de algoritmo "delegado"
            escuela.Cursos.RemoveAll(delegate (Curso cur){
                return cur.Nombre == "301";
            });
            escuela.Cursos.RemoveAll((cur) => {return cur.Nombre == "501" && cur.Jornada == TiposJornada.Mañana;});//expresión lambda

            */



    }
}
