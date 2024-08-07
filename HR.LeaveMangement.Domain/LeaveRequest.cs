using HR.LeaveMangement.Domain.Common;

namespace HR.LeaveMangement.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndtDate { get; set; }
    public LeaveType ? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string ? RequestComments { get; set; }
    public bool? Approved { get; set; } 
    public bool? Cancelled { get; set; }
    public string RequestingEmployeeId { get; set; }=string.Empty;

}