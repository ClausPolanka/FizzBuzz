module FizzBuzz

open Xunit
open Xunit.Extensions
open Swensen.Unquote

module FizzBuzz =
    let transform number = ""

module Tests =
    [<Theory>]
    [<InlineData(4)>]
    let ``FizzBuzz.transform returns the number`` (number : int) = 
        let actual = FizzBuzz.transform number
        let expected = string number
        test <@ expected = actual @>

