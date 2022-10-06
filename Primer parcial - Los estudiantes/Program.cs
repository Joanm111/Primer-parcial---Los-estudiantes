using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.Extensions.Options;
using System.Numerics;
using System.Runtime.Remoting.Contexts;
using Primer_parcial___Los_estudiantes.Models;

namespace Primer_parcial___Los_estudiantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            Estudiantes estudiantes = new Estudiantes();

           List<asignatura>asignaturaslist = new List<asignatura>();
            List<estudiante> estudiantelist = new List<estudiante>();
            List<seleccion> seleccionlist = new List<seleccion>();
            List<Estudiantes> TblEstudiante = new List<Estudiantes>();
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("** Menu principal **" +
                    "\n 1. Leer el Archivo Seleccion.csv" +
                    "\n 2. Leer el Archivo Estudiantes.csv " +
                    "\n 3. Leer el Archivo Asignatura.csv" +
                    "\n 4. Cargar a base de datos"
                     +
                     "\n 5. Mostrar máximo y mínimo"
                     +
                     "\n 6. Procesar archivo TXT"
                     +
                     "\n 7. Salir"
                     +
                    "\n"
                    );

                opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":
                        {
                            string[] lineas1 = File.ReadAllLines("C://Users//joanj//Desktop//Seleccion.csv");

                            foreach (var linea in lineas1)
                            {
                                var valores = linea.Split(',');
                                Console.WriteLine(valores[0] + "   " + valores[1] + "   " + valores[2] + "   " + valores[3] + "   " + valores[4] + "   " + valores[5] + "   " + valores[6]);
   
                                int? pptre = null;
                                if (valores[6] != "")
                                    pptre = Convert.ToInt32(valores[6]);

                                seleccionlist.Add(new seleccion() {
                                    //12-0001,Inf-345-01s,Mayo - Agosto,2021,85,60,
                                    Matricula = valores[0],
                                    CodigoAsignatura = valores[1],
                                    periodo = valores[2],
                                    ano = Convert.ToInt32(valores[3]),
                                    PP1 = Convert.ToInt32(valores[4]),
                                    PP2 = Convert.ToInt32(valores[5]),
                                    PP3 = pptre
                                }) ;
                               }
                        }


                        break;

                    case "2":
                        {
                            string[] lineas1 = File.ReadAllLines("C://Users//joanj//Desktop//Estudiantes.csv");

                            foreach (var linea in lineas1)
                            {
                                var valores = linea.Split(',');
                                Console.WriteLine(valores[0] + "   " + valores[1] + "   " + valores[2]);

                                estudiantelist.Add(new estudiante()
                                {
                                    Matricula = valores[0],
                                    Nombre = valores[1],
                                    Apellido = valores[2]
                                });
                            }
                        }

                        break;

                    case "3":
                        {
                            string[] lineas1 = File.ReadAllLines("C://Users//joanj//Desktop//Asignaturas.csv");

                            foreach (var linea in lineas1)
                            {
                                var valores = linea.Split(',');
                                Console.WriteLine(valores[0] + "   " + valores[1]);

                                asignaturaslist.Add(new asignatura()
                                {
                                    codigoAsignatuta = valores[0],
                                    Asignatura = valores[1]
                                });
                            }
                        }

                        break;

                    case "4":
                        opcion = "4";
                        foreach (var selecc in seleccionlist)
                        {
                            var estudia = estudiantelist.Where(e => e.Matricula == selecc.Matricula).FirstOrDefault();
                            var asignat = asignaturaslist.Where(a => a.Asignatura == selecc.CodigoAsignatura).FirstOrDefault();

                            TblEstudiante.Add(new Estudiantes()
                            {
                                Ano = selecc.ano,
                                Apellido = estudia.Apellido,
                                Asignatura = asignat.Asignatura,
                                CodAsignatura = asignat.codigoAsignatuta,
                                Matricula = estudia.Matricula,
                                Nombre = estudia.Nombre,
                                Periodo = selecc.periodo,
                                Pp1 = selecc.PP1,
                                Pp2 = selecc.PP2,
                                Pp3 = selecc.PP3
                            });
                        }
                        using (var context = new PrimerParcialContext())
                        {
                            context.Estudiantes.AddRange(TblEstudiante);
                            context.SaveChanges();
                        }
                        Console.WriteLine("Carga exitosa.");
                        break;
                    case "5":
                        opcion = "5";

                        foreach (var item in TblEstudiante.GroupBy(t=>t.CodAsignatura))
                        {
                            Console.WriteLine($"Asignatura {item.FirstOrDefault().Asignatura}. Promedio: {item.Average(a=>a.Pp1)}");
                            var temp1 = item.OrderByDescending(o => o.Pp1).FirstOrDefault();
                            var temp2 = item.OrderBy(o => o.Pp1).FirstOrDefault();
                            Console.WriteLine($"Maxima calificacion: {temp1.Nombre} {temp1.Apellido}: {temp1.Pp1}");
                            Console.WriteLine($"Minima calificacion: {temp2.Nombre} {temp2.Apellido}: {temp2.Pp1}");
                            Console.WriteLine("");
                        }
                        
                        break;
                    case "6":
                        StringBuilder sb = new StringBuilder();
                        foreach (var item in TblEstudiante.GroupBy(g=>g.CodAsignatura))
                        {
                            sb.AppendLine("Asignatura: " + item.FirstOrDefault().Asignatura + " Cantidad Estudiante: "+item.Count());
                            foreach (var it in item)
                            {
                                sb.AppendLine("Estudiante: " + it.Nombre + " " + it.Apellido);
                            }
                            
                            sb.AppendLine("");
                        }
                        File.WriteAllText("C://Users//joanj//Desktop//CargaTexto.txt", sb.ToString());
                        opcion = "6";
                        break;
                    case "7":
                        opcion = "7";
                        break;
                    default:
                        Console.WriteLine("elige una opcion del menu");
                        break;
                }

            } while (opcion != "7");





          



        }
    }
}
