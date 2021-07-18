# Project Name
Redfin Food Truck Challenge Assessment

## Overview
The goal of this assessment is to write a simple command line program which can use a timestamp and an API endpoint to returns a list of food trucks.

## Technologies
I use REST API with .Net Core library.

## Code Structure
There are three mains parts under this project:
1. DataTransferObjects class to represent the objects return the request results by the api endpoint.
2. Services class contains all api services of the details logic to support the communication with Food Truck REST API.
3. Controllers class use to wrap up the api services call.

## How to install
There are nothing need to install, just need to run it since this is a C# simple console application.

## How to convert it to a fully-featured web application
For convert this project to a web application, we need to finish the following tasks:
1. Adding more specific routes and http methods to the controllers class.
2. Register these controllers class.
3. Define a REST API endpoint can be host in the back end service.
4. In UI level I plan use Angular Reactive Form & Material designer controller to rendering the modern UX interface:
   a). Mat Grid list controller to rendering all food trucks data with paging controller.
   b). Above the grid list controller we can add a date time search function to support if any user want to filter out data by time stamp, and also we can expand this function can support advanced search (by example: search by applicant id or city name, etc... ).
   c). When user click any row of the grid, the UI will redirect to the detail page which give user more information.

## High Level design for scalability and reliability
If the system will be serving for millions of concurrent users in the future, we should design the system can easy scalable and reliable at the beginning, here are some thoughts from high level:
1. We will need a load balancer in front of our servers, we can map each UserID to a server that holds the connection for the user and then direct the request to that server.
2. For handle millions of requests we need to split reads and write into separate services, we assuming read requests are highly more than write requests in this case, so we can have more read service servers for support more read requests.
3. If our system holding millions of food truck data since lots of data need to stay in the system for multi years for some audit purpose, we probably need data partition, in this case I think we can partition by permit id, we find the shard number by hash function ("hash(permitid) % 100") and then save to the correspond database.
4. Losing data is not an option for the food truck service, since this is very critical for the government, we can retrieve the food trucks data and copy to the different storage servers, same for the service components, if the primary component has any problem the backup system can take control after the failover.
5. Server Cache and Load balancing
   1) with 80-20 rule, we can try caching 20% of daily read volume of food truck data, we can use either Redis or Memcache.
   2) We should use Consistent Hashing to hand the fault tolerance and replication.
6. We can also introduce an API Rate Limiter service into the system, to do so we can:
   a). Prevent misbehaving clients and scripts.
   b). Improve system security.
   c). To prevent abusive behavior and bad design practices.
   d). To keep costs and resource usage under control.
   f). To eliminate spikiness in traffic.
