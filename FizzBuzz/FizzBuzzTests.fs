module FizzBuzz

open Xunit
open Xunit.Extensions
open Swensen.Unquote

module FizzBuzz =
    let transform number = 
        match number with
        | 4 -> "4"
        | _ -> "1"

module Tests =
    [<Theory>]
    [<InlineData(4)>]
    [<InlineData(1)>]
    [<InlineData(1000003)>]
    let ``FizzBuzz.transform returns the number`` (number : int) = 
        let actual = FizzBuzz.transform number
        let expected = string number
        test <@ expected = actual @>

