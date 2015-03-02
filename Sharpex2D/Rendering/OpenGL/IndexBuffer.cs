﻿// Copyright (c) 2012-2014 Sharpex2D - Kevin Scholz (ThuCommix)
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

using System;

namespace Sharpex2D.Rendering.OpenGL
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    internal class IndexBuffer : IDisposable
    {
        /// <summary>
        /// Gets the opengl identifer.
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// Initializes a new IndexBuffer class.
        /// </summary>
        public IndexBuffer()
        {
            var buffers = new uint[1];
            OpenGLInterops.GenBuffers(1, buffers);
            if (buffers[0] == 0) throw new GraphicsException("Unable to allocate memory for index buffer.");

            Id = buffers[0];
        }

                /// <summary>
        /// Deconstructs the IndexBuffer class.
        /// </summary>
        ~IndexBuffer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Binds the IndexBuffer.
        /// </summary>
        public void Bind()
        {
            OpenGLInterops.BindBuffer(OpenGLInterops.GL_ELEMENT_ARRAY_BUFFER, Id);
        }

        /// <summary>
        /// Sets the Data.
        /// </summary>
        /// <param name="indices">The Indices.</param>
        /// <remarks>Bind must be called in order to take effect.</remarks>
        public void SetData(ushort[] indices)
        {
            OpenGLInterops.BufferData(OpenGLInterops.GL_ELEMENT_ARRAY_BUFFER, indices, OpenGLInterops.GL_STATIC_DRAW);
        }

        /// <summary>
        /// Unbinds the IndexBuffer.
        /// </summary>
        public void Unbind()
        {
            OpenGLInterops.BindBuffer(OpenGLInterops.GL_ELEMENT_ARRAY_BUFFER, 0);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">The disposing state.</param>
        protected void Dispose(bool disposing)
        {
            OpenGLInterops.DeleteBuffers(1, new[] {Id});
        }
    }
}