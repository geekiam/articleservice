# Geekiam Articles Service

A microservice to build a list of articles from a list of sources to incrementally feed the Geekiam app.

This project structure  was generated using the [API Template Pack](https://www.apitemplatepack.com/ "API Template Pack")

### Local Development configuration

In order to configure your local environment with all the prerequisites for development a `docker-compose.yml` is provided containing all the infrastructure

Simply run the docker compose file before starting the API

Check out [How to run docker compose files in Rider](https://garywoodfine.com/how-to-run-docker-compose-files-in-rider/)
or run the following command on the terminal in the root project directory 

```shell
docker compose up -d 
```

#### Integration tests

Execute the integration test suite will require the installation of Httpyac
```shell
npm i -g httpyac
```

Once installed you can run the project using the the tests using the code below int he root project directory

```shell
httpyac tests/Integration/Tests/ --all --env dev
```
#### Seeding the Database
We seed the database using our predefined endpoints.

Each folder may specific release updates etc

```shell
httpyac seeding/Seeding/initial/ --all --env seeding
```
