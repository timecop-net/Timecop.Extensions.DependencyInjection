using System;

namespace TCop.Extensions.DependencyInjection;

public class CurrentTimeClock: IClock
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}