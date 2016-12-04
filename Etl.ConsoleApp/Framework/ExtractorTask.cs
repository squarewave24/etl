using System.Data;
using System.Diagnostics;
using Etl.ConsoleApp.Util;

namespace Etl.ConsoleApp.Framework
{
    public abstract class ExtractorTask : EtlTask, IExtractor
    {
        protected ExtractorTask(int jobId) : base(jobId) {}

        // concrete class will be implemented here
        protected abstract DataTable OnExtract();

        public DataTable Extract() {
            var watch = new Stopwatch();
            watch.Start();

            _logger.Info($"{this.GetType().Name} starting");
            try {
                return OnExtract();
            } finally {
                _logger.Info($"{this.GetType().Name} finished in {watch.Elapsed.TotalSeconds} seconds");
            }
        }
    }
}
