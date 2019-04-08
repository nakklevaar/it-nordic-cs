using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		public static string OutputPrefixFormat { get; set; }

		static ErrorList()
		{
			OutputPrefixFormat = "MMMM d, yyyy (hh:mm tt)";
		}

		public string Category { get; }
		private List<string> _errors;

		public ErrorList(string category)
		{
			Category = category;
			_errors = new List<string>();
		}

		public void Dispose()
		{
			if(_errors != null)
			{
				_errors.Clear();
				_errors = null;
			}
		}

		public void WriteToConsole()
		{
			foreach (var error in _errors)
			{
				Console.WriteLine(DateTime.Now.ToString(OutputPrefixFormat) + " "+error);
			}
		}

		public void Add(string errorMessage)
		{
			_errors.Add(errorMessage);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _errors.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
