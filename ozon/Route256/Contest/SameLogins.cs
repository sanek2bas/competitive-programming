namespace Route256.Contest
{
    public static class SameLogins
    {
        /// <summary>
        /// </summary>
        public static IList<int> Execute(IList<string> oldEmployess, IList<string> newEmployees)
        {
            var dic = new Dictionary<string, List<string>>();
            foreach (var employee in oldEmployess)
            {
                var key = new string(employee.Order().ToArray());
                if(!dic.ContainsKey(key))
                    dic.Add(key, new List<string>());
                dic[key].Add(employee);
            }
            var result = new List<int>();
            foreach(var employee in newEmployees)
            {
                var key = new string(employee.Order().ToArray());
                int res = 0;
                if(dic.ContainsKey(key))
                {
                    bool found = false;
                    foreach(var original in dic[key])
                    {
                        if (original == employee)
                        {
                            found = true;
                            break;
                        }    
                        bool oneError = false;
                        bool twoError = false;
                        for(int i = 0; i < original.Length; i++)
                        {
                            if (original[i] == employee[i])
                                continue;
                            if (original[i] == employee[i+1] && original[i+1] == employee[i])
                            {
                                if (oneError)
                                {
                                    twoError = true;
                                    break;
                                }
                                oneError = true;
                                i++;
                            }
                            else 
                            {
                                twoError= true;
                                break;
                            }
                        }
                        if(twoError == false)
                        {
                            found = true;
                            break;
                        }
                    }
                    res = found ? 1 : 0;
                }
                result.Add(res);
            }
            return result;
        }

        public static IEnumerable<(IList<string> oldEmployess, IList<string> newEmployees, IList<int> answer)> GetTests()
        {
            yield return (
                new List<string> { "hello", "ozoner", "roma", "anykey"}, 
                new List<string> { "roma", "ello", "zooner", "ankyey", "ynakey", "amor", "rom" },
                new List<int> { 1, 0, 1, 1, 0, 0, 0 });
        }

        public static bool CheckResult(IList<int> result, IList<int> answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}
