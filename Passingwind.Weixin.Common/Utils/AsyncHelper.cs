using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Utils
{
    /// <summary>
    /// Async Helper
    /// </summary>
    public class AsyncHelper
    {
        private static readonly TaskFactory _factory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        /// <summary>
        /// run 
        /// </summary> 
        public static void RunSync(Func<Task> func)
        {
            CultureInfo cultureUi = CultureInfo.CurrentUICulture;
            CultureInfo culture = CultureInfo.CurrentCulture;

            _factory.StartNew<Task>(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;

                return func();
            }).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// run 
        /// </summary> 
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            CultureInfo cultureUi = CultureInfo.CurrentUICulture;
            CultureInfo culture = CultureInfo.CurrentCulture;

            return _factory.StartNew<Task<TResult>>(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;

                return func();
            }).Unwrap<TResult>().GetAwaiter().GetResult();
        }
    }
}
