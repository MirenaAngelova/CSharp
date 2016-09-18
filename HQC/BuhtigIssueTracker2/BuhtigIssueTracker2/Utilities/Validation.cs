namespace BuhtigIssueTracker2.Utilities
{
    public class Validation
    {
        public const string MessageUserExists = "A user with username {0} already exists";
        public const string MessageUserRegistredSuccessfully = "User {0} registered successfully";
        public const string MessageUserNotExist = "A user with username {0} does not exist";
        public const string MessageAlreadyLoggedInUser = "There is already a logged in user";
        public const string MessageNoLoggedInUser = "There is no currently logged in user";
        public const string MessageUserLoggedInSuccsessfully = "User {0} logged in successfully";
        public const string MessageUserLoggedOutSuccsessfully = "User {0} logged out successfully";

        public const string MessagePasswordNotMatch = "The provided passwords do not match";
        public const string MessagePasswordInvalid = "The password is invalid for user {0}";
        
        public const string MessageIssueCreatedSuccessfully = "Issue {0} created successfully.";
        public const string MessageNoIssueId = "There is no issue with ID {0}";
        public const string MessageIssueNotBelongToUser = "The issue with ID {0} does not belong to user {1}";
        public const string MessageNoIssues = "No issues";
        public const string MessageIssueRemoved = "Issue {0} removed";
        public const string MessageCommentAddedToIssue = "Comment added successfully to issue {0}";
        public const string MessageNoComments = "No comments";
        public const string MessageNoTags = "There are no tags provided";
        public const string MessageNoIssuesMatchingTags = "There are no issues matching the tags provided";

        public const int MinTextLength = 2;
        public const int MinTitleLength = 3;
        public const int MinDescriptionLength = 5;
        public const int MinTagsLength = 0;
    }
}
