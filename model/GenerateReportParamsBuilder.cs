/*
 * Copyright (c) 2017, Neotys
 * All rights reserved.
 */

namespace Neotys.ResultsAPI.Model
{
    /// <summary>
	/// Builder for object <seealso cref="GenerateReportParams"/>.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class GenerateReportParamsBuilder
    {
        public string TestResultName { get; set; }

        public bool ComparisonReport { get; set; }

        public string OtherTestResultName { get; set; }

        public string TestResultLabel { get; set; }

        public string OtherTestResultLabel { get; set; }

        public bool CustomReportContents { get; set; }

        public Format Format { get; set; }

        public string FileName { get; set; }

        public GenerateReportParamsBuilder()
        {
            this.TestResultName = "";
            this.ComparisonReport = false;
            this.OtherTestResultName = "";
            this.TestResultLabel = "";
            this.OtherTestResultLabel = "";
            this.CustomReportContents = false;
            this.Format = Format.RTF;
            this.FileName = "";
        }

        public GenerateReportParamsBuilder testResultName(string testResultName)
        {
            this.TestResultName = testResultName;
            return this;
        }


        public GenerateReportParamsBuilder comparisonReport(bool comparisonReport)
        {
            this.ComparisonReport = comparisonReport;
            return this;
        }

        public GenerateReportParamsBuilder otherTestResultName(string otherTestResultName)
        {
            this.OtherTestResultName = otherTestResultName;
            return this;
        }


        public GenerateReportParamsBuilder testResultLabel(string testResultLabel)
        {
            this.TestResultLabel = testResultLabel;
            return this;
        }

        public GenerateReportParamsBuilder otherTestResultLabel(string otherTestResultLabel)
        {
            this.OtherTestResultLabel = otherTestResultLabel;
            return this;
        }

        public GenerateReportParamsBuilder customReportContents(bool customReportContents)
        {
            this.CustomReportContents = customReportContents;
            return this;
        }

        public GenerateReportParamsBuilder format(Format format)
        {
            this.Format = format;
            return this;
        }

        public GenerateReportParamsBuilder fileName(string fileName)
        {
            this.FileName = fileName;
            return this;
        }

        public GenerateReportParams Build()
        {
            return new GenerateReportParams(this);
        }

    }
}
