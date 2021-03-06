﻿using System.Data;
using JetBrains.Annotations;
using MirrorSharp;
using SharpLab.Runtime;
using SharpLab.Server.MirrorSharp;

namespace SharpLab.Server.Compilation.Setups {
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class FSharpSetup : IMirrorSharpSetup {
        public void SlowApplyTo(MirrorSharpOptions options) {
            options.EnableFSharp(o => o.AssemblyReferencePaths = o.AssemblyReferencePaths.AddRange(new[] {
                // Runtime
                typeof(JitGenericAttribute).Assembly.Location,

                // Requested
                typeof(IDataReader).Assembly.Location // System.Data
            }));
        }
    }
}