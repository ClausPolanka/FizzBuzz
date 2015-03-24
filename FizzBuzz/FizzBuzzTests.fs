﻿module FizzBuzz

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
    
    [<Theory>]
    [<InlineData(5)>]
    [<InlineData(10)>]
    [<InlineData(20)>]
    let ``FizzBuzz.transform returns Buzz`` (number : int) = 
        let actual = FizzBuzz.transform number
        let expected = "Buzz"
        test <@ expected = actual @>
    
    [<Theory>]
    [<InlineData(15)>]
    [<InlineData(30)>]
    [<InlineData(1000000005)>]
    let ``FizzBuzz.transform returns FizzBuzz`` (number : int) = 
        let actual = FizzBuzz.transform number
        let expected = "FizzBuzz"
        test <@ expected = actual @>

