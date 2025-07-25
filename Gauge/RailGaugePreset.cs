namespace Gauge
{
    public enum RailGaugePreset
    {
        Custom = 0,
        Standard = 1,
        Cape = 2,
        ThreeFoot = 3,
        Metre = 4,
        FiveFoot = 5,
        Iberian = 6,
        Indian = 7
    }

    public static class RailGaugePresetExtensions
    {
        public static RailGauge RailGauge(this RailGaugePreset preset)
        {
            return global::Gauge.RailGauge.PRESETS[preset];
        }
    }
}
