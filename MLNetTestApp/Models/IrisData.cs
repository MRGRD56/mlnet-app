using Microsoft.ML.Data;

namespace MLNetTestApp.Models
{
    /// <summary>
    /// Данные о цветке ириса.
    /// </summary>
    public class IrisData
    {
        /// <summary>
        /// Длина чашелистика.
        /// </summary>
        [LoadColumn(0)]
        public float SepalLength { get; set; }
        
        /// <summary>
        /// Ширина чашелистика.
        /// </summary>
        [LoadColumn(1)]
        public float SepalWidth { get; set; }
        
        /// <summary>
        /// Длина лепестка.
        /// </summary>
        [LoadColumn(2)]
        public float PetalLength { get; set; }
        
        /// <summary>
        /// Ширина лепестка.
        /// </summary>
        [LoadColumn(3)]
        public float PetalWidth { get; set; }
        
        /// <summary>
        /// Тип цветка ириса.
        /// </summary>
        [LoadColumn(4)]
        public string Label { get; set; }
    }
}