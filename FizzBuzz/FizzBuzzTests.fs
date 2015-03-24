module FizzBuzz

open Xunit
open Xunit.Extensions
open Swensen.Unquote

module FizzBuzz =
    let transform number = 
        match number % 3 with 
        | 0 -> "Fizz"
        | _ -> string number

module Tests =

    [<Theory>]
    [<InlineData(4)>]
    [<InlineData(1)>]
    [<InlineData(1000003)>]
    let ``FizzBuzz.transform returns the number`` (number : int) = 
        let actual = FizzBuzz.transform number
        let expected = string number
        test <@ expected = actual @>
    
    [<Theory>]
    [<InlineData(3)>]
    [<InlineData(9)>]
    [<InlineData(12)>]
    let ``FizzBuzz.transform returns Fizz`` (number : int) = 
        let actual = FizzBuzz.transform number
        let expected = "Fizz"
        test <@ expected = actual @>

