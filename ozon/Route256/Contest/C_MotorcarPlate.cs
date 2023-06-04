using System.Text;

namespace Route256.Contest
{
    public static class C_MotorcarPlate
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var origin = Console.ReadLine();
                var plates = new List<string>();
                var plate = new StringBuilder();
                bool isCheck = true;
                for (int j = 0; j < origin.Length; j++)
                {
                    plate.Append(origin[j]);
                    if(plate.Length == 4)
                    {
                        if(checkPlate1(plate.ToString()))
                        {
                            plates.Add(plate.ToString());
                            plate.Clear();
                        }
                        continue;
                    }

                    if (plate.Length == 5)
                    {
                        if (checkPlate2(plate.ToString()))
                        {
                            plates.Add(plate.ToString());
                            plate.Clear();
                            continue;
                        }
                        isCheck= false;
                        break;
                    }
                }

                if (isCheck && plate.Length > 0)
                {
                    if (plate.Length == 4)
                    {
                        if (checkPlate1(plate.ToString()))
                            plates.Add(plate.ToString());
                        else
                            isCheck = false;
                    }
                    else if (plate.Length == 5)
                    {
                        if (checkPlate2(plate.ToString()))
                            plates.Add(plate.ToString());
                        else
                            isCheck = false;

                    }
                    else
                    {
                        isCheck = false;
                    }
                }
                
                if(isCheck)
                {
                    foreach (var pl in plates)
                        Console.Write($"{pl} ");
                }
                else
                {
                    Console.Write($"-");
                }
                Console.WriteLine();
            }
        }

        private static bool checkPlate1(string plate)
        {
            if(plate.Length != 4)
                return false;
            if (!char.IsLetter(plate[0]))
                return false;
            if (!char.IsNumber(plate[1]))
                return false;
            if (!char.IsLetter(plate[2]))
                return false;
            if (!char.IsLetter(plate[3]))
                return false;
            return true;
        }

        private static bool checkPlate2(string plate)
        {
            if (plate.Length != 5)
                return false;
            if (!char.IsLetter(plate[0]))
                return false;
            if (!char.IsNumber(plate[1]))
                return false;
            if (!char.IsNumber(plate[2]))
                return false;
            if (!char.IsLetter(plate[3]))
                return false;
            if (!char.IsLetter(plate[4]))
                return false;
            return true;
        }
    }
}
