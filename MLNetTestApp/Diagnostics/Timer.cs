using System;
using System.Diagnostics;

namespace MLNetTestApp.Diagnostics
{
    public static class Timer
    {
        /// <summary>
        /// Выполняет <paramref name="action"/>, замеряя время выполнения.
        /// </summary>
        /// <param name="action">Делегат, который будет вызван для изменения времени его выполнения.</param>
        /// <param name="elapsedTime">Время, за которое выполнилось <paramref name="action"/>.</param>
        /// <returns></returns>
        public static void Invoke(Action action, out TimeSpan elapsedTime)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
        }
        
        /// <summary>
        /// Выполняет <paramref name="action"/>, замеряя время выполнения.
        /// </summary>
        /// <param name="action">Делегат, который будет вызван для изменения времени его выполнения.</param>
        /// <param name="elapsedTime">Время, за которое выполнилось <paramref name="action"/>.</param>
        /// <typeparam name="TResult">Тип возвращаемого из <paramref name="action"/> значения.</typeparam>
        /// <returns>Значение, возвращённое из <paramref name="action"/>.</returns>
        public static TResult Invoke<TResult>(Func<TResult> action, out TimeSpan elapsedTime)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = action();
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
            return result;
        }

        /// <summary>
        /// Выполняет <paramref name="action"/>, замеряя время выполнения и передавая его в <paramref name="timeCallback"/>.
        /// </summary>
        /// <param name="action">Делегат, который будет вызван для изменения времени его выполнения.</param>
        /// <param name="timeCallback">Делегат, вызываемый после выполнения <paramref name="action"/>.</param>
        public static void Invoke(Action action, Action<TimeSpan> timeCallback)
        {
            timeCallback ??= time => Console.WriteLine(time.ToString());
            Invoke(action, out var elapsedTime);
            timeCallback(elapsedTime);
        }

        /// <summary>
        /// Выполняет <paramref name="action"/>, замеряя время выполнения и передавая его в <paramref name="timeCallback"/>.
        /// </summary>
        /// <param name="action">Делегат, который будет вызван для изменения времени его выполнения.</param>
        /// <param name="timeCallback">Делегат, вызываемый после выполнения <paramref name="action"/>.</param>
        /// <typeparam name="TResult">Тип возвращаемого из <paramref name="action"/> значения.</typeparam>
        /// <returns>Значение, возвращённое из <paramref name="action"/>.</returns>
        public static TResult Invoke<TResult>(Func<TResult> action, Action<TimeSpan> timeCallback)
        {
            timeCallback ??= time => Console.WriteLine(time.ToString());
            var result = Invoke(action, out var elapsedTime);
            timeCallback(elapsedTime);
            return result;
        }
    }
}