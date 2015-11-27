using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnyKindOfTests
{
    public class AsyncTests
    {
        readonly ParallelOptions n = new ParallelOptions() { MaxDegreeOfParallelism = 5 };
        static object locakable;

        public void AddAsync(IEnumerable<string> items)
        {
            ConcurrentDictionary<string, string> proced = new ConcurrentDictionary<string, string>();
            List<int> a = new List<int>();
            Parallel.ForEach(items, n, async item =>
            {
                await Task.Delay(100);
                item += "1";
                proced.TryAdd(item + "a", item);
            });
        }

        public async Task aaa(IEnumerable<string> items)
        {
            Task<List<string>> t = Task.Run(() =>
            {
                var result = new List<string>();
                Parallel.ForEach(items,
                    () => new List<string>(),
                    (item, loopState, localResult) =>
                    {
                        item += "1";
                        localResult.Add(item + "a");
                        return localResult;
                    },
                    finalLocalResult =>
                    {
                        lock (result)
                        {
                            result.AddRange(finalLocalResult);
                        }
                    });

                return result;
            });

            await t.ContinueWith(r =>
            {
                var result = r.Result;

            });

        }
    }
}
