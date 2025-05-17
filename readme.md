# ?? Custom File Logger in ASP.NET Core (Without DI)

This project demonstrates how to implement a **custom file logger** manually in an ASP.NET Core Web API **without using dependency injection**. It uses a **singleton pattern** to write logs to a file safely and consistently.

---

## ?? What This Project Covers

### ? Created a Custom Logger

- Implemented a `FileLogger` class.
- Uses the Singleton pattern to ensure a single instance is used throughout the application.

### ?? Verified Logger Functionality

- Called the logger directly from middleware and controller actions.
- Confirmed that log entries are correctly written to a file.

### ?? Why Use a Singleton?

Using multiple logger instances can lead to:
- **Race conditions**: Concurrent writes to the same file.
- **File access conflicts**: Risk of file locks or I/O exceptions.
- **Inconsistent logging**: Differing configurations per instance.

Using a **singleton** ensures:
- Thread-safe logging using `lock`.
- Centralized control and configuration.
- Consistent logging behavior.

### ?? Integrated Logger into Middleware

- Inserted custom logger calls in various middleware components.
- Logged key stages of the request pipeline:  
  - Application startup  
  - Controller mapping  
  - Routing  
  - Authorization

### ?? Used Logs to Trace Execution Flow

Sample log entries:


---

## ?? Log File Location

The logger writes to:


You can change the location in `FileLogger.cs`:
```csharp
logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "log.txt");
