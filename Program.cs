using System;

abstract class TPrism
{
    public double BaseArea { get; set; }
    public double Height { get; set; }

    public abstract double SurfaceArea();
    public abstract double Volume();
}

class TPrism3 : TPrism
{
    public double SideLength { get; set; }

    public override double SurfaceArea()
    {
        return BaseArea * 2 + 3 * SideLength * Height;
    }

    public override double Volume()
    {
        return BaseArea * Height;
    }
}

class TPrism4 : TPrism
{
    public double SideLength { get; set; }

    public override double SurfaceArea()
    {
        return BaseArea * 2 + 4 * SideLength * Height;
    }

    public override double Volume()
    {
        return BaseArea * Height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть кількість правильних призм: ");
        int m = int.Parse(Console.ReadLine());

        TPrism[] prisms = new TPrism[m];

        Console.WriteLine("Введіть дані для створення правильної трикутної призми:");
        Console.Write("Довжина сторони: ");
        double sideLength3 = double.Parse(Console.ReadLine());
        Console.Write("Висота: ");
        double height3 = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть дані для створення правильної чотирикутної призми:");
        Console.Write("Довжина сторони: ");
        double sideLength4 = double.Parse(Console.ReadLine());
        Console.Write("Висота: ");
        double height4 = double.Parse(Console.ReadLine());

        double baseArea3 = Math.Sqrt(3) * Math.Pow(sideLength3, 2) / 4;
        double baseArea4 = Math.Pow(sideLength4, 2);

        for (int i = 0; i < m; i++)
        {
            if (i % 2 == 0)
            {
                prisms[i] = new TPrism3 { BaseArea = baseArea3, Height = height3, SideLength = sideLength3 };
                height3 += 5;
            }
            else
            {
                prisms[i] = new TPrism4 { BaseArea = baseArea4, Height = height4, SideLength = sideLength4 };
                height4 += 5;
            }
        }

        double totalVolume3 = 0;
        double totalSurfaceArea4 = 0;

        for (int i = 0; i < m; i++)
        {
            if (prisms[i] is TPrism3)
            {
                totalVolume3 += prisms[i].Volume();
            }
            else
            {
                totalSurfaceArea4 += prisms[i].SurfaceArea();
            }
        }

        Console.WriteLine($"Сумарний об'єм трикутних призм: {totalVolume3}");
        Console.WriteLine($"Сума площ поверхні чотирикутних призм: {totalSurfaceArea4}");

        Console.ReadLine();
    }
}