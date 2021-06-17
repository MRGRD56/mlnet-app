using System;
using System.IO;
using System.Net;
using Microsoft.ML;
using MLNetTestApp.Data;
using MLNetTestApp.Diagnostics;
using MLNetTestApp.Models;
using Timer = System.Timers.Timer;

namespace MLNetTestApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(GetPredictedSum(500f, 50f));

            // var mlContext = new MLContext();
            //
            // var textLoader = mlContext.Data.CreateTextLoader<IrisData>(',', false);
            //
            // var pipeline = mlContext.Transforms.Conversion
            //     .MapValueToKey("Label")
            //     .Append(mlContext.Transforms.Concatenate("Features",
            //         "SepalLength",
            //         "SepalWidth",
            //         "PetalLength",
            //         "PetalWidth"))
            //     .Append(mlContext.MulticlassClassification.Trainers.SdcaNonCalibrated())
            //     .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            //
            // var trainingDataView = DataRepository.GetIrisDataView(textLoader);
            // var transformerChain = Timer.Invoke(() =>
            // {
            //     return pipeline.Fit(trainingDataView);
            // }, elapsedTime =>
            // {
            //     Console.WriteLine($"Модель обучена за {elapsedTime.TotalSeconds:N3} с.");
            // });
            //
            // var predictionEngine = mlContext.Model.CreatePredictionEngine<IrisData, IrisPrediction>(transformerChain);
            //
            // var prediction = new IrisPrediction();
            // predictionEngine.Predict(new IrisData
            // {   //6.0,2.7,5.1,1.6,Iris-versicolor
            //     SepalLength = 6.0f,
            //     SepalWidth = 2.7f,
            //     PetalLength = 5.1f,
            //     PetalWidth = 1.6f,
            // }, ref prediction);
            //
            // Console.WriteLine(prediction.PredictedLabels);
        }

        private static float GetPredictedSum(float a, float b)
        {
            var mlContext = new MLContext();
            var pipeline = mlContext.Transforms.CopyColumns("Label", "Label")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("FirstNumberEncoded", "FirstNumber"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("SecondNumberEncoded", "SecondNumber"))
                .Append(mlContext.Transforms.Concatenate("Features",
                    "FirstNumberEncoded",
                    "SecondNumberEncoded"))
                // .Append(mlContext.Transforms.CopyColumns("Score", "Score"))
                .Append(mlContext.Regression.Trainers.LbfgsPoissonRegression());
                // .Append(mlContext.Transforms.Conversion.MapKeyToValue("Score"));
            
            var textLoader = mlContext.Data.CreateTextLoader<Sum>(',');
            var dataset = DataRepository.GetSumsDataView(textLoader);
            
            Console.WriteLine("Обучение модели...");
            var transformerChain = MLNetTestApp.Diagnostics.Timer.Invoke(() =>
            {
                return pipeline.Fit(dataset);
            }, time =>
            {
                Console.WriteLine($"Модель обучена за {time.TotalSeconds} с.");
            });

            var predicationEngine = mlContext.Model.CreatePredictionEngine<Sum, SumPrediction>(transformerChain);

            var sumPredication = predicationEngine.Predict(new Sum(a, b));
            return sumPredication.PredictedLabel;
        }
    }
}