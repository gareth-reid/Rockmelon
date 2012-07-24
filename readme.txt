Xbox app (Rockmelon)
1. Create new database 
2. Run Rockmelon.deploy.sql script on new database
3. Change web.config connection string (in Rockmelon.SIte)
4. Run app through vs2010 or as a website (.net4/ MVC3)
5. Optional - Change app.config in Rockmelon.Repository.Tests 
	(to run integration tests)

Fizzbuzz and Supermarket Register just need to be opened in VS2010 and ran

Rockmelon (a random name I chose) uses:
-EF 4.3.1
-IOC, Ninject (I have used unity on the last 3 projects I have worked on so I thought I might see how ninject works)
-SQL Server 2008R2
-Nunit
-A basic pattern of my own divising with ease of testing in mind

