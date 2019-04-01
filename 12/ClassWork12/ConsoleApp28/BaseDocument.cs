using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
	class BaseDocument
	{
		public BaseDocument(string docName, int docNumber, DateTimeOffset issueDate)
		{
			DocName = docName;
			DocNumber = docNumber;
			IssueDate = issueDate;
		}

		public string DocName;
		public int DocNumber;
		public DateTimeOffset IssueDate;
		public virtual string PropertiesString { get { return $"Document name {DocName}, document number {DocNumber}, issueDate {IssueDate}"; } }

		public void WriteToConsole()
		{
			Console.WriteLine(PropertiesString);
		}
	}
}
