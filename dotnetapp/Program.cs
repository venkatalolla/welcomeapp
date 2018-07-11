using System;
using System.Runtime.InteropServices;
using Utils;
using static System.Console;

public static class Program
{
  public static void Main(string[] args) 
  {
        string message = "Dotnet-bot: Welcome to using .NET Core!";

        if (args.Length > 0) 
        {
          message = String.Join(" ",args);
        }

        var reversedString = $"Reversed string: {ReverseUtil.ReverseString(message)}";
        WriteLine("<html><head><style>body {background-color: #b0e0e6; }</style><head><body><div><pre>");
        WriteLine(GetBot(reversedString));
        WriteLine("Date: " + DateTime.Now);
        WriteLine("**Environment**");
        WriteLine($"Platform: .NET Core 2.0");
        WriteLine($"OS: {RuntimeInformation.OSDescription}");
        WriteLine();
        WriteLine("</pre><div></body></html>");
  }

  public static string GetBot(string message) 
  {
          string bot = $"\n        {message}";
          bot += @"
%%%%%%#####################%%%%%%%%%%%%%%%%%%%%%%%%%&##%%%%%%%###(((((((##############%%%%%%%##(((((((####((((((((((((((((((((((((((#######((((((#############
%%%%%%#####################%%%%%%%%%%%%%%%%%%%%%%%%%&###%%%%%%%###(((((((############%%%%%%%##(((((((#####((((((((((((((((((((((((((#######((((((##############
%%%%%%#####################%%%%%%%%%%%%%%%%%%%%%%%%%&####%%%%%%%###(((((((##########%%%%%%%##(((((((######((((((((((((((((((((((((((#######((((((##############
%%%%%%#####################%%%%%%#########################%%%%%%%###(((((((########%%%%%%%##(((((((#######(((((((##########################((((((##############
%%%%%%#####################%%%%%%##########################%%%%%%%###(((((((######%%%%%%%##(((((((########(((((((##########################((((((##############
%%%%%%#####################%%%%%%###########################%%%%%%%###(((((((###(%%%%%%%##(((((((#########(((((((##########################((((((##############
%%%%%%#####################%%%%%%############################%%%%%%%###((((((##(%%%%%%%##(((((((##########(((((((##########################((((((##############
%%%%%%#####################%%%%%%#############################%%%%%%%###((((##(%%%%%%%##(((((((###########(((((((##########################((((((##############
%%%%%%#####################%%%%%%%%%%%%%%%%%%%%%%##############%%%%%%%%##((##(%%%%%%%##(((((((############(((((((((((((((((((((((##########((((((##############
%%%%%%#####################%%%%%%%%%%%%%%%%%%%%%%###############%%%%%%%(#####%%%%%%%##((((((( ############(((((((((((((((((((((((##########((((((##############
%%%%%%#####################%%%%%%%%%%%%%%%%%%%%%%################%%%%%%%%##%%%%%%%%##((((((( #############(((((((((((((((((((((((##########((((((##############
%%%%%%#####################%%%%%%#################################%%%%%%%%%%%%%%%%##(((((((*##############(((((((##########################((((((##############
%%%%%%#####################%%%%%%##################################%%%%%%%%%%%%%%##((((((((###############(((((((##########################((((((##############
%%%%%%#####################%%%%%%###################################%%%%%%%%%%%%##((((((((################(((((((##########################((((((##############
%%%%%%#####################%%%%%%####################################%%%%%%%%%%##((((((((#################(((((((##########################((((((##############
%%%%%%#####################%%%%%%#####################################%%%%%%%%##((((((((##################(((((((##########################((((((##############
%%%%%%%%%%%%%%%%%%%%#######%%%%%%%%%%%%%%%%%%%%%%%%%&##################%%%%%%##((((((((###################((((((((((((((((((((((((((#######((((((((((((((((((((
%%%%%%%%%%%%%%%%%%%%#######%%%%%%%%%%%%%%%%%%%%%%%%%&###################%%%%##((((((((####################((((((((((((((((((((((((((#######((((((((((((((((((((
%%%%%%%%%%%%%%%%%%%%#######%%%%%%%%%%%%%%%%%%%%%%%%%&####################%%##((((((((#####################((((((((((((((((((((((((((#######((((((((((((((((((((
";
  return bot;
  }
}
