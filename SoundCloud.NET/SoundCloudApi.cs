/*
    SoundCloud.NET Library For Sound Cloud Api Management.
    Copyright (C) 2012 Haythem Tlili

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
using System.IO.Compression;
using System.Net;

namespace SoundCloud.NET
{
    /// <summary>
    /// Handles api actions execution.
    /// </summary>
    internal class SoundCloudApi : SoundCloudClient
    {
        #region Private Properties

        /// <summary>
        /// List of the api action associated to api commands.
        /// </summary>
        private static readonly Dictionary<ApiCommand, Uri> ApiDictionary = new Dictionary<ApiCommand, Uri>
        {
            //Authorization
            { ApiCommand.AuthorizationCodeFlow, new Uri("https://soundcloud.com/connect?scope=non-expiring&client_id={0}&response_type={1}&redirect_uri={2}") },
            { ApiCommand.UserAgentFlow,         new Uri("https://soundcloud.com/connect?client_id={0}&response_type=token&redirect_uri={1}") },
            { ApiCommand.UserCredentialsFlow,   new Uri("https://api.soundcloud.com/oauth2/token?client_id={0}&client_secret={1}&grant_type=password&username={2}&password={3}") },
            { ApiCommand.RefreshToken,          new Uri("https://api.soundcloud.com/oauth2/token&client_id={0}&client_secret={1}&grant_type=refresh_token&refresh_token={2}") },

            //Me
            { ApiCommand.Me,                    new Uri("https://api.soundcloud.com/me.json") },
            { ApiCommand.MeTracks,              new Uri("https://api.soundcloud.com/me/tracks.json") },
            { ApiCommand.MeComments,            new Uri("https://api.soundcloud.com/me/comments.json") },
            { ApiCommand.MeFollowings,          new Uri("https://api.soundcloud.com/me/followings.json") },
            { ApiCommand.MeFollowingsContact,   new Uri("https://api.soundcloud.com/me/followings/{0}.json") },
            { ApiCommand.MeFollowers,           new Uri("https://api.soundcloud.com/me/followers.json") },
            { ApiCommand.MeFollowersContact,    new Uri("https://api.soundcloud.com/me/followers/{0}.json") },
            { ApiCommand.MeFavorites,           new Uri("https://api.soundcloud.com/me/favorites.json") },
            { ApiCommand.MeFavoritesTrack,      new Uri("https://api.soundcloud.com/me/favorites/{0}.json") },
            { ApiCommand.MeGroups,              new Uri("https://api.soundcloud.com/me/groups.json") },
            { ApiCommand.MePlaylists,           new Uri("https://api.soundcloud.com/me/playlists.json") },
            { ApiCommand.MeConnections,         new Uri("https://api.soundcloud.com/me/connections.json") },

            //Users
            { ApiCommand.Users,                 new Uri("https://api.soundcloud.com/users.json") },
            { ApiCommand.User,                  new Uri("https://api.soundcloud.com/users/{0}.json") },
            { ApiCommand.UserTracks,            new Uri("https://api.soundcloud.com/users/{0}/tracks.json") },
            { ApiCommand.UserComments,          new Uri("https://api.soundcloud.com/users/{0}/comments.json") },
            { ApiCommand.UserFollowings,        new Uri("https://api.soundcloud.com/users/{0}/followings.json") },
            { ApiCommand.UserFollowingsContact, new Uri("https://api.soundcloud.com/users/{0}/followings/{contact_id}.json") },
            { ApiCommand.UserFollowers,         new Uri("https://api.soundcloud.com/users/{0}/followers.json") },
            { ApiCommand.UserFollowersContact,  new Uri("https://api.soundcloud.com/users/{0}/followers/{1}.json?consumer_key={2}") },
            { ApiCommand.UserFavorites,         new Uri("https://api.soundcloud.com/users/{0}/favorites.json") },
            { ApiCommand.UserFavoritesTrack,    new Uri("https://api.soundcloud.com/users/{0}/favorites/{1}.json") },
            { ApiCommand.UserGroups,            new Uri("https://api.soundcloud.com/users/{0}/groups.json") },
            { ApiCommand.UserPlaylists,         new Uri("https://api.soundcloud.com/users/{0}/playlists.json") },

            //Tracks
            { ApiCommand.Tracks,                new Uri("https://api.soundcloud.com/tracks.json") },
            { ApiCommand.Track,                 new Uri("https://api.soundcloud.com/tracks/{0}.json") },
            { ApiCommand.TrackComments,         new Uri("https://api.soundcloud.com/tracks/{0}/comments.json") },
            { ApiCommand.TrackPermissions,      new Uri("https://api.soundcloud.com/tracks/{0}/permissions.json") },
            { ApiCommand.TrackSecretToken,      new Uri("https://api.soundcloud.com/tracks/{0}/secret-token.json") },
            { ApiCommand.TrackShare,            new Uri("https://api.soundcloud.com/tracks/{0}/shared-to/connections") },

            //Comments
            { ApiCommand.Comment,               new Uri("https://api.soundcloud.com/comments/{0}.json") },

            //Groups
            { ApiCommand.Groups,                new Uri("https://api.soundcloud.com/groups.json") },
            { ApiCommand.Group,                 new Uri("https://api.soundcloud.com/groups/{0}.json") },
            { ApiCommand.GroupUsers,            new Uri("https://api.soundcloud.com/groups/{0}/users.json") },
            { ApiCommand.GroupModerators,       new Uri("https://api.soundcloud.com/groups/{0}/moderators.json") },
            { ApiCommand.GroupMembers,          new Uri("https://api.soundcloud.com/groups/{0}/members.json") },
            { ApiCommand.GroupContributors,     new Uri("https://api.soundcloud.com/groups/{0}/contributors.json") },
            { ApiCommand.GroupTracks,           new Uri("https://api.soundcloud.com/groups/{0}/tracks.json") },

            //Playlists
            { ApiCommand.Playlists,             new Uri("https://api.soundcloud.com/playlists.json") },
            { ApiCommand.Playlist,              new Uri("https://api.soundcloud.com/playlists/{0}.json") },

            //Resolver
            { ApiCommand.Resolve,               new Uri("https://api.soundcloud.com/resolve.json?url={0}") },
        };

        #endregion Private Properties

        #region Shared Methods




        /// <summary>
        /// Executes an api action.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="parameters">Parameters format of an api command uri.</param>
        public static T ApiAction<T>(ApiCommand command, params object[] parameters)
        {
            var uri =
                ApiDictionary[command]
                    .With(parameters);

            return ApiAction<T>(uri);
        }


        /// <summary>
        /// Executes an api action.
        /// </summary>
        /// 
        /// <param name="command">Api command.</param>
        /// <param name="method">Http method. <seealso cref="HttpMethod"/>.</param>
        /// <param name="parameters">Parameters format of an api command uri.</param>
        public static T ApiAction<T>(ApiCommand command, HttpMethod method, params object[] parameters)
        {
            var uri =
                ApiDictionary[command]
                    .With(parameters);

            bool requireAuthentication = command != ApiCommand.UserCredentialsFlow;

            return ApiAction<T>(uri, method, requireAuthentication);
        }

        /// <summary>
        /// Executes an api action.
        /// </summary>
        /// 
        /// <param name="command">Api command;</param>
        /// <param name="extraParameters">Dictionnary of parameters to be passed in the api action uri.</param>
        public static T ApiAction<T>(ApiCommand command, Dictionary<string, object> extraParameters)
        {
            var uri =
                ApiDictionary[command]
                    .UriAppendingParameters(extraParameters);


            return ApiAction<T>(uri);
        }


        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="command"></param>
        /// <param name="method"></param>
        /// <param name="extraParameters"></param>
        /// <param name="parameters"></param>
        public static T ApiAction<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> extraParameters, params object[] parameters)
        {
            var uri =
                ApiDictionary[command]
                    .UriAppendingParameters(extraParameters)
                    .With(parameters);

            return ApiAction<T>(uri, method);
        }

        /// <summary>
        /// Executes an api action.
        /// </summary>
        /// 
        /// <param name="uri">Uri of the api command</param>
        /// <param name="method">Http method. <seealso cref="HttpMethod"/>.</param>
        /// <param name="requireAuthentication">The action requires an authentication or not.</param>
        /// <returns>An object returned back from the api action.</returns>
        public static T ApiAction<T>(Uri uri, HttpMethod method = HttpMethod.Get, bool requireAuthentication = true)
        {
            Uri api = uri;

            if (requireAuthentication)
                if (SoundCloudAccessToken == null)
                {
                    if (string.IsNullOrEmpty(SoundCloudClientID))
                        throw new SoundCloudException("Please authenticate using the SoundCloudClient class contructor before making an API call");
                    // try an unauthenticated request
                    api = uri.UriWithClientID(SoundCloudClientID);
                }
                else
                {
                    api = uri.UriWithAuthorizedUri(SoundCloudAccessToken.AccessToken);
                }

            var request = WebRequest.Create(api);

            request.Method = method.ToString().ToUpperInvariant();

            // Force returned type to JSON
            request.ContentType = "application/json";
            request.ContentLength = 0;
            
            //add gzip enabled header
            if (EnableGZip) request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            if (method == HttpMethod.Put) request.ContentLength = 0;

            HttpWebResponse response = null;

            try
            {
                //OnApiActionExecuting Event
                OnApiActionExecuting(EventArgs.Empty);

                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    var stream = response.GetResponseStream();

                    //check for gzipped response and unzip it
                    try
                    {
                        if (response.Headers[HttpResponseHeader.ContentEncoding].Equals("gzip") ||
                            response.Headers[HttpResponseHeader.ContentEncoding].Equals("deflate"))
                        {
                            stream = new GZipStream(stream, CompressionMode.Decompress);
                        }
                    }
                    catch (Exception) {/* no ziped response found, return to normal */}


                    string json;

                    using (var reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }

                    //close stream
                    stream.Close();

                    var args = new SoundCloudEventArgs { RawResponse = json, ReturnedType = typeof(T) };

                    //OnApiActionExecuted Event
                    OnApiActionExecuted(args);

                    return JsonSerializer.Deserialize<T>(json);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //OnApiActionError Event
                    OnApiActionError(EventArgs.Empty);
                }
            }

            catch (SoundCloudException e)
            {
                throw new SoundCloudException(string.Format("{0} : {1}", response.StatusCode, response.StatusDescription));
            }

            return default(T);
        }

        #endregion Shared Methods
    }
}
