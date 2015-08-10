﻿// Copyright (c) 2012-2015 Sharpex2D - Kevin Scholz (ThuCommix)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the 'Software'), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.IO;
using System.Linq;
using Sharpex2D.Framework.Audio;

namespace Sharpex2D.Framework.Content.Importers
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    [ImportContent(typeof(Sound))]
    public class SoundImporter : Importer
    {
        /// <summary>
        /// Raises when the xml content is loaded and ready for processing.
        /// </summary>
        /// <param name="xmlContent">The XmlContent.</param>
        /// <returns>IContent.</returns>
        public override IContent OnCreate(XmlContent xmlContent)
        {
            var artist = xmlContent.First(x => x.Name == "Artist").Value;
            var title = xmlContent.First(x => x.Name == "Title").Value;
            var album = xmlContent.First(x => x.Name == "Album").Value;
            var year = xmlContent.First(x => x.Name == "Year").Value;
            var formattedYear = year == "" ? 0 : int.Parse(year);

            var waveFile = new WaveFile(new MemoryStream(xmlContent.GetData()));

            return new Sound(title, album, artist, formattedYear, waveFile.WaveFormat, waveFile);
        }
    }
}
