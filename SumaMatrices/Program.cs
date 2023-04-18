
//arreglo multidimensional
int[,] array1 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
int[,] array2 = new int[3, 3] { { 1, 1, 1 }, { 5, 6, 1 }, { 7, 8, 1 } };
int[,] arrayResult = new int[3, 3];

for (int j = 0; j < 3; j++)
{
    for (int i = 0; i < 3; i++)
    {
        arrayResult[j, i] = array1[j, i] + array2[j, i];
    }
}

Console.WriteLine("Resultado de la suma de matrices: ");

for (int i = 0;i < 3; i++)
{
    Console.Write("{ ");
    for (int j = 0; j < 3; j++)
    {
        Console.Write(arrayResult[i,j] + " ");
    }
    Console.WriteLine(" }");
}

Console.WriteLine("Presione cualquier tecla para salir...");
Console.ReadKey();
