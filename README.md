# .NET Chat and Cast
.NET Windows Forms Chat and Screen Casting using WCF Duplex
This application is a host and a client. You can run the host on one machine and run multiple clients on same/different machines.

*This is not a production ready application, it's a showcase on how to screen chast and transmit data using WCF Duplex. However you may use it with your team in a work environment.*

## How to run it
This application is built on .NET Framework 4.5.
Clone this solution, open it using Visual Studio, and build it.
Run the SecuredChat.exe from the output directory.

## How to use it
1. Run one instance of the application as a host: 
    - Open SecuredChat.exe
    - Click Remoot
    - Click Connect
    - Click Yes.
2. Run one instance of the application as a client:
    - Open SecuredChat.exe
    - Click Remoot > Preferences > Set Custom User Name
    - Enter *User 1*
    - Click Remoot > Connect
    - Choose No.
    - Enter *localhost*.
3. Run another instance as a client on a different machine:
    - Make sure port **8080** is open on the host machine.
    - Repeat steps on point 2 above. On the last step instead of *localhost*, enter the IP of the machine where the host instance is running.
 
 ## Features
 - As a client, you can now chat and cast your screen to other clients.
 - As a client, you can protect your messages with a password (Remoot > Preferences > Enable Encryption). Only clients with the same password can decrypt your messages.
  
 ## Shortcuts
 - `Ctrl + S` to send a screenshot.
 - `Ctrl + K` to go into hack mode (just for privacy or fun).
 - `Ctrl + H` to hide the application.
 - `Ctrl + N` to connect.
 - `Ctrl + D` to disconnect.
 - `Ctrl + E` to exit.
 
 ## To Do
- Sharing files with drag drop
- Share screen (or screenshot) with a specific user by right clicking on his name
- When in hack mode change background color to incoming font color
- When in hack mode reset width of clients listbox
- Messages should be listview instead of richtextbox 
- Right click any message to do actions
- Option to save chat to txt files
 
 ## Contribute
 Contributions are more than welcome, fork this repository, commit your changes, and create a pull request.
 
 ## License
 MIT
