using static System.Math;
namespace TeleprompterConsole;

internal class TelePrompterConfig
{
    public int DelayInMilliseconds { get; private set; } = 200;
    /// <summary> 
    /// Used to change the speed at which the teleprompter moves
    /// </summary>
    /// <param name="increment">
    /// Positive number for slower speeds Negative for faster speeds
    /// </param> 
    public void UpdateDelay(int increment) 
    {
        var newDelay = Min(DelayInMilliseconds + increment, 1000);
        newDelay = Max(newDelay, 20);
        DelayInMilliseconds = newDelay;
    }


    public bool Done { get; private set; }

    /// <summary> 
    /// Sets the Done variable to true
    /// </summary>
    public void SetDone()
    {
        Done = true;
    }
}
