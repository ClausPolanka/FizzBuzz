module FizzBuzz

open Xunit
open Xunit.Extensions
open Swensen.Unquote

module FizzBuzz =
    let transform number = 
        match number % 3, number % 5 with 
        | 0, 0 -> "FizzBuzz"
        | _, 0 -> "Buzz"
        | 0, _ -> "Fizz"
        | _ -> string number

module Tests =

    open FsCheck
    open FsCheck.Xunit

    [<Property>]
    let ``FizzBuzz.transform returns the number`` (number : int) = 
        (number % 3 <> 0 && number % 5 <> 0) ==> lazy
        let actual = FizzBuzz.transform number
        let expected = string number
        expected = actual
    
    [<Property>]
    let ``FizzBuzz.transform returns Fizz`` (number : int) = 
        (number % 3 = 0 && number % 5 <> 0) ==> lazy
        let actual = FizzBuzz.transform number
        let expected = "Fizz"
        expected = actual
    
    [<Property>]
    let ``FizzBuzz.transform returns Buzz`` (number : int) = 
        (number % 3 <> 0 && number % 5  = 0) ==> lazy
        let actual = FizzBuzz.transform number
        let expected = "Buzz"
        expected = actual
    
    type IntegerDivisibleBy3And5 = 
        static member Int() =
            Arb.Default.Int32()
            |> Arb.mapFilter (fun x -> x * 3 * 5) (fun _ -> true)

    [<Property(Arbitrary = [| typeof<IntegerDivisibleBy3And5> |])>]
    let ``FizzBuzz.transform returns FizzBuzz`` (number : int) = 
        let actual = FizzBuzz.transform number
        let expected = "FizzBuzz"
        expected = actual

