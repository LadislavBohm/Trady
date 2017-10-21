﻿using System;
using System.Collections.Generic;
using System.Linq;
using Trady.Analysis.Infrastructure;
using Trady.Core;
using Trady.Core.Infrastructure;

namespace Trady.Analysis.Indicator
{
    public class ExponentialMovingAverage<TInput, TOutput> : NumericAnalyzableBase<TInput, decimal?, TOutput>
    {
        private readonly GenericMovingAverage _ema;

        public ExponentialMovingAverage(IEnumerable<TInput> inputs, Func<TInput, decimal?> inputMapper, int periodCount) : base(inputs, inputMapper)
        {
            _ema = new GenericMovingAverage(
                i => inputs.Select(inputMapper).ElementAt(i),
                2.0m / (periodCount + 1),
                inputs.Count());

            PeriodCount = periodCount;
        }

        public int PeriodCount { get; }

        protected override decimal? ComputeByIndexImpl(IReadOnlyList<decimal?> mappedInputs, int index) => _ema[index];
    }

    public class ExponentialMovingAverageByTuple : ExponentialMovingAverage<decimal?, decimal?>
    {
        public ExponentialMovingAverageByTuple(IEnumerable<decimal?> inputs, int periodCount)
            : base(inputs, i => i, periodCount)
        {
        }

		public ExponentialMovingAverageByTuple(IEnumerable<decimal> inputs, int periodCount)
	        : this(inputs.Cast<decimal?>(), periodCount)
		{
		}
    }

    public class ExponentialMovingAverage : ExponentialMovingAverage<IOhlcvData, AnalyzableTick<decimal?>>
    {
        public ExponentialMovingAverage(IEnumerable<IOhlcvData> inputs, int periodCount)
            : base(inputs, i => i.Close, periodCount)
        {
        }
    }
}