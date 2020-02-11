# POC Ocelot

This project intends to be used as an example of architecture with microservices and a Gateway API using [Ocelot](https://www.nuget.org/packages/Ocelot/) to achieve that

## Getting Started

```
git clone https://github.com/LeaoSomogyi/poc-ocelot.git
```

## Dev Certs

In order to run this project, you will need the self-signed certficates. So, let's install the [dotnet dev-certs tool](https://www.nuget.org/packages/dotnet-dev-certs):

```
dotnet tool install --global dotnet-dev-certs --version 2.2.0
```

This step was a little to hard but it everything will be allright.

First, run the follow command to generate the self-signed certificate:

```
dotnet dev-certs https
```

Now, we need to expose the UserSecret keys to development machine in order to work.

For that, run the follow commands:

```
dotnet user-secrets set "Kestrel:Certificates:Default:Password" "53bfa119-f10c-4acb-b8a0-43282638879f" --project "<Your repo folder>\poc-ocelot\src\Poc.Ocelot.Gateway"
```

```
dotnet user-secrets set "Kestrel:Certificates:Default:Password" "c9acc524-6b79-4ef5-9937-5327e9e3e24c" --project "<Your repo folder>\poc-ocelot\src\Poc.Ocelot.Accounts"
```

```
dotnet user-secrets set "Kestrel:Certificates:Default:Password" "f9c493d3-035e-4341-9400-02936966c24a" --project "<Your repo folder>\poc-ocelot\src\Poc.Ocelot.Products"
```

```
dotnet user-secrets set "Kestrel:Certificates:Default:Password" "1b9eb99c-b8c8-4ce4-bdfa-44e0f325b86f" --project "<Your repo folder>\poc-ocelot\src\Poc.Ocelot.Payments"
```

The last step is to export the certificates to a .pfx file to use on our docker containers:

```
dotnet dev-certs https --export-path "<Your folder to use on docker volume>\Poc.Ocelot.Gateway.pfx" -p "53bfa119-f10c-4acb-b8a0-43282638879f"
```

```
dotnet dev-certs https --export-path "<Your folder to use on docker volume>\Poc.Ocelot.Accounts.pfx" -p "c9acc524-6b79-4ef5-9937-5327e9e3e24c"
```

```
dotnet dev-certs https --export-path "<Your folder to use on docker volume>\Poc.Ocelot.Products.pfx" -p "f9c493d3-035e-4341-9400-02936966c24a"
```

```
dotnet dev-certs https --export-path "<Your folder to use on docker volume>\Poc.Ocelot.Payments.pfx" -p "1b9eb99c-b8c8-4ce4-bdfa-44e0f325b86f"
```

Now we be able to use docker-compose to run the entire solution!

## Docker

First of all, you need to adjust the docker-compose file to the correspondent folders on your machine in order to mount the volumes properly.

On the root folder of the solution, just run the follow command to the magic begins:

```
docker-compose build
```

Once the build was finished:

```
docker-compose up
```

## Authors

* **Felipe Somogyi** - [LeaoSomogyi](https://github.com/LeaoSomogyi)

Check all contributors [contributors](https://github.com/LeaoSomogyi/poc-ocelot/graphs/contributors)