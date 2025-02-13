using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Tipos de datos primitivos
        byte byteVar = 255;
        sbyte sbyteVar = -128;
        short shortVar = -32768;
        ushort ushortVar = 65535;
        int intVar = 2147483647;
        uint uintVar = 4294967295;
        long longVar = 9223372036854775807;
        ulong ulongVar = 18446744073709551615;
        float floatVar = 3.1416f;
        double doubleVar = 3.14159265359;
        decimal decimalVar = 79228162514264337593543950335m;
        char charVar = 'A';
        string stringVar = "Hola, C#";
        bool boolVar = true;

        // Tipos complejos
        DateTime fecha = DateTime.Now;
        object objVar = "Soy un objeto";
        dynamic dynVar = 10;

        // Tipos de colección
        int[] arrayInt = {1, 2, 3, 4, 5};
        List<string> listaString = new List<string> {"Perro", "Gato", "Caballo"};
        Dictionary<int, string> diccionario = new Dictionary<int, string> {{1, "Uno"}, {2, "Dos"}};

        // Imprimir valores
        Console.WriteLine($"byte: {byteVar}, int: {intVar}, double: {doubleVar}, string: {stringVar}, bool: {boolVar}");
        Console.WriteLine($"Fecha actual: {fecha}, Objeto: {objVar}, Dinámico: {dynVar}");
        Console.WriteLine($"Lista de animales: {string.Join(", ", listaString)}");
    }
}