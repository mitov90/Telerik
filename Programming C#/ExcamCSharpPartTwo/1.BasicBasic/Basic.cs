using System;
using System.Text;

internal class Basic
{
    private static void Main()
    {
        var lines = new string[10001];
        int maxCommandLineId = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = string.Empty;
        }

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "RUN")
            {
                break;
            }
            string[] lineNumberAndCommand = line.Split(new[] {' '}, 2);
            int lineId = int.Parse(lineNumberAndCommand[0]);
            lines[lineId] = lineNumberAndCommand[1].Trim();
            maxCommandLineId = lineId;
        }

        var executor = new BasicBASICExecutor();
        executor.ExecuteCode(lines, maxCommandLineId);
        Console.Write(executor.GetOutputResult());
    }
}

internal class BasicBASICExecutor
{
    private readonly StringBuilder output;
    private string[] lines;
    private int varV;
    private int varW;
    private int varX;
    private int varY;
    private int varZ;

    public BasicBASICExecutor()
    {
        this.output = new StringBuilder();
        this.lines = new string[0];
    }

    private int FindNextCommandId(int currentLine, int maxCommandLineId)
    {
        for (int i = currentLine + 1; i <= maxCommandLineId; i++)
        {
            if (!string.IsNullOrWhiteSpace(this.lines[i]))
            {
                return i;
            }
        }
        return int.MaxValue; // Indicates the end of all commands
    }

    private int GetValue(string expression)
    {
        switch (expression.Trim())
        {
            case "":
                return 0;
            case "V":
                return this.varV;
            case "W":
                return this.varW;
            case "X":
                return this.varX;
            case "Y":
                return this.varY;
            case "Z":
                return this.varZ;
            default:
                return int.Parse(expression);
        }
    }

    public void ExecuteCode(string[] lines, int maxCommandLineId)
    {
        this.lines = lines;
        int currentCommandId = this.FindNextCommandId(-1, maxCommandLineId);

        while (currentCommandId != int.MaxValue)
        {
            string command = lines[currentCommandId]; // Get the current command

            if (command[0] == 'I') // IF
            {
                string[] conditionAndCommand = command.Substring(2).Split(new[] {"THEN"}, StringSplitOptions.None);
                string condition = conditionAndCommand[0].Replace(" ", "");
                if (condition.Contains("="))
                {
                    string[] values = condition.Split('=');
                    if (!(this.GetValue(values[0]) == this.GetValue(values[1])))
                    {
                        currentCommandId = this.FindNextCommandId(currentCommandId, maxCommandLineId);
                        continue;
                    }
                }
                else if (condition.Contains(">"))
                {
                    string[] values = condition.Split('>');
                    if (!(this.GetValue(values[0]) > this.GetValue(values[1])))
                    {
                        currentCommandId = this.FindNextCommandId(currentCommandId, maxCommandLineId);
                        continue;
                    }
                }
                else if (condition.Contains("<"))
                {
                    string[] values = condition.Split('<');
                    if (!(this.GetValue(values[0]) < this.GetValue(values[1])))
                    {
                        currentCommandId = this.FindNextCommandId(currentCommandId, maxCommandLineId);
                        continue;
                    }
                }
                command = conditionAndCommand[1].Trim();
            }

            if (command[0] == 'S') // STOP
            {
                break;
            }
            if (command[0] == 'C') // CLS
            {
                this.output.Clear();
            }
            else if (command[0] == 'P') // PRINT
            {
                string variable = command.Substring(5).Trim();
                this.output.AppendLine(this.GetValue(variable).ToString());
            }
            else if (command[0] == 'G') // GOTO
            {
                string lineIdAsString = command.Substring(4).Trim();
                currentCommandId = int.Parse(lineIdAsString);
                continue;
            }
            else if (command.Contains("="))
            {
                string[] variableAndExpression = command.Split('=');
                string variable = variableAndExpression[0].Trim();
                string expression = variableAndExpression[1].Trim();
                int value = 0;
                if (expression.Contains("+"))
                {
                    string[] expressionParts = expression.Split('+');
                    value = this.GetValue(expressionParts[0]) + this.GetValue(expressionParts[1]);
                }
                else if (expression.Contains("-"))
                {
                    string[] expressionParts = expression.Split('-');
                    value = this.GetValue(expressionParts[0]) - this.GetValue(expressionParts[1]);
                }
                else
                {
                    value = this.GetValue(expression);
                }
                switch (variable)
                {
                    case "V":
                        this.varV = value;
                        break;
                    case "W":
                        this.varW = value;
                        break;
                    case "X":
                        this.varX = value;
                        break;
                    case "Y":
                        this.varY = value;
                        break;
                    case "Z":
                        this.varZ = value;
                        break;
                    default:
                        break;
                }
            }

            currentCommandId = this.FindNextCommandId(currentCommandId, maxCommandLineId);
        }
    }

    public string GetOutputResult()
    {
        return this.output.ToString();
    }
}
