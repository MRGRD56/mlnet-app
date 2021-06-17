using Microsoft.ML.Data;

namespace MLNetTestApp.Models
{
    /// <summary>
    /// Прогнозирование типа цвета ириса.
    /// </summary>
    public class IrisPrediction
    {
        /// <summary>
        /// Результат прогнозирования типа цветка ириса.
        /// </summary>
        [ColumnName("PredictedLabel")]
        public string PredictedLabels { get; set; }
    }
}