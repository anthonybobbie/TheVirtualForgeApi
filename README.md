# TheVirtualForge  Catalog Api
The API is layered  internally, this project's organization into multiple projects based on responsibility improves the maintainability of the application.
Units can be scaled up or out to take advantage of cloud-based on-demand scalability
## Application core 
This project defines abstractions, or interfaces  which are then implemented by types defined in the Infrastructure layer
## Infrastructure  
This project contains the implementation of abstractions defined in the application core. It also contains entities and services for database interaction.
## Presentation  
The Api project itself which applications interact with via endpoints
## Test  
Console apps to test endpoint of the presentation layer

