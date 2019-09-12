/*
 * Copyright (c) 2019, Neotys
 * All rights reserved.
 */

using Neotys.CommonAPI.Utils;
using NeotysRestCommonAPI.Data;

namespace Neotys.ResultsAPI.Model
{
    /// <summary>
	/// UpdateQualityStatus is the method sent to the Results API Server to update the quality status of a test result.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class UpdateQualityStatusParams
    {
        private readonly string testResultName;
        private readonly QualityStatus qualityStatus;

        internal UpdateQualityStatusParams(UpdateQualityStatusParamsBuilder updateQualityStatusParamsBuilder)
        {
            this.testResultName = updateQualityStatusParamsBuilder.TestResultName;
            this.qualityStatus = updateQualityStatusParamsBuilder.QualityStatus;

        }

        public virtual string TestResultName
        {
            get
            {
                return testResultName;
            }
        }

        public virtual QualityStatus QualityStatus
        {
            get
            {
                return qualityStatus;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<UpdateQualityStatusParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(UpdateQualityStatusParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<UpdateQualityStatusParams>(this)
                .With(m => m.testResultName)
                .With(m => m.qualityStatus)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GenerateReportParams))
            {
                return false;
            }

            return new EqualsBuilder<UpdateQualityStatusParams>(this, obj)
                .With(m => m.testResultName)
                .With(m => m.qualityStatus)
                .Equals();
        }
    }
}
