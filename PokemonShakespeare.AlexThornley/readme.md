Instructions
------------

This is a .NET Core API. You can load the solution and run in Visual Studio 2019. The start up project should be the API.

Alternatively, .NET Core APIs can self host. You can download the bin folder (separate download) and run PokemonShakespeare.API.exe. The console window will tell you the port to connect on.

The route is as specified in the instructions e.g. GET http://localhost:5000/pokemon/charizard


Comments
--------

I have limited time, so just tried to do the simple thing. The solution structure should be unsurprising.

I have not integrated with the Shakespeare API, since this is not free. I have provided a mock implementation.

I added some simple in memory caching. Cache entries invalidate after an hour. In this scenario, it seems likely the data would not change frequently. 
It is a single level cache, based on Pokemon name. You could argue for a two level cache, one for Pokemon to species and one for species to flavour text. 
However, there is almost a one-to-one mapping between Pokemon and species, so I thought this unnecessarily complicated the code.

I did think about a different approach, caching all pokemon and text into a database, with an overnight batch process. The API project would then only look at the db. 
The advantage here would be stability, removing the run time reliance on external services.

I have not used Docker. My home laptop is not on Windows Professional so this was not an option for me.

I don't have a personal Git account. If you would like to see a personal project I am working on, I would be happy to bring my laptop to interview.
