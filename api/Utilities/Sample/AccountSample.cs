using api.Models;
using api.Utilities.Handlers;

namespace api.Utilities.Sample;

public class AccountSample
{
    public static Account JohnDoe()
    {
        return new Account
        {
            Guid = EmployeeSample.JohnDoe().Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Email = "john.doe@example.com",
            IsDisabled = false,
            IsOtpUsed = true,
            Otp = 123456,
            OtpExpireTime = DateTime.Now,
            Password = HashHandler.Password("abcd123456")
            
        };
    }

    public static Account JaneSmith()
    {
        return new Account
        {
            Guid = EmployeeSample.JaneSmith().Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Email = "jane.smith@example.com",
            IsDisabled = false,
            IsOtpUsed = true,
            Otp = 123456,
            OtpExpireTime = DateTime.Now,
            Password = HashHandler.Password("abcd123456")
        };
    }

    public static Account BobJohnson()
    {
        return new Account
        {
            Guid = EmployeeSample.BobJohnson().Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Email = "bob.johnson@example.com",
            IsDisabled = false,
            IsOtpUsed = true,
            Otp = 123456,
            OtpExpireTime = DateTime.Now,
            Password = HashHandler.Password("abcd123456")
        };
    }


}
