# issue-tracker
- Project I made to practice Clean Architecture (Robert C. Martin ) and thin Controllers using MediatR with ASP.NET MVC
- Fronted is made with the Vue composition API and script setup

<br/>

> I'm a self taught developer and I only started coding late 2019 (in my free time), so my implementation of Clean Architecture might be faulty 

## Work in progress
- You can already use the project and improve upon what I have created so far
   - the Fronted is created and can communicate with the back-end
   - state and position of the issues gets saved when you drag  an issue to another column and when you leave the project page
## Ideas
 - Add possibility to share your project / issue with another user.
    - share button > fill in user email > if email exists in DB > user gets invitation > upon accepting > project / issues gets pushed to his DB
    - When you share an issue, the other user  can write comments in the description (link a different font color to the other user)
    - add possibility to add  other users to the project, when you initially create the project
 - Link issues to github commits
 - Add possibility to add Screenshots to your issue Description
 - Make a mobile version or make mobile friendly
 - ...

## Install project
- Make sure you have PostGress installed on your pc, create a DB for your project and Change the ConntectionString in /WebUI/appsettings.Development.json
    - "ConnectionStrings": {
    "DefaultConnection": "Server=localhost; Port=5432;User ID=jan; Password=xxxx; Database=issue_tracker_db; Pooling=true;"
  }
  <br/>
 > There is a known issue, at the time of writing, where EF Core doesn't create the DB automatically for you when your DB is Postgress. 
 <br/>
  > For Postgress, you have to create the DB for your project manually (just DB name, not the tables etc.)
  > And after creating the DB you can run the dotnet run command
  <br/>
    > When you read this this problem might allready be resolved, and you might be able to just run dotnet build, without having to first setup your PG DB manually

```
- cd into Client folder 
    - $ pnpm install 
    - $ npm run dev
```

```
- cd into WebUI folder
    - $ dotnet run

```
<br />

## After installation
- when you run '$ dotnet run', seed (dummy) data gets stored into your db, so you have something to work with
    - check Infrastructure/Persistence/Seed.cs
<br/>
Dummy user:
<br/>
>  Email = "jan@test.com"
<br/>
> Pasword = "Pa$$w0rd"

## Images

![image](https://github.com/JDN89/vue-dotnet-issue-tracker/blob/main/ReadMeImages/issue-tracker-light.png)
![image](https://github.com/JDN89/vue-dotnet-issue-tracker/blob/main/ReadMeImages/issue-tracker-dark.png)


# After word
- This project is a continuation of my former issue-tracker repo https://github.com/JDN89/issue-tracker-discontinued .
<br/> Github was not displaying my commits in my activity graph (that's why there is a gap in 02/2022 and 03/2022). 
<br/> The only solution I found was creating a new repo (this one) and cloning my old repo into this one.
    
