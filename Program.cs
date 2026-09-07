namespace ArrayHelperApp;

public static class ArrayHelper
{
    public static void PrintArray<T>(T[] array, string title)
    {
        Console.WriteLine($"{title}:");
        Console.WriteLine(string.Join(" ", array));
    }

    public static int IndexOf<T>(T[] array, T value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(value)) return i;
        }
        return -1;
    }

    public static T Min<T>(T[] array) where T : IComparable<T>
    {
        T min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(min) < 0) min = array[i];
        }
        return min;
    }

    public static T Max<T>(T[] array) where T : IComparable<T>
    {
        T max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(max) > 0) max = array[i];
        }
        return max;
    }

    public static T[] Reverse<T>(T[] array)
    {
        T[] reversed = (T[])array.Clone();
        int left = 0, right = reversed.Length - 1;
        while (left < right)
        {
            T temp = reversed[left];
            reversed[left] = reversed[right];
            reversed[right] = temp;
            left++;
            right--;
        }
        return reversed;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 5, 12, 1, 9, 20 };
        ArrayHelper.PrintArray(numbers, "Числа");
        Console.WriteLine($"Індекс 9: {ArrayHelper.IndexOf(numbers, 9)}");
        Console.WriteLine($"Мін: {ArrayHelper.Min(numbers)}");
        Console.WriteLine($"Макс: {ArrayHelper.Max(numbers)}");
        Console.WriteLine($"Реверс: {string.Join(" ", ArrayHelper.Reverse(numbers))}");

        Console.WriteLine();

        string[] words = { "один", "два", "три", "чотири" };
        ArrayHelper.PrintArray(words, "Рядки");
        Console.WriteLine($"Індекс три: {ArrayHelper.IndexOf(words, "три")}");
        Console.WriteLine($"Мін: {ArrayHelper.Min(words)}");
        Console.WriteLine($"Макс: {ArrayHelper.Max(words)}");
        Console.WriteLine($"Реверс: {string.Join(" ", ArrayHelper.Reverse(words))}");
    }
}
