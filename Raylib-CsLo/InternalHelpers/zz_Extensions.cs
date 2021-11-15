using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.HighPerformance;
using Microsoft.Toolkit.HighPerformance.Buffers;

namespace Raylib_CsLo.InternalHelpers;


public unsafe static class zz_Extensions
{

	public static SpanOwner<sbyte> MarshalUtf8(this string text)
	{
		if (text == null)
		{
			text = "";
		}
		var toReturn = SpanOwner<sbyte>.Allocate(text.Length,AllocationMode.Clear);
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


}
