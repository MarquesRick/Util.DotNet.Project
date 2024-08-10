using DelegatesCrudExemple.Entities;
using DelegatesCrudExemple.Handles;

UserServiceHandle userService = new();

User user1 = new() { Id = 1, Name = "John Doe", Email = "john@example.com" };
User user2 = new() { Id = 2, Name = "Jane Smith", Email = "jane@example" };
User user4 = new() { Id = 3, Name = "Henrique Marques", Email = "henmarques.com" }; // Invalid email

// Insert users
userService.InsertUser(user1);
userService.InsertUser(user2);
userService.InsertUser(user4);
// Update user
User user3 = new() { Id = 1, Name = "John Updated", Email = "johnupdated@example.com" };
userService.UpdateUser(user3);

// Delete user
userService.DeleteUser(1);