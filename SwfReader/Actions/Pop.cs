/* Copyright (C) 2008 Robin Debreuil -- Released under the BSD License */

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;

namespace DDW.Swf
{
	public struct Pop : IAction, IStackManipulator
	{
		public ActionKind ActionId{get{return ActionKind.Pop;}}
		public uint Version {get{return 4;}}
		public uint Length {get{return 1;}}

		public uint StackPops { get { return 1; } }
		public uint StackPushes { get { return 0; } }
		public int StackChange { get { return -1; } }

		public void ToFlashAsm(IndentedTextWriter w)
		{
			w.WriteLine("pop");
		}
		public void ToSwf(SwfWriter w)
		{
            w.AppendByte((byte)ActionKind.Pop);
		}

		public void Dump(IndentedTextWriter w)
		{
			w.WriteLine("Pop");
		}
	}
}
