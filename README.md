# Expense Tracker

![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)

## Description

Expense Tracker is a .NET WebAPI project built on Clean Architecture and Domain-Driven Design (DDD) principles. It provides a platform for managing expenses, allowing users to track their spending efficiently.

## Introduction

Expense Tracker is built on top of DDD principles. Thus, it is divided into bounded-contexts, aggregates, entities and value objects. 

Currently, only one bounded context is explored, which covers the end-user modeling and use cases. It can be modeled as:

![Expense Tracker C4 diagram](https://assets.sverdejot.dev/expense-tracker/diagram.png)

Currently, it covers:

* **_Expense_**: creating new expenses to track spending.
* **_Budgets_**: create budget to track maximum spendings, being able to attach multiple types of alerts to this budgets. Expenses will automatically be included into every active Budget.
* **_Groups_**: track shared spendings with multiple dividing options like percentages, equally and multi-currency.

## Technologies

- .NET 8.0
- EntityFramework 8.0
- CQRS:
    - MediatR
    - FluentValidations
    - Mapster
- Testing
    - xUnit
    - FluentAssertions
    - Moq
    - AutoMock
- CI/CD:
    - Docker
    - GitHub Actions

## Installation

To set up the project, make sure you have [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed. Also, install `Makefile` by:

```bash
# Windows
choco install make

# macOS
brew install make

# Linux
apt install make
```

Then, run the following commands:

```bash
make install
```

## Usage

Expense Tracker can be easily set up using Docker Compose. Follow these steps:

1. Make sure you have Docker installed on your system.

2. In the root directory of the project, run the following command to build and start the containers:

```bash
make start
```

Now you can access the OpenAPI Specification on `http://localhost:5001/swagger`

You can take a look at all the available commands by running `make` or `make help` at the root directory.

## Contributing

This project uses [`conventional-commits`](https://www.conventionalcommits.org/en/v1.0.0/) as contributing standard. It enables ease of tracking changes as well as automatic SemVer and CHANGELOG.md generation. For all this purposes, it is using [`Versionize`](https://github.com/versionize/versionize) .NET Tool.

To enable automatic CHANGELOG and versioning generation, follow the following format:

```text
<type>(<scope>): <message>
```

Where `<type>` can be one of the following:

* feat: A new feature
* fix: A bug fix
* docs: Documentation changes
* style: Code style changes (e.g., formatting)
* refactor: Code refactoring
* test: Adding or modifying tests
* chore: Routine tasks, maintenance, etc.

Type any breaking change by adding a `!` after `(<scope>)` and before semicolon:

```text
<type>(<scope>)!: <message>
```

Author:

- Samuel Verdejo <<contacto@sverdejot.dev>>
