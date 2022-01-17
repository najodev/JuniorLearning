using System.Reflection;

using System.Runtime.CompilerServices;
using System;  
using System.Collections.Generic;  
using System.ComponentModel;  
using System.Drawing;  
using System.Runtime.CompilerServices;  


[Obsolete]
public class MyClass
{

}

[Obsolete("ThisClass is obsolete. Use ThisClass2 instead.")]
public class ThisClass
{
}

public class MySpecialAttribute : Attribute
{

}

[MySpecial]
public class SomeOtherClass
{
}


public class GotchaAttribute : Attribute
{
    public GotchaAttribute(Foo myClass, string str) {
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class MyAttributeForClassAndStructOnly : Attribute
{
}
class Program
{
    static void Main(string[] args){
        TypeInfo typeInfo = typeof(MyClass).GetTypeInfo();
        Console.WriteLine("The assembly qualified name of MyClass is " + typeInfo.AssemblyQualifiedName);
        var attrs = typeInfo.GetCustomAttributes();
        foreach(var attr in attrs)
            Console.WriteLine("Attribute on MyClass: " + attr.GetType().Name);
    }
}
public class Foo
{
    public Foo()
    { }
}

public class MyUIClass : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _name;
    public string Name
    {
        get { return _name;}
        set
        {
            if (value != _name)
            {
                _name = value;
                RaisePropertyChanged();   // notice that "Name" is not needed here explicitly
            }
        }
    }
}
