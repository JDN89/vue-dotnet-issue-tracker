# issue-tracker
- Project I made to practice DDD and thin Controllers using MediatR with ASP.NET MVC
- Fronted is made with the vue composition API and script setup
- I tried to incorporate some form of Domain Driven Design into this project

<br/>

> I'm a self thaught developer and I only started coding late 2019 (in my free time), so my application of DDD might be faulty 

## Work in progress
- You can allready use the project and improve upon what I have created so far
   - the Fronted is created and can communicate with the backend
   - state and position of the issues get saved upon drag and upon loggging in
##  To Do
- fix display of date time
    > 
- add new issue
    - automatically fill in current date upon creation of issue
- edit existing issue
- delete issue
- add new project
- delete a project and related issues (cascade delete?)
- load issues related to a specific project
    - upon logging in Project [0] gets loaded - DONE
- remove token automatically when it expires
- display errors in a nice format
    - display Axios errors


## Install project
- Make sure you have PostGress installed onto your pc
```
- cd into Client folder 
    - $ pnpm install 
    - $ npm run dev
```

```
- cd into WebUI folder
    - $ dotnet run
- cd into root folder (set up code first migration)
    - $ dotnet ef migrations add initialCreate -p Infrastructure -s WebUI
```
 > it's possible that you have to switch the order of dotnet run and dotnet ef migrations ( I don't remember the exact order).
<br />

## After installation
- when you run dotnet run, seed (dummmy) data gets stored into your db, so you have something to work with
    - check Infrastructure/Persistence/Seed.cs
<br/>
Dummy user:
<br/>
>  Email = "jan@test.com"
<br/>
> Pasword = "Pa$$w0rd"

# After word
- This project is a continuation of my former issue-tracker repo. Github was not displaying my commits in my activity graph. The only solution I found was creating a new repo (this one) and cloning my old repo into this one.

<br/> 
Feel free to contact me at jan.de.niels@gmail.com for comments, improvements or for sharing your cloned repo with me.
    
    
or 