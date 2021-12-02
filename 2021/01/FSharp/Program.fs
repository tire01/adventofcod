open System.IO;
open System;
open System.Net

// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
let readData path : string[] = File.ReadAllLines(path);

let converToInt (value : string) : int = Convert.ToInt32(value)

let oneIfGreater (pair : (int * int)) : int = match pair with a,b when a > b -> 1 | _ -> 0

let windowAvg (tuple : (int * int * int)) : int = match tuple with a,b,c -> (a + b + c) / 3 

let window (source : int[]) : seq<int * int * int> =
   
    

    

[<EntryPoint>]
let main argv = 

    let data = readData(@".\Data.txt") |> Array.map converToInt 

    

   // printf $"{result}"
    0 // return an integer exit code

   