using QHackCLR.Common;
using QHackCLR.DataTargets;
using QHackLib;
using QHackLib.Assemble;
using QHackLib.FunctionHelper;
using QHackLib.Memory;
using QTRHacker.Core;
using QTRHacker.Core.GameObjects;
using QTRHacker.Core.GameObjects.Terraria;
using QTRHacker.Core.ProjectileImage;
using QTRHacker.Core.ProjectileImage.RainbowImage;
using QTRHacker.Functions.Test;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading;

namespace QTRHacker.Functions.Test;
public unsafe struct EXCEPTION_RECORD
{
	public int ExceptionCode;
	public int ExceptionFlags;
	public EXCEPTION_RECORD* ExceptionRecord;
	public int ExceptionAddress;
	public int NumberParameters;
	public fixed int ExceptionInformation[15];
}

[StructLayout(LayoutKind.Sequential, Size = 84)]
public struct DEBUG_EVENT_UNION_EXCEPTION_DEBUG_INFO
{
	public EXCEPTION_RECORD ExceptionRecord;
	public int dwFirstChance;
}

[StructLayout(LayoutKind.Explicit, Size = 84)]
public struct DEBUG_EVENT_UNION_86
{
	[FieldOffset(0)]
	public DEBUG_EVENT_UNION_EXCEPTION_DEBUG_INFO EXCEPTION_DEBUG_INFO;
}

[StructLayout(LayoutKind.Sequential)]
public struct DEBUG_EVENT_86
{
	public int dwDebugEventCode;
	public int dwProcessId;
	public int dwThreadId;
	public DEBUG_EVENT_UNION_86 union;
}

unsafe class Program
{
	public static unsafe int GetOffset(GameContext context, string module, string type, string field) => (int)context.HContext.GetCLRHelper(module).GetInstanceFieldOffset(type, field) + sizeof(nuint);
	public static unsafe int GetOffset(GameContext context, string type, string field) => (int)context.GameModuleHelper.GetInstanceFieldOffset(type, field) + sizeof(nuint);
	unsafe static void Main()
	{
		//using GameContext ctx = GameContext.OpenGame(Process.GetProcessesByName("Terraria")[0]);
		var process = Process.GetProcessesByName("Terraria")[0];
		var pid = process.Id;

		DebugActiveProcess(pid);
		bool exit = false;
		new Thread(() =>
		{
			Console.Read();
			exit = true;
		}).Start();
		while (true)
		{
			if (exit)
				break;
			if (WaitForDebugEvent(out var e, 100))
			{
				switch (e.dwDebugEventCode)
				{
					case 1:
						var t = e.union.EXCEPTION_DEBUG_INFO;
						Console.WriteLine(t.ExceptionRecord.ExceptionCode.ToString("X8"));
						break;
				}
				Console.WriteLine(e.dwDebugEventCode);
				ContinueDebugEvent(e.dwProcessId, e.dwThreadId, 0x00010002);
			}
		}
		Console.WriteLine("exited");
		Console.Read();
		DebugActiveProcessStop(pid);
	}

	private unsafe static T VCast<T, V>(V v) where T : unmanaged where V : unmanaged
	{
		return *(T*)&v;
	}
	[DllImport("kernel32.dll")]
	internal static extern nuint OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DebugActiveProcess(int dwProcessId);

	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DebugActiveProcessStop(int dwProcessId);

	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DebugBreakProcess(nuint Process);

	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WaitForDebugEvent(
		out DEBUG_EVENT_86 lpDebugEvent,
		int dwMilliseconds);


	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ContinueDebugEvent(
		int dwProcessId,
		int dwThreadId,
		int dwContinueStatus
);
}