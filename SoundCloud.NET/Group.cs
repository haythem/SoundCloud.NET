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
    /// <summary>
    /// SoundCloud Group.
    /// </summary>
    [DataContract]
    public class Group : SoundCloudClient
    {
        #region Properties

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "created_at")]
        private string creationDate;
        /// <summary>
        /// Gets or sets the comment's creation date.
        /// </summary>
        public DateTime CreationDate { get { return (DateTime.Parse(creationDate)); } set { creationDate = value.ToString(); } }

        [DataMember(Name = "permalink")]
        public string Permalink { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "short_description")]
        public string ShortDescription { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }

        [DataMember(Name = "artwork_url")]
        public string Artwork { get; set; }

        [DataMember(Name = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [DataMember(Name = "creator")]
        public User User { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Returns a combined collection of moderators, members and contributors of the group with group id.
        /// </summary>
        /// 
        /// <param name="id">Group id.</param>        
        public List<User> GetUsers()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.GroupUsers, this.Id);
        }

        /// <summary>
        /// Returns a collection of moderators of the group with group id.
        /// </summary>
        /// 
        /// <param name="id">Group id.</param>
        public List<User> GetModerators()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.GroupModerators, this.Id);
        }

        /// <summary>
        /// Returns a collection of members of the group with group id.
        /// </summary>
        /// 
        /// <param name="id">Group id.</param>
        public List<User> GetMembers()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.GroupMembers, this.Id);
        }

        /// <summary>
        /// Returns a collection of contributors of the group with group id.
        /// </summary>
        /// 
        /// <param name="id">Group id.</param>
        public List<User> GetContributors()
        {
            return SoundCloudApi.ApiAction<List<User>>(ApiCommand.GroupContributors, this.Id);
        }

        /// <summary>
        /// Returns a collection of tracks contributed to the group with group id.
        /// </summary>
        /// 
        /// <param name="id">Group id.</param>
        public List<Track> GetTracks()
        {
            return SoundCloudApi.ApiAction<List<Track>>(ApiCommand.GroupTracks, this.Id);
        }

        #endregion Public Methods

        #region Shared Methods

        /// <summary>
        /// Returns a collection of groups.
        /// </summary>
        public static List<Group> GetAllGroups()
        {
            return SoundCloudApi.ApiAction<List<Group>>(ApiCommand.Groups);
        }

        /// <summary>
        /// Returns a group by group id.
        /// </summary>
        /// <param name="id">Group id.</param>
        public static Group GetGroup(int id)
        {
            return SoundCloudApi.ApiAction<Group>(ApiCommand.Group, id);
        }

        /// <summary>
        /// Returns a collection of groups based on a search action.
        /// </summary>
        /// 
        /// <param name="term">Term to search for.</param>
        public static List<Group> Search(string term)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("q", term);

            return SoundCloudApi.ApiAction<List<Group>>(ApiCommand.Groups, parameters);
        }

        #endregion Shared Methods
    }
}