# Surface identity - Call Identify API using C Sharp

Surface Identity Web Api 1.0 C# Sample

## Description

This is a sample project that allow to use Surface Identity Web Api 1.0

## Getting Started

### Dependencies

* .NET Core 3.1
* Visual Studio 2019

### Installing
* Clone repository
* Open project with Visual Studio 2019
* Save your *.obj file in the project name. N.B. Use a file that contains vertices
* Set other parameters used by recognition process in appsettings.json file
* Run the project
```json

  "IdentificationSettings": {
    "AppId":  "your-app-id",                                                // App Id: your app id 
    "Secret": "your-app-secret",                                            // App secret: your app secret
    "TokenRequestURL": "https://...",                                       // Access token URL: surface identity URL used to get access token ('https://is.surfaceidentity.com/connect/token')
    "IdentificationEndpointURL": "https://...",                             // Identification Service URL: url of surface identity web service ( i.e. 'https://api.surfaceidentity.com/api/Identify')
    "ProjectIds": [ 'projectId-1', 'projectId-2', 'projectId-N' ],          // Project Ids: set of project that I would like to query
    "UnitOfMeasure": "m",                                                   // Unit Of Measure Symbol: unit of measure used in the file i.e. 'm'
    "Filename": "your-file-name.obj",                                        // Name of the file that contains the surface to recognize 
    "InstanceName": "your-instance-name"                                    // Name of the instance sending to server
  }

```

## Help

Any advise for common problems or issues.

## Authors

Contributors names and contact info

ex. Beniamino Ferrari info@surfaceidentity.com 
