using DelegatesCrudExemple.Entities;
using DelegatesCrudExemple.Handles;
using DelegatesCrudExemple.Validator;

UserServiceHandle userService = new();
UserValidator validator = new();

// Subscribe to the UserValidating event
userService.UserValidating += validator.ValidateUser;

// Create users
User user1 = new(1, "John Doe", "john@example.com");
User user2 = new(2, "", "jane@example.com"); // Invalid name
User user3 = new(3, "Jane Smith", "janeexample.com"); // Invalid email

// Insert users
userService.InsertUser(user1); // Valid user
userService.InsertUser(user2); // Invalid user
userService.InsertUser(user3); // Invalid user

// Update users
User updatedUser1 = new(1, "John Updated", "johnupdated@example.com");
userService.UpdateUser(updatedUser1); // Valid update

User invalidUpdateUser = new(1, "", "johnupdated@example.com");
userService.UpdateUser(invalidUpdateUser); // Invalid update