﻿using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Editing;

namespace Ullikummi.CodeGeneration.Objective.Roslyn.Code
{
    internal class TypeName : ICanConvertToSyntaxNode
    {
        private const string VoidTypeName = "void";

        public string Name { get; private set; }

        private TypeName()
        {
        }

        public static TypeName CreateTypeName(string name)
        {
            return new TypeName()
            {
                Name = name
            };
        }

        public static TypeName Void()
        {
            return CreateTypeName(VoidTypeName);
        }

        private static readonly IReadOnlyDictionary<string, SpecialType> SpecialTypesMap = new Dictionary<string, SpecialType>
            {
                { "bool", SpecialType.System_Boolean },
                { "byte", SpecialType.System_Byte },
                { "sbyte", SpecialType.System_SByte },
                { "char", SpecialType.System_Char },
                { "decimal", SpecialType.System_Decimal },
                { "double", SpecialType.System_Double },
                { "float", SpecialType.System_Single },
                { "int", SpecialType.System_Int32 },
                { "uint", SpecialType.System_UInt32 },
                { "long", SpecialType.System_Int64 },
                { "ulong", SpecialType.System_UInt64 },
                { "object", SpecialType.System_Object },
                { "short", SpecialType.System_Int16 },
                { "ushort", SpecialType.System_UInt16 },
                { "string", SpecialType.System_String }
            };

        public SyntaxNode ToSyntaxNode(SyntaxGenerator syntaxGenerator)
        {
            if (Name.Equals(VoidTypeName))
            {
                return null;
            }

            if (SpecialTypesMap.ContainsKey(Name))
            {
                return syntaxGenerator.TypeExpression(SpecialTypesMap[Name]);
            }

            return syntaxGenerator.IdentifierName(Name);
        }
    }
}
