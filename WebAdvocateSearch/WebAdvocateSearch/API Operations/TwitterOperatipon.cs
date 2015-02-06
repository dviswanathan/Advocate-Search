using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.oAuth;

namespace WebAdvocateSearch.API_Operations
{
    public class TwitterOperation
    {
        string accesstoken = ConfigurationManager.AppSettings["Accesstoken"].ToString();
        string Access_TokenSceret = ConfigurationManager.AppSettings["Access_TokenSceret"].ToString();
        string ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"].ToString();
        string Consumer_Secret = ConfigurationManager.AppSettings["Consumer_Secret"].ToString();


        public List<ITweet> GetTweets(string searchKey)
        {
            TwitterCredentials.SetCredentials(accesstoken, Access_TokenSceret, ConsumerKey, Consumer_Secret);

            List<ITweet> result = SearchTweetsBystream(TwitterCredentials.Credentials, searchKey);

            return result;
        }

        public static List<ITweet> SearchTweetsBystream(IOAuthCredentials credentials, string query)
        {
            List<ITweet> tweets = new List<ITweet>();

            TwitterCredentials.ExecuteOperationWithCredentials(credentials, () =>
            {
                var searchParam = Search.GenerateSearchTweetParameter(query);
                searchParam.Lang = Language.English;
                searchParam.MaximumNumberOfResults = 2000;
                tweets = Search.SearchTweets(searchParam);
            });

            return tweets;
        }
    }
}