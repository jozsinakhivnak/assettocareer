﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.ProcessedResult
{
    public class ResultPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BestLap
        {
            get
            {
                if (this.Laps == null || this.Laps.Where(l => l.Time > 0).Count() < 1)
                {
                    return 0;
                }
                else
                {
                    return this.Laps.Where(l => l.Time > 0).OrderBy(l => l.Time).First().Time;
                }
            }
        }

        public string BestLapTimeSpan
        {
            get
            {
                return TimeSpan.FromMilliseconds(BestLap).ToString("mm\\:ss\\:fff");
            }
        }

        public int LapCount { get; set; }

        public List<ResultLap> Laps { get; set; }

        public int Position { get; set; }

        public int TotalTime { get; set; }

        public bool IsPlayer { get; set; }

    }
}
