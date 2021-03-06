﻿using System;
using System.Collections.Generic;
using System.Linq;
using Trady.Analysis.Infrastructure;
using Trady.Core;
using Trady.Core.Infrastructure;

namespace Trady.Analysis.Indicator
{
    public class MinusDirectionalIndicator<TInput, TOutput> : NumericAnalyzableBase<TInput, (decimal High, decimal Low, decimal Close), TOutput>
    {
        private PlusDirectionalMovementByTuple _pdm;
        private MinusDirectionalMovementByTuple _mdm;
        private readonly GenericMovingAverage _tmdmEma;
        private readonly AverageTrueRangeByTuple _atr;

        public MinusDirectionalIndicator(IEnumerable<TInput> inputs, Func<TInput, (decimal High, decimal Low, decimal Close)> inputMapper, int periodCount) : base(inputs, inputMapper)
        {
            _pdm = new PlusDirectionalMovementByTuple(inputs.Select(i => inputMapper(i).High));
            _mdm = new MinusDirectionalMovementByTuple(inputs.Select(i => inputMapper(i).Low));

            Func<int, decimal?> tmdm = i => _mdm[i] > 0 && _pdm[i] < _mdm[i] ? _mdm[i] : 0;

            _tmdmEma = new GenericMovingAverage(
                periodCount,
                i => Enumerable.Range(i - periodCount + 1, periodCount).Select(tmdm).Average(),
                tmdm,
                i => 1.0m / periodCount,
                inputs.Count());

            _atr = new AverageTrueRangeByTuple(inputs.Select(inputMapper), periodCount);

            PeriodCount = periodCount;
        }

        public int PeriodCount { get; }

        protected override decimal? ComputeByIndexImpl(IReadOnlyList<(decimal High, decimal Low, decimal Close)> mappedInputs, int index)
            => _tmdmEma[index] / _atr[index] * 100;
    }

    public class MinusDirectionalIndicatorByTuple : MinusDirectionalIndicator<(decimal High, decimal Low, decimal Close), decimal?>
    {
        public MinusDirectionalIndicatorByTuple(IEnumerable<(decimal High, decimal Low, decimal Close)> inputs, int periodCount)
            : base(inputs, i => i, periodCount)
        {
        }
    }

    public class MinusDirectionalIndicator : MinusDirectionalIndicator<IOhlcvData, AnalyzableTick<decimal?>>
    {
        public MinusDirectionalIndicator(IEnumerable<IOhlcvData> inputs, int periodCount)
            : base(inputs, i => (i.High, i.Low, i.Close), periodCount)
        {
        }
    }
}