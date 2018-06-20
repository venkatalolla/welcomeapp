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
        WriteLine("<html><body><div>");
        WriteLine(GetBot(reversedString));
        WriteLine("Date: " + DateTime.Now);
        WriteLine("**Environment**");
        WriteLine($"Platform: .NET Core 2.0");
        WriteLine($"OS: {RuntimeInformation.OSDescription}");
        WriteLine();
        WriteLine("<div></body></html>");
  }

  public static string GetBot(string message) 
  {
          string bot = $"\n        {message}";
          bot += @"
    __________________
                      \
                       \
                          ....
                          ....'
                           ....
                        ..........
                    .............'..'..
                 ................'..'.....
               .......'..........'..'..'....
              ........'..........'..'..'.....
             .'....'..'..........'..'.......'.
             .'..................'...   ......
             .  ......'.........         .....
             .                           ......
            ..    .            ..        ......
           ....       .                 .......
           ......  .......          ............
            ................  ......................
            ........................'................
           ......................'..'......    .......
        .........................'..'.....       .......
     ........    ..'.............'..'....      ..........
   ..'..'...      ...............'.......      ..........
  ...'......     ...... ..........  ......         .......
 ...........   .......              ........        ......
.......        '...'.'.              '.'.'.'         ....
.......       .....'..               ..'.....
   ..       ..........               ..'........
          ............               ..............
         .............               '..............
        ...........'..              .'.'............
       ...............              .'.'.............
      .............'..               ..'..'...........
      ...............                 .'..............
       .........                        ..............
        .....

";
  return bot;
  }
}
