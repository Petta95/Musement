Francesco Pettazzoni

In order to run the application you have to download the code, open Musement.sln and run the CLIApplication. The class with the Main method is Default.cs.

For the second point, I have never designed an API, so I propose what I thought could be done in order to save the information retrieved from the application I designed (which retrieves the forecast weather of a city) in the TUI Musement's API.
As we used the GetAsync method to retrieve information from the two existing endpoints GET /api/v3/cities and GET /api/v3/cities{id}, similarly we could use the POST method to create two new resources and to send to TUI Musement's API the information retrieved by the GetInfoWeather method.

A POST request in fact creates a resource, and since in our case this resource doesn't initially exist then it seems to me the suitable method.
Client side we specify the URI for the resource, such as:
1. POST https://api.musement.com/api/v3/cities/id/setForecastCity.json?weather=cloudy
2. GET https://api.musement.com/api/v3/cities/id/readForecastCity.json

Since a Server-side resource with this URI doesn't already exist, a new one is created. Obviously this must be supported by the server.
The server assigns a URI for the new resource and returns this URI to the client, so on the Client side we prepare to manage the different responses returned: If the POST method creates the resource correctly, then we will have HTTP 201 status code and the body of the response contains a representation of the resource.
However, if the client enters invalid data into the request, the status code returned will be HTTP 400 (Invalid Request). The body of the response can contain additional information about the error or a link to a URI that offers more detail.
Consequently on the Client side we will have a switch which, according to the returned code, will print a certain message instead of another, as follows:
- response = 201 -> Console.WriteLine ("Response OK! City with id" + id + "has changed forecast weather in" + weather);
- response = 400 -> Console.WriteLine ("Response KO! Request not valid");

For the first new endpoint, in the specified URI we already have the id of the city whose forecast weather we want to change and as a parameter we enter the value we want to assign to it.
On the server side, therefore, this endpoint must be configured so that, based on the URI id, it modifies the forecast weather with the input parameter.

For the second new endpoint, on the other hand, it should be configured on the Server side, in order to return the value of the forecast weather, based on the id specified in the URI. Client side we will only have to use a GetAsync method and we will receive the info of the forecast weather.
