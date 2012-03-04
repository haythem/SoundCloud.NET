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
using System.IO;
using System.Net;
using System.Text;

namespace SoundCloud.NET
{
    /// <summary>
    /// Common helpers.
    /// </summary>
    public class Utils : SoundCloudClient
    {
        #region Licenses

        protected const string NoRightsReserved = "no-rights-reserved";
        protected const string AllRightsReserved = "all-rights-reserved";
        protected const string CcBy = "cc-by";
        protected const string CcByNc = "cc-by-nc";
        protected const string CcByNd = "cc-by-nd";
        protected const string CcBySa = "cc-by-sa";
        protected const string CcByNcNd = "cc-by-nc-nd";
        protected const string CcByNcSa = "cc-by-nc-sa";

        #endregion

        #region Uri

        /// <summary>
        /// Returns an Uri after replacement of the format item with the corresponding string representation.
        /// </summary>
        /// 
        /// <param name="uri">Input Uri.</param>
        /// <param name="keys">Format items.</param>
        public static Uri FormatToUri(Uri uri, params object[] keys)
        {
            return new Uri(string.Format(uri.ToString(), keys));
        }

        /// <summary>
        /// Returns a Uri with authorization segment.
        /// </summary>
        /// 
        /// <param name="baseUri">Input Uri.</param>
        /// <param name="token">Token.</param>
        public static Uri AuthorizedUri(Uri baseUri, string token)
        {
            string json = ".json";

            string baseToken = "?oauth_token=" + token;

            string newUri = string.Empty;

            if (baseUri.ToString().IndexOf(json) != -1)
            {
                newUri = baseUri.ToString().Insert(baseUri.ToString().IndexOf(json) + json.Length, baseToken);
            }
            else
            {
                newUri = baseUri.ToString().Insert(baseUri.ToString().IndexOf("&"), baseToken);
            }

            return new Uri(newUri);
        }

        /// <summary>
        /// Adds query strings to a given uri.
        /// </summary>
        /// 
        /// <param name="baseUri">Input uri.</param>
        /// <param name="parameters">Dictionnary of^parameters to add.</param>
        public static Uri AddParametersToUri(Uri baseUri, Dictionary<string, object> parameters)
        {
            StringBuilder sb = new StringBuilder(baseUri.ToString());

            foreach (KeyValuePair<string, object> pair in parameters)
            {
                sb.AppendFormat("&{0}={1}", pair.Key, pair.Value);
            }

            return new Uri(sb.ToString());
        }

        #endregion Uri
    }
}