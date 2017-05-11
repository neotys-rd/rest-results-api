using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2017, Neotys
 * All rights reserved.
 */

namespace Neotys.ResultsAPI.Model
{
    /// <summary>
	/// DownloadReport is the method sent to the Results API Server to download a report previously generated.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class DownloadReportParams : IComparable<DownloadReportParams>
    {
        private readonly string reportId;

        public DownloadReportParams(string reportId)
        {
            if (reportId == null || reportId.Equals(""))
            {
                throw new ArgumentException("ReportId of the Transaction to be created is mandatory.", "ReportId");
            }
            this.reportId = reportId;
        }

        public virtual string ReportId
        {
            get
            {
                return reportId;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<DownloadReportParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(DownloadReportParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<DownloadReportParams>(this)
                .With(m => m.reportId)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DownloadReportParams))
            {
                return false;
            }

            return new EqualsBuilder<DownloadReportParams>(this, obj)
                .With(m => m.reportId)
                .Equals();
        }
    }
}
