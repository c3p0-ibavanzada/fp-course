#r "nuget: Fli"

open Fli 

let postsFlaDir = "/Users/flavioc/Web/fcolavecchia/_posts/fsharp"
let srcDir = "/Users/flavioc/Documents/Blog/"

let nbConvert file =
    $"jupyter nbconvert --to markdown en/{file} --no-prompt"

let command file = 
    cli {
        Exec (nbConvert file)
        // Arguments "/C echo Hello World!"
    }
    |> Command.toString

printfn "%A" (command "Hola")

    