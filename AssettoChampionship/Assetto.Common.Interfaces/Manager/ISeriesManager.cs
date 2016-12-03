﻿using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Manager
{
    public interface ISeriesManager
    {
        IEnumerable<SeriesData> GetAvailableSeries();
        void StartEvent(EventData eventData);

    }
}
