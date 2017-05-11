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
        // TODO doc methods

        string GenerateReport(GenerateReportParams generateReportParams);

        BinaryData DownloadReport(DownloadReportParams downloadReportParams);

        string SaveReport(DownloadReportParams downloadReportParams, string destinationFolder);
    }
}
