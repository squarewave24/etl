using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etl.ConsoleApp.Util;
using Newtonsoft.Json;

namespace Etl.ConsoleApp.Framework
{
    public class EtlTask
    {
        private int _jobId;
        protected ILogger _logger;

        public EtlTask(int jobId) {
            _jobId = jobId;
            _logger = Resolve<ILogger>();

        }
        // public for testing purposes
        public static object ParseConfig() {
            var configStr = "";
            using (var sr = new StreamReader(ConfigurationManager.AppSettings["etl.config.db"])) {
                configStr = sr.ReadToEnd();
            }
            dynamic parsed = JsonConvert.DeserializeObject(configStr);
            return parsed;
        }

        protected object GetConfig() {
            dynamic parsed = ParseConfig();
            if (parsed.jobs == null)
                throw new ArgumentException("jobs section not found in configuration");

            dynamic jobs = parsed.jobs as IEnumerable<dynamic>;
            if (jobs == null)
                throw new ArgumentException("jobs section was found but it is not a collection");

            foreach (dynamic job in jobs) {
                if (job.jobId != null && Convert.ToInt32(job.jobId) == _jobId)
                    return job;
            }
            throw new ArgumentException(string.Format("could not find a job for id: {0}", _jobId));

        }

        protected T Resolve<T>() {
            return Ioc.Container.Resolve<T>();
        }
    }
}
