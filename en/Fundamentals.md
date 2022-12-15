## Fundamentals

### In preparation for take off

These guides are oriented to those progammers interested in learning some concepts on functional programming, from a practical perspective. F\# is an excelent _first_ functional programming language: it is functional (of course), it has a clean and readable syntax (not a lot of fancy symbols and stuff), it is flexible (in case you need to grasp some other paradigm in the middle of your code) and it is concise enough to express your ideas with clarity. 

Learning a new language _and_ a new programming paradigm is a wonderful adventure. You do not need any special preparation, although I assume that the reader has some background in at least one popular language (let us say C, Python, Java or JavaScript, for example). Hope you enjoy your journey as much as I did when I started with F\# a few years ago. Rembember to code and make mistakes, for there is where the learning transforms. 

F\#, as every other computer language, has it own syntax and peculiarities that one needs to understand. But learning the functional paradigm requires to set aside a few concepts that one is very fond of and uses in everyday coding in imperative or object oriented languages. 

> This difference has profound roots at the very origin of computing science.
> In the beginning, there where two mutually equivalent approaches to formal computing, one developed by Alan Turing with his [computing machine](https://londmathsoc.onlinelibrary.wiley.com/doi/epdf/10.1112/plms/s2-42.1.230), while the other one was worked out by Alonzo Church with his [lambda calculus](https://www.jstor.org/stable/2371045?origin=crossref&seq=10#metadata_info_tab_contents). Both approaches evolved in parallel, and gave rise to different branches of programming styles. 
> Functional programming is by no means new. LISP, the first functional programming language appeared in 1958, just a year shy of its 
> imperative counterpart, Fortran.
> 
> In a very loose sense, learning a functional language is like travelling in time, going back through the imperative branch of  programming and taking the other exit in the roundabout.

Even though you do not finally adopt the functional paradigm, adding a new language style to your assets will give you the experience to revisit old programming habits with new eyes, giving a deeper understanding, and more fine tuning to your code. You will become a better programmer, definetly!

F\# is one of the languages provided by the .NET framework (together with C# and Visual Basic). As such, F\# is tighly integrated with all the tools and libraries that .NET provides. In this sense, and __only for pedagogical purposes__, I will view .NET as the set of libraries that one can use to enhance your code. In other words, I will stay away from using them, and focusing in the core features of F\# as a functional language. From Web programming to Machine Learning, from databases to windows, .NET has everything you need to make your programming a better experience, once you know the core features F\# provides. 

> If you are a C# programmer, you will probably get a better mileage going into some of the excellent resources of F\# for C# coders, such as [Get programming with F\#](https://www.manning.com/books/get-programming-with-f-sharp#:~:text=about%20the%20book-,Get%20Programming%20with%20F%23%3A%20A%20guide%20for%20.,of%20functional%20programming%20in%20F%23.) 
See the Resources section for more information.


## Tools

This series is about the fundamentals of F\# programming, and none of the examples need even to install F\#. You can simply code along in your web browser of your choice, heading to the [Fable REPL](https://fable.io/repl/). Just write your code in the left panel, click the usual play button (or Alt+Enter), and there you go, you are programming in F\#!.

You can also install the F\# language and use your everyday editor, see instructions __[here]__. 

Besides, all this series is written as [Jupyter notebooks](https://jupyter.org/). You can grab them at [this github repository](https://github.com/fcolavecchia/fp-course). Instructions on how to set up F\# as a Notebook kernel can be found __[here]__. 

[Visual Studio Code](https://code.visualstudio.com/) has a wonderful extension called [Ionide](https://ionide.io/Editors/Code/overview.html) to work with F\#. I personally use JetBrains Rider for my daily coding.

You can also use F\# with Visual Studio for Windows or MacOS, if you are familiar with that tool. 

Moreover, if you want to code F\# with `vim`, [Ionide gets you covered](https://ionide.io/Editors/Vim/overview.html).



## So what is a function anyway?

Since we are about to learn functional programming, we need to agree in what a _function_ is in this context. Let us start with a set of entities, for example, the cars parked in a given block of a street. One can identify each car by its license plate, and then build a table with two columns: the first one with the license plate, and the second one with the corresponding the color of each car:

| Lic. Plate | Color         | 
| :----------: |:-------------:|
| ABC 124 | black |
| DEF 350 | red   |
| QRZ 441 | black |
| JPG 255 | white | 

That's a function that we can call `carColor`, that associates each car of the block with its color. The table is a representation of that function. A function from a set of entities A to a set of entities B is then a relation that associates elements between the sets A and B, with the property that each and every element of A has a one and only one corresponding element of B. 

There are two things to note. First, a function is defined _from_ one set _to_ another set, in our example, from the set of license plates to the set of colors. To get the color of a particular car, you go to the table representation of the function, look up the plate in the column of license plates, and get the color from the second column. With this in mind, one can identify the _from_ set as the _input_ of the function, while the _to_ set is the _output_. 

Second, all elements of the input must relate to some element in the output set. In our example, every car in the block has a color assigned in the table. This means that there cannot be empty cells in the second column of our table. 

> ❓ Can you come up with more examples of functions in the real world? 

In math, functions are ubiquitous. Let us assume that $x$ is an integer, and define the function 
$$
f(x) = x + 1 , 
$$
that is, the function that returns the value $x$ plus one. The input set (which is called the _domain_ of the function in math) is the set of all integer values, $\mathbb{Z}$, while the output set (the _codomain_ in math) is also $\mathbb{Z}$. Using the _arrow_ notation, the complete definition of the function would be
$$
f: \mathbb{Z} \rightarrow \mathbb{N} \cup \{0\} / x \mapsto x + 1 
$$
Or in english, $f$ is a function from $\mathbb{Z}$ to $\mathbb{Z}$ such that $f$ of $x$ is $x + 1$.

> 🔔 A slight detour around the codomain. The codomain is the set of entities where the function can possibly map input values. For example, in the case of the color of the cars, the codomain is simply all the possible colors. In many cases that information is too general, and it is convenient to define the _range_ of the function, which is the set of actual values of outputs the function maps inputs into. The _range_ in the cars example is the set {black, red, white}.

### Multiple inputs and outputs

Let us take the example of a vending machine. In a vending machine, products are arranged in shelves, where each shelf is named by a letter. In each shelf, the products are aligned and identified by a number. Then, in A1 you have a bag of chips, in A2 a chocolate, in B1 a soda, and so on. The machine also has a keyboard with letters and numbers for you to choose the product. To buy something, you need to give the machine some money (coins, bills, credit card, etc), select the product by clicking the letter and the number on the keyboard. The machine returns the product and some cashback, if any. 
The inputs of our `vendingMachine` function are the money, the letter and the number you selected, and the outputs are the product and 
the cashback (if any). 

An example from math could be a translation function, where given a point with coordinates $x$ and $y$ in the plane, it returns a point with coordinates $x+1$ and $y+1$.  

> 

### Composition 
 


The example of the friends, names, and initials.



Binding functions

Functions with many arguments





### `let` the fun begin 

Any code you write will need data. 

Any code you write will do _something_ with that data. 

So the first step in a new language is to learn how to define a way to hold your data, and how to transform it along the prgram. The former concept usually translates into _variables_ and while the latter one into _routines_, (or any other name, such as procedures, or functions, depending your programming scope). In this way, one uses routines to change the variables, or create other ones, from an order to buy something in a website, to the color of a pixel in your game of preference. 

But let us go back and start with _expressions_. An expression is an ordered set of symbols that may represent different entities in the code. Pretty much like a sentence in a human language, an expression has to have a valid syntax (nobody will understand me if I use the. period wrong.) and also has to be meaningful (I a example for if me nobody of sentence sort the understand will words). The compiler, however, is much more strict with the rules and does not allow such poems. Why? Because the compiler needs to grab the expression, process it and obtain a _value_. So the value is the result of the evaluation of an expression. 

And since every expression results in a value, one needs to manage all these values that will be appearing as the code runs, identify and use them as one sees fit. To that end, F\# uses several _keywords_, and one of them is the `let`. 

In F\# one says that `let` _binds_ an expression to an identifier. For example


```F#
// My first line in F# 
let a = 1 
```

binds the literal expression `1` to the name `a`. On the right hand side of the `=` symbol (that acts here as a binding operator), one can have any valid expression:

```F#
let a = 1 + 3
let s = "this is a string" 
let l = [1 ; 2 ; 3] // A list of integers 
```

and so on. Of course one can associate a previous binding with a new one through an expression:

```F#
let b = a + 4 
```

    8


In the line above, we add four to `a` and bind the result of this expression to the `b` identifier. 

### Inmutability

However, you cannot bind an expression to an identifier that has already been used:

```F#
let q = 3
let q = q + 1
```


    input.fsx (2,5)-(2,6) typecheck error Duplicate definition of value 'q'


which answers why one does not use _variables_ in F\#: once the value of an expression is obtained, it cannot be changed. In other words, all the values are _immutable_: once there, they cannot be changed. There are no variables in the language, because there is nothing to _vary_. You can create as many values as you want, but you cannot change them: 


```F#
let q = 3
let qq = q + 1
```

> ❗️ There are some cases where one can use the same identifier, see this 

The implications of this are deep and it is very important to let the concept mature and sink in, because it percolates all the code in F\# (and any other functional language). In some way, since everything is an expression, coding in F\# is mananging the expressions that solve our problem. You name an expression (that is, you bind it to an identifier), use it in another expression, bind its value to a new identifier and so on an so on.

The perspective of a code as a long list of `let` bindings is kind of daunting. That is where functions come in.

### Resources









>> [A nice thread on reusability of binding names](https://github.com/dotnet/fsharp/issues/9900).







```F#
let demo () = 
    let x = 7  
    let x = x + 3
    printfn "The x is %d" x
```

```F#
demo()
```

    The x is 10





<null>





```F#
let x4 = for i in [1..10]
          do printf "%i" i
```

    12345678910

```F#
let c = "nobody will understand me I a example for if of sentence sort the words"
let q = c.Split(' ')
Array.sort q 
|> String.concat " "
```


    I a example for if me nobody of sentence sort the understand will words


```F#
let p = 5
```

```F#
printfn "%A" p 
```

    5


```F#
let p = 6
printfn "%A" p 
```

    6


### Functions everywhere

Looks like one can reuse the binding name in different cells, provided one runs in the current order. Same value on one cell are not allowed, though.

```F#
let foo (a:string) b =
    a + b
   
```

```F#
let d = foo "John " "Doe"
let d = foo 2 3 
```


    input.fsx (2,13)-(2,14) typecheck error This expression was expected to have type


        'string'    


    but here has type


        'int'    


    input.fsx (2,15)-(2,16) typecheck error This expression was expected to have type


        'string'    


    but here has type


        'int'    


```F#
let foo (a:int) b =
    a + b
```

```F#
let d = foo 2 3 
```

```F#
let next x = 
    x + 1 
```

### Types

#### Product type: Records

#### Sum type: Discriminated unions



### To be or not to be, that is the option 

### On Lists

```F#
let indexOfAny (text: string) (charList: char list) = 
    let textList = Seq.toList text 
    let found = charList
                    |> List.map (fun c -> List.tryFindIndex (fun t -> t = c) textList )
                    |> List.choose id 
    match found with
    | [] -> -1     
    | _ -> List.min found 
```

[A nice discussion on indexing pairing al list with indexes](https://stackoverflow.com/questions/71074342/pairing-list-elements-with-indexes)






```F#
let myIndexed (xs: list<'a>) = 
    ([0..(xs.Length - 1)], xs)
        ||> List.map2 (fun i t -> (i,t))  // This is List.zip
```

```F#
let indexOfAny2 (text: string) (charList: char list) = 

    // let textList = ([0..text.Length-1], Seq.toList text)
    //                 ||> List.map2 (fun i t -> (i,t))

    let textList = List.indexed (Seq.toList text)

    let found = [ for (i,t) in textList do 
                    for c in charList do 
                        if (c = t) then yield i 
                    ]
    
    match found with
    | [] -> -1     
    | _ -> List.min found 
```

```F#
let a = 0 
```

```F#
indexOfAny "zzabyycdxx" ['z';'a'] |> printfn "%A"
indexOfAny "zzabyycdxx" ['b';'y'] |> printfn "%A"
indexOfAny "aba" ['z'] |> printfn "%A"      

```

    0
    3
    -1


```F#
#!js
// Function to compute the product of p1 and p2
function foo_js(a, b) {
  return a + b;
}

// Sum 
c = foo_js(3,2);
console.log('c is:'+c);

// Concat
c = foo_js("John ","Doe")
console.log("or maybe is: "+c);

// Or something else
c = foo_js(true,true)
console.log("or maybe is: "+c)

// or something weirder 
c = foo_js(true,4)
console.log("or maybe is: "+c)



```


    c is:5



    c is:5



    or maybe is: John Doe



    or maybe is: John Doe



    or maybe is: 1



    or maybe is: 1



    or maybe is: 5



    or maybe is: 5


```F#
indexOfAny2 "zzabyycdxx" ['z';'a'] |> printfn "%A"
indexOfAny2 "zzabyycdxx" ['b';'y'] |> printfn "%A"
indexOfAny2 "aba" ['z'] |> printfn "%A"      

```

    0
    3
    -1

