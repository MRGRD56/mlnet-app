using Microsoft.ML.Data;

namespace MLNetTestApp.Models
{
    public class Sum
    {
        [LoadColumn(0)]
        public float FirstNumber { get; set; }
        
        [LoadColumn(1)]
        public float SecondNumber { get; set; }
        
        [LoadColumn(2)]
        public float Label { get; set; }

        public Sum()
        {
            
        }
        
        public Sum(float firstNumber, float secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }
        
        public Sum(float firstNumber, float secondNumber, float label)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Label = label;
        }
    }
}