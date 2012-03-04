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
using System.Runtime.Serialization;

namespace SoundCloud.NET
{
    [DataContract]
    public class Comment : SoundCloudClient
    {
        #region Properties

        /// <summary>
        /// Gets or sets the comment id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the track id.
        /// </summary>
        [DataMember(Name = "track_id")]
        public int TrackId { get; set; }

        [DataMember(Name = "created_at")]
        private string creationDate;
        /// <summary>
        /// Gets or sets the comment's creation date.
        /// </summary>
        public DateTime CreationDate { get { return (DateTime.Parse(creationDate)); } set { creationDate = value.ToString(); } }

        /// <summary>
        /// Gets or sets the position of the comment(milliseconds).
        /// </summary>
        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the body text of the comment.
        /// </summary>
        [DataMember(Name = "body")]
        public string Body { get; set; }

        #region Links

        /// <summary>
        /// Gets or sets the uri of the comment.
        /// </summary>
        [DataMember(Name = "uri")]
        public string Uri { get; set; }

        #endregion Links

        #region User

        /// <summary>
        /// Gets or sets the comment's user id.
        /// </summary>
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user informations.
        /// </summary>
        [DataMember(Name = "user")]
        public User User { get; set; }

        #endregion User

        #endregion Properties

        #region Shared Methods

        /// <summary>
        /// Returns a comment by comment id.
        /// </summary>
        /// 
        /// <param name="id">Comment id.</param>
        public static Comment GetComment(int id)
        {
            return SoundCloudApi.ApiAction<Comment>(ApiCommand.Comment);
        }

        #endregion Shared Methods
    }
}