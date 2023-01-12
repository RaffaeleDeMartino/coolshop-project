void checkArguments(string[] args)
{
    if(args.Length != 4){
        throw new Exception("Arguments must be 3.");
    }

    if(!File.Exists(args[1])){
        throw new FileNotFoundException($"File {args[1]} cannot be found.");
    }

    try{
        int columnIndex = Int32.Parse(args[2]);

        if (columnIndex < 0){
            throw new ArgumentOutOfRangeException("Index of column to be filtered must be greater or equal than 0.");
        }
    }
    catch (FormatException){
        throw new FormatException($"Second parameter must be Integer. Provided parameter {args[2]} cannot be parsed as Integer.");
    }
}

string[] getRowValues(string line) => line.Replace(";","").Split(',');

string getSearchedRow(string filename, int columnIndex, string value){

    int numberOfColumns = 0;

    foreach(var line in File.ReadLines(filename))
    {
        var values = getRowValues(line);

        if(numberOfColumns == 0){
            numberOfColumns = values.Length;
            
            if (numberOfColumns < columnIndex){
                throw new ArgumentOutOfRangeException(@$"Index of column to be filtered is outside the range
                    (Number of columns: {numberOfColumns}; column index {columnIndex}).");
            }
        }
        
        if (values.Length != numberOfColumns)
            throw new Exception($"Provided .csv file is corrupted (found {values.Length} columns, expected {numberOfColumns}).");

        if(values[columnIndex] == value){
            return line;        
        }
    }

    return "";
}

checkArguments(args);

string filename = args[1];
int columnIndex = Int32.Parse(args[2]);
string value = args[3];       

var result = getSearchedRow(filename, columnIndex, value);

if (result == "")
    Console.WriteLine("No line matches ...");
else 
    Console.WriteLine(result);
