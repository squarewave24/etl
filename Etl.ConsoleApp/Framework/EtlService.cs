using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etl.ConsoleApp.Tasks;

namespace Etl.ConsoleApp.Framework
{
    public class EtlService
    {
        private LoaderTask _loader; // this can be a collection
        private ExtractorTask _extractor; // this cold be a collection 

        public void RunEtlJob(int jobId)
        {
            // CUTTING CORNERS
            // running out of time, so will cut corners here 
            // in real life these concrete implementations would be done dynamically based on config
            _extractor = new CsvExtractor(jobId);
            _loader = new SqlLoader(jobId);


            var data = _extractor.Extract();

            // if we had transformers, we'd pipe them here

            _loader.Load(data);

        }
    }
}
