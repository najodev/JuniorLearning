using classes;

/// <summary> 
/// Creates a new WorkItem called item
/// </summary>
WorkItem item = new WorkItem("Fix Bugs", "Fix all bugs in my git pull request", new TimeSpan(3, 4, 0, 0));

/// <summary> 
/// create a new change request called change 
/// </summary>
ChangeRequest change = new ChangeRequest("Change Base Class Design", "Add members to the class", new TimeSpan(4, 0, 0), 1);

Console.WriteLine(item.ToString());

change.Update("Change the Design of the base class", new TimeSpan(4, 0, 0));

Console.WriteLine(change.ToString());

