# Preference recruitment test 
Basic web issue manager.

[Trello panel](https://trello.com/b/TmjLeAKI/issue-manager)

## Exercise
Implement the next functionality:
* Issue list (all fields must be editable)<br/>
  Fields:
   * Title
   * Description
   * Severity (High, Medium, Low)
   * Status (TODO, DOING, DONE)
   
The issue status must be editable from the issue list itself, not from any detailed view.<br/>
We recommend all fields editable in the issue list itself.<br/>
Don't use save button, just autosave.<br/>
Use websocket to update issues automaticaly when something changes.<br/>
Asume users will use last chrome version (don't care about browser compatibilities).<br/>
Use the backend technology you want, for frontend you must use VueJS or React, and we recommend also to use typescript you can use the DB technology you want.<br/>

### Use cases
![SW architecture](assests/images/Use%20cases.png)

## SW technologies
* Web APP: [React](https://reactjs.org/) Front App  
    * Aplication State Library: [Redux](https://es.redux.js.org/)
    * Styling:
        * Styling templates: [Styled-components](https://styled-components.com/)
        * CSS Framework: [Tailwind](https://tailwindcss.com/)
    * Language: [TypeScript](https://www.typescriptlang.org/)

* API: [.Net Core](https://dotnet.microsoft.com/) API
    * Query Languaje: [GraphQL](https://graphql.org/) *Only for fun. If it gets complicated I'll change to REST.*
    * RealTime communication: [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
    * Language: [C#](https://docs.microsoft.com/es-es/dotnet/csharp/)

* BD: [SQLite](https://sqlite.org/index.html)
    * Language: [SQL](https://en.wikipedia.org/wiki/SQL)

![SW architecture](assests/images/SW%20architecture%20diagram.png)

## Time planning
