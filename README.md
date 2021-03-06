# homework assignment

SUMMARY
---------------------------------------------------------------------------------------------------

This WebAPI application is based off an empty Visual Studio 2015 Community
Version web application template using WebApi. The directory structure and Nuget
packages were then manually added in a fully licensed version of Microsoft 
Visual Studio 2012 Premium. 

INSTALLATION
---------------------------------------------------------------------------------------------------

Download the source from here: 
https://github.com/XQ44T65M4S30/homework.git

Open the project in Visual Studio, and then build the application. If any 
reference libraries are not not found at complie time, you may need to remove
the .Nuget folder and then re-add Nuget to the project in order to restore any
missing reference libraries.

After the appliction has successfully compiled you will directed to the WebApi Help Pages. Help
Pages are autogenerated from the various routes found in all the WebApi controllers. 

//////////////////
// -IMPORTANT - //
//////////////////
In order for the GET methods to return any data, the user MUST popoulate the Event table using
the following curl commands: [BE ADVISED WHEN COPYING AND PASTING THE FOLLOWING COMMANDS
YOU MAY NEED TO CONVERT THIS TEXT FILE FROM DOS TO UNIX, AS SOME VERSIONS OF CURL DO 
NOT ACCEPT WINDOWS LINEFEEDS.]

curl -v -X POST -H "Content-Type: application/json" -d '
{"Id":0,"Name":"breakfast","Descripton":"most important meal of the day","Location":"IHOP","StartTime":"2016-10-01T07:00:00","EndTime":"2016-10-01T08:00:00"}
' http://localhost:[PORT]/api/events

curl -v -X POST -H "Content-Type: application/json" -d '
{"Id":0,"Name":"lunch","Descripton":"take a break and refuel","Location":"Mc Donalds","StartTime":"2016-10-01T12:00:00","EndTime":"2016-10-01T13:00:00"}
' http://localhost:[PORT]/api/events

curl -v -X POST -H "Content-Type: application/json" -d '
{"Id":0,"Name":"dinner","Descripton":"unwind and enjoy the rest of the evening","Location":"Home","StartTime":"2016-10-01T19:00:00","EndTime":"2016-10-01T20:00:00"}
' http://localhost:[PORT]/api/events
 
 
USAGE 
---------------------------------------------------------------------------------------------------
Curl scripts to call the API

GET ALL ITEMS:
------------------------------------------------------
curl -v http://localhost:[PORT]/api/events

EXPECTED RESULTS:
PASS:
  [{"Id":1,"Name":"breakfast","Descripton":"most important meal of the day","Location":"IHOP","StartTime":"2016-10-01T07:00:00","EndTime":"2016-10-01T08:00:00"},
  {"Id":2,"Name":"lunch","Descripton":"take a break and refuel","Location":"Mc Donalds","StartTime":"2016-10-01T12:00:00","EndTime":"2016-10-01T13:00:00"},
  {"Id":3,"Name":"dinner","Descripton":"unwind and enjoy the rest of the evening","Location":"home","StartTime":"2016-10-01T19:00:00","EndTime":"2016-10-01T20:00:00"}]
FAIL:
  HTTP/1.1 404 Not Found


GET A SINGLE ITEM
------------------------------------------------------
curl -v http://localhost:[PORT]/api/events/3 

EXPECTED RESULTS:
PASS:
  {"Id":3,"Name":"dinner","Descripton":"unwind and enjoy the rest of the evening","Location":"home","StartTime":"2016-10-01T19:00:00","EndTime":"2016-10-01T20:00:00"}
FAIL:
  HTTP/1.1 404 Not Found
  
CREATE A NEW ITEM
------------------------------------------------------
curl -v -X POST -H "Content-Type: application/json" -d '
{"Id":0,"Name":"TEST NAME","Descripton":"TEST DESCRIPTION","Location":"TEST DESCRIPTION","StartTime":"2016-10-01T00:00:00","EndTime":"2016-10-01T23:59:59"}
' http://localhost:[PORT]/api/events

EXPECTED RESULTS:
PASS:
  HTTP/1.1 201 Created
FAIL:
  HTTP/1.1 400 Bad Request  <-- malformed JSON

UPDATE AN EXISITING ITEM
------------------------------------------------------
curl -v -X PUT -H "Content-Type: application/json" -d '
{"Id":3,"Name":"DINNER","Descripton":"Head over to moms and enjoy a plate of Rice-A-Roni The San Franciso treat!","Location":"home","StartTime":"2016-10-01T19:00:00","EndTime":"2016-10-01T23:59:59"}
' http://localhost:[PORT]/api/events/3

EXPECTED RESULTS:
PASS:
  HTTP/1.1 200 OK
FAIL:
  HTTP/1.1 304 Not Modified <-- mismatched ID
  HTTP/1.1 400 Bad Request  <-- malformed JSON
  HTTP/1.1 404 Not Found    <-- ID does not exist
  
  
REMOVE / DELETE AN EXISITING ITEM
------------------------------------------------------
curl -v -X DELETE http://localhost:[PORT]/api/events/1 

EXPECTED RESULTS:
PASS:
  HTTP/1.1 200 OK
FAIL:
  HTTP/1.1 404 Not Found


REFERENCES
---------------------------------------------------------------------------------------------------

WebApi Application template loosely based on this example
Mike Wasson
http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api

Entity Framework "Code First" local DB implementation
unknown author
http://www.entityframeworktutorial.net/code-first/simple-code-first-example.aspx
http://www.entityframeworktutorial.net/code-first/database-initialization-in-code-first.aspx

Techniques for consuming content-type application/data directly from the HttpRequestMessage
Darrel Miller
http://www.bizcoder.com/posting-raw-json-to-web-api

Adding Help Pages to an Existing Project
Mike Wasson
http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages