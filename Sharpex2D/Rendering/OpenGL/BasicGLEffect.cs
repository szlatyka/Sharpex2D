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

namespace Sharpex2D.Framework.Rendering.OpenGL
{
    internal class BasicGLEffect : GLEffect
    {
        public static string FragmentShader = @"#version 150 core
in vec3 Color;
in vec2 Texcoord;
in float Alpha;
out vec4 outColor;
uniform sampler2D tex;

void main() {
    outColor = texture(tex, Texcoord) * vec4(Color, Alpha);
}
";

        public static string VertexShader = @"#version 150 core
in vec2 position;
in vec3 color;
in vec2 texcoord;
uniform vec3 dim;
uniform mat4 transform;
out vec3 Color;
out vec2 Texcoord;
out float Alpha;

void main() {
    Color = color;
    Texcoord = texcoord;
    Alpha = dim.z;
    vec4 transformed = vec4(position.x, position.y, 1, 1) * transform;
    gl_Position = vec4(transformed.x * 2.0 / dim.x - 1.0, transformed.y * -2.0 / dim.y + 1.0, 0.0, 1.0);
}
";
        /// <summary>
        /// Initializes a new BasicGLEffect class
        /// </summary>
        public BasicGLEffect() : base(FragmentShader, VertexShader, "Internal Effect.fx")
        {
        }
    }
}
