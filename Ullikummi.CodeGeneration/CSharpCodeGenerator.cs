﻿using Microsoft.CodeAnalysis;
using Ullikummi.Data;

namespace Ullikummi.CodeGeneration
{
    public class CSharpCodeGenerator : ICodeGenerator
    {
        private readonly RoslynCodeGenerator _roslynCodeGenerator = new RoslynCodeGenerator();

        public string GenerateCode(Graph graph)
        {
            return _roslynCodeGenerator.GenerateCode(graph, LanguageNames.CSharp);
        }
    }
}
