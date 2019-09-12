/*
 * Copyright (c) 2019, Neotys
 * All rights reserved.
 */
using NeotysRestCommonAPI.Data;

namespace Neotys.ResultsAPI.Model
{
    /// <summary>
	/// Builder for object <seealso cref="UpdateQualityStatusParams"/>.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class UpdateQualityStatusParamsBuilder
    {
        public string TestResultName { get; set; }

        public QualityStatus QualityStatus { get; set; }

        public UpdateQualityStatusParamsBuilder()
        {
            this.TestResultName = "";
        }

        public UpdateQualityStatusParamsBuilder testResultName(string testResultName)
        {
            this.TestResultName = testResultName;
            return this;
        }


        public UpdateQualityStatusParamsBuilder qualityStatus(QualityStatus qualityStatus)
        {
            this.QualityStatus = qualityStatus;
            return this;
        }

        public UpdateQualityStatusParams Build()
        {
            return new UpdateQualityStatusParams(this);
        }
    }
}
