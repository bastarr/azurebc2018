#! "netcoreapp2.0"
#r "Newtonsoft.Json"
#r "Microsoft.AspNetCore.Mvc"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Net.Http.Headers;

public static IActionResult Run(HttpRequest req, string id, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    var person = GetPerson(id);

    return person != null
        ? (ActionResult)new OkObjectResult(person)
        : new BadRequestObjectResult("Please pass an id on the query string");
}

private static Person GetPerson(string id)
{
    string baseUri = "https://swapi.co/api";

    Person returnValues = new Person();

    using(HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, String.Format("{0}/people/{1}", baseUri, id));
        HttpResponseMessage response = client.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            string result = response.Content.ReadAsStringAsync().Result;
            if (!String.IsNullOrEmpty(result))
                returnValues = JsonConvert.DeserializeObject<Person>(result);
        }
    }
    return returnValues;
}

private class Person
{
	public string name { get;set; }
	public string height { get;set; }
	public string mass { get;set; }
	public string hair_color { get;set; }
	public string skin_color { get;set; }
	public string eye_color { get;set; }
	public string birth_year { get;set; }
	public string gender { get;set; }

}
