using DelegatesEvents;

#region Events & Delegates
Console.WriteLine("######### Delegates and Events ######### ");
Console.WriteLine();
var figura = new GeometricFigure()
{
    Height = 10,
    Width = 10,
    Depth = 10
};

figura.Calculate += CalculateSquareArea;
figura.Calculate += CalculateVolumeCube;
figura.EventHandler();

static void CalculateSquareArea(double height, double width, double depth)
{
    var area = height * width;
    Console.WriteLine("Event triggered from the client class, square area calculation");
    Console.WriteLine(area);
}

static void CalculateVolumeCube(double height, double width, double depth)
{
    var volume = height * width * depth;
    Console.WriteLine("Event triggered from the client class, volume of cube calculation");
    Console.WriteLine(volume);
}
#endregion

#region Func, Action & Predicate
Console.WriteLine("######### Func, Action & Predicate ######### ");
Console.WriteLine();
var moreTypesList = new MoreTypesDelegates();

//multicast delegate -> more than one delegates
moreTypesList.Notify += Notify;
moreTypesList.Notify += NotifyAgain;
moreTypesList.Add("A");
moreTypesList.Add("B");
moreTypesList.Add("C");

Action<MoreTypesDelegates> action = new Action<MoreTypesDelegates>(i => Console.WriteLine("Action: " + i));
Func<MoreTypesDelegates, bool> func = new Func<MoreTypesDelegates, bool>(i => i.Id == 1);
Predicate<MoreTypesDelegates> pred = new Predicate<MoreTypesDelegates>(i => i.Id == 3);
Console.WriteLine();
moreTypesList.PrintAllItems(action);
Console.WriteLine();
var f = moreTypesList.GetItemById(func);
Console.WriteLine("Func: " + f);
Console.WriteLine();
var exist = moreTypesList.ExistItem(pred);
Console.WriteLine("Predicate: " + exist);
Console.WriteLine();
static void Notify()
{
    Console.WriteLine($"I've been notified");
}

static void NotifyAgain()
{
    Console.WriteLine($"I was notified again");
}
#endregion