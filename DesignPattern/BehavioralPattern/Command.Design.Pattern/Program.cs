using Command.Design.Pattern.Commands;
using Command.Design.Pattern.Entities;
using Command.Design.Pattern.Interfaces;
using Command.Design.Pattern.Invoker;
using Command.Design.Pattern.Receivers;

UserServiceReceiver userService = new();
UserCommandInvoker invoker = new();

User user1 = new(1, "John Doe", "john@example.com");
User user2 = new(2, "Jane Smith", "jane@example.com");

ICommand insertUser1 = new InsertUserCommand(userService, user1);
ICommand insertUser2 = new InsertUserCommand(userService, user2);
ICommand updateUser1 = new UpdateUserCommand(userService, new User(1, "John TestUpdated", "johnutestpdated@example.com"));
ICommand deleteUser2 = new DeleteUserCommand(userService, 2);

// Insert users
invoker.ExecuteCommand(insertUser1);
invoker.ExecuteCommand(insertUser2);

// Update user
invoker.ExecuteCommand(updateUser1);

// Delete user
invoker.ExecuteCommand(deleteUser2);

// Undo delete
invoker.UndoLastCommand();

// Undo update
invoker.UndoLastCommand();

// Undo insert user2
invoker.UndoLastCommand();