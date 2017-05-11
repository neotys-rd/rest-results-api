using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2017, Neotys
 * All rights reserved.
 */

namespace Neotys.ResultsAPI.Model
{
    /// <summary>
	/// GenerateReport is the method sent to the Results API Server to trigger the generation of a report.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class GenerateReportParams : IComparable<GenerateReportParams>
    {
        private readonly string testResultName;
	    private readonly bool comparisonReport;
	    private readonly string otherTestResultName;
	    private readonly string testResultLabel;
	    private readonly string otherTestResultLabel;
	    private readonly bool customReportContents;
	    private readonly Format format;
	    private readonly string fileName;

        internal GenerateReportParams(GenerateReportParamsBuilder generateReportParamsBuilder)
        {
            this.testResultName = generateReportParamsBuilder.TestResultName;
            this.comparisonReport = generateReportParamsBuilder.ComparisonReport;
            this.otherTestResultName = generateReportParamsBuilder.OtherTestResultName;
            this.testResultLabel = generateReportParamsBuilder.TestResultLabel;
            this.otherTestResultLabel = generateReportParamsBuilder.OtherTestResultLabel;
            this.customReportContents = generateReportParamsBuilder.CustomReportContents;
            this.format = generateReportParamsBuilder.Format;
            this.fileName = generateReportParamsBuilder.FileName;
        }

        public virtual string TestResultName
        {
            get
            {
                return testResultName;
            }
        }

        public virtual bool ComparisonReport
        {
            get
            {
                return comparisonReport;
            }
        }

        public virtual string OtherTestResultName
        {
            get
            {
                return otherTestResultName;
            }
        }

        public virtual string TestResultLabel
        {
            get
            {
                return testResultLabel;
            }
        }

        public virtual string OtherTestResultLabel
        {
            get
            {
                return otherTestResultLabel;
            }
        }

        public virtual bool CustomReportContents
        {
            get
            {
                return customReportContents;
            }
        }

        public virtual Format Format
        {
            get
            {
                return format;
            }
        }

        public virtual string FileName
        {
            get
            {
                return fileName;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<GenerateReportParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(GenerateReportParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<GenerateReportParams>(this)
                .With(m => m.testResultName)
                .With(m => m.comparisonReport)
                .With(m => m.otherTestResultName)
                .With(m => m.testResultLabel)
                .With(m => m.otherTestResultLabel)
                .With(m => m.customReportContents)
                .With(m => m.format)
                .With(m => m.fileName)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GenerateReportParams))
            {
                return false;
            }

            return new EqualsBuilder<GenerateReportParams>(this, obj)
                .With(m => m.testResultName)
                .With(m => m.comparisonReport)
                .With(m => m.otherTestResultName)
                .With(m => m.testResultLabel)
                .With(m => m.otherTestResultLabel)
                .With(m => m.customReportContents)
                .With(m => m.format)
                .With(m => m.fileName)
                .Equals();
        }
    }
}
