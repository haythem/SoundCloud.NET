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
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace SoundCloud.NET
{
    /// <summary>
    /// Serializes or deserializes a json result.
    /// </summary>
    public class JsonSerializer
    {
        /// <summary>
        /// Convert an object to a json format.
        /// </summary>
        /// 
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// 
        /// <returns>Serialized object.</returns>
        public static string Serialize<T>(T obj)
        {
            MemoryStream stream = new MemoryStream();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            serializer.WriteObject(stream, obj);

            string result = Encoding.UTF8.GetString(stream.ToArray());

            return result;
        }

        /// <summary>
        /// Convert json format to an object.
        /// </summary>
        /// 
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// 
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json));

            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));

            T result = (T)deserializer.ReadObject(stream);

            return result;
        }
    }
}