[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/TyBvFPPq)

# .net25-oop-group

Grupparbete för första kursen

#
```
    ██████╗ ██╗   ██╗ ██████╗██╗  ██╗██╗      ██████╗ ██████╗ ██████╗      
    ██╔══██╗██║   ██║██╔════╝██║ ██╔╝██║     ██╔═══██╗██╔══██╗██╔══██╗     
    ██║  ██║██║   ██║██║     █████╔╝ ██║     ██║   ██║██████╔╝██║  ██║     
    ██║  ██║██║   ██║██║     ██╔═██╗ ██║     ██║   ██║██╔══██╗██║  ██║     
    ██████╔╝╚██████╔╝╚██████╗██║  ██╗███████╗╚██████╔╝██║  ██║██████╔╝     
    ╚═════╝  ╚═════╝  ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝      
                                                                           
       ██████╗██╗  ██╗ █████╗ ████████╗██╗  ██╗██╗███╗   ██╗ ██████╗       
      ██╔════╝██║  ██║██╔══██╗╚══██╔══╝██║ ██╔╝██║████╗  ██║██╔════╝       
█████╗██║     ███████║███████║   ██║   █████╔╝ ██║██╔██╗ ██║██║  ███╗█████╗
╚════╝██║     ██╔══██║██╔══██║   ██║   ██╔═██╗ ██║██║╚██╗██║██║   ██║╚════╝  
      ╚██████╗██║  ██║██║  ██║   ██║   ██║  ██╗██║██║ ╚████║╚██████╔╝      
       ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝ ╚═════╝
```
## Overview
Ducklord, Chatking is a playful chat client for communicating with friends.
It blends a game-like UI with real-time messaging so conversations feel fun and fluid.

- **Functions:** Change name and password, mute client, fullscreen/windowed
- **Client:** `C# (.NET 9)` with `Raylib_cs` for graphics.
- **Server:** `ASP.NET` backend exposing a REST API with interactive docs at `/scalar` (and via deployment).
- **Project status:** Functional prototype with core flows (create duck, login, chat, preferences) and documented API. 

## Installation & Requirements
### Requirements
- `.NET 9 SDK` must be installed on your system.  
- `Raylib_cs` is required for graphics (installed automatically via NuGet).  
- The `ASP.NET` server is already deployed and available online, so no local server setup is needed.  

### Installation
1. Clone repository from [GitHub](https://github.com/EduEdugrade/net25-kurs-1-grupparbete-h1)
2. Restore dependencies: `dotnet restore`
3. Launch the application: `dotnet run`

## Getting started
1. Register a new account (Create duck).
2. Login on your account.
3. Quack with the other ducks in the pond.

### User options
1. Click on the gear-symbol in the top right corner in chat window.
2. Change your preferences.
3. Go back to quack with the other ducks in the pond. 

## Server API Documentation

The full interactive API reference is available at:

`/scalar`

If the server is deployed, you can also visit:

`https://ducklord-server.onrender.com/scalar`

### Created by
Viktor, Christian, Marcus, André
```
>(.)__ <(.)__ =(.)__ >(.)__ 
 (___/  (___/  (___/  (___/
```
 
