using Neotys.CommonAPI.Error;
using Neotys.ResultsAPI.Model;
using System;
using System.Collections.Generic;

/*
 * Copyright (c) 2017, Neotys
 * All rights reserved.
 */

namespace Neotys.ResultsAPI.Utils
{
    public class ResultsApiUtils
    {
        public const string API_KEY = "ApiKey";

        // GenerateReport
	    public const string GENERATE_REPORT = "GenerateReport";
	    public const string TEST_RESULT_NAME = "TestResultName";
	    public const string COMPARISON_REPORT = "ComparisonReport";
	    public const string OTHER_TEST_RESULT_NAME = "OtherTestResultName";
	    public const string TEST_RESULT_LABEL = "TestResultLabel";
	    public const string OTHER_TEST_RESULT_LABEL = "OtherTestResultLabel";
	    public const string CUSTOM_REPORT_CONTENTS = "CustomReportContents";
	    public const string FORMAT = "Format";
	    public const string FILE_NAME = "FileName";
	    public const string REPORT_ID = "ReportId";
	
	    // DownloadReport
	    public const string DOWNLOAD_REPORT = "DownloadReport";
	    public const string REPORT_BINARY = "ReportBinary";

        // UpdateQualityStatus
        public const string UPDATE_QUALITY_STATUS = "UpdateQualityStatus";
        public const string QUALITY_STATUS = "QualityStatus";

        private ResultsApiUtils()
        {
            throw new AccessViolationException();
        }

        public static IDictionary<string, object> getGenerateReportProperties(GenerateReportParams generateReportParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[TEST_RESULT_NAME] = generateReportParams.TestResultName;
            properties[COMPARISON_REPORT] = generateReportParams.ComparisonReport;
            properties[OTHER_TEST_RESULT_NAME] = generateReportParams.OtherTestResultName;
            properties[TEST_RESULT_LABEL] = generateReportParams.TestResultLabel;
            properties[OTHER_TEST_RESULT_LABEL] = generateReportParams.OtherTestResultLabel;
            properties[CUSTOM_REPORT_CONTENTS] = generateReportParams.CustomReportContents;
            properties[FORMAT] = generateReportParams.Format;
            properties[FILE_NAME] = generateReportParams.FileName;
            return properties;
        }

        public static IDictionary<string, object> getDownloadReportProperties(DownloadReportParams downloadReportParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[REPORT_ID] = downloadReportParams.ReportId;
            return properties;
        }

        public static string getReportId(IDictionary<string, object> properties)
        {
            object reportId = properties[REPORT_ID];
            if (reportId == null)
            {
                return null;
            }
            return reportId.ToString();
        }

        public static IDictionary<string, object> getUpdateQualityStatusProperties(UpdateQualityStatusParams updateQualityStatusParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[TEST_RESULT_NAME] = updateQualityStatusParams.TestResultName;
            properties[QUALITY_STATUS] = updateQualityStatusParams.QualityStatus;
            return properties;
        }
    }
}
