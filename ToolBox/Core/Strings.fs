namespace ToolBox.Core

open System


module Strings =

    open System.Text

    type String with

        member str.ToSnakeCase() =
            str
            |> List.ofSeq
            |> List.fold
                (fun (acc, i) c ->
                    let newAcc =
                        match Char.IsUpper c, i = 0 with
                        | false, _ -> acc @ [ c ]
                        | true, true -> acc @ [ Char.ToLower(c) ]
                        | true, false -> acc @ [ '_'; Char.ToLower(c) ]

                    (newAcc, i + 1))
                ([], 0)
            |> (fun (chars, _) -> String(chars |> Array.ofList))

        member str.ToPascalCase() =
            let isMatch c = [ '_'; '-'; ' ' ] |> List.contains c

            str
            |> List.ofSeq
            |> List.fold
                (fun (acc, i) c ->
                    let newAcc =
                        //match c =
                        match i - 1 >= 0 && isMatch str.[i - 1], i = 0, isMatch c with
                        | true, _, false -> acc @ [ Char.ToUpper c ]
                        | true, _, true -> acc
                        | false, false, false -> acc @ [ c ]
                        | false, true, _ -> acc @ [ Char.ToUpper c ]
                        | false, false, true -> acc

                    //match Char.IsUpper c, i = 0 with
                    //| false, _ -> acc @ [ c ]
                    //| true, true -> acc @ [ Char.ToLower(c) ]
                    //| true, false -> acc @ [ '_'; Char.ToLower(c) ]
                    (newAcc, i + 1))
                ([], 0)
            |> (fun (chars, _) -> String(chars |> Array.ofList))

        member str.ToCamelCase() =
            let isMatch c = [ '_'; '-'; ' ' ] |> List.contains c

            str
            |> List.ofSeq
            |> List.fold
                (fun (acc, i) c ->
                    let newAcc =
                        //match c =
                        match i - 1 >= 0 && isMatch str.[i - 1], i = 0, isMatch c with
                        | true, _, false -> acc @ [ Char.ToUpper c ]
                        | true, _, true -> acc
                        | false, false, false -> acc @ [ c ]
                        | false, true, _ -> acc @ [ Char.ToUpper c ]
                        | false, false, true -> acc

                    //match Char.IsUpper c, i = 0 with
                    //| false, _ -> acc @ [ c ]
                    //| true, true -> acc @ [ Char.ToLower(c) ]
                    //| true, false -> acc @ [ '_'; Char.ToLower(c) ]
                    (newAcc, i + 1))
                ([], 0)
            |> (fun (chars, _) ->
                match chars.Length > 0 with
                | true -> String([ Char.ToLower chars.Head ] @ chars.Tail |> Array.ofList)
                | false -> "")

    let bytesToHex (bytes: byte array) =
        bytes
        |> Array.fold (fun (sb: StringBuilder) b -> sb.AppendFormat("{0:x2}", b)) (StringBuilder(bytes.Length * 2))
        |> fun sb -> sb.ToString()

    let equalOrdinal a b =
        String.Equals(a, b, StringComparison.Ordinal)

    let equalOrdinalIgnoreCase a b =
        String.Equals(a, b, StringComparison.OrdinalIgnoreCase)
