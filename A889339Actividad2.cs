/*Se requiere que programe una aplicación de consola para un torneo de fútbol. Es un torneo de
un solo partido “todos contra todos”, donde se adjudica 3 puntos al ganador, 0 al perdedor, y
uno a cada uno en caso de empate. La aplicación debe:
o A) Permitir el ingreso de los equipos participantes (identificados por nombre).
o B) Listar los partidos a jugar, solicitando el ingreso del resultado de cada uno (el orden
en el que se muestran/ingresan resultados no es importante).
o C) Liste el puntaje obtenido por cada equipo, ordenado en forma descendente.*/

using System;
using System.Linq;
using System.Collections.Generic;
class Actividad2 {
  static void Main() {
      int NumeroEquipos;
      
      Console.WriteLine("Buenas tardes, Por favor ingrese cuántos equipos participarán en el torneo:");
      string ingreso = Console.ReadLine(); 
      bool validarNumero = Int32.TryParse(ingreso, out NumeroEquipos);
      
      while (!validarNumero || NumeroEquipos < 2 )
      {
          Console.WriteLine("Ingreso incorrecto, por favor ingrese un número mayor o igual a 2");
          ingreso = Console.ReadLine(); 
          validarNumero = Int32.TryParse(ingreso, out NumeroEquipos);
      }
    Dictionary<string,int> Equipos = new Dictionary<string,int>();
    List<string> NombresEquipos = new List<string>();
    
    for (int i = 0; i < NumeroEquipos ; i++)
    {
        Console.WriteLine($"Por favor escriba el nombre del equipo {i+1}: ");
        string NombreEquipo = Console.ReadLine();
        if(String.IsNullOrEmpty(NombreEquipo))
        {
            Console.WriteLine("Ingreso inválido"); 
            i--;
            continue;
        }
        NombreEquipo = NombreEquipo.Trim().ToUpper();
        if(Equipos.ContainsKey(NombreEquipo))
        {
            Console.WriteLine("El equipo ya existe"); 
            i--;
            continue;
        }
        Equipos.Add(NombreEquipo, 0);
        NombresEquipos.Add(NombreEquipo);
    }
    for (int i = 0; i < NumeroEquipos ; i++)
    {
        for (int j = i+1; j < NumeroEquipos ; j++)
        {
            int resultado1;
            int resultado2;
            Console.WriteLine($"Resultado de {NombresEquipos[i]} vs {NombresEquipos[j]}:");
            Console.Write($"{NombresEquipos[i]}: ");
            bool VoF = Int32.TryParse(Console.ReadLine(), out resultado1);
            while (!VoF || resultado1 < 0 )
            {
                Console.WriteLine("Ingreso incorrecto, por favor ingrese un número mayor o igual a 0");
                VoF = Int32.TryParse(Console.ReadLine(), out resultado1);
            }
            Console.Write($"{NombresEquipos[j]}: ");
            VoF = Int32.TryParse(Console.ReadLine(), out resultado2);
            while (!VoF || resultado2 < 0 )
            {
                Console.WriteLine("Ingreso incorrecto, por favor ingrese un número mayor o igual a 0");
                VoF = Int32.TryParse(Console.ReadLine(), out resultado2);
            }
            if(resultado2<resultado1)
            {
                Equipos[NombresEquipos[i]] += 3;
            }
            else if (resultado1 == resultado2)
            {
                Equipos[NombresEquipos[i]] += 1;
                Equipos[NombresEquipos[j]] += 1;
            }
            else
            {
                Equipos[NombresEquipos[j]] += 3;    
            }
        }
        
    }
    Equipos = Equipos.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    Console.Clear();
    Console.WriteLine("Tabla de posiciones: ");
    foreach(string nombre in Equipos.Keys)
    {
        Console.WriteLine($"{nombre}: {Equipos[nombre]}");
    }

  }
}