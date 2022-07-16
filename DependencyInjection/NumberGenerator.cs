namespace DependencyInjection;

public class NumberGenerator: INumberGenerator
{
    public int GetRandomNumber()
    {
        return new Random().Next(1000);
    }
    
  
}
public interface INumberGenerator
{
    public int GetRandomNumber();
}