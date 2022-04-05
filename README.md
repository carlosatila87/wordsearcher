# WordSearcher
This is a Code Test for Deltatre.
This code was made using:
- .Net 6.0
- React 18.0
- MSSQL Server 19
- Docker

# Building the Application
To run the application you will need docker previously installed.
1. Clone the repository
2. Open the CMD, powershell or preferred terminal on the project folder
3. Rum command: docker-compose build

After that the solution will build and be ready to run from docker containers

# Running the Solution
1. After build the service images, run in the terminal: docker-compose up
2. The solution will be ready to be accessed.
  - FrontEnd: http://localhost:8081/search-word
  - BackEnd: http://localhost:9100/api/SingleWord/{method_name}

# Running Unit Tests
To run unit tests you will need dotnet installed in your machine.
1. Navigate to WordService.Tests in terminal
2. Run dotnet test



The solution is holding ports 8081 and 9100. Feel free to change these ports in the solution.
