using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSandbox
{
	class Program
	{

		private delegate void DelegatePrintString(string str);


		private static void MethodPrintStringLower(string str)
		{
			Console.WriteLine(str.ToLower());
		}

		private static void MethodPrintStringUpper(string str)
		{
			Console.WriteLine(str.ToUpper());
		}


		static void Main(string[] args)
		{
			DelegatePrintString delegatePrintString = null;

			delegatePrintString += new DelegatePrintString(MethodPrintStringLower);
			delegatePrintString += new DelegatePrintString(MethodPrintStringUpper);

			delegatePrintString("Output");

			Console.WriteLine();
			Console.WriteLine();

			Func<int> func = delegate { Console.WriteLine("first part"); return 5; };
			func += delegate { Console.WriteLine("second part"); return 7; };
			int result = func();
			Console.WriteLine(result);

			Console.WriteLine();
			Console.WriteLine();

			foreach (Func<int> part in func.GetInvocationList())
			{
				result = part();
				Console.WriteLine(result);
			}

			Console.ReadKey();


		}
	}
}
