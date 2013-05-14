/*
    SoundCloud.NET Library For Sound Cloud Api Management.
    Copyright (C) 2011 Haythem Tlili

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace SoundCloud.NET
{
    /// <summary>
    /// Common helpers.
    /// </summary>
    public static class Utils
    {
        #region Licenses

        public const string NoRightsReserved = "no-rights-reserved";
        public const string AllRightsReserved = "all-rights-reserved";
        public const string CcBy = "cc-by";
        public const string CcByNc = "cc-by-nc";
        public const string CcByNd = "cc-by-nd";
        public const string CcBySa = "cc-by-sa";
        public const string CcByNcNd = "cc-by-nc-nd";
        public const string CcByNcSa = "cc-by-nc-sa";

        #endregion

        #region Uri

        /// <summary>
        /// Returns an Uri after replacement of the format item with the corresponding string representation.
        /// </summary>
        /// 
        /// <param name="uri">Input Uri.</param>
        /// <param name="keys">Format items.</param>
        public static Uri With(this Uri uri, params object[] keys)
        {
            return new Uri(string.Format(uri.ToString(), keys));
        }

        /// <summary>
        /// Returns a Uri with authorization segment.
        /// </summary>
        /// 
        /// <param name="baseUri">Input Uri.</param>
        /// <param name="token">Token.</param>
        public static Uri UriWithAuthorizedUri(this Uri baseUri, string token)
        {
            return baseUri.UriAppendingQueryString("oauth_token", token);
        }

        /// <summary>
        /// Returns a Uri with authorization segment.
        /// </summary>
        /// <param name="baseUri">Input Uri.</param>
        /// <param name="clientID">The client ID.</param>
        /// <returns></returns>
        public static Uri UriWithClientID(this Uri baseUri, string clientID)
        {
            return baseUri.UriAppendingQueryString("client_id", clientID);
        }

        /// <summary>
        /// Adds query strings to a given uri.
        /// </summary>
        /// 
        /// <param name="baseUri">Input uri.</param>
        /// <param name="parameters">Dictionnary of^parameters to add.</param>
        public static Uri UriAppendingParameters(this Uri baseUri, Dictionary<string, object> parameters)
        {

            var sb = new StringBuilder();

            foreach (KeyValuePair<string, object> pair in parameters)
            {
                sb.AppendFormat("{0}={1}&", pair.Key, pair.Value);
            }

            return baseUri.UriAppendingQueryString(sb.ToString().TrimEnd('&'));
        }
        public static Uri UriAppendingQueryString(this Uri uri, string name, string value)
        {
            return
                new UriBuilder(uri)
                    {
                        Query = (uri.Query + "&" + name + "=" + value).TrimStart('&')
                    }
                    .Uri;
        }
        public static Uri UriAppendingQueryString(this Uri uri, string querystring)
        {
            return
                new UriBuilder(uri)
                {
                    Query = (uri.Query + "&" + querystring).TrimStart('&')
                }
                .Uri;
        }

        #endregion Uri
    }
}