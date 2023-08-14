- create a console application  
  ```dotnet new console --framework net7.0```
- run application  
  ```dotnet run```
- create a solution  
  ```dotnet new sln```
- create a library  
  ```dotnet new classlib -o StringLibrary```
- build a project
  dotnet build
- add reference  
  ```dotnet add ShowCase/ShowCase.csproj reference StringLibrary/StringLibrary.csproj```
- run a project  
  ```dotnet run --project ShowCase/ShowCase.csproj```
- create a test project  
  ```dotnet new mstest -o StringLibraryTest```
- add a project to the solution  
  ```dotnet sln add StringLibraryTest/StringLibraryTest.csproj```
- test a project  
  ```dotnet test StringLibraryTest/StringLibraryTest.csproj```
- test a project with released version
  ```dotnet test StringLibraryTest/StringLibraryTest.csproj --configuration Release```
