using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Налаштування коректного відображення української мови в консолі
        Console.OutputEncoding = Encoding.UTF8;

        // 1. Створення масиву цілих чисел довжиною 20 елементів
        int[] numbers = new int[20];
        Random random = new Random();

        // Заповнення випадковими значеннями від 1 до 12
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 13); // від 1 до 12 включно
        }

        Console.WriteLine("Згенерований масив чисел:");
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("\nЗапуск розрахунку факторіалів у потоках Thread...\n");

        // Масив для збереження посилань на потоки
        Thread[] threads = new Thread[numbers.Length];

        // 2. Для кожного елемента масиву створення та запуск окремого потоку Thread
        for (int i = 0; i < numbers.Length; i++)
        {
            int num = numbers[i]; // Локальна копія змінної для замикання в потоці

            threads[i] = new Thread(() =>
            {
                long numF = CalculateFactorial(num);
                Console.WriteLine($"факторіал числа: {num}! = {numF}");
            });

            // Запуск потоку
            threads[i].Start();
        }

        // 3. Очікування завершення роботи усіх потоків
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }

        // 4. Повідомлення про закінчення після того, як всі потоки відпрацювали
        Console.WriteLine("\nРозрахунок закінчено.");
    }

    // Метод для обчислення факторіалу числа
    static long CalculateFactorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
