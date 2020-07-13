using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;
using CorEscuela.Util;

namespace CorEscuela
{
    //sealed, selllada para que nadie pueda heredar de esa clase
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Alfonso Lopez", 1996, (TiposEscuela.Primaria),
                        ciudad: "Valledupar", pais: "Colombia");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }
        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic){
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());
                
                foreach (var valK in obj.Value)
                {
                    Console.WriteLine(valK);
                }
            }
        }
        //Diccionario<llave,contenido>
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {

            //usar las enum para las llaves del diccionario como buena practica
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            var listmpEval = new List<Evaluacion>();
            var listmpAsig = new List<Asignatura>();
            var listmpAlum = new List<Alumno>();
            foreach (var curso in Escuela.Cursos)
            {
                listmpAsig.AddRange(curso.Asignaturas);
                listmpAlum.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listmpEval.AddRange(alumno.Evaluaciones);

                }


            }
            diccionario.Add(LlaveDiccionario.Asignatura, listmpAsig.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listmpAlum.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluacion, listmpEval.Cast<ObjetoEscuelaBase>());
            return diccionario;
        }

        //sobrecarga de método
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            //parametros de salida
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            //parametros de salida
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            //parametros de salida
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            //parametros de salida
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            //parametros de salida
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0; ;


            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (traeCursos)
            {
                listaObj.AddRange(Escuela.Cursos);//varios cursos, se añade un rango    
            }
            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignaturas);
                }
                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumnos);
                }

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }

            }

            return (listaObj.AsReadOnly());
        }

        #region Métodos de Carga
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var lista = new List<Evaluacion>();
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rand = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nota = Convert.ToSingle(rand.Next(0, 5) + rand.NextDouble())
                            };
                            alumno.Evaluaciones.Add(ev);
                        }

                    }
                }
            }
        }


        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"},
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Natura"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }
        ///Un producto cartesiano de los 3 arreglos
        private List<Alumno> CrearAlumnosAleatorios(int cantidad)
        {
            string[] nombre1 = { "Alba", "Jose", "Ricardo", "Carlos", "Jorge", "Nauris" };
            string[] apellido1 = { "Cordoba", "Castillo", "Bastidas", "Mejia", "Daza", "Oñate" };
            string[] nombre2 = { "Daniel", "Brineth", "Carolina", "Walter", "Harold" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueID).Take(cantidad).ToList();//Ordernar lista
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
               new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
               new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
               new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
               new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
               new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
            };
            Random rnd = new Random();

            foreach (var c in Escuela.Cursos)
            {
                int cantidadRandom = rnd.Next(5, 30);
                c.Alumnos = CrearAlumnosAleatorios(cantidadRandom);
            }
        }
    }
    #endregion
}