using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using One.Core.Api;
using One.Mobile.Api.Clients;
using One.Module.Checklists;
using One.Module.Deviations;
using One.Module.FormAnswers;
using One.Module.FormQuestions;
using One.Module.Forms;
using One.Module.OrganizationInvites;
using One.Module.Organizations;
using One.Module.Profile;
using One.Module.Projects;
using One.Module.TimeEntries;
using One.Module.Tasks;
using One.Module.UserOrganizations;
using One.Module.UserProjects;
using One.Module.UserSettings;
using One.Module.Validators;

namespace One.Mobile.Api;

public static class DependencyInjection
{
    public static void AddDependencies(this IServiceCollection services, string connectionString)
    {
        services.AddOneCore(connectionString, AppDomain.CurrentDomain.GetAssemblies());
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(connectionString));
        services.AddTransient<IFileManagementModuleClient, FileManagementModuleClient>();
        services.AddScoped<ISqlConnectionService, SqlConnectionService>(_ => new SqlConnectionService(connectionString));
        services.AddValidatorsDependencies();
        services.AddFormsAnswersDependencies();
        services.AddUserOrganizationsDependencies();
        services.AddFormsQuestionsDependencies();
        services.AddFormsDependencies();
        services.AddProjectsDependencies();
        services.AddTasksDependencies();
        services.AddProfileDependencies();
        services.AddOrganizationsDependencies();
        services.AddTimeEntriesDependencies();
        services.OrganizationInvitesDependencies();
        services.AddUserSettingsDependencies();
        services.AddUserProjectsDependencies();
        services.AddChecklistsDependencies();
        services.AddDeviationDependencies();
    }
}