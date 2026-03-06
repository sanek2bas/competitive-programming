namespace Payments.Checker;

public interface IUserLimitsService
{
    UserLimits GetUserLimits(int userId);
}