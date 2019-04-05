# open
dotnet core tool for opening files using default program

# usages

Syntax: `open [<extension>] [-e] [-a] [-f <file>]`

* `open sln` - to open all .sln files in current directory
* `open -f test.txt` - open `test.txt` file with default program
* `open -f mysolution.sln -e` - edit `mysolution.sln` file with default program
* `open -aef mysolution.sln` - open in edit mode the `mysolution.sln` as administrator

# options

* `-e` - open in edit mode
* `-a` - open as administrator
* `-f <file>` - specify file to open

For combined usage of `-e` and `-a` options, the default program for `.txt` files will be used.