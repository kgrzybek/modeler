# Modeler

## General information

Modeler is a sample project demonstrating the concept of Model As Code – an approach where models are defined, managed, and versioned as code. This allows for better traceability, automation, and integration with development workflows.

    ⚠️ Work in Progress
    This project is currently under active development. Interfaces and functionality may change as the project evolves.
    Documentation is in progress and will be updated continuously.

Stay tuned for updates, and feel free to explore or contribute.

## Prerequisites

To run and build the Modeler project, you need the following tools installed on your system:

1. PlantUML – used for generating UML diagrams from code-based definitions.

2. Asciidoctor – a toolchain for converting AsciiDoc files to HTML, PDF, and other formats.

3. Asciidoctor Diagram – an Asciidoctor extension that enables embedding diagrams (e.g., PlantUML) directly within AsciiDoc files.

Make sure these tools are properly installed and available in your system's PATH before working with the project.

## How to run

Run Modeler.CLI program with output directory path argument:

```shell
dotnet Modeler.CLI "C:\Modeler_sample_docs"
```

This command will generate views based on views definitions and models. Then, you can use this views in your documentation.

See [example documentation](/example-doc/).

## Models list

### Components

Represents the main building blocks of a system and their dependencies. Useful for visualizing system architecture at a high level.

#### Supported Views

1. AsciiDoc Table generator
2. AsciiDoc Details
3. PlantUml Components Diagram

#### Documentation

See [Components Documentation](docs/Models/Component).

### Conceptual

Focuses on high-level domain concepts and their relationships. Helps in understanding the business or problem domain without technical details.

#### Supported Views

1. AsciiDoc Details
2. Mermaid Class Diagram
3. PlantUml Class Diagram

#### Documentation

See [Conceptual Model Documentation](docs/Models/Conceptual).

### Data

Defines data structures, tables, and their relationships. Useful for modeling databases or data-centric systems.

#### Supported Views

1. AsciiDoc Structure
2. PlantUml DataModel Diagram
3. SQL Script

#### Documentation

See [Data Model Documentation](docs/Models/Data).

### Events Flow

Illustrates the flow of events between components or systems. Helps in understanding how different parts of the system react and communicate through events.

#### Supported Views

1. Mermaid Flow Diagram

#### Documentation

See [Events Flow Documentation](docs/Models/EventsFlow).

### Sequence

Describes interactions between objects or components in a time-ordered sequence. Ideal for capturing detailed behavior and scenarios.

#### Supported Views

1. Mermaid Sequence Diagram
2. PlantUML Sequence Diagram

#### Documentation

See [Sequence Documentation](docs/Models/Sequence).

### State machine

Models the states of an object and the transitions between them based on events. Useful for describing system behavior over time.

#### Supported Views

1. AsciiDoc Table
2. PlantUML State Diagram
3. Markdown Table

#### Documentation

See [State Model Documentation](docs/Models/State).

### Rest API

Defines endpoints along with request and response models.

#### Supported Views

1. AsciiDoc tables
2. OpenAPI JSON specification
3. OpenAPI YAML specification

#### Documentation

See [Rest API Model Documentation](docs/Models/RestApi).
