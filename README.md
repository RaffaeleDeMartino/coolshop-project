# coolshop-project

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

The following repository contains a command-line script that given a .csv filename, column index and filter-key, returns the matching row (if present).

## Requirements
The project is a command-line executable script that only requires the installation of [.NET 7](https://dotnet.microsoft.com/en-us/download) on your local machine.

## Installation
In order to download this repository, execute this command:
```
git clone git@github.com:RaffaeleDeMartino/coolshop-project.git

```
## Running the script
In order to execute the script, run the following commands:
```
cd CoolshopProject
dotnet run Program.cs <filename> <column-index> <filter-key>

```
The script was tested on a simple .csv [file](https://github.com/RaffaeleDeMartino/coolshop-project/blob/main/CoolshopProject/dati.csv);
still, it can be tested on any .csv file stored on your local system.

## Arguments validation
The Arguments are validated by:
* Number of arguments 
* Existence of the .csv file
* Type of the Column argument and its impossible case ( column index < 0 )
* Integrity of the .csv file ( In case of different numbers of column within the file's rows )

## Example of successful runs
```
# Execution example for filtering on the first column with value 1
dotnet run Program.cs dati.csv 0 1

# Execution example for filtering on the second column with value "Gialli"
dotnet run Program.cs dati.csv 1 Gialli

# Execution example for filtering on the third column with value "Alessandro"
dotnet run Program.cs dati.csv 2 Alessandro

# Execution example for filtering on the fourth column with value "03/08/1987"
dotnet run Program.cs dati.csv 3 03/08/1987

```

## Example of managed, not successful runs
```
# Execution example in which the number of arguments is incorrect
dotnet run Program.cs dati.csv 0 

# Execution example in which the file is not found 
dotnet run Program.cs da.csv 1 Gialli

# Execution example in which the column index is out of range
dotnet run Program.cs dati.csv 5 Alessandro

# Execution example in which the column index is not an integer
dotnet run Program.cs dati.csv Verdi 03/08/1987

```
