# Toolbox

A collection of helpers for `FSharp`. 

The library is designed to cut down on code duplication across projects 
and have one place to update.

## Strings

## IO

## Streams

## Type helpers

A collection of type helpers for working with types in `FSharp`.

## Mapping

Helpers for object mapping in `FSharp`.

**TODO** Currently focused around arg mapping, needs to be made a bit more generic.

## Hashing

Helpers for hashing data.

## Encryption

Helpers for encrypting and decrypting data. 

## Passwords

**This is mainly for simple password solutions, for production apps etc there are better options.**

A collection of helper functions for working with passwords.

Always be careful with passwords and check for best practices.

## App environment

### Arg parser

Helpers for parsing command line args to `FSharp` unions and records.

The supported format currently is a union for the command and records for options.

`ArgValue` attributes are used to specify the arg switches.

For example:
```f#
open ToolBox.AppEnvironment

//...

type FooOptions = 
    { [<ArgValue("-n", "--name")>]
      Name: string }
      
type BarOptions = 
    { [<ArgValue("-n", "--name")>]
      Name: string }
      
type Command =
    | Foo of FooOptions
    | Bar of BarOptions

// Accepted args:
//  * [name] foo -n ""
//  * [name] bar -n ""
match ArgParser.tryGetOptions<Command> (Environment.GetCommandLineArgs() |> List.ofArray) with
| Ok cmd -> 
    // Do something...
    printfn "Ok"
| Error e -> printfn $"Error: {e}"
```