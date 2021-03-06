﻿using System;
using System.Collections.Generic;

using Trady.Analysis.Indicator;
using Trady.Analysis.Infrastructure;
using Trady.Core.Infrastructure;

namespace Trady.Analysis.Extension
{
    public static class IOhlcvDatasExtension
    {
        public static IReadOnlyList<AnalyzableTick<decimal?>> Func(this IEnumerable<IOhlcvData> candles, Func<IReadOnlyList<IOhlcvData>, int, IReadOnlyList<decimal>, IAnalyzeContext<IOhlcvData>, decimal?> func, params decimal[] parameters)
            => func.AsAnalyzable(candles, parameters).Compute();

        public static IReadOnlyList<AnalyzableTick<decimal?>> Func(this IEnumerable<IOhlcvData> candles, string name, params decimal[] parameters)
            => FuncAnalyzableFactory.CreateAnalyzable(name, candles, parameters).Compute();

        public static IReadOnlyList<AnalyzableTick<decimal?>> AccumDist(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new AccumulationDistributionLine(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? Up, decimal? Down)>> Aroon(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new Aroon(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> AroonOsc(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new AroonOscillator(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Adx(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new AverageDirectionalIndex(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Adxr(this IEnumerable<IOhlcvData> candles, int periodCount, int adxrPeriodCount, int? startIndex = null, int? endIndex = null)
            => new AverageDirectionalIndexRating(candles, periodCount, adxrPeriodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Atr(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new AverageTrueRange(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? LowerBand, decimal? MiddleBand, decimal? UpperBand)>> Bb(this IEnumerable<IOhlcvData> candles, int periodCount, decimal sdCount, int? startIndex = null, int? endIndex = null)
            => new BollingerBands(candles, periodCount, sdCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> BbWidth(this IEnumerable<IOhlcvData> candles, int periodCount, decimal sdCount, int? startIndex = null, int? endIndex = null)
            => new BollingerBandWidth(candles, periodCount, sdCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? Long, decimal? Short)>> Chandlr(this IEnumerable<IOhlcvData> candles, int periodCount, decimal atrCount, int? startIndex = null, int? endIndex = null)
            => new ChandelierExit(candles, periodCount, atrCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> CloseDiff(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new ClosePriceChange(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> CloseDiff(this IEnumerable<IOhlcvData> candles, int numberOfDays, int? startIndex = null, int? endIndex = null)
            => new ClosePriceChange(candles, numberOfDays).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> ClosePcDiff(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new ClosePricePercentageChange(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> ClosePcDiff(this IEnumerable<IOhlcvData> candles, int numberOfDays, int? startIndex = null, int? endIndex = null)
            => new ClosePricePercentageChange(candles, numberOfDays).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Dmi(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new DirectionalMovementIndex(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Er(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new EfficiencyRatio(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Ema(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new ExponentialMovingAverage(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> EmaOsc(this IEnumerable<IOhlcvData> candles, int periodCount1, int periodCount2, int? startIndex = null, int? endIndex = null)
            => new ExponentialMovingAverageOscillator(candles, periodCount1, periodCount2).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> HighHigh(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new HighestHigh(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> HistHighHigh(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new HistoricalHighestHigh(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> HistHighClose(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new HistoricalHighestClose(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> HighClose(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new HighestClose(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? ConversionLine, decimal? BaseLine, decimal? LeadingSpanA, decimal? LeadingSpanB, decimal? LaggingSpan)>> Ichimoku(this IEnumerable<IOhlcvData> candles, int shortPeriodCount, int middlePeriodCount, int longPeriodCount, int? startIndex = null, int? endIndex = null)
            => new IchimokuCloud(candles, shortPeriodCount, middlePeriodCount, longPeriodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Kama(this IEnumerable<IOhlcvData> candles, int periodCount, int emaFastPeriodCount, int emaSlowPeriodCount, int? startIndex = null, int? endIndex = null)
            => new KaufmanAdaptiveMovingAverage(candles, periodCount, emaFastPeriodCount, emaSlowPeriodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> LowLow(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new LowestLow(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> HistLowLow(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new HistoricalLowestLow(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> HistLowClose(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new HistoricalLowestClose(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> LowClose(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new LowestClose(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Mdi(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new MinusDirectionalIndicator(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Mdm(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new MinusDirectionalMovement(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Mma(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new ModifiedMovingAverage(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? MacdLine, decimal? SignalLine, decimal? MacdHistogram)>> Macd(this IEnumerable<IOhlcvData> candles, int emaPeriodCount1, int emaPeriodCount2, int demPeriodCount, int? startIndex = null, int? endIndex = null)
            => new MovingAverageConvergenceDivergence(candles, emaPeriodCount1, emaPeriodCount2, demPeriodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> MacdHist(this IEnumerable<IOhlcvData> candles, int emaPeriodCount1, int emaPeriodCount2, int demPeriodCount, int? startIndex = null, int? endIndex = null)
	        => new MovingAverageConvergenceDivergenceHistogram(candles, emaPeriodCount1, emaPeriodCount2, demPeriodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Obv(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new OnBalanceVolume(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Pdi(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new PlusDirectionalIndicator(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Pdm(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new PlusDirectionalMovement(candles).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Rsv(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new RawStochasticsValue(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Rs(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new RelativeStrength(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Rsi(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new RelativeStrengthIndex(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Sma(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new SimpleMovingAverage(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> SmaOsc(this IEnumerable<IOhlcvData> candles, int periodCount1, int periodCount2, int? startIndex = null, int? endIndex = null)
            => new SimpleMovingAverageOscillator(candles, periodCount1, periodCount2).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Sd(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
            => new StandardDeviation(candles, periodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? K, decimal? D, decimal? J)>> FastSto(this IEnumerable<IOhlcvData> candles, int periodCount, int smaPeriodCount, int? startIndex = null, int? endIndex = null)
            => new Stochastics.Fast(candles, periodCount, smaPeriodCount).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? K, decimal? D, decimal? J)>> FullSto(this IEnumerable<IOhlcvData> candles, int periodCount, int smaPeriodCountK, int smaPeriodCountD, int? startIndex = null, int? endIndex = null)
            => new Stochastics.Full(candles, periodCount, smaPeriodCountK, smaPeriodCountD).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<(decimal? K, decimal? D, decimal? J)>> SlowSto(this IEnumerable<IOhlcvData> candles, int periodCount, int smaPeriodCountD, int? startIndex = null, int? endIndex = null)
            => new Stochastics.Slow(candles, periodCount, smaPeriodCountD).Compute(startIndex, endIndex);

		public static IReadOnlyList<AnalyzableTick<decimal?>> FastStoOsc(this IEnumerable<IOhlcvData> candles, int periodCount, int smaPeriodCount, int? startIndex = null, int? endIndex = null)
	        => new StochasticsOscillator.Fast(candles, periodCount, smaPeriodCount).Compute(startIndex, endIndex);

		public static IReadOnlyList<AnalyzableTick<decimal?>> FullStoOsc(this IEnumerable<IOhlcvData> candles, int periodCount, int smaPeriodCountK, int smaPeriodCountD, int? startIndex = null, int? endIndex = null)
			=> new StochasticsOscillator.Full(candles, periodCount, smaPeriodCountK, smaPeriodCountD).Compute(startIndex, endIndex);

		public static IReadOnlyList<AnalyzableTick<decimal?>> SlowStoOsc(this IEnumerable<IOhlcvData> candles, int periodCount, int smaPeriodCountD, int? startIndex = null, int? endIndex = null)
			=> new StochasticsOscillator.Slow(candles, periodCount, smaPeriodCountD).Compute(startIndex, endIndex);

        public static IReadOnlyList<AnalyzableTick<decimal?>> Tr(this IEnumerable<IOhlcvData> candles, int? startIndex = null, int? endIndex = null)
            => new TrueRange(candles).Compute(startIndex, endIndex);

		public static IReadOnlyList<AnalyzableTick<decimal?>> Median(this IEnumerable<IOhlcvData> candles, int periodCount, int? startIndex = null, int? endIndex = null)
	        => new Median(candles, periodCount).Compute(startIndex, endIndex);

		public static IReadOnlyList<AnalyzableTick<decimal?>> Percentile(this IEnumerable<IOhlcvData> candles, int periodCount, decimal percent, int? startIndex = null, int? endIndex = null)
	        => new Percentile(candles, periodCount, percent).Compute(startIndex, endIndex);
    }
}