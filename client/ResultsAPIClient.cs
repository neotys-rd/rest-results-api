/*
 * Copyright (c) 2017, Neotys
 * All rights reserved.
 */

namespace Neotys.ResultsAPI.Client
{
    using CommonAPI.Data;
    using Model;

    /// <summary>
    /// Neotys Results API Client interface.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public interface IResultsAPIClient
    {
        /// <summary>
        /// Trigger the generation of a report.
        /// </summary>
        /// <param name="generateReportParams">generate report parameters</param>
        /// <returns>reportId</returns>
        string GenerateReport(GenerateReportParams generateReportParams);

        /// <summary>
        /// Download a report.
        /// </summary>
        /// <param name="downloadReportParams">download report parameters</param>
        /// <returns>the report as binary content</returns>
        BinaryData DownloadReport(DownloadReportParams downloadReportParams);

        /// <summary>
        /// Save a report and write it to a file on the NeoLoad controller machine.
        /// </summary>
        /// <param name="downloadReportParams">download report parameters</param>
        /// <param name="destinationFolder">the destination folder when the generated report will be saved.</param>
        /// <returns>the absolute path of the report file</returns>
        string SaveReport(DownloadReportParams downloadReportParams, string destinationFolder);
    }
}
