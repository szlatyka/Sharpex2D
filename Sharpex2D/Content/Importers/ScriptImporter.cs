// Copyright (c) 2012-2015 Sharpex2D - Kevin Scholz (ThuCommix)
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
using System.Text;
using Sharpex2D.Framework.Scripting;

namespace Sharpex2D.Framework.Content.Importers
{
    [ImportContent(typeof (Script))]
    public class ScriptImporter : Importer
    {
        /// <summary>
        /// Creates the content based on the content binary.
        /// </summary>
        /// <param name="xcf">The ExtensibleContentFormat.</param>
        /// <returns>IContent</returns>
        public override IContent OnCreate(ExtensibleContentFormat xcf)
        {
            var scriptType = (ScriptType) int.Parse(xcf.First(x => x.Key == "Type").Value);
            var encoding = Encoding.GetEncoding(xcf.First(x => x.Key == "Encoding").Value);
            var scriptContent = encoding.GetString(xcf.GetData());

            return new Script(new FileInfo(xcf.BasePath).Name, scriptContent, scriptType);
        }
    }
}
