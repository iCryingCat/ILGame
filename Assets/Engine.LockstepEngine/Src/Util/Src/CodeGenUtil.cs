// Copyright 2019 谭杰鹏. All Rights Reserved //https://github.com/JiepengTan 

using System;

namespace Lockstep.Util {
    public class CodeGenUtil {
        private const string CodeGenPrefix = @"
//------------------------------------------------------------------------------    
// <auto-generated>                                                                 
//     This code was generated by #TOOL_NAME. 
//     https://github.com/JiepengTan/LockstepEngine                                          
//     Changes to this file may cause incorrect behavior and will be lost if        
//     the code is regenerated.                                                     
// </auto-generated>                                                                
//------------------------------------------------------------------------------  
";

        private const string CodeGenPrefixToolNameTag = "#TOOL_NAME";

        public static string GetCodeGenPrefix(Type toolType){
            return CodeGenPrefix.Replace(CodeGenPrefixToolNameTag, toolType.Assembly.FullName);

        }
    }
}