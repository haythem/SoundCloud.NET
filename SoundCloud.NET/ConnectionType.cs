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
    /// List of social networks whish a sound cloud account can be linked to.
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// Facebook connection.
        /// </summary>
        Faceook_Profile,

        /// <summary>
        /// Twitter connection.
        /// </summary>
        Twitter,

        /// <summary>
        /// Myspace connection.
        /// </summary>
        MySpace
    }
}