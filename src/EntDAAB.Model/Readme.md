## Scenarios for the Data Access Application Block

Developers often write applications that use databases. Because it is so common, developers may find themselves repeatedly writing the same code for each application. In addition, these applications may need to work with different types of databases. Although the tasks are the same, the code must be adapted to suit the programming model of each database. The Data Access Application Block solves these problems by providing the logic to perform the most common data access tasks. 
### Developers only need to do the following:
  - Create the database object.
  - Supply the parameters for the command, if they are needed.
  - Call the appropriate method(s). These methods are optimized for performance. They are also portable.

The most common tasks developers face when they are writing database applications are arranged according to scenarios. Each scenario gives an example of a real-world situation, such as retrieving information from a catalog or performing a banking transaction, describes the database functions the situation requires, and shows the code that accomplishes the task.
The goal of arranging these tasks according to scenarios is to give the code some context. Instead of showing an isolated group of methods, with no sense of where they can best be used, scenarios provide a setting for the code, placing it in situations familiar to many developers whose applications must access databases.

### The scenarios are the following:
  - Using a DataReader to retrieve multiple rows of data
  - Using a DataSet to retrieve multiple rows of data
  - Executing a command and retrieving the output parameters
  - Executing a command and retrieving a single-value item
  - Performing multiple operations within a transaction
  - Updating a database with data contained in a DataSet object
  - Retrieving XML data from a SQL Server database
  - Querying the data returned using client-side techniques such as LINQ
  - Performing asynchronous data access with a callback handler or Lambda expression

## Code generation

To generate DAL code, please modified ''SQLServer.ttinclude'' file as following sections:

  	const string Namespace = "DataGenerator";
    const string ConnectionStringName = "TestDB";
	const string ConnectionString = @"data source=.;initial catalog=TestPerformaceDB;integrated security=True";

## TODO
Entlib DAAB Query/Where method