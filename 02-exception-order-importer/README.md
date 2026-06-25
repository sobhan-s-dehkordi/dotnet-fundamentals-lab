# Exception Order Importer
A clean .NET Console application built to practice professional Exception Handling techniques and defensive programming in C# through an order import simulation.

### Goal
Move beyond basic `try/catch` blocks and apply advanced, structured exception handling strategies in a practical scenario to build resilient, fail-safe applications.

### Concepts Covered
**Exception Handling Principles**
* Custom Exceptions (Domain vs. System errors)
* Exception Wrapping (Preserving `InnerException`)
* Fail-Safe Processing (Partial success in batch jobs)
* Global Exception Handling (Console middleware simulation)
* Meaningful Error Reporting

**C# Features**
* Pattern Matching (`switch` expressions for type-checking)
* Abstract Classes (Base exception definition)
* `System.Text.Json` (Deserialization & error catching)
* Exception Filters (Handling specific `IOException`s)

**Design Principles**
* SoC (Separation of Concerns)
* Fail-Fast Validation
* Defensive Programming
* Avoiding `try/catch` clutter in business logic

**Other**
* File I/O operations
* Simulating external dependencies (Random service failures)
* Generating structured console reports

### Project Description
This project simulates an asynchronous-like batch processing system that reads a JSON file of customer orders. It is intentionally designed to face various realistic failure points (missing files, malformed JSON, business logic violations, and external database timeouts) to demonstrate how a system should gracefully handle and report them.

### Features
* Read and deserialize a list of orders from a JSON file.
* Validate strict business rules (e.g., no negative amounts, no empty IDs).
* Process batch data safely (a single bad order does not crash the entire process).
* Simulate domain errors like "Duplicate Orders".
* Simulate infrastructure errors like random "External Service Unavailable".
* Translate complex stack traces into clean, user-friendly messages.
* Generate a final summary report showing total, successful, and failed imports with specific reasons.

The system is kept architecturally simple (no heavy frameworks) to keep the strict focus on writing clean, maintainable, and predictable error management code.
