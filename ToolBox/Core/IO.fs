﻿namespace ToolBox.Core

open System
open System.IO

[<RequireQualifiedAccess>]
module FileIO =
    
    let writeBytes (path: string) (bytes: byte array) =
        try 
            File.WriteAllBytes(path, bytes) |> Ok
        with
        | exn -> Error exn.Message
    
    let readBytes (path: string) =
        try
            File.ReadAllBytes(path) |> Ok
        with
        | exn -> Error exn.Message


module ConsoleIO =
    
    
    let cprintfn (color: ConsoleColor) message =
        Console.ForegroundColor <- color
        printfn $"{message}"
        Console.ResetColor()
        
        
    let printSuccess message = cprintfn ConsoleColor.Green message
    
    let printError message = cprintfn ConsoleColor.Red message
    
    let printWarning message = cprintfn ConsoleColor.DarkYellow message
    
    let printDebug message = cprintfn ConsoleColor.DarkMagenta message 