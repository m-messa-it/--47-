using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // створюємо масив з 20 елементів
        int[] numbers = new int[20];
        Random random = new Random();

        // заповнюємо масив випадковими числами від 1 до 12
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 13);
        }

        // виводимо масив
        Console.Write("Масив чисел: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        // масив потоків
        Thread[] threads = new Thread[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            int num = numbers[i]; // треба щоб i не змінилась поки потік запуститься

            threads[i] = new Thread(() =>
            {
                long numF = Factorial(num);
                Console.WriteLine($"факторіал числа: {num}! = {numF}");
            });

            threads[i].Start();
        }

        // чекаємо поки всі потоки закінчать роботу
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }

        Console.WriteLine("Розрахунок закінчено.");
    }

    static long Factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result = result * i;
        }
        return result;
    }
}
