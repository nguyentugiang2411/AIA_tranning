using AIA_Tranning.Contracts;
using AIA_Tranning.Service;
using AIA_Tranning.Service.IService;
using Microsoft.Extensions.DependencyInjection;

namespace AIA_Tranning.Reponsitory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services) {
            services.AddScoped<ILeaveTypesService, LeaveTypesService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddTransient<ILeaveHistoryRepository, LeaveHistoryRepository>();
            services.AddTransient<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
