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
    /// List of the availaible api commands in the sound cloud platform.
    /// </summary>
    public enum ApiCommand
    {
        /// <summary>
        /// The flow is initiated by directing the end user in a browser to the SoundCloud authorization endpoint which is https://soundcloud.com/connect.
        /// </summary>
        AuthorizationCodeFlow,

        /// <summary>
        /// The user agent flow works similar to the authorization code flow with the difference that an access_token will be returned directly in the hash part of the redirect_uri.
        /// </summary>
        UserAgentFlow,

        /// <summary>
        /// The credentials flow allows you to directly exchange a users SoundCloud credentials for an access/refresh token pair.
        /// </summary>
        UserCredentialsFlow,

        /// <summary>
        /// Once an access_token is expired you can use the refresh_token to obtain a new one.
        /// </summary>
        RefreshToken,

        Me,

        MeTracks,

        MeComments,

        MeFollowings,

        MeFollowingsContact,

        MeFollowers,

        MeFollowersContact,

        MeFavorites,

        MeFavoritesTrack,

        MeGroups,

        MePlaylists,
         
        MeConnections,

        Users,

        User,

        UserTracks,

        UserComments,

        UserFollowings,

        UserFollowingsContact,

        UserFollowers,

        UserFollowersContact,

        UserFavorites,

        UserFavoritesTrack,

        UserGroups,

        UserPlaylists,

        Tracks,

        Track,

        TrackComments,

        TrackPermissions,

        TrackSecretToken,

        TrackShare,

        Comment,

        Groups,

        Group,

        GroupUsers,

        GroupModerators,

        GroupMembers,

        GroupContributors,

        GroupTracks,

        Playlists,

        Playlist,

        Resolve
    }
}