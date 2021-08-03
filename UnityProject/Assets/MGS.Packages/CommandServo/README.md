[TOC]

# MGS.CommandServo

## Summary
- Command servo system for Unity project.
- This project just provide the framework for command servo system.
- You can use it to do more things.

## Environment

- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Platform
- Windows

## Demand
- Listener the command IO and read command buffer.
- Parse the command buffer to Command.
- Execute the Command and respond the result after complete.
- Parse the respond result to buffer and write to command IO.

## Implemented

```C#
public interface ICommandIO{}

public interface ICommandParser{}

public interface ICommandUnit{}

public struct Command{}

public abstract class CommandUnit : ICommandUnit{}

public class CommandManager : ICommandManager{}

public class CommandUnitManager : ICommandUnitManager{}

public sealed class CommandServoProcessor : SingleTimer<CommandServoProcessor>, ICommandServoProcessor{}
```

## Usage

- Implement interfaces base your business logic.

```C#
//Implement ICommandIO.
public class CommandIO : ICommandIO
{
    public byte[] ReadBuffer()
    {
        //TODO:
        return null;
    }

    public void WriteBuffer(byte[] buffer)
    {
        //TODO:
    }
}

//Implement ICommandParser.
public class CommandParser : ICommandParser
{
    public byte[] ToBuffer(Command Command)
    {
        //TODO:
        return null;
    }

    public IEnumerable<Command> ToCommands(byte[] buffer)
    {
        //TODO:
        return null;
    }
}

//Implement ICommandUnit.
public class MyCommandUnit : CommandUnit
{
    public override void Execute(params object[] args)
    {
        //TODO:
    }
}
```

- Construct command manager.

```C#
var cmdIO = new CommandIO();
var cmdParser = new CommandParser();
var cmdManager = new CommandManager(cmdIO, cmdParser);
```

- Construct command unit manager and Register units.

```c#
var unitManager = new CommandUnitManager();
var unit_0 = new MyCommandUnit();
unitManager.RegisterUnit(unit_0);
```

- Initialize command servo processor.

```C#
//Processor cruise starts after initialized.
CommandServoProcessor.Instance.Initialize(cmdManager, unitManager);
```


## Demo

- Demos in the path "MGS.Packages/CommandServo/Demo/" provide reference to you.

## Source

- https://github.com/mogoson/MGS.CommandServo.
------

Copyright © 2021 Mogoson.	mogoson@outlook.com
