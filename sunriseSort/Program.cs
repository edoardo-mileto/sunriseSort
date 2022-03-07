using Spectre.Console;
using static sunriseSort.SunriseSort;

AnsiConsole.Write(
    new FigletText("Sunrise sort")
        .Centered()
        .Color(Color.Yellow));

string[] controllore =
{
    "[maroon on maroon]11[/]",
    "[green on green]11[/]",
    "[olive on olive]11[/]",
    "[navy on navy]11[/]",
    "[purple on purple]11[/]",
    "[teal on teal]11[/]",
    "[silver on silver]11[/]",
    "[red on red]11[/]",
    "[lime on lime]11[/]",
    "[yellow on yellow]11[/]",
    "[blue on blue]11[/]",
    "[fuchsia on fuchsia]11[/]",
    "[aqua on aqua]11[/]",
    "[white on white]11[/]",
    "[darkturquoise on darkturquoise]11[/]",
    "[hotpink on hotpink]11[/]",
};


(int, string)[] tuplesArray = new (int, string)[16];
Random rd = new Random();

for (int i = 0; i < 16; i++)
{
    tuplesArray[i].Item1 = rd.Next(0, 100);
    tuplesArray[i].Item2 = controllore[i];
}

var numbers = tuplesArray.Select(x => x.Item1).ToArray();

string[] result = numbers.Select(x => x.ToString()).ToArray();


var table = new Table().Centered();

AnsiConsole.Live(table)
    .Start(ctx =>
    {
        table.Title("[Red bold] Unsorted [/]");
        for (int i = 0; i < 16; i++)
        {
            table.AddColumn(new TableColumn(new Markup($"{tuplesArray[i].Item2}")));
            table.Columns[i].Width(2);
            ctx.Refresh();
            Thread.Sleep(100);
        }

        table.AddRow(result);
    });

Sort(tuplesArray);

var numbersSorted = tuplesArray.Select(x => x.Item1).ToArray();

string[] resultSorted = numbersSorted.Select(x => x.ToString()).ToArray();


var tableSorted = new Table().Centered();

AnsiConsole.Live(tableSorted)
    .Start(ctx =>
    {
        tableSorted.Title("[Green bold] Sorted [/]");
        for (int i = 0; i < 16; i++)
        {
            tableSorted.AddColumn(new TableColumn(new Markup($"{tuplesArray[i].Item2}")));
            tableSorted.Columns[i].Width(2);
            ctx.Refresh();
            Thread.Sleep(100);
        }

        tableSorted.AddRow(resultSorted);
    });