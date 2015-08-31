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

using Sharpex2D.Framework.Rendering;

namespace Sharpex2D.Framework.Entities
{
    public abstract class Entity : IUpdateable, IDrawable
    {
        /// <summary>
        /// Initializes a new Entity class
        /// </summary>
        protected Entity()
        {
            Visible = true;
            Enabled = true;
        }

        /// <summary>
        /// Converts the entity to the specified type
        /// </summary>
        /// <typeparam name="T">The Type</typeparam>
        /// <returns>T</returns>
        public T As<T>() where T : Entity
        {
            return this as T;
        }

        /// <summary>
        /// Gets a value indicating whether the entity is assignable from the specified type
        /// </summary>
        /// <typeparam name="T">The Type</typeparam>
        /// <returns>True on success</returns>
        public bool Is<T>() where T : Entity
        {
            return GetType().IsAssignableFrom(typeof (T));
        }

        /// <summary>
        /// A value indicating whether the entity is visible
        /// </summary>
        public bool Visible { set; get; }

        /// <summary>
        /// A value indicating whether the entity is enabled
        /// </summary>
        public bool Enabled { set; get; }

        /// <summary>
        /// Updates the object.
        /// </summary>
        /// <param name="gameTime">The GameTime.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Processes a Render.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch.</param>
        /// <param name="gameTime">The GameTime.</param>
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
