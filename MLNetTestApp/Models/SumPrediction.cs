using Microsoft.ML.Data;

namespace MLNetTestApp.Models
{
    public class SumPrediction
    {
        [ColumnName("Score")]
        public float PredictedLabel { get; set; }
    }
}