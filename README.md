# pencil
C# solution to the pencil durability kata

## Initial setup
I'm not using Rider or VSCode, so I did the dotnet steps by hand to set up the project.
```
mkdir pencil
cd pencil
git init
dotnet new sln
mkdir Pencil
cd Pencil
dotnet new console
cd ..
dotnet sln add Pencil
mkdir PencilTest
cd PencilTest
dotnet new nunit
cd ..
dotnet sln add PencilTest
```