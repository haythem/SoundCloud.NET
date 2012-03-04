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

namespace SoundCloud.NET
{
    /// <summary>
    /// SoundCloud credentials required for authentication.
    /// </summary>
    public class SoundCloudCredentials
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        public string ClientID { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the authorization end point.
        /// </summary>
        public string EndUserAuthorization { get; set; }

        /// <summary>
        /// Gets or sets the user name required for authentication.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password required for authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Get OAuth version.
        /// </summary>
        public double OAuth { get { return 2.0; } }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SoundCloudCredentials"/> class.
        /// </summary>
        public SoundCloudCredentials() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SoundCloudCredentials"/> class.
        /// </summary>
        /// 
        /// <param name="clientID"></param>
        /// <param name="clientSecret"></param>
        public SoundCloudCredentials(string clientID, string clientSecret)
        {
            this.ClientID = clientID;
            this.ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SoundCloudCredentials"/> class.
        /// </summary>
        /// 
        /// <param name="clientID"></param>
        /// <param name="clientSecret"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public SoundCloudCredentials(string clientID, string clientSecret, string userName, string password)
        {
            this.ClientID = clientID;
            this.ClientSecret = clientSecret;
            this.UserName = userName;
            this.Password = password;
        }

        #endregion Constructors
    }
}