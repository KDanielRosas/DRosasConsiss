
Console.WriteLine("\t---- Factorial -----");
int fac = 1, x, n;
x = 1;
    Console.Write("Ingrese un numero entero: ");
n = int.Parse(Console.ReadLine());

while (x <= n)
{
    fac *= x;
    x++;
}
Console.Write("El factorial es: " + fac);
Console.ReadKey();
