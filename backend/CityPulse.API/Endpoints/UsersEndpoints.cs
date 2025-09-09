// API для отправки кода и подтверждения номера
using CityPulse.API.Contracts.Users;
using CityPulse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityPulse.API.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/test", TestMap); 
        
        app.MapPost("auth/request-otp", SendConfirmationCode);
        app.MapGet("auth/verify-otp", VerifyConfirmationCode);
        
        app.MapPost("auth/sign-up", Register);
        app.MapPost("auth/sign-in", Login);

        app.MapGet("auth/request-password-reset", ForgotPassword);
        app.MapPost("auth/reset-password", ResetPassword);

        
        return app;
    }

    private static async Task<IResult> TestMap()
    {
        return Results.Ok();
    }
    
    private static async Task<IResult> SendConfirmationCode(
        [FromBody] SendConfirmationCodeRequest request,
        UserService userService)
    {
        
        if(await userService.IsPhoneNumberTaken(request.PhoneNumber))
            return Results.BadRequest("Phone number is already in use.");
        
        var code = userService.GenerateConfirmationCode(request.PhoneNumber);
        return Results.Ok(new { ConfirmationCode = code });
    }

    private static async Task<IResult> VerifyConfirmationCode(
        [FromQuery] string PhoneNumber,
        [FromQuery] string ConfirmationCode,
        UserService userService)
    {
        var isCodeValid = userService.VerifyConfirmationCode(PhoneNumber, ConfirmationCode);

        if (!isCodeValid)
        {
            return Results.BadRequest("Invalid confirmation code.");
        }

        userService.MarkPhoneAsConfirmed(PhoneNumber);
        return Results.Ok("Phone confirmed successfully.");
    }

    private static async Task<IResult> Register(
        [FromBody] RegisterUserRequest request,
        UserService userService)
    {
        var isPhoneConfirmed = userService.IsPhoneConfirmed(request.PhoneNumber);

        if (!isPhoneConfirmed)
        {
            return Results.BadRequest("Phone number not confirmed.");
        }

        await userService.Register(request.UserNickName, request.Password, request.UserFullName, request.PhoneNumber);
        return Results.Ok("Registration successful.");
    }

    private static async Task<IResult> Login(
        [FromBody] LoginUserRequest request,
        UserService userService,
        HttpContext context)
    {
        var token = await userService.Login(request.Phone, request.Password);
        context.Response.Cookies.Append("secretCookie", token);
        return Results.Ok(token);
    }
    
    private static async Task<IResult> ForgotPassword(
        [FromQuery] string PhoneNumber,
        UserService userService)
    {
        if (!await userService.IsPhoneNumberTaken(PhoneNumber))
        {
            return Results.BadRequest("Phone number is not registered.");
        }

        var code = userService.GenerateResetPasswordCode(PhoneNumber);
        return Results.Ok(new { ResetCode = code });
    }
    
    private static async Task<IResult> ResetPassword(
        [FromBody] ResetPasswordRequest request,
        UserService userService)
    {
        var isCodeValid = userService.VerifyResetPasswordCode(request.PhoneNumber, request.ResetCode);

        if (!isCodeValid)
        {
            return Results.BadRequest("Invalid reset code.");
        }

        await userService.UpdatePassword(request.PhoneNumber, request.NewPassword);
        return Results.Ok("Password has been reset successfully.");
    }


}
