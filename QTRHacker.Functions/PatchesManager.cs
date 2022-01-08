﻿using QTRHacker.Functions.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QTRHacker.Functions
{
	public sealed class PatchesManager
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct STile
		{
			public ushort Type;
			public ushort Wall;
			public byte Liquid;
			public short STileHeader;
			public byte BTileHeader;
			public byte BTileHeader2;
			public byte BTileHeader3;
			public short FrameX;
			public short FrameY;

			public bool Active()
			{
				return (STileHeader & 0x20) == 0x20;
			}
			public int WallFrameX()
			{
				return (BTileHeader2 & 0xF) * 36;
			}
			public int WallFrameY()
			{
				return (BTileHeader3 & 7) * 36;
			}
		}
		public QHackLib.CLRHelper PatchHelper => Context.HContext.GetCLRHelper("QTRHacker.Patches");
		public GameContext Context { get; }
		public PatchesManager(GameContext context)
		{
			Context = context;
		}

		public void Init()
		{
			if (PatchHelper != null)
				return;
			if (!Context.LoadAssemblyAsBytes(Path.GetFullPath("./QTRHacker.Patches.dll"), "QTRHacker.Patches.Boot"))
				throw new InvalidOperationException("Couldn't load patches");
		}

		public GameObjectArray2DV<STile> WorldPainter_DropperTiles
			=> new(Context, PatchHelper.GetStaticHackObject("QTRHacker.Patches.WorldPainter", "DropperTiles"));

		public bool WorldPainter_EyeDropperActive
		{
			get => PatchHelper.GetStaticFieldValue<bool>("QTRHacker.Patches.WorldPainter", "EyeDropperActive");
			set => PatchHelper.SetStaticFieldValue("QTRHacker.Patches.WorldPainter", "EyeDropperActive", value);
		}
		public bool WorldPainter_BrushActive
		{
			get => PatchHelper.GetStaticFieldValue<bool>("QTRHacker.Patches.WorldPainter", "BrushActive");
			set => PatchHelper.SetStaticFieldValue("QTRHacker.Patches.WorldPainter", "BrushActive", value);
		}
		public nuint WorldPainter_BrushTiles
		{
			get => PatchHelper.GetStaticFieldValue<nuint>("QTRHacker.Patches.WorldPainter", "BrushTiles");
			set => PatchHelper.SetStaticFieldValue("QTRHacker.Patches.WorldPainter", "BrushTiles", value);
		}
		public int WorldPainter_BrushWidth
		{
			get => PatchHelper.GetStaticFieldValue<int>("QTRHacker.Patches.WorldPainter", "BrushWidth");
			set => PatchHelper.SetStaticFieldValue("QTRHacker.Patches.WorldPainter", "BrushWidth", value);
		}
		public int WorldPainter_BrushHeight
		{
			get => PatchHelper.GetStaticFieldValue<int>("QTRHacker.Patches.WorldPainter", "BrushHeight");
			set => PatchHelper.SetStaticFieldValue("QTRHacker.Patches.WorldPainter", "BrushHeight", value);
		}
	}
}
