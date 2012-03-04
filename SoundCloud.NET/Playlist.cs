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
    public class Playlist : SoundCloudClient
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

        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        [DataMember(Name = "sharing")]
        public string Sharing { get; set; }

        [DataMember(Name = "tag_list")]
        public string TagsList { get; set; }

        [DataMember(Name = "permalink")]
        public string Permalink { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "streamable")]
        public bool Streamabale { get; set; }

        [DataMember(Name = "downloadable")]
        public bool Downloadable { get; set; }

        [DataMember(Name = "genre")]
        public string Genre { get; set; }

        [DataMember(Name = "release")]
        public string Release { get; set; }

        [DataMember(Name = "purchase_url")]
        public string PurchaseUrl { get; set; }

        [DataMember(Name = "label_id")]
        public int? LabelId { get; set; }

        [DataMember(Name = "label_name")]
        public string LabelName { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "playlist_type")]
        public string PlaylistType { get; set; }

        [DataMember(Name = "ean")]
        public string Ean { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "release_year")]
        public int? ReleaseYear { get; set; }

        [DataMember(Name = "release_month")]
        public int? ReleaseMonth { get; set; }

        [DataMember(Name = "release_day")]
        public int? ReleaseDay { get; set; }

        public DateTime RealeaseDate 
        {
            get
            {
                if (ReleaseDay != null && ReleaseMonth != null && ReleaseYear != null)
                    return new DateTime((int)ReleaseYear, (int)ReleaseMonth, (int)ReleaseDay);

                return DateTime.MinValue;
            }
        }

        [DataMember(Name = "license")]
        public string License { get; set; }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }

        [DataMember(Name = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [DataMember(Name = "artwork_url")]
        public string ArtworkUrl { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "tracks")]
        public List<Track> Tracks { get; set; }

        #endregion Public

        #region Shared Methods

        /// <summary>
        /// Returns a collection of playlists.
        /// </summary>
        public static List<Playlist> GetAllPlaylists()
        {
            return SoundCloudApi.ApiAction<List<Playlist>>(ApiCommand.Playlists);
        }

        /// <summary>
        /// Returns a playlist by playlist id.
        /// </summary>
        /// 
        /// <param name="id">Playlist id.</param>
        public static Playlist GetPlaylist(int id)
        {
            return SoundCloudApi.ApiAction<Playlist>(ApiCommand.Playlist, id);
        }

        #endregion Shared Methods
    }
}