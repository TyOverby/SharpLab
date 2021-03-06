﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using ICSharpCode.Decompiler.Disassembler;
using Mono.Cecil;
using SharpLab.Server.Decompilation.Internal;

namespace SharpLab.Server.Decompilation {
    public class ILDecompiler : IDecompiler {
        public void Decompile(Stream assemblyStream, TextWriter codeWriter) {
            var assembly = AssemblyDefinition.ReadAssembly(assemblyStream);

            var output = new CustomizableIndentPlainTextOutput(codeWriter) {
                IndentationString = "    "
            };
            var disassembler = new ReflectionDisassembler(new ILCommentingTextOutput(output, 30), false, new CancellationToken());
            disassembler.WriteModuleContents(assembly.MainModule);
        }

        public string LanguageName => "IL";
    }
}