using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Natural
{
    private int number;

    // Натуральное число
    public int Number
    {
        get
        {
            return number;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Ожидается натуральное число");
            }
            number = value;
        }
    }

    // Конструктор по значению. 
    public Natural(int n)
    {
        number = n;
    }

    // Создание объекта
    public static Natural Create(int n)
    {
        var e = new Natural(n);
        return e;
    }

    // Проверка числа на чётное
    public bool IsOdd()
    {
        return (number % 2) != 0;
    }

    // Увеличение числа
    public void Increment()
    {
        number++;
    }

    // Возвращает число как параметр
    public void GetNumber(out int n)
    {
        n = number;
    }
}

class Program
{
    static void Main()
    {
        var e1 = Natural.Create(100);
        int n;
        e1.Increment();
        e1.GetNumber(out n);
    }
}

