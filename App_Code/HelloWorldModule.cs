using System;
using System.Collections.Generic;
using System.Web;
using Nancy;

/// <summary>
/// Summary description for HelloWorldModule
/// </summary>
public class HelloWorldModule : NancyModule
{
	public HelloWorldModule()
	{
		Get["/"] = parameters => {
			return "Hello, Nancy!";
		};
		
		Get["/test"] = x => {
			return "This is the Test route";
		};
		
		Get["/spark"] = x => {
			var model = new Person { FirstName = "Nancy", LastName = "Spark" };
			return View["spark", model];
		};
	}
}
