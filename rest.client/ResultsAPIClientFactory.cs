/*
 * Copyright (c) 2017, Neotys
 * All rights reserved.
 */
namespace Neotys.ResultsAPI.Client
{
    using NeotysAPIException = CommonAPI.Error.NeotysAPIException;

    /// <summary>
    /// Factory to build ResultsAPIClient based on Apache Olingo implementation.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public sealed class ResultsAPIClientFactory
    {
        private ResultsAPIClientFactory()
        {
            throw new System.AccessViolationException();
        }

        /// <summary>
        /// Create a new Results API client, connected to the server at the end point 'url'. </summary>
        /// <param name="url"> </param>
        /// <exception cref="NeotysAPIException"> </exception>
        public static IResultsAPIClient NewClient(string url)
        {
            return NewClient(url, "");
        }

        /// <summary>
        /// Create a new Results API client, connected to the server at the end point 'url', with authenticating with 'apiKey'. </summary>
        /// <param name="url"> </param>
        /// <param name="apiKey"> </param>
        /// <exception cref="NeotysAPIException"> </exception>
        public static IResultsAPIClient NewClient(string url, string apiKey)
        {
            return new ResultsAPIClientOlingo(url, apiKey);
        }
    }
}
