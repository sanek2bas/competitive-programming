using Top.Interview._150.Linked_List;

namespace Linked_List;

public class LruCacheTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(IList<(string command, int[] args)> data)
    {
        LruCashe cache = null;
        foreach(var d in data)
        {
            switch (d.command)
            {
                case "LRUCache":
                    var capacity = d.args[0];
                    cache = new LruCashe(capacity);
                break;
                case "put":
                    var key = d.args[0];
                    var value = d.args[1];
                    cache.Put(key, value);
                break;
                case "get":
                    var k = d.args[0];
                    var answer = d.args[1];
                    var result = cache.Get(k);
                    await Assert.That(result).IsEqualTo(answer);
                break;
            }
        }
    }

    public IEnumerable<IList<(string command, int[] args)>> DataSource()
    {
        yield return new List<(string command, int[] args)>
        {
            ("LRUCache", [2]),
            ("put", [1, 1]),
            ("put", [2, 2]),
            ("get", [1, 1]),
            ("put", [3, 3]),
            ("get", [2, -1]),
            ("put", [4, 4]),
            ("get", [1, -1]),
            ("get", [3, 3]),
            ("get", [4, 4])
        };
    }
}