﻿namespace ToolBox.Core

open System.IO
open System.Security.Cryptography

module Hashing =
    
    open Strings
    
    let generateHash (hasher: SHA256) (bytes: byte array) = hasher.ComputeHash bytes |> bytesToHex
    
    let hashStream (hasher: SHA256) (stream: Stream) =
        stream.Seek(0L, SeekOrigin.Begin) |> ignore
        let hash = hasher.ComputeHash stream |> bytesToHex
        stream.Seek(0L, SeekOrigin.Begin) |> ignore
        hash