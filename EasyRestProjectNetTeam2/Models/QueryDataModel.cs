namespace EasyRestProjectNetTeam2.Models
{
    public class QueryDataModel
    {
        public string DeleteUserByEmail { get; set; }
        public string SelectUserEmailByEmail { get; set; }
        public string DeleteTokenByEmail { get; set; }
        public string SetPreviousAdministrator { get; set; }
        public string InsertInDBWaiterForDeleting { get; set; }
        public string InsertInDBAdministratorForDeleting { get; set; }
        public string SetTempAdministrator { get; set; }
        public string SetRestaurantStatusToUnapprovedByName { get; set; }
        public string InsertOrderInAssignedWaiterStatus { get; set; }
        public string InsertOrderInProgressStatus { get; set; }
        public string DeleteOrderInAssignedWaiterStatus { get; set; }
        public string DeleteOrderInProgressStatus { get; set; }
        public string DeleteFromOrderAssociationByEmail { get; set; }
        public string DeleteFromDraftOrderByEmail { get; set; }
        public string DeleteLastFromOrderAssociationsByEmail { get; set; }
        public string DeleteLastFromOrdersByEmail { get; set; }
    }
}