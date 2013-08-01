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
using System.Runtime.Serialization;

namespace SoundCloud.NET
{
    /// <summary>
    /// Base class for authentication in order to execute api actions.
    /// </summary>
    [DataContract(IsReference = false)]
    public class SoundCloudClient
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the credentials required for authentication.
        /// </summary>
        protected SoundCloudCredentials Credentials { get; set; }

        private bool isAuthenticated = false;
        /// <summary>
        /// Gets or sets whether the user is authenticated or not.
        /// </summary>
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set { isAuthenticated = value; }
        }

        #endregion Public Properties

        protected static SoundCloudAccessToken SoundCloudAccessToken = null;

        protected static String SoundCloudClientID = null;

        protected static Boolean EnableGZip = false;

        #region Constructors

        /// <summary>
        /// Initializes a new isntance of the <see cref="SoundCloudClient"/> class.
        /// </summary>
        protected SoundCloudClient() { }

        /// <summary>
        /// Initializes a new isntance of the <see cref="SoundCloudClient"/> class.
        /// </summary>
        /// 
        /// <param name="credentials">Required credentials for authentication.</param>
        public SoundCloudClient(SoundCloudCredentials credentials)
        {
            Credentials = credentials;
            SoundCloudClientID = credentials.ClientID;

            EnableGZip = true;
        }

        #endregion Constructors

        public SoundCloudAccessToken Authenticate()
        {
            SoundCloudAccessToken token = SoundCloudApi.ApiAction<SoundCloudAccessToken>(ApiCommand.UserCredentialsFlow, HttpMethod.Post, Credentials.ClientID, Credentials.ClientSecret, Credentials.UserName, Credentials.Password);

            SoundCloudAccessToken = token;

            if (token != null)
            {
                IsAuthenticated = true;
            }

            return token;
        }

        #region Events

        public delegate void EventHandler(object sender, EventArgs e);

        public static event EventHandler ApiActionExecuting;

        protected static void OnApiActionExecuting(EventArgs e)
        {
            if (ApiActionExecuting != null)
                ApiActionExecuting(null, e);
        }

        public static event EventHandler ApiActionExecuted;

        protected static void OnApiActionExecuted(SoundCloudEventArgs e)
        {
            if (ApiActionExecuted != null)
                ApiActionExecuted(null, e);
        }

        public static event EventHandler ApiActionError;

        protected static void OnApiActionError(EventArgs e)
        {
            if (ApiActionError != null)
                ApiActionError(null, e);
        }

        #endregion Events
    }
}