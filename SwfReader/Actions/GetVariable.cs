/* Copyright (C) 2008 Robin Debreuil -- Released under the BSD License */

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;

namespace DDW.Swf
{
	public struct GetVariable : IAction, IStackManipulator
	{
		public ActionKind ActionId{get{return ActionKind.GetVariable;}}
		public uint Version {get{return 4;}}
		public uint Length { get { return 1; } }
		
		public uint StackPops { get { return 1; } }
		public uint StackPushes { get { return 1; } }
		public int StackChange { get { return 0; } }

		public void ToFlashAsm(IndentedTextWriter w)
		{
			w.WriteLine("getvariable");
		}

		public void ToSwf(SwfWriter w)
		{
            w.AppendByte((byte)ActionKind.GetVariable);
		}

		public void Dump(IndentedTextWriter w)
		{
			w.WriteLine("GetVariable");
		}
	}
}
