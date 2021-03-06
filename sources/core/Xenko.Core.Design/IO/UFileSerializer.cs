// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using Xenko.Core.Serialization;

namespace Xenko.Core.IO
{
    /// <summary>
    /// Data serializer for Guid.
    /// </summary>
    [DataSerializerGlobal(typeof(UFileSerializer))]
    internal class UFileSerializer : DataSerializer<UFile>
    {
        /// <inheritdoc/>
        public override void Serialize(ref UFile obj, ArchiveMode mode, SerializationStream stream)
        {
            if (mode == ArchiveMode.Serialize)
            {
                var path = obj?.FullPath;
                stream.Serialize(ref path);
            }
            else if (mode == ArchiveMode.Deserialize)
            {
                string path = null;
                stream.Serialize(ref path);
                obj = new UFile(path);
            }
        }
    }
}
