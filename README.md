# OldBoardGamesNeedLoveToo

OldBoardGamesNeedLoveToo is a website for people to find the board games they've always desired. 
Users connect with other board games lovers;
Users find people who will love their old board games;
Users find people who want to give/sell their old board game;

The site includes cool features like:
- Adding a detailed information about the game they want to give/sell.
- Browsing a collection of cool board games;
- Searching a type of game by name;
- Filtering game results;
- Commenting cool games with other users;
- Rate other users who love board games;

## Available Pages
### Public part (accessible without authentication)
- Home Page with a list of offered games and an option for search and filtering;
- Details page information about each game;
- Public user profiles with their board games collection and contacts;

### Private part (available for registered users)
- Users can add a new game to offered;
- Update their account information;
- Rate other users;

### Aministrative part (available for administrators only)
- Manage Users Admin Page
- Manage Games Admin Page
- Manage Categories Admin Page

## Technologies, frameworks and development techniques
- ASP.NET Web Forms
- Server-side Web Forms UI rendering (ASPX pages and ASCX controls)
- MS SQL Server as database back-end
- Entity Framework 
- Bootstrap
- Registered users have two roles: user and administrator
- Use of the standard ASP.NET Web Forms controls (from System.Web.UI)
- Services and presenters unit tests
- Use of MVP pattern
- IoC Container - Ninject
