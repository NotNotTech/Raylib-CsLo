// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raylib_CsLo.InternalHelpers;

/// <summary>
/// Contains the printf family of functions.
/// It supports the following formats: 'diufeExXoscp';
/// The following flags: '-+ #0';
/// Width and precision;
/// Length (h, l) for hexadecimal output (for other formats, integers are treated as Int64 or UInt64)
/// 
/// Decimal separator is not localized, it is always a '.' character.
/// %g and %G does not remove trailing zeroes.
/// NaN and infinities are not guaranteed to have a fixed representation accross platforms.
/// 
/// At the moment, it does NOT support %n (number of chars printed, through a prointer),
///  and the 1$..n$ position specifier.
/// </summary>
/// <remarks>from https://sourceforge.net/projects/printfnet/  MIT License</remarks>
public static class Printf
{
	/// <summary>
	/// Formats the arguments according to the format string.
	/// Returns the result as a string.
	/// </summary>
	/// <param name="format">The format string</param>
	/// <param name="args">The objects to format</param>
	/// <returns>The formatted output</returns>
	/// <exception cref="ArgumentException">The format string is invalid or too few arguments provided.</exception>
	/// <exception cref="ArgumentNullException">Format string is null</exception>
	public static string sprintf(string format, params object[] args)
	{
		if (format == null) throw new ArgumentNullException("format");
		try
		{
			FormatObject f = new FormatObject(format);
			f.SetArgs(args);
			return f.ToString();
		}
		catch (InvalidOperationException ex)
		{
			throw new ArgumentException("Error in format string or arguments, see inner exception for details", ex);
		}
	}

	/// <summary>
	/// Formats the arguments according to the format string,
	/// and writes the formatted string to the standard output.
	/// </summary>
	/// <param name="format">The format string</param>
	/// <param name="args">The objects to format</param>
	/// <exception cref="ArgumentException">The format string is invalid or too few arguments provided.</exception>
	/// <exception cref="ArgumentNullException">Format string is null</exception>
	public static void printf(string format, params object[] args)
	{
		if (format == null) throw new ArgumentNullException("format");
		Console.Write(sprintf(format, args));
	}

	/// <summary>
	/// Formats the arguments according to the format string,
	/// and writes the formatted string to the specified TextWriter.
	/// </summary>
	/// <param name="writer">The target TextWriter</param>
	/// <param name="format">The format string</param>
	/// <param name="args">The objects to format</param>
	/// <exception cref="ArgumentException">The format string is invalid or too few arguments provided.</exception>
	/// <exception cref="ArgumentNullException">Format string or TextWriter is null</exception>
	public static void fprintf(System.IO.TextWriter writer, string format, params object[] args)
	{
		if (format == null) throw new ArgumentNullException("format");
		if (writer == null) throw new ArgumentNullException("writer");
		writer.Write(sprintf(format, args));
	}
}



/// <summary>
/// Applies string formatting to objects using a "printf" format string.
/// Can be extended to use custom formats.
/// </summary>
internal class FormatObject
{
	///<summary>
	/// The default precision for floating point numbers
	/// </summary>
	public const int DefaultPrecision = 6;

	/// <summary>
	/// Represents a formatting part of the format string (i.e. %1.3d)
	/// All fields are interpreted as specified in the C language specification
	/// </summary>
	public class FormatStringPart
	{
		/// <summary>
		/// Minimum width
		/// </summary>
		public int width = 0;

		/// <summary>
		/// Precision
		/// </summary>
		public int? precision;

		/// <summary>
		/// Length (h or l)
		/// </summary>
		public char length;

		/// <summary>
		/// Specifier (s for strings, d for integers etc.)
		/// </summary>
		public char specifier;

		/// <summary>
		/// Left aligns the result instead of the default right align
		/// </summary>
		public bool LeftAlign = false;

		/// <summary>
		/// Displays + cahracter for positive numbers (by default it is omitted)
		/// </summary>
		public bool ForcePlus = false;

		/// <summary>
		/// Displays ' ' (space) character for positive numbers (by default it is omitted)
		/// </summary>
		public bool BlankIfPlus = false;

		/// <summary>
		/// Has different meanings for format specifiers
		/// </summary>
		public bool HashMark = false;

		/// <summary>
		/// If LeftAlign = false, pads with the '0' character instead of ' '.
		/// If LeftAlign = true, this flag is ignored.
		/// </summary>
		public bool PadWithZero = false;
	}

	//List of actual arguments
	List<object> args = new List<object>();

	//Number of required arguments
	int argCount = 0;

	//Format string parts
	FormatStringPart[] parts;
	string[] staticParts;

	string? finalString;

	enum ParseMode
	{
		Static,
		Format
	}

	enum FormatStep
	{
		Flags,
		Width,
		PrecisionStart,
		Precision,
		Length,
		Specifier
	}

	/// <summary>
	/// Creates a new formatter with the default formatters (used by the printf functions).
	/// </summary>
	/// <param name="format"></param>
	public FormatObject(string format) : this(format, true)
	{
	}

	/// <summary>
	/// Creates a new formatter with or without the default formatters (used by the printf functions).
	/// </summary>
	/// <param name="format">The format string</param>
	/// <param name="useDefaultFormatters">Load the default formatters or not</param>
	public FormatObject(string format, bool useDefaultFormatters)
	{

		//State machine to parse the format string
		//Surprisingly, the regexp version is not really shorter:
		//Parsing the string is easier, but extracting the results is longer

		List<FormatStringPart> parts = new List<FormatStringPart>();
		List<string> staticParts = new List<string>();
		StringBuilder staticPart = new StringBuilder();

		//Static mode: not in a % block, Format mode: in a % block
		ParseMode mode = ParseMode.Static;
		FormatStringPart? part = null;
		FormatStep step = FormatStep.Flags;
		StringBuilder? tempBuffer = null;

		for (int i = 0; i < format.Length; ++i)
		{
			char c = format[i];

			if (mode == ParseMode.Static)
			{
				//If
				if (c == '%')
				{
					mode = ParseMode.Format;
					step = FormatStep.Flags;
				}
				else
				{
					staticPart.Append(c);
				}
			}
			else
			{
				//if (part == null) part = new FormatStringPart();
				part ??= new FormatStringPart();
				//For the terminology (flags, specifiers etc.) look up any printf documentation.
				switch (step)
				{
					case FormatStep.Flags:
						if (c == '%')
						{
							staticPart.Append('%');
							mode = ParseMode.Static;
							continue;
						}

						
						if (c == '-')
						{
							part.LeftAlign = true;
						}
						else if (c == '+')
						{
							part.ForcePlus = true;
						}
						else if (c == ' ')
						{
							part.BlankIfPlus = true;
						}
						else if (c == '#')
						{
							part.HashMark = true;
						}
						else if (c == '0')
						{
							part.PadWithZero = true;
						}
						else
						{
							step = FormatStep.Width;
							goto case FormatStep.Width;
						}

						break;
					case FormatStep.Width:
						if (tempBuffer != null)
						{
							if (c >= '0' && c <= '9')
							{
								tempBuffer.Append(c);
							}
							else
							{
								part.width = int.Parse(tempBuffer.ToString());
								tempBuffer = null;
								step = FormatStep.PrecisionStart;
								goto case FormatStep.PrecisionStart;
							}
						}
						else if (c == '*')
						{
							part.width = -1;
							argCount++;
						}
						else if (c >= '0' && c <= '9')
						{
							tempBuffer = new StringBuilder();
							tempBuffer.Append(c);
						}
						else
						{
							step = FormatStep.PrecisionStart;
							goto case FormatStep.PrecisionStart;
						}

						break;
					case FormatStep.PrecisionStart:
						if (c != '.')
						{
							step = FormatStep.Length;
							goto case FormatStep.Length;
						}
						else
						{
							step = FormatStep.Precision;
						}

						break;
					case FormatStep.Precision:
						if (tempBuffer != null)
						{
							if (c >= '0' && c <= '9')
							{
								tempBuffer.Append(c);
							}
							else
							{
								part.precision = int.Parse(tempBuffer.ToString());
								tempBuffer = null;
								step = FormatStep.Length;
								goto case FormatStep.Length;
							}
						}
						else if (c == '*')
						{
							part.precision = -1;
							argCount++;
						}
						else if (c >= '0' && c <= '9')
						{
							tempBuffer = new StringBuilder();
							tempBuffer.Append(c);
						}
						else
						{
							part.precision = 0;
							step = FormatStep.Length;
							goto case FormatStep.Length;
						}

						break;
					case FormatStep.Length:
						if ("hlL".IndexOf(c) != -1)
						{
							part.length = c;
							step = FormatStep.Specifier;
						}
						else
						{
							step = FormatStep.Specifier;
							goto case FormatStep.Specifier;
						}

						break;
					case FormatStep.Specifier:
						argCount++;
						part.specifier = c;

						staticParts.Add(staticPart.ToString());
						staticPart = new StringBuilder();
						parts.Add(part);
						part = null;

						mode = ParseMode.Static;
						break;
				}
			}
		}

		if (mode == ParseMode.Format)
		{
			throw new ArgumentException("Invalid format string", "format");
		}

		staticParts.Add(staticPart.ToString());

		this.parts = parts.ToArray();
		this.staticParts = staticParts.ToArray();

		if (useDefaultFormatters) LoadDefaultFormatters();
	}

	/// <summary>
	/// Set the objects to format.
	/// If they are already set, the function will overwrite them.
	/// This is useful if you want to use the same format string to
	/// format many objects.
	/// </summary>
	/// <param name="objs">The list of objects</param>
	public void SetArgs(params object[] objs)
	{
		for (int i = 0; i < objs.Length; ++i)
		{
			args.Add(objs[i]);
		}

		this.finalString = null;
	}

	/// <summary>
	/// Formats the object according to the FormatStringPart argument.
	/// If you create a custom formatter, you should ignore the width property,
	/// as padding is done independently for all format types.
	/// </summary>
	/// <param name="part">It contains the flags, specifier etc.</param>
	/// <param name="arg">The object to format</param>
	public delegate FormatResult Formatter(FormatStringPart part, object arg);

	Dictionary<char, Formatter> formatters = new Dictionary<char, Formatter>();

	/// <summary>
	/// Adds a custom formatter.
	/// </summary>
	/// <param name="specifier">The character in the format string (e.g. 's' for %s)</param>
	/// <param name="formatter">The formatter function</param>
	public void AddFormatter(char specifier, Formatter formatter)
	{
		formatters.Add(specifier, formatter);
	}

	private void DoFormat()
	{
		try
		{
			if (argCount > args.Count)
			{
				throw new InvalidOperationException(string.Format(
					"Expected argument count: {0}, provided: {1}", argCount, args.Count));
			}

			StringBuilder final = new StringBuilder();
			for (int i = 0, j = 0; i < parts.Length; ++i, ++j)
			{
				final.Append(staticParts[i]);
				var f = parts[j];
				if (f.width == -1)
				{
					f.width = (int)args[j];
					j++;
				}

				if (f.precision == -1)
				{
					f.width = (int)args[j];
					j++;
				}

				FormatResult afterSpecifiers = formatters[f.specifier].Invoke(f, args[j]);
				int pad = f.width - afterSpecifiers.Result.Length - afterSpecifiers.Sign.Length;
				if (pad > 0 && !f.LeftAlign)
				{
					if (f.PadWithZero)
					{
						final.Append(afterSpecifiers.Sign);
						final.Append(new string('0', pad));
					}
					else
					{
						final.Append(new string(' ', pad));
						final.Append(afterSpecifiers.Sign);
					}
				}
				else
				{
					final.Append(afterSpecifiers.Sign);
				}

				final.Append(afterSpecifiers.Result);
				if (pad > 0 && f.LeftAlign)
				{
					final.Append(new string(' ', pad));
				}
			}

			final.Append(staticParts[staticParts.Length - 1]);
			finalString = final.ToString();
		}
		catch (KeyNotFoundException ex)
		{
			throw new InvalidOperationException("Invalid specifier in format string", ex);
		}
	}

	/// <summary>
	/// Returns the formatted string.
	/// </summary>
	/// <returns>The formatted string</returns>
	public override string ToString()
	{
		if (this.finalString == null) DoFormat();
		return finalString!;
	}

	/// <summary>
	/// The results of the Formatter type functions.
	/// </summary>
	public struct FormatResult
	{
		/// <summary>
		/// The resulting strings sign, if any.
		/// </summary>
		public string Sign { get; set; }

		/// <summary>
		/// The resulting string, without the sign if any.
		/// </summary>
		public string Result { get; set; }

		/// <summary>
		/// Converts to string into a FormatResult object.
		/// The string is assigned to the Result property of the created FormatString,
		/// the Sign property will be "" (empty string).
		/// </summary>
		/// <param name="s">The string to convert</param>
		/// <returns>A FormatResult object</returns>
		public static implicit operator FormatResult(string s)
		{
			return new FormatResult
			{
				Sign = "",
				Result = s
			};
		}
	}

	private string IntPrecision(string str, FormatStringPart part)
	{
		if (str.Equals("0") && part.precision == 0) return "";
		else if (str.Length < part.precision)
		{
			return new string('0', (part.precision ?? 1) - str.Length) + str;
		}
		else
		{
			return str;
		}
	}

	private void LoadDefaultFormatters()
	{
		var format = new System.Globalization.NumberFormatInfo();
		format.NumberDecimalSeparator = ".";

		Formatter charFormatter = (part, arg) =>
		{
			char c = (char)arg;
			return c.ToString();
		};
		AddFormatter('c', charFormatter);
		Formatter intFormatter = (part, arg) =>
		{
			long i = Convert.ToInt64(arg);
			string sign = "";
			if (i >= 0)
			{
				if (part.ForcePlus) sign = "+";
				else if (part.BlankIfPlus) sign = " ";
			}
			else
			{
				i = -i;
				sign = "-";
			}

			return new FormatResult { Result = IntPrecision(i.ToString(), part), Sign = sign };
		};
		AddFormatter('i', intFormatter);
		AddFormatter('d', intFormatter);
		Formatter uintFormatter = (part, arg) =>
		{
			ulong u = Convert.ToUInt64(arg);
			string sign = "";
			if (u >= 0)
			{
				if (part.ForcePlus) sign = "+";
				else if (part.BlankIfPlus) sign = " ";
			}

			return new FormatResult { Result = IntPrecision(u.ToString(), part), Sign = sign };
		};
		AddFormatter('u', uintFormatter);
		Formatter sciFormatter = (part, arg) =>
		{
			double d = Convert.ToDouble(arg);
			string sign = "";
			if (d >= 0 || double.IsNaN(d))
			{
				if (part.ForcePlus) sign = "+";
				else if (part.BlankIfPlus) sign = " ";
			}
			else
			{
				d = -d;
				sign = "-";
			}

			string retStr = d.ToString(string.Concat("0.",
					new string('0', part.precision ?? DefaultPrecision),
					part.specifier.ToString(),
					"+000"),
				format);
			//# flag: place decimal point even if not needed
			if (part.HashMark && !retStr.Contains(format.NumberDecimalSeparator))
			{
				retStr = string.Join(format.NumberDecimalSeparator + part.specifier,
					retStr.Split(part.specifier));
			}

			return new FormatResult
			{
				Result = retStr,
				Sign = sign
			};
		};
		AddFormatter('e', sciFormatter);
		AddFormatter('E', sciFormatter);
		Formatter floatFormatter = (part, arg) =>
		{
			double d = Convert.ToDouble(arg);
			string sign = "";
			if (d >= 0)
			{
				if (part.ForcePlus) sign = "+";
				else if (part.BlankIfPlus) sign = " ";
			}
			else
			{
				d = -d;
				sign = "-";
			}

			format.NumberDecimalDigits = part.precision ?? DefaultPrecision;
			string retStr = d.ToString("f", format);
			//# flag: place decimal point even if not needed
			if (part.HashMark && !retStr.Contains(format.NumberDecimalSeparator))
			{
				retStr += format.NumberDecimalSeparator;
			}

			return new FormatResult { Result = retStr, Sign = sign };
		};
		AddFormatter('f', floatFormatter);

		Formatter gFormatter = (part, arg) =>
		{
			double d = Convert.ToDouble(arg);
			string sign = "";
			if (d >= 0)
			{
				if (part.ForcePlus) sign = "+";
				else if (part.BlankIfPlus) sign = " ";
			}
			else
			{
				d = -d;
				sign = "-";
			}

			format.NumberDecimalDigits = part.precision ?? DefaultPrecision;
			/*string formatString = part.specifier.ToString() + part.precision.ToString() +
								  (part.HashMark ? ":0." + new string('#', part.precision ?? DefaultPrecision) : "");
			string retStr = string.Format(format, formatString, d);*/
			//Could not make it work
			string retStr = d.ToString(part.specifier.ToString() + part.precision.ToString(), format);
			return new FormatResult { Result = retStr, Sign = sign };
		};
		AddFormatter('g', gFormatter);
		AddFormatter('G', gFormatter);

		Formatter octFormatter = (part, arg) =>
		{
			long l = Convert.ToInt64(arg);
			string retStr = IntPrecision(Convert.ToString(l, 8), part);
			//# flag: put a 0 before tha number
			if (part.HashMark)
			{
				return "0" + retStr;
			}
			else
			{
				return retStr;
			}
		};
		AddFormatter('o', octFormatter);
		Formatter hexFormatter = (part, arg) =>
		{
			string retStr;
			if (part.length == 'h')
			{
				short s = Convert.ToInt16(arg);
				retStr = string.Format(
					part.specifier == 'x' ? "{0:x}" : "{0:X}",
					s);
			}
			else if (part.length == 'l')
			{
				long l = Convert.ToInt64(arg);
				retStr = string.Format(
					part.specifier == 'x' ? "{0:x}" : "{0:X}",
					l);
			}
			else
			{
				int i = Convert.ToInt32(arg);
				retStr = string.Format(
					part.specifier == 'x' ? "{0:x}" : "{0:X}",
					i);
			}

			//# flag: put a 0x before tha number
			return new FormatResult
			{
				Result = IntPrecision(retStr, part),
				Sign = part.HashMark ? "0" + part.specifier : ""
			};
		};
		AddFormatter('x', hexFormatter);
		AddFormatter('X', hexFormatter);
		Formatter strFormatter = (part, arg) =>
		{
			arg ??= "";
			if (part.precision != null)
			{
				return arg.ToString()!.Remove(part.precision.Value);
			}
			else
			{
				return arg.ToString()!;
			}
		};
		AddFormatter('s', strFormatter);
		Formatter ptrFormatter = (part, arg) => { return arg.GetHashCode().ToString(); };
		AddFormatter('p', ptrFormatter);
		AddFormatter('n',
			(part, arg) => { throw new NotSupportedException("Getting the number of characters is not supported"); });
	}
}
