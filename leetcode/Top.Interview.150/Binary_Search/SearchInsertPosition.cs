namespace Top.Interview._150.Binary_Search
{
    public class SearchInsertPosition
    {
        public int Execute(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int middle = (left + right) / 2;
                if (nums[middle] == target)
                    return middle;
                if (nums[middle] < target)
                    left = middle + 1;
                else
                    right = middle;
            }
            return left;
        }
    }
}
