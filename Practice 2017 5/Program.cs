using System;

// Задание №5 практики 2017г. 
// Задание 692к, стр. 326: !В задание не сказано учитывается ли диагональ матрицы, решено учитывать! Дана действительная квадратная матрица порядка n. Найти наибольшее из значений элементов, расположенных в заштрихованной части матрицы
// Ссылка на "Задачи по программированию": http://aesa.kz:8081/computer-science/abramov.pdf

namespace Practice_2017_5
{
    class Program
    {
        static double[,] ReadMatrix(int n)
        {
            double[,] matrix =new double[n,n];
             
            for (int i = 0; i < n; i++)          // Обход всех рядов для записи
            {
                Console.WriteLine("Введите ВСЮ " + (i + 1) + "-ую строку (отделяя числа одним пробелом): ");
                string row = Console.ReadLine();

                for (int j = 0; j < n; j++)      // Обход всех столбцов для записи
                    matrix[i, j] = double.Parse(row.Split(' ')[j]);
            }
            return matrix;
        } // Чтение матрицы

        static double MatrixsLeftBottomPartMax(double[,]matrix)
        {
            int n = matrix.GetLength(0);
            double max = int.MinValue;

            for (int i = 0; i < n; i++)              // Обход всех рядов
                for (int j = n - 1 - i; j < n; j++)  // Обход столбцов из заданной части матрицы (правый нижний угол вместе с диагональю)
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
            return max;
        } // Поиск максимума из заданной части матрицы (правый нижний угол вместе с диагональю)

        static void Main(string[] args)
        {
            Console.Write("Введите размерность матрицы: ");
            int n = int.Parse(Console.ReadLine());

            double[,] matrix = ReadMatrix(n);
            
            Console.WriteLine("Максимальное число из заданной части матрицы = "+ MatrixsLeftBottomPartMax(matrix));
            Console.ReadLine();
        }
    }
}
