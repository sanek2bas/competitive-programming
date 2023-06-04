namespace Route256.Sandbox
{
    public static class G_PotentialFriends
    {
        public static void Main()
        {
            var nm = Console.ReadLine()
                .Split()
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            int usersCount = nm[0];
            int pairsCount = nm[1];

            var usersArray = new User[usersCount];
            for (int i = 0; i < usersCount; i++)
            {
                usersArray[i] = new User(i + 1);
            }

            for (int i = 0; i < pairsCount; i++)
            {
                var pairArray = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();

                var user1 = usersArray[pairArray[0] - 1];
                var user2 = usersArray[pairArray[1] - 1];

                user1.Friends.Add(user2.Id);
                user2.Friends.Add(user1.Id);
            }

            for (int i = 0; i < usersCount; i++)
            {
                var curUser = usersArray[i];
                var potentialFriendsDic = new Dictionary<int, int>();
                foreach (var friendId in curUser.Friends)
                {
                    foreach (var potentialFriendId in usersArray[friendId - 1].Friends)
                    {
                        if (potentialFriendId == curUser.Id ||
                            curUser.Friends.Contains(potentialFriendId))
                            continue;

                        if (potentialFriendsDic.ContainsKey(potentialFriendId))
                            potentialFriendsDic[potentialFriendId]++;
                        else
                            potentialFriendsDic.Add(potentialFriendId, 1);
                    }
                }
                if (potentialFriendsDic.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(String.Join(" ", getAllKeyWithMaxValue(potentialFriendsDic).OrderBy(x => x).ToArray()));
                }
            }
        }

        private static List<int> getAllKeyWithMaxValue(Dictionary<int, int> dic)
        {
            int max = 0;
            var result = new List<int>();
            foreach (var pair in dic)
            {
                if (pair.Value < max)
                    continue;

                if (pair.Value > max)
                {
                    result.Clear();
                    max = pair.Value;
                }
                result.Add(pair.Key);
            }
            return result;
        }

        private class User
        {
            public int Id { get; }

            public HashSet<int> Friends { get; }

            public User(int id)
            {
                Id = id;
                Friends = new HashSet<int>();
            }
        }
    }
}
