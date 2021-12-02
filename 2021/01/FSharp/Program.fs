open System.IO;
open System;

// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
let readData path : string[] = File.ReadAllLines(path);

let converToInt (value : string) : int = Convert.ToInt32(value)

let oneIfGreater (pair : (int * int)) : int = match pair with a,b when a > b -> 1 | _ -> 0

[<EntryPoint>]
let main argv =
    let data = readData(@".\Data.txt") |> Array.map converToInt |> Array.toSeq
    let nextValue = data |> Seq.skip 1
    let result = data |> Seq.zip nextValue |> Seq.map oneIfGreater |> Seq.sum

    printf $"{result}"
    0 // return an integer exit code

   