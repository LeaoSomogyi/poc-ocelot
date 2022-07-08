# POC Ocelot

This project intends to be used as an example of architecture with microservices and a Gateway API using [Ocelot](https://ocelot.readthedocs.io/en/latest/index.html) to achieve that.

Updated to [.NET 6.0](https://docs.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-6) and [Ocelot 18.0.0](https://www.nuget.org/packages/Ocelot/).

Give a star on [Ocelot Github](https://github.com/ThreeMammals/Ocelot) to support the developers!

## Getting Started

```
git clone https://github.com/LeaoSomogyi/poc-ocelot.git
```

## Project Architecture

This solution has five projects, only [Poc.Ocelot.Gateway](https://github.com/LeaoSomogyi/poc-ocelot/tree/master/src/Poc.Ocelot.Gateway) has exposed on docker network and this project knows how to redirect requests to another services.

This routes configurations can be found on `ocelot.json` file.

Take a look at the diagram:

![Untitled Diagram drawio (1)](https://user-images.githubusercontent.com/19554749/177908232-b22aa801-e956-46a9-9d40-9e77a8d31885.png)

## Postman

Import [Poc Ocelot.postman_collection.json](https://github.com/LeaoSomogyi/poc-ocelot/blob/master/Poc%20Ocelot.postman_collection.json) to Postman and follow the requests order.

### 0 - Auth

Service called: [Poc.Ocelot.Accounts](https://github.com/LeaoSomogyi/poc-ocelot/tree/master/src/Poc.Ocelot.Accounts)

Only request with anonymous allowed. Used to get JWT token. If you pass the `permission_claim` query param, your can change if this token returned can access `Backoffice` API's or not. Possible values for this query param: `Common` or `Backoffice`.

### 1 - Product List

Service called: [Poc.Ocelot.Products](https://github.com/LeaoSomogyi/poc-ocelot/tree/master/src/Poc.Ocelot.Products)

Just a simple get returning a message, but only requests authenticated can access. Note the authentication is provided by Gateway, none configuration is made on the project.

### 2 - Payment List

Service called: [Poc.Ocelot.Payments](https://github.com/LeaoSomogyi/poc-ocelot/tree/master/src/Poc.Ocelot.Payments)

Just a simple get returning a message, but only requests authenticated can access. Note the authentication is provided by Gateway, none configuration is made on the project.

### 3 - Backoffice Orders

Service called: [Poc.Ocelot.Backoffice](https://github.com/LeaoSomogyi/poc-ocelot/tree/master/src/Poc.Ocelot.Backoffice)

This project has your own authentication rule. Only tokens with `permission` claim with the value `Backoffice` can access this request, otherwise and status 403 is returned.

## Docker

On the root folder of the solution, just run the follow command to the magic begins:

```
docker-compose build
```

Once the build was finished:

```
docker-compose up
```

To run and force build:

```
docker-compose up --build
```

## Authors

* **Felipe Somogyi** - [LeaoSomogyi](https://github.com/LeaoSomogyi)

Check all contributors [contributors](https://github.com/LeaoSomogyi/poc-ocelot/graphs/contributors)
