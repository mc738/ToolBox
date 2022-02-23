namespace ToolBox.Core

open System
open System.IO
open System.Xml.Linq

module Xml =

    open System.Xml.Linq

    let xName (name: string) = XName.op_Implicit name

    let tryGetElement (name: string) (parent: XElement) =
        parent.Element name
        |> fun r ->
            match r <> null with
            | true -> Some r
            | false -> None

    let getElements (name: string) (parent: XElement) = parent.Elements name |> List.ofSeq

    let setValue (element: XElement) (value: string) = element.Value <- value

    let tryGetAttribute (name: string) (element: XElement) =
        element.Attribute name
        |> fun r ->
            match r <> null with
            | true -> Some r
            | false -> None

    let tryGetAttributeValue (name: string) (element: XElement) =
        tryGetAttribute "id" element
        |> Option.bind (fun att -> Some att.Value)

    let tryGetGuidAttributeValue (name: string) (element: XElement) =
        tryGetAttributeValue name element
        |> Option.bind
            (fun v ->
                match Guid.TryParse v with
                | true, r -> Some r
                | false, _ -> None)
            
    let tryGetDateTimeAttributeValue (name: string) (element: XElement) =
        tryGetAttributeValue name element
        |> Option.bind
            (fun v ->
                match DateTime.TryParse v with
                | true, r -> Some r
                | false, _ -> None)


    let parse (xml: string) =
        try
            XDocument.Parse xml |> Ok
        with
        | exn ->
            Error
                { Message = exn.Message
                  Exception = Some exn }

    let save (path: string) (xDoc: XDocument) = xDoc.Save(path)
