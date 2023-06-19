using UserLogging.Enums;

namespace UserLogging.Models.PossibleActions
{
    public class PossibleAction
    {
        public int PossibleActionId { get; set; }

        public ActionsEnum ActionType { get; set; }

        public string Message { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
