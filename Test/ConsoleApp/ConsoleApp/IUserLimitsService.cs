namespace ConsoleApp;

public interface IUserLimitsService
{
    double GetOnceLimit(int userId);
    double GetDayLimit(int userId);
}
