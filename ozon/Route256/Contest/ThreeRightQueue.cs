using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Contest
{
    public static class ThreeRightQueue
    {
        /// <summary>
        /// </summary>

        const char x = 'X';
        const char y = 'Y';
        const char z = 'Z';
        public static bool Execute(string queue)
        {
            var noVisisted = new Dictionary<char, SortedSet<int>>();
            noVisisted.Add(x, new SortedSet<int>());
            noVisisted.Add(y, new SortedSet<int>());
            noVisisted.Add(z, new SortedSet<int>());

            for (int i = 0; i < queue.Length; i++)
                noVisisted[queue[i]].Add(i);

            int first = 0;
            int last = queue.Length - 1;

            return check(queue, noVisisted, first, last);
            //while (noVisisted[x].Count > 0 || noVisisted[y].Count > 0 || noVisisted[z].Count > 0)
            //{
            //    if (first > last)
            //        return false;

            //    if (queue[first] == z)
            //    {
            //        if (noVisisted[z].Contains(first))
            //        {
            //            return false;
            //        }
            //        else
            //        {
            //            first++;
            //        }                
            //    }
            //    else if(queue[last] == x)
            //    {
            //        if (noVisisted[x].Contains(last))
            //        {
            //            return false;
            //        }
            //        else
            //        {
            //            last--;
            //        }
            //    }
            //    else if (queue[last] == y)
            //    {
            //        if (noVisisted[y].Contains(last))
            //        {
            //            noVisisted[y].Remove(last);
            //            last--;
            //            if (noVisisted[x].Count == 0)
            //                return false;
            //            var lastX = noVisisted[x].Last();
            //            noVisisted[x].Remove(lastX);
            //            if (last == lastX)
            //                last--;
            //        }
            //        else
            //        {
            //            last--;
            //        }                    
            //    }
            //    else if (queue[first] == y)
            //    {
            //        if (noVisisted[y].Contains(first))
            //        {
            //            noVisisted[y].Remove(first);
            //            first++;
            //            if (noVisisted[z].Count == 0)
            //                return false;
            //            var firstZ = noVisisted[z].First();
            //            noVisisted[z].Remove(firstZ);
            //            if (firstZ == first)
            //                first++;
            //        }
            //        else
            //        {
            //            first++;
            //        }
            //    }
            //    else
            //    {
            //        if (noVisisted[x].Contains(first))
            //        {
            //            if (noVisisted[y].Count == 0 && noVisisted[z].Count == 0)
            //                return false;
            //            noVisisted[x].Remove(first);
            //            first++;
            //            var firstY = noVisisted[y].Count() > 0 ? noVisisted[y].First() : -1;
            //            var firstZ = noVisisted[z].Count() > 0 ? noVisisted[z].First() : -1;
            //            if ((noVisisted[y].Count > noVisisted[z].Count) ||
            //                (noVisisted[y].Count == noVisisted[z].Count && firstZ - firstY > 1))
            //            {;
            //                noVisisted[y].Remove(firstY);
            //                if (firstY == first)
            //                    first++;
            //            }
            //            else
            //            {
            //                noVisisted[z].Remove(firstZ);
            //                if (firstZ == first)
            //                    first++;
            //            }
            //        }
            //        else
            //        {
            //            first++;
            //        }
            //    }               
            //}                     
            
            //return true;

        }

        static bool check(string queue, Dictionary<char, SortedSet<int>> noVisited, int first, int last)
        {
            if (noVisited[x].Count == 0 &&
                noVisited[y].Count == 0 &&
                noVisited[z].Count == 0)
                return true;

            if (first > last)
                return false;

            if (queue[first] == z)
            {
                return noVisited[z].Contains(first)
                    ? false
                    : check(queue, noVisited, first+1, last);
            }

            if (queue[last] == x)
            {
                return noVisited[x].Contains(last)
                    ? false
                    : check(queue, noVisited, first, last-1);
            }

            if (queue[first] == y)
            {
                if (!noVisited[y].Contains(first))
                    return check(queue, noVisited, first+1, last);
                if (noVisited[z].Count == 0)
                    return false;
                noVisited[y].Remove(first);
                first++;
                var zIdx = noVisited[z].First();
                noVisited[z].Remove(zIdx);
                var res = check(queue, noVisited, first == zIdx ? first + 1 : first, last == zIdx ? last - 1 : last);
                if (res)
                    return true;
                first--;
                noVisited[z].Add(zIdx);
                noVisited[y].Add(first);                
                return false;
            }

            if (queue[last] == y)
            {
                if (!noVisited[y].Contains(last))
                    return check(queue, noVisited, first, last - 1);
                if (noVisited[x].Count == 0)
                    return false;
                noVisited[y].Remove(last);
                last--;
                var xIdx = noVisited[x].Last();
                noVisited[x].Remove(xIdx);
                var res = check(queue, noVisited, first == xIdx ? first + 1 : first, last == xIdx ? last - 1 : last);
                if (res)
                    return true;
                last++;
                noVisited[z].Add(xIdx);
                noVisited[y].Add(last);
                return false;
            }


            if (noVisited[y].Count == 0 && noVisited[z].Count == 0)
                return false;

            if (!noVisited[x].Contains(first))
                return check(queue, noVisited, first + 1, last);

            noVisited[x].Remove(first);
            first++;

            var forX = new SortedSet<int>();
            forX.UnionWith(noVisited[y]);
            forX.UnionWith(noVisited[z].Take(2));
            var yzArray = forX.ToArray();

            foreach(var next in yzArray)
            {
                if (noVisited[y].Contains(next))
                {
                    noVisited[y].Remove(next);
                    var res = check(queue, noVisited, first == next ? first + 1 : first, last == next ? last - 1 : last);
                    if (res)
                        return true;
                    noVisited[y].Add(next);
                }
                else
                {
                    noVisited[z].Remove(next);
                    var res = check(queue, noVisited, first == next ? first + 1 : first, last == next ? last - 1 : last);
                    if (res)
                        return true;
                    noVisited[z].Add(next);
                }
            }

            first--;
            noVisited[x].Add(first);            

            return false;
        }

        //static bool check(string queue, Dictionary<char, SortedSet<int>> idxs, int idx)
        //{
        //    if (idx == queue.Length)
        //        return idxs['X'].Count == 0
        //            && idxs['Y'].Count == 0
        //            && idxs['Z'].Count == 0;

        //    var curr = queue[idx];

        //    if (curr == 'X')
        //    {
        //        idxs['X'].Add(idx);
        //        var res = check(queue, idxs, idx+1);
        //        if (res)
        //            return true;
        //        idxs['X'].Remove(idx);
        //    }
        //    else if(curr == 'Y')
        //    {
        //        foreach(var i in idxs['X'].ToArray())
        //        {
        //            idxs['X'].Remove(i);
        //            var res = check(queue, idxs, idx+1);
        //            if (res)
        //                return true;
        //            idxs['X'].Add(i);
        //        }
        //        idxs['Y'].Add(idx);
        //        var r = check(queue, idxs, idx+1);
        //        if (r)
        //            return true;
        //        idxs['Y'].Remove(idx);
        //    }
        //    else
        //    {
        //        foreach (var i in idxs['Y'].ToArray())
        //        {
        //            idxs['Y'].Remove(i);
        //            var res = check(queue, idxs, idx + 1);
        //            if (res)
        //                return true;
        //            idxs['Y'].Add(i);
        //        }

        //        foreach (var i in idxs['X'].ToArray())
        //        {
        //            idxs['X'].Remove(i);
        //            var res = check(queue, idxs, idx + 1);
        //            if (res)
        //                return true;
        //            idxs['X'].Add(i);
        //        }
        //    }            

        //    return false;
        //}

        //static bool check(string queue, SortedSet<int> noVisited)
        //{
        //    if (noVisited.Count == 0)
        //        return true;
        //    var first = noVisited.First();
        //    if (queue[first] == 'Z')
        //        return false;
        //    noVisited.Remove(first);
        //    if (queue[first] == 'Y')
        //    {
        //        foreach(var second in noVisited.ToArray())
        //        {
        //            if (queue[second] != 'Z')
        //                continue;
        //            noVisited.Remove(second);
        //            if(check(queue, noVisited))
        //                return true;
        //            noVisited.Add(second);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var second in noVisited.ToArray())
        //        {
        //            if (queue[second] == 'X')
        //                continue;
        //            noVisited.Remove(second);
        //            if (check(queue, noVisited))
        //                return true;
        //            noVisited.Add(second);
        //        }
        //    }

        //    noVisited.Add(first);
        //    return false;

        //    //foreach (var second in noVisited.ToArray())
        //    //{
        //    //    if ((queue[first] == 'X' && (queue[second] == 'Y' || queue[second] == 'Z')) ||
        //    //        (queue[first] == 'Y' && queue[second] == 'Z'))
        //    //    {
        //    //        noVisited.Remove(second);
        //    //        if(check(queue, set, noVisited))
        //    //            return true;
        //    //        noVisited.Add(second);
        //    //    }
        //    //}
        //    //noVisited.Add(first);
        //    //return false;
        //}

        public static IEnumerable<(string queue, bool answer)> GetTests()
        {
            yield return ("YXYYZZ", true);
            yield return ("ZYXZ", false);
            yield return ("XYZXZY", true);
            yield return ("YYZYZZZZYXYZZXYX", false);
            yield return ("YYXXYXYZZXYXZZZYZZYY", true);
            yield return ("XYYXYZZZXY", true);
            yield return ("YXYYZZ", true);
            yield return ("XYXXZZ", true);
            yield return ("XYXZZY", true);
            yield return ("XYXZZZ", true);
            yield return ("XXZXYY", true);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}
