using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForTest
{
    class ContestWinner : IContestWinner
    {
        public int GetWinner(int[] events)
        {
            var records = events.Select((e, i) => new {contestant = e, index = i})
                .GroupBy(g => g.contestant, g => g.index);
            var query = records.Select(q => new {contestant = q.Key, tasks = q.ToList().Count, place = q.Max()});
           
            int maxTask = 0;
            int minPlace = events.Length;
            int winner = 0;
            foreach (var q in query)
            {
                if (q.tasks > maxTask)
                {
                    winner = q.contestant;
                    maxTask = q.tasks;
                    minPlace = q.place;
                }
                else if (q.tasks == maxTask)
                {
                    if (q.place < minPlace)
                    {
                        winner = q.contestant;
                        minPlace = q.place;
                    }
                }
                
            }
            return winner;
        }

        public int GetWinnerLINQ(int[] events)
        {
            var records = events.Select((e, i) => new { contestant = e, index = i })
                .GroupBy(g => g.contestant, g => g.index);
            var query = records.Select(q => new { contestant = q.Key, tasks = q.ToList().Count, place = q.Max() });

            int maxTask = query.Max(q => q.tasks);
            var winners = query.Where(q => q.tasks == maxTask);
            int winner = winners.First(w => w.place == winners.Min(x => x.place)).contestant;
            return winner;

        }
    }
}
