// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.HighPerformance;
using Microsoft.Toolkit.HighPerformance.Buffers;

namespace Raylib_CsLo.InternalHelpers;


public unsafe static class zz_Extensions
{
	public static GCHandle GcPin(this object obj)
	{
		var handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
		return handle;
	}

	public static SpanOwner<sbyte> MarshalUtf8(this string text)
	{
		if (text == null)
		{
			text = "";
		}

		var length = Encoding.UTF8.GetByteCount(text) + 1;//need Length+1 so that we always can guarantee a null terminated ending char
		var toReturn = SpanOwner<sbyte>.Allocate(length, AllocationMode.Clear); 
		var count = Encoding.UTF8.GetBytes(text.AsSpan(), toReturn.Span.AsBytes());
		return toReturn;
	}

	public static TPtr* AsPtr<TPtr>(this SpanOwner<TPtr> spanOwner) where TPtr : unmanaged
	{
		return (TPtr*)Unsafe.AsPointer(ref spanOwner.DangerousGetReference());
	}


	public static string SPrintF(this string format, params object[] args)
	{
		var toReturn = Printf.sprintf(format, args);
		return toReturn;
	}

	//public static ref float x(ref this Vector2 item)
	//{
	//	return ref item.X;
	//}

	public static void CreateYawPitchRoll(this Quaternion r, out float yaw, out float pitch, out float roll)
	{
		//implementation from: LEI-Hongfann: https://github.com/dotnet/runtime/issues/38567#issuecomment-655567603
		yaw = MathF.Atan2(2.0f * (r.Y * r.W + r.X * r.Z), 1.0f - 2.0f * (r.X * r.X + r.Y * r.Y));
		pitch = MathF.Asin(2.0f * (r.X * r.W - r.Y * r.Z));
		roll = MathF.Atan2(2.0f * (r.X * r.Y + r.Z * r.W), 1.0f - 2.0f * (r.X * r.X + r.Z * r.Z));
	}

	public static Vector3 CreateYawPitchRoll(this Quaternion r)
	{
		//implementation from: LEI-Hongfann: https://github.com/dotnet/runtime/issues/38567#issuecomment-655567603
		var yaw = MathF.Atan2(2.0f * (r.Y * r.W + r.X * r.Z), 1.0f - 2.0f * (r.X * r.X + r.Y * r.Y));
		var pitch = MathF.Asin(2.0f * (r.X * r.W - r.Y * r.Z));
		var roll = MathF.Atan2(2.0f * (r.X * r.Y + r.Z * r.W), 1.0f - 2.0f * (r.X * r.X + r.Z * r.Z));
		return new(yaw, pitch, roll);
	}
}
