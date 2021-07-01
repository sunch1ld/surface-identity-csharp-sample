### SURFACE IDENTITY
 
## 1.ABOUT AS 
This library allows the recognition of 3D objects.
is a library installed on the Oauth 2.0 protocol.
 
## 2. table of contents


### IdentificationClient
IdentificationClient to make a surface recognition request to the server.
Through the IdentifyAsync method, passing the request as a parameter, both the token request and the surface recognition request will be made.
you must have the following data:
* **clientID**: unique id of the client;
* **clientSecret**: represented the password of the client;
* **authority**: represents the server for authentication;







### Identification Request
IdentificationRequest: represents the request made by the client to access the resource
 

* **ProjectIdS**: represents an array of strings containing the project ids
* **InstanceName**: Name of the instance , guid type;
* **X**: Double's Array, which represents the coordinates relative to the points of the X axis;
* **Y**: Double's Array, which represents the coordinates relative to the points of the Y axis;
* **Z**: Double's Array, which represents the coordinates relative to the points of the axis;
UnitOfMeasureSymbol: Unit of measure of the project;
* **UnitOfMeasureSymbol**: Unit of measure project;



### Identification Response
* **Found**: Bool value that can be true or false if match between sections is found;
* **RecognizedObjectId**: it is of type string,represents the id of the object;
* **RecognizedObjectName**: it is of type string;
* **RecognizedSurfaceId**: it is of type string;
* **RecognizedSurfaceName**: it is of type string;
* **Similarity**: it is double, the field is not visible to the user but is used to compare the different objects of the train / test in order to calculate the percentage of similarity between objects;
* **RecognitionTime**: ulong


## 3. installation
To make the library work you can download the nuget package, npm package.

## 4. usage
This library is useful for comparing surfaces and recognizing their similarity

## 5. configuration
To configure the library use the library class you can use a json file.
Example 
 
"IdentificationSettings": {

    "Authority": "https://surfaceidentity.it:4000",
    "ClientId": "5ef99703617c890164cd6985",
    "ClientSecret": "Password123",
    "ServiceOfRecognition": "https://surfaceidentity.it:6005/api/Identify",
    "ProjectIds": [ "5ef9929c617c890164cd683c", "5f1ebf08d56b3c1abc41678b" ],
    "UnitOfMeasureSymbol": "mm"
      }







## 6. Dependence
* IdentityModel
* Microsoft.AspNetCore.Session
* Microsoft.Extensions.Configuration
* Microsoft.Extensions.Configuration.EnviromentVariables
* Microsoft.Extensions.Configurations.Json
* Microsoft.Extensions.DependencyInjection.Abstractions
* Microsoft.Extensions.Logging.Console
* Newtonsoft.Json
* Quartz
* UnitsNet

