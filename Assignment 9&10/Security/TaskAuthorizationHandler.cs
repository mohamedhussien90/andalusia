using Assignment_8.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Assignment_8.Security
{
    public class TaskAuthorizationHandler : AuthorizationHandler<ManageTaskRequirement, TaskResponseDto>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ManageTaskRequirement requirement,
            TaskResponseDto resource)
        {
            // Admins bypass ownership check
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Check Ownership
            if (int.TryParse(userIdClaim, out int loggedInUserId) && resource.UserId == loggedInUserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
