(*
---------------------------------------------------------
F# Interactive (FSI) - Building Lists with Computation Expressions
---------------------------------------------------------

This file demonstrates how to use F# computation expressions to build lists in a functional way.
The code is designed to be run in F# Interactive (FSI) and can be evaluated interactively.
The code uses a custom computation expression builder called `MyList` to create lists in a more readable and functional style.

This file contains F# code that can be evaluated interactively using F# Interactive (FSI).

To evaluate the code, select the desired portion of the code and press

- `Alt + Enter` (on Windows) 
- `Option + Enter` (on macOS) 

This will send the selected code to F# Interactive for execution.

You can select portions of the code - even single identifiers - to evaluate them and see their value.
Just play around and explore how F# Interactive works and have Fun :)
---------------------------------------------------------
*)


type MyList() =
    member _.Yield(x) = [x]
    member _.Combine(xs, ys) = List.append xs ys
    
    // ignore that - this is required for more complex use cases
    member _.Delay(f) = f()

let myList = MyList()


/ --------------------------------------------------------------------
// Example: Using the MyList type to create a list of integers
// This will create a list of integers [1; 2; 3; 4]
// The result is a list of integers
/ --------------------------------------------------------------------


// val it : int list = [1; 2; 3; 4]
myList {
    yield 1
    yield 2
    yield 3
    yield 4
}


// `yield`is implied and can be omitted
myList {
    1
    2
    3
    4
}


// We use `;` to separate the elements
// Why? Because `,` is used to denote a tuple!
myList { 1; 2; 3; 4 }


// ... we have successfully created a list comprehension `myList { ... }`
// that works like the built-in list comprehension `[ ... ]`
[ 1; 2; 3; 4 ]
