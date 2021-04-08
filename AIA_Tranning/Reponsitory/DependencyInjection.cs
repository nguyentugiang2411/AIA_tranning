using AIA_Tranning.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AIA_Tranning.Reponsitory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services) {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddTransient<ILeaveHistoryRepository, LeaveHistoryRepository>();
            services.AddTransient<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
