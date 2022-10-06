
# APP Technical Exercise
Please fork this repo to complete the tasks below. Treat this as any other project in terms of how you would handle it to meet the requirements including your regular frequency of commits.

## Setup
You'll need Docker on your machine to run the environment you'll be working in easily.

* The database connection string will be passed via an environment variable and can be retrieved from the configuration using key `ConnectionStrings:DbContext`

## Tasks
Please use this project as the base for your work to accomplish the following:

* Please provide an API with which you can accomplish the following

    * Create a user account with the following:
    
        * Name
        
        * Email
        
        * Password
        
    * A user should be able to authenticate with an email and password
        
    * An authenticated user should be able to add and remove their favorite cities where a city consists of the following:
    
        * City name
        
        * Country
        
    * An authenticated user should be able to retrieve a list of their favorite cities


## Running with Docker
From command line

1. Navigate to the solution folder

2. Run/update docker compose: `docker-compose up -d --build`

3. Once docker compose has been deployed successfully (you'll see it in the output), you can access the api at `http://localhost:8100`.
