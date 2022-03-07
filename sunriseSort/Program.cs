using static sunriseSort.SunriseSort;

Random rand = new Random();

int[] array = new int[16];

//il contenuto dell'array è generato in maniera random con interi compresi tra 0 e 100 
for (int i = 0; i < array.Length; i++)
    array[i] = rand.Next(0, 100);

Console.WriteLine("Unsorted");
foreach(var num in array){
    Console.Write($"{num} ");
}

Console.WriteLine("\n\nSorted");

Sort(array);

foreach(var num in array){
    Console.Write($"{num} ");
}