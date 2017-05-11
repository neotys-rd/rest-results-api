using System.Collections.Generic;
using System.Threading;
using Simple.OData.Client;

/*
 * Copyright (c) 2017, Neotys
 * All rights reserved.
 */

namespace Neotys.ResultsAPI.Client
{
    using Model;
    using CommonAPI.Client;
    using CommonAPI.Data;
    using Utils;
    using NeotysAPIException = CommonAPI.Error.NeotysAPIException;
    using System;
    using System.IO;

    /// <summary>
    /// An implementation of a Results API Client, based on Apache Olingo framework.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    internal sealed class ResultsAPIClientOlingo : NeotysAPIClientOlingo, IResultsAPIClient
    {
        private readonly string apiKey;

        /// <summary>
        /// Create a new Results API client, connected to the server at the end point 'url' and authenticating with 'apiKey'. </summary>
        /// <param name="url"> </param>
        /// <param name="apiKey"> </param>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        internal ResultsAPIClientOlingo(string url, string apiKey) : base(url)
        {
            if (Enabled)
            {
                this.apiKey = apiKey != null ? apiKey : "";
            }
            else
            {
                this.apiKey = "";
            }
        }

        /// <summary>
        /// Trigger the generation of a report. </summary>
        /// <param name="generateReportParams"> </param>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public string GenerateReport(GenerateReportParams generateReportParams)
        {
            if (!Enabled)
            {
                return null;
            }
            IDictionary<string, object> properties = ResultsApiUtils.getGenerateReportProperties(generateReportParams);
            properties[ResultsApiUtils.API_KEY] = apiKey;
            try
            {
                ODataEntry entity = ReadEntity(ResultsApiUtils.GENERATE_REPORT, properties);
                return ResultsApiUtils.getReportId(entity.AsDictionary());
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Download a report. </summary>
        /// <param name="downloadReportParams"> </param>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public BinaryData DownloadReport(DownloadReportParams downloadReportParams)
        {
            if (!Enabled)
            {
                return new BinaryData("", new byte[0]);
            }
            string jsonContent = "\"" + ResultsApiUtils.REPORT_ID + "\": \"" + downloadReportParams.ReportId + "\"";
            while (true)
            {
                try
                {
                    return ReadBinary(ResultsApiUtils.DOWNLOAD_REPORT, apiKey, jsonContent);
                }
                catch (NeotysAPIException neotysAPIException)
                {
                    // FIXME get a specific Error type for report generation in progress exception (and maybe pass a timeout).
                    if (isGenerationInProgressException(neotysAPIException))
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        throw neotysAPIException;
                    }
                }
                catch (Microsoft.OData.Core.ODataException oDataException)
                {
                    throw new NeotysAPIException(oDataException);
                }
            }
        }

        private bool isGenerationInProgressException(NeotysAPIException exception)
        {
            return NeotysAPIException.ErrorType.NL_API_ERROR.Equals(exception.getErrorType()) && exception.Details != null && exception.Details.Contains("in progress");
        }

        private static readonly DateTime Jan1st1970 = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public string SaveReport(DownloadReportParams downloadReportParams, string destinationFolder)
        {
            BinaryData report = DownloadReport(downloadReportParams);

            string fileName = report.FileName;
            if (fileName == null || fileName.Length == 0)
            {
                fileName = "generate_report_" + CurrentTimeMillis();
            }

            string filePath = destinationFolder + "\\" + fileName;
            BinaryWriter bw = new BinaryWriter(new FileStream(filePath, FileMode.Create));
            bw.Write(report.FileBinary);
            bw.Close();

            return filePath;
        }
    }
}
