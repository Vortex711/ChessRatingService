# Chess Rating Service

A backend service built with ASP.NET Core and Entity Framework Core to process chess matches and maintain player ratings using an Elo-based system.

## Features

- Process chess matches with realistic Elo rating updates
- Supports wins, losses, and draws
- Variable K-factor based on player rating
- Transactional match processing
- Paginated leaderboard API
- Active/inactive player filtering
- Read-optimized queries using EF Core

## Tech Stack

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQL Server Express
- RESTful APIs
- Postman (for testing)

## Core APIs

### Process Match
`POST /api/matches/process`

Processes a completed chess match and updates:
- Player ratings
- Match history
- Rating change history

### Leaderboard
`GET /api/leaderboard`

Returns a paginated leaderboard ordered by rating.
Supports optional inclusion of inactive players.

## Design Notes

- Ratings are stored as current state in the Players table
- Rating history is preserved separately for auditability
- Leaderboard queries are read-only and use no-tracking for performance
- Match processing is idempotent using an external match ID

## Future Improvements

- Player match history API
- Time-based leaderboards (weekly/monthly)
- Authentication and authorization
