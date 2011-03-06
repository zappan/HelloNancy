using System;
using System.Collections.Generic;
using System.Web;
using Nancy;
using Simple.Data;

/// <summary>
/// Summary description for HelloWorldModule
/// </summary>
public class HelloWorldModule : NancyModule
{
    private static readonly string DbPath = System.IO.Path.Combine
				( System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)
				, @"App_Data\HelloNancy.sdf");

	
	public HelloWorldModule()
	{
		Get["/"] = parameters => {
			return "Hello, Nancy!";
		};
		
		Get["/test"] = parameters => {
			return "This is the Test route";
		};
		
		Get["/dynamic"] = parameters => {
			var model = new { FirstName = "Jane", LastName = "Doe", FullName = "Jane Doe" };
			return View["dynamic", model];
		};
		
		Get["/spark"] = parameters => {
			var db = Database.OpenFile(DbPath);
			Person model = db.Persons.FindById(1);
			if (model == null)
				model = new Person { FirstName = "Jane", LastName = "Doe" };
			return View["spark", model];
		};
	}
}
