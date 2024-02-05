namespace Route256.Sandbox
{
    public static class DataCompression
    {
        /// <summary>
        /// Вам предстоит реализовать простейший алгоритм компрессии последовательности чисел, который предполагает, 
        /// что последовательность состоит из подряд идущих возрастающих или убывающих отрезков чисел.
        /// Формально, будем представлять результат компрессии как новую последовательность чётной длины вида 
        /// b1,c1,b2,c2,...,bk,ck, где пара идущих подряд членов bi,ci означает, что:
        /// - если ci >= 0, что в искомой последовательности был возрастающий отрезок вида bi,bi+1,bi+2,...,bi+ci;
        /// - если ci < 0, что в искомой последовательности был убывающий отрезок вида bi,bi-1,bi-2,...,bi-|ci|.
        /// По заданной последовательности a выведите такой результат сжатия, который имеет наименьшую 
        /// длину(последовательность-результат содержит минимальное количество элементов). 
        /// Если такое сжатие неоднозначно, то выведите любое из них.
        /// </summary>
        public static int[] Execute(int[] numbers)
        {
            var result = new List<int>();
            int step = 0;
            int firstNum = numbers[0];
            int countNum = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (step == 0)
                {
                    if (Math.Abs(numbers[i] - numbers[i-1]) == 1)
                    {
                        step = numbers[i] - numbers[i-1];
                        countNum++;
                    }
                    else
                    {
                        result.Add(firstNum);
                        result.Add(countNum * step);
                        firstNum = numbers[i];
                    }
                }
                else
                {
                    if (numbers[i - 1] + step == numbers[i])
                    {
                        countNum++;
                    }
                    else
                    {
                        result.Add(firstNum);
                        result.Add(countNum * step);
                        step = 0;
                        countNum = 0;
                        firstNum = numbers[i];
                    }
                }
            }
            result.Add(firstNum);
            result.Add(countNum * step);
            return result.ToArray();
        }
        
        public static IEnumerable<(int[] numbers, int[] answer)> GetTests()
        {
            yield return (
                new int[] { 3, 2, 1, 0, -1, 0, 6, 6, 7 },
                new int[] { 3, -4, 0, 0, 6, 0, 6, 1 });
            yield return (
                new int[] { 1000 },
                new int[] { 1000, 0 });
            yield return (
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 1, 6 });
            yield return (
                new int[] { 1, 3, 5, 7, 9, 11, 13 },
                new int[] { 1, 0, 3, 0, 5, 0, 7, 0, 9, 0, 11, 0, 13, 0 });
            yield return (
                new int[] { 100, 101, 102, 103, 19, 20, 21, 22, 42, 41, 40 },
                new int[] { 100, 3, 19, 3, 42, -2 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}
