using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = -1;
            string[] line = new string[3];
            line[0] = Console.ReadLine();
            line[1] = Console.ReadLine();
            line[2] = Console.ReadLine();
            int i1 = -1, j1 = -1, i2 = -1, j2 = -1;
            int[,] nums = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    nums[i, j] = Convert.ToInt32(line[i].Split(' ')[j]);
                }
            }
            /*{
                { 1, 2, 3 },
                { 9, 7, 6 },
                { 5, 8, 4 } };*/
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if ((nums[i, j] > max) && ((i + j) % 2 == 0)) // Находим первое число - оно должно быть в центре или в углу
                    {
                        max = nums[i, j];
                        i1 = i;
                        j1 = j;
                    }

            if ((i1 == 1) && (j1 == 1)) // первое число в центре
            {
                max = -1;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if ((nums[i, j] > max) && ((i + j) % 2 == 1))
                        {
                            max = nums[i, j];
                            i2 = i;
                            j2 = j;
                        }
                switch (i2 * 3 + j2) // Разворачиваем матрицу так, чтобы второе число было сверху
                {
                    case 3:
                        nums = Rotate(nums, 1);
                        break;
                    case 5:
                        nums = Rotate(nums, 3);
                        break;
                    case 7:
                        nums = Rotate(nums, 2);
                        break;
                    default:
                        break;
                }
                if (nums[0, 0] > nums[0, 2]) // Разворачиваем чтобы третье было справа
                    nums = HorMirror(nums);
                Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", nums[1, 1], nums[0, 1], nums[0, 2], nums[1, 2], nums[2, 2], nums[2, 1], nums[2, 0], nums[1, 0], nums[0, 0]);
                Console.ReadLine();
                return;
            }
            // Первое число в углах
            switch (i1 * 3 + j1) // разворачиваем чтобы первое было в левом верхнем углу
            {
                case 2:
                    nums = Rotate(nums, 3);
                    break;
                case 6:
                    nums = Rotate(nums, 1);
                    break;
                case 8:
                    nums = Rotate(nums, 2);
                    break;
                default:
                    break;
            }
            if (nums[1, 0] > nums[0, 1]) // второе сверху по центру
                nums = DiagMirror(nums);
            if (nums[1, 1] > nums[0, 2]) // если третье в центре
                Console.WriteLine("" + nums[0, 0] + nums[0, 1] + nums[1, 1] + nums[1, 0] + nums[2, 0] + nums[2, 1] + nums[2, 2] + nums[1, 2] + nums[0, 2]);
            else if (nums[1, 1] > nums[2, 2]) // если пятое в центре 
                Console.WriteLine("" + nums[0, 0] + nums[0, 1] + nums[0, 2] + nums[1, 2] + nums[1, 1] + nums[1, 0] + nums[2, 0] + nums[2, 1] + nums[2, 2]);
            else if (nums[1, 1] > nums[2, 0]) // если седьмое в центре
                Console.WriteLine("" + nums[0, 0] + nums[0, 1] + nums[0, 2] + nums[1, 2] + nums[2, 2] + nums[2, 1] + nums[1, 1] + nums[1, 0] + nums[2, 0]);
            else
                Console.WriteLine("" + nums[0, 0] + nums[0, 1] + nums[0, 2] + nums[1, 2] + nums[2, 2] + nums[2, 1] + nums[2, 0] + nums[1, 0] + nums[1, 1]);

            Console.ReadLine();
        }


        public static int[,] Rotate(int[,] m, int times)
        {
            int[,] result = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    result[i, j] = m[2 - j, i];
            if (times > 1)
                return Rotate(result, times - 1);
            else
                return result;
        }
        public static int[,] HorMirror(int[,] m)
        {
            int[,] result = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    result[i, j] = m[i, 2 - j];
            return result;
        }

        /// <summary>
        /// Разворачиваем матрицу по диагонали
        /// </summary>
        /// <param name="m">Матрица</param>
        /// <returns></returns>
        public static int[,] DiagMirror(int[,] m)
        {
            int[,] result = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = m[j, i];
                }
            }

            return result;
        }
    }
}
