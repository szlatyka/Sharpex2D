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

using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace Sharpex2D.Framework.Scripting
{
    public static class ScriptCompiler
    {
        /// <summary>
        /// Compiles the source to assembly.
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="type">The type</param>
        /// <returns>The compiled assembly</returns>
        public static Assembly CompileToAssembly(string source, ScriptType type)
        {
            if (type == ScriptType.VisualBasic)
            {
                return CompileFromVisualBasicScript(source);
            }

            return CompileFromCSharpScript(source);
        }

        /// <summary>
        /// Compiles an assembly from a visual basic script.
        /// </summary>
        /// <param name="source">The Source.</param>
        /// <returns>Assembly.</returns>
        private static Assembly CompileFromVisualBasicScript(string source)
        {
            var cdProvider = new VBCodeProvider();
            var param = new CompilerParameters();
            param.ReferencedAssemblies.Add("System.dll");
            param.ReferencedAssemblies.Add("Sharpex2D.dll");
            param.ReferencedAssemblies.Add(Application.ExecutablePath);
            param.GenerateExecutable = false;

            CompilerResults result = cdProvider.CompileAssemblyFromSource(param, source);

            bool flag = false;

            foreach (CompilerError error in result.Errors)
            {
                if (error.IsWarning)
                {
                    Logger.Instance.Warn($"{error.ErrorText} (Line {error.Line})");
                }
                else
                {
                    Logger.Instance.Error($"{error.ErrorText} (Line {error.Line})");
                    flag = true;
                }
            }

            if (flag)
            {
                throw new ScriptException("Critical error while compiling script.");
            }

            return result.CompiledAssembly;
        }

        /// <summary>
        /// Compiles an assembly from a csharp script.
        /// </summary>
        /// <param name="source">The Source.</param>
        /// <returns>Assembly.</returns>
        private static Assembly CompileFromCSharpScript(string source)
        {
            var cdProvider = new CSharpCodeProvider();
            var param = new CompilerParameters();
            param.ReferencedAssemblies.Add("System.dll");
            param.ReferencedAssemblies.Add("Sharpex2D.dll");
            param.ReferencedAssemblies.Add(Application.ExecutablePath);
            param.GenerateExecutable = false;

            CompilerResults result = cdProvider.CompileAssemblyFromSource(param, source);

            bool flag = false;

            foreach (CompilerError error in result.Errors)
            {
                if (error.IsWarning)
                {
                    Logger.Instance.Warn($"{error.ErrorText} (Line {error.Line})");
                }
                else
                {
                    Logger.Instance.Error($"{error.ErrorText} (Line {error.Line})");
                    flag = true;
                }
            }

            if (flag)
            {
                throw new ScriptException("Critical error while compiling script.");
            }

            return result.CompiledAssembly;
        }
    }
}
