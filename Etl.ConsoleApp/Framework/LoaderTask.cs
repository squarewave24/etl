﻿using System.Data;
using System.Diagnostics;
using Etl.ConsoleApp.Util;

namespace Etl.ConsoleApp.Framework
{
    public abstract class LoaderTask : EtlTask, ILoader
    {
        protected LoaderTask(int jobId) : base(jobId) {}

        // concrete class will be implemented here
        public abstract void OnLoad(DataTable data);

        public void Load(DataTable data) {
            var watch = new Stopwatch();
            watch.Start();

            _logger.Info("{0} starting", GetType().Name);
            try {
                OnLoad(data);
            } finally {
                _logger.Info("{0} finished in {1} seconds", GetType().Name, watch.Elapsed.TotalSeconds);
            }
        }
    }
}
