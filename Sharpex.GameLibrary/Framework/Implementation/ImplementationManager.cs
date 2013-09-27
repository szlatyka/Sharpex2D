﻿using System;
using System.Collections.Generic;
using SharpexGL.Framework.Components;
using SharpexGL.Framework.Content.Serialization;

namespace SharpexGL.Framework.Implementation
{
    public class ImplementationManager : IComponent
    {
        /// <summary>
        /// Initializes a new ImplementationProvider
        /// </summary>
        public ImplementationManager()
        {
            _implementations = new List<IImplementation>();
            AddSerializers();
        }

        private List<IImplementation> _implementations;

        /// <summary>
        /// Adds an Implementation to SGL.
        /// </summary>
        /// <param name="implementation"></param>
        public void AddImplementation(IImplementation implementation)
        {
            _implementations.Add(implementation);
        }
        /// <summary>
        /// Removes Implementations from SGL. Be careful, might cause unexpected behaviour.
        /// </summary>
        /// <param name="implementation">The Implementation.</param>
        public void RemoveImplementation(IImplementation implementation)
        {
            _implementations.Remove(implementation);
        }

        public T Get<T>()
        {
            var implementationObject = default(T);
            var flag = true;
            foreach (var implementation in _implementations)
            {
                if (typeof (T) == implementation.GetType())
                {
                    implementationObject = (T)implementation;
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                //No Implemenation found
                throw new InvalidOperationException("Implementation not found (" + typeof (T).FullName + ").");
            }

            return implementationObject;
        }
        /// <summary>
        /// Gets all Implementations.
        /// </summary>
        /// <returns>IImplementation Array</returns>
        public IImplementation[] GetImplementations()
        {
            return _implementations.ToArray();
        }

        #region Private

        /// <summary>
        /// Adds build in Serializers to SGL.
        /// </summary>
        private void AddSerializers()
        {
            AddImplementation(new BooleanSerializer());
            AddImplementation(new ByteArraySerializer());
            AddImplementation(new ByteSerializer());
            AddImplementation(new CharSerializer());
            AddImplementation(new ColorSerializer());
            AddImplementation(new DoubleSerializer());
            AddImplementation(new FloatSerializer());
            AddImplementation(new IntegerSerializer());
            AddImplementation(new LongSerializer());
            AddImplementation(new ShortSerializer());
            AddImplementation(new SpriteFontSerializer());
            AddImplementation(new StringSerializer());
            AddImplementation(new TextureSerializer());
            AddImplementation(new Vector2Serializer());
        }

        #endregion
    }
}