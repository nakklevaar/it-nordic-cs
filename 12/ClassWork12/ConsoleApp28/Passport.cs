using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
	class Passport : BaseDocument
	{
		public Passport(string docName,int docNumber, DateTimeOffset issueDate, string country, string personName)
			: base(docName, docNumber, issueDate)
		{
			Country = country;
			PersonName = personName;
		}

		public string Country;
		public string PersonName;
		public override string PropertiesString { get { return $"Document name {DocName}, document number {DocNumber}, issueDate {IssueDate}, country {Country}, personName {PersonName}"; } }

		public void ChangeIssueDate(DateTimeOffset newIssueDate)
		{
			IssueDate = newIssueDate;
		}
	}
}
