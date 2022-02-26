namespace ToolBox.Core

[<RequireQualifiedAccess>]
module Json =
    
    open System.Text.Json
    
    let deserialize<'T> (json: string) = attempt (fun _ -> JsonSerializer.Deserialize<'T>(json))
       
    let serialize<'T> (value: 'T) = attempt (fun _ -> JsonSerializer.Serialize<'T>(value) |> Ok)

