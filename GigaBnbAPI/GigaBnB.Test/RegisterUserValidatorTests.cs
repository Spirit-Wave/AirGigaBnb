using GigaBnB.Business.DTOs;
using GigaBnB.Business.Exceptions;
using GigaBnB.Business.Utility;
using GigaBnB.Business.Validation;
using GigaBnB.DataAccess.Repository.IRepository;
using GigaBnB.Model.Enum;
using GigaBnB.Model.Models;
using Moq;

namespace GigaBnB.Test
{
    public class RegisterUserValidatorTests
    {
        [Fact]
        public async Task RegistrationHasAtLeastOneError()
        {
            RegisterUserValidator registerUserValidator = GetRegisterUserValidatorMock();

            var userRegistration = new RegisterDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "password",
                ConfirmPassword = "password",
                PhoneNumber = "12345",
                Description = "description",
                Role = UserRole.Lessee
            };

            var hasNoValidationErrors = await registerUserValidator.Validate(userRegistration);

            Assert.False(hasNoValidationErrors);
        }

        [Fact]
        public async Task RegistrationHasNoErrors()
        {
            RegisterUserValidator registerUserValidator = GetRegisterUserValidatorMock();

            var userRegistration = new RegisterDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "P@ssword123",
                ConfirmPassword = "P@ssword123",
                PhoneNumber = "12345",
                Description = "description",
                Role = UserRole.Lessee
            };

            var hasNoValidationErrors = await registerUserValidator.Validate(userRegistration);

            Assert.True(hasNoValidationErrors);
        }

        [Fact]
        public async Task RegistrationPasswordLengthIsUnderEight()
        {
            RegisterUserValidator registerUserValidator = GetRegisterUserValidatorMock();

            var userRegistration = new RegisterDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "P@ss8",
                ConfirmPassword = "P@ss8",
                PhoneNumber = "12345",
                Description = "description",
                Role = UserRole.Lessee
            };

            await registerUserValidator.Validate(userRegistration);

            var errorMessages = new ValidationException(registerUserValidator.Errors).Messages.Values;
            var selectedErrorMessage = errorMessages.SelectMany(q => q.ToList());

            Assert.Contains("Password must contain 8 or more characters", selectedErrorMessage);
        }

        [Fact]
        public async Task RegistrationPasswordAndConfirmPasswordDoNotMatch()
        {
            RegisterUserValidator registerUserValidator = GetRegisterUserValidatorMock();

            var userRegistration = new RegisterDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "P@ss8",
                ConfirmPassword = "P@ss82",
                PhoneNumber = "12345",
                Description = "description",
                Role = UserRole.Lessee
            };

            await registerUserValidator.Validate(userRegistration);

            var errorMessages = new ValidationException(registerUserValidator.Errors).Messages.Values;
            var selectedErrorMessage = errorMessages.SelectMany(q => q.ToList());

            Assert.Contains("Password does not match confirm password", selectedErrorMessage);
        }

        [Fact]
        public async Task RegistrationPasswordDoesNotMeetFormatRequirements()
        {
            RegisterUserValidator registerUserValidator = GetRegisterUserValidatorMock();

            var userRegistration = new RegisterDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "Password",
                ConfirmPassword = "Password",
                PhoneNumber = "12345",
                Description = "description",
                Role = UserRole.Lessee
            };

            await registerUserValidator.Validate(userRegistration);

            var errorMessages = new ValidationException(registerUserValidator.Errors).Messages.Values;
            var selectedErrorMessage = errorMessages.SelectMany(q => q.ToList());

            Assert.Contains("Password must contain at least one uppercase letter, one lowercase letter, one number and one special character", selectedErrorMessage);
        }

        [Fact]
        public async Task RegistrationEmailDoesNotMeetFormatRequirements()
        {
            RegisterUserValidator registerUserValidator = GetRegisterUserValidatorMock();

            var userRegistration = new RegisterDto()
            {
                Name = "Test",
                Email = "Test",
                Password = "P@ssword123",
                ConfirmPassword = "P@ssword123",
                PhoneNumber = "12345",
                Description = "description",
                Role = UserRole.Lessee
            };

            await registerUserValidator.Validate(userRegistration);

            var errorMessages = new ValidationException(registerUserValidator.Errors).Messages.Values;
            var selectedErrorMessage = errorMessages.SelectMany(q => q.ToList());

            Assert.Contains("Invalid email format", selectedErrorMessage);
        }

        private static RegisterUserValidator GetRegisterUserValidatorMock()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(q => q.User).Returns(userRepositoryMock.Object);

            return new RegisterUserValidator(mockUnitOfWork.Object);
        }
    }
}